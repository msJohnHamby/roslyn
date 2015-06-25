﻿// Copyright (c) Microsoft Open Technologies, Inc.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Semantics;
using Roslyn.Diagnostics.Analyzers;

namespace Microsoft.CodeAnalysis.Performance
{
    /// <summary>Analyzer that looks boxing operations.</summary>
    public class BoxingOperationAnalyzer : DiagnosticAnalyzer
    {
        /// <summary>Diagnostic category "Performance".</summary>
        private const string PerformanceCategory = "Performance";
        
        private static LocalizableString localizableTitle = new LocalizableResourceString(nameof(RoslynDiagnosticsResources.BoxingDescription), RoslynDiagnosticsResources.ResourceManager, typeof(RoslynDiagnosticsResources));
        private static LocalizableString localizableMessage = new LocalizableResourceString(nameof(RoslynDiagnosticsResources.BoxingMessage), RoslynDiagnosticsResources.ResourceManager, typeof(RoslynDiagnosticsResources));
        
        /// <summary>The diagnostic descriptor used when boxing is detected.</summary>
        internal static readonly DiagnosticDescriptor BoxingDescriptor = new DiagnosticDescriptor(
            RoslynDiagnosticIds.BoxingRuleId,
            localizableTitle,
            localizableMessage,
            PerformanceCategory,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        /// <summary>Gets the set of supported diagnostic descriptors from this analyzer.</summary>
        public sealed override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get { return ImmutableArray.Create(BoxingDescriptor); }
        }

        public sealed override void Initialize(AnalysisContext context)
        {
            context.RegisterOperationAction(
                 (operationContext) =>
                 {
                     IOperation operation = operationContext.Operation;

                     if (operation.Kind == OperationKind.Conversion)
                     {
                         IConversion conversion = (IConversion)operation;
                         if (conversion.ResultType.IsReferenceType &&
                             conversion.Operand.ResultType != null &&
                             conversion.Operand.ResultType.IsValueType &&
                             !conversion.UsesOperatorMethod)
                         {
                             Report(operationContext, conversion.Syntax);
                         }
                     }

                     // Calls to instance methods of value types don’t have conversions.
                     if (operation.Kind == OperationKind.Invocation)
                     {
                         IInvocation invocation = (IInvocation)operation;

                         if (invocation.Instance != null &&
                             invocation.Instance.ResultType.IsValueType &&
                             invocation.TargetMethod.ContainingType.IsReferenceType)
                         {
                             Report(operationContext, invocation.Instance.Syntax);
                         }
                     }
                 },
                 OperationKind.Conversion,
                 OperationKind.Invocation);
        }

        /// <summary>Reports a diagnostic warning for a boxing operation.</summary>
        /// <param name="context">The context.</param>
        /// <param name="boxingExpression">The expression that produces the boxing.</param>
        internal void Report(OperationAnalysisContext context, SyntaxNode boxingExpression)
        {
            context.ReportDiagnostic(Diagnostic.Create(BoxingDescriptor, boxingExpression.GetLocation()));
        }
    }
}