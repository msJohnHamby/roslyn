// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.ExpressionEvaluator;
using Microsoft.VisualStudio.Debugger.Clr;
using Microsoft.VisualStudio.Debugger.Evaluation;
using Xunit;

namespace Microsoft.CodeAnalysis.CSharp.UnitTests
{
    public class FormatSpecifierTests : CSharpResultProviderTestBase
    {
        [Fact]
        public void NoQuotes_String()
        {
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlib());
            var inspectionContext = CreateDkmInspectionContext(DkmEvaluationFlags.NoQuotes);
            var stringType = runtime.GetType(typeof(string));

            // null
            var value = CreateDkmClrValue(null, type: stringType, inspectionContext: inspectionContext);
            var evalResult = FormatResult("s", value);
            Verify(evalResult,
                EvalResult("s", "null", "string", "s", editableValue: null, flags: DkmEvaluationResultFlags.None));

            // ""
            value = CreateDkmClrValue(string.Empty, type: stringType, inspectionContext: inspectionContext);
            evalResult = FormatResult("s", value);
            Verify(evalResult,
                EvalResult("s", "", "string", "s", editableValue: "\"\"", flags: DkmEvaluationResultFlags.RawString));

            // "'"
            value = CreateDkmClrValue("'", type: stringType, inspectionContext: inspectionContext);
            evalResult = FormatResult("s", value);
            Verify(evalResult,
                EvalResult("s", "'", "string", "s", editableValue: "\"'\"", flags: DkmEvaluationResultFlags.RawString));

            // "\""
            value = CreateDkmClrValue("\"", type: stringType, inspectionContext: inspectionContext);
            evalResult = FormatResult("s", value);
            Verify(evalResult,
                EvalResult("s", "\"", "string", "s", editableValue: "\"\\\"\"", flags: DkmEvaluationResultFlags.RawString));

            // " " with alias
            value = CreateDkmClrValue(" ", type: stringType, alias: "1", evalFlags: DkmEvaluationResultFlags.HasObjectId, inspectionContext: inspectionContext);
            evalResult = FormatResult("s", value);
            Verify(evalResult,
                EvalResult("s", "  {$1}", "string", "s", editableValue: "\" \"", flags: DkmEvaluationResultFlags.RawString | DkmEvaluationResultFlags.HasObjectId));

            // array
            value = CreateDkmClrValue(new string[] { "1" }, type: stringType.MakeArrayType(), inspectionContext: inspectionContext);
            evalResult = FormatResult("a", value);
            Verify(evalResult,
                EvalResult("a", "{string[1]}", "string[]", "a", editableValue: null, flags: DkmEvaluationResultFlags.Expandable));
            var children = GetChildren(evalResult);
            // TODO: InspectionContext should not be inherited. See IDkmClrFormatter.GetValueString.
            Verify(children,
                EvalResult("[0]", "1", "string", "a[0]", editableValue: "\"1\"", flags: DkmEvaluationResultFlags.RawString));
        }

        [Fact]
        public void NoQuotes_Char()
        {
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlib());
            var inspectionContext = CreateDkmInspectionContext(DkmEvaluationFlags.NoQuotes);
            var charType = runtime.GetType(typeof(char));

            // 0
            var value = CreateDkmClrValue((char)0, type: charType, inspectionContext: inspectionContext);
            var evalResult = FormatResult("c", value);
            Verify(evalResult,
                EvalResult("c", "0 \\0", "char", "c", editableValue: "'\\0'", flags: DkmEvaluationResultFlags.None));

            // '\''
            value = CreateDkmClrValue('\'', type: charType, inspectionContext: inspectionContext);
            evalResult = FormatResult("c", value);
            Verify(evalResult,
                EvalResult("c", "39 '", "char", "c", editableValue: "'\\''", flags: DkmEvaluationResultFlags.None));

            // '"'
            value = CreateDkmClrValue('"', type: charType, inspectionContext: inspectionContext);
            evalResult = FormatResult("c", value);
            Verify(evalResult,
                EvalResult("c", "34 \"", "char", "c", editableValue: "'\"'", flags: DkmEvaluationResultFlags.None));

            // array
            value = CreateDkmClrValue(new char[] { '1' }, type: charType.MakeArrayType(), inspectionContext: inspectionContext);
            evalResult = FormatResult("a", value);
            Verify(evalResult,
                EvalResult("a", "{char[1]}", "char[]", "a", editableValue: null, flags: DkmEvaluationResultFlags.Expandable));
            var children = GetChildren(evalResult);
            // TODO: InspectionContext should not be inherited. See IDkmClrFormatter.GetValueString.
            Verify(children,
                EvalResult("[0]", "49 1", "char", "a[0]", editableValue: "'1'", flags: DkmEvaluationResultFlags.None));
        }

        [Fact]
        public void NoQuotes_DebuggerDisplay()
        {
            var source =
@"using System.Diagnostics;
[DebuggerDisplay(""{F}+{G}"")]
class C
{
    string F = ""f"";
    object G = 'g';
}";
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlib(GetAssembly(source)));
            using (runtime.Load())
            {
                var type = runtime.GetType("C");
                var value = CreateDkmClrValue(
                    value: type.Instantiate(),
                    type: type,
                    inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.NoQuotes));
                var evalResult = FormatResult("o", value);
                Verify(evalResult,
                    EvalResult("o", "f+103 g", "C", "o", DkmEvaluationResultFlags.Expandable));
            }
        }

        [Fact]
        public void RawView_NoProxy()
        {
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlib());
            var inspectionContext = CreateDkmInspectionContext(DkmEvaluationFlags.ShowValueRaw);

            // int
            var value = CreateDkmClrValue(1, type: runtime.GetType(typeof(int)), inspectionContext: inspectionContext);
            var evalResult = FormatResult("i", value);
            Verify(evalResult,
                EvalResult("i", "1", "int", "i, raw", editableValue: null, flags: DkmEvaluationResultFlags.None));

            // string
            value = CreateDkmClrValue(string.Empty, type: runtime.GetType(typeof(string)), inspectionContext: inspectionContext);
            evalResult = FormatResult("s", value);
            Verify(evalResult,
                EvalResult("s", "\"\"", "string", "s, raw", editableValue: "\"\"", flags: DkmEvaluationResultFlags.RawString));

            // object[]
            value = CreateDkmClrValue(new object[] { 1, 2, 3 }, type: runtime.GetType(typeof(object)).MakeArrayType(), inspectionContext: inspectionContext);
            evalResult = FormatResult("a", value);
            Verify(evalResult,
                EvalResult("a", "{object[3]}", "object[]", "a, raw", editableValue: null, flags: DkmEvaluationResultFlags.Expandable));
        }

        [Fact]
        public void RawView()
        {
            var source =
@"using System.Diagnostics;
internal class P
{
    public P(C c)
    {
        this.G = c.F != null;
    }
    public readonly bool G;
}
[DebuggerTypeProxy(typeof(P))]
class C
{
    internal C() : this(new C(null))
    {
    }
    internal C(C f)
    {
        this.F = f;
    }
    internal readonly C F;
}
class Program
{
    static void Main()
    {
        var o = new C();
        System.Diagnostics.Debugger.Break();
    }
}";
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlib(GetAssembly(source)));
            using (runtime.Load())
            {
                var type = runtime.GetType("C");

                // Non-null value.
                var value = CreateDkmClrValue(
                    value: type.Instantiate(),
                    type: type,
                    inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.ShowValueRaw));
                var evalResult = FormatResult("o", "o, raw", value);
                Verify(evalResult,
                    EvalResult("o", "{C}", "C", "o, raw", DkmEvaluationResultFlags.Expandable));
                var children = GetChildren(evalResult);
                Verify(children,
                    EvalResult("F", "{C}", "C", "o.F", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly));
                children = GetChildren(children[0]);
                // ShowValueRaw is not inherited.
                Verify(children,
                    EvalResult("G", "false", "bool", "new P(o.F).G", DkmEvaluationResultFlags.Boolean | DkmEvaluationResultFlags.ReadOnly),
                    EvalResult("Raw View", null, "", "o.F, raw", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly, DkmEvaluationResultCategory.Data));

                // Null value.
                value = CreateDkmClrValue(
                    value: null,
                    type: type,
                    inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.ShowValueRaw));
                evalResult = FormatResult("o", "o, raw", value);
                Verify(evalResult,
                    EvalResult("o", "null", "C", "o, raw"));
            }
        }

        [Fact]
        public void ResultsView_FrameworkTypes()
        {
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlibAndSystemCore());
            var inspectionContext = CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly);

            // object: not enumerable
            var value = CreateDkmClrValue(new object(), type: runtime.GetType(typeof(object)), inspectionContext: inspectionContext);
            var evalResult = FormatResult("o", value);
            Verify(evalResult,
                EvalFailedResult("o", "Only Enumerable types can have Results View"));

            // string: not considered enumerable which is consistent with legacy EE
            value = CreateDkmClrValue("", type: runtime.GetType(typeof(string)), inspectionContext: inspectionContext);
            evalResult = FormatResult("s", value);
            Verify(evalResult,
                EvalFailedResult("s", "Only Enumerable types can have Results View"));

            // Array: not considered enumerable which is consistent with legacy EE
            value = CreateDkmClrValue(new[] { 1 }, type: runtime.GetType(typeof(int[])), inspectionContext: inspectionContext);
            evalResult = FormatResult("i", value);
            Verify(evalResult,
                EvalFailedResult("i", "Only Enumerable types can have Results View"));

            // ArrayList
            value = CreateDkmClrValue(new System.Collections.ArrayList(new[] { 2 }), type: runtime.GetType(typeof(System.Collections.ArrayList)), inspectionContext: inspectionContext);
            evalResult = FormatResult("a", value);
            Verify(evalResult,
                EvalResult("a", "Expanding the Results View will enumerate the IEnumerable", "", "a, results", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly, DkmEvaluationResultCategory.Method));
            var children = GetChildren(evalResult);
            Verify(children,
                EvalResult("[0]", "2", "object {int}", "new System.Linq.SystemCore_EnumerableDebugView(a).Items[0]"));

            // List<object>
            value = CreateDkmClrValue(new System.Collections.Generic.List<object>(new object[] { 3 }), type: runtime.GetType(typeof(System.Collections.Generic.List<object>)), inspectionContext: inspectionContext);
            evalResult = FormatResult("l", value);
            Verify(evalResult,
                EvalResult("l", "Expanding the Results View will enumerate the IEnumerable", "", "l, results", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly, DkmEvaluationResultCategory.Method));
            children = GetChildren(evalResult);
            Verify(children,
                EvalResult("[0]", "3", "object {int}", "new System.Linq.SystemCore_EnumerableDebugView<object>(l).Items[0]"));

            // int?
            value = CreateDkmClrValue(1, type: runtime.GetType(typeof(System.Nullable<>)).MakeGenericType(runtime.GetType(typeof(int))), inspectionContext: inspectionContext);
            evalResult = FormatResult("i", value);
            Verify(evalResult,
                EvalFailedResult("i", "Only Enumerable types can have Results View"));
        }

        [Fact]
        public void ResultsView_IEnumerable()
        {
            var source =
@"using System.Collections;
class C : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new C();
    }
}";
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlibAndSystemCore(GetAssembly(source)));
            using (runtime.Load())
            {
                var type = runtime.GetType("C");
                var value = CreateDkmClrValue(
                    value: type.Instantiate(),
                    type: type,
                    inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                var evalResult = FormatResult("o", "o, results, d", value);
                Verify(evalResult,
                    EvalResult("o", "Expanding the Results View will enumerate the IEnumerable", "", "o, results", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly, DkmEvaluationResultCategory.Method));
                var children = GetChildren(evalResult);
                // ResultsOnly is not inherited.
                Verify(children,
                    EvalResult("[0]", "{C}", "object {C}", "new System.Linq.SystemCore_EnumerableDebugView(o).Items[0]"));
            }
        }

        [Fact]
        public void ResultsView_IEnumerableOfT()
        {
            var source =
@"using System;
using System.Collections;
using System.Collections.Generic;
struct S<T> : IEnumerable<T>
{
    private readonly T t;
    internal S(T t)
    {
        this.t = t;
    }
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        yield return t;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}";
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlibAndSystemCore(GetAssembly(source)));
            using (runtime.Load())
            {
                var type = runtime.GetType("S`1").MakeGenericType(runtime.GetType(typeof(int)));
                var value = CreateDkmClrValue(
                    value: type.Instantiate(2),
                    type: type,
                    inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                var evalResult = FormatResult("o", "o, results", value);
                Verify(evalResult,
                    EvalResult("o", "Expanding the Results View will enumerate the IEnumerable", "", "o, results", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly, DkmEvaluationResultCategory.Method));
                var children = GetChildren(evalResult);
                Verify(children,
                    EvalResult("[0]", "2", "int", "new System.Linq.SystemCore_EnumerableDebugView<int>(o).Items[0]"));
            }
        }

        /// <summary>
        /// ResultsOnly is ignored for GetChildren and GetItems.
        /// </summary>
        [Fact]
        public void ResultsView_GetChildren()
        {
            var source =
@"using System.Collections;
using System.Collections.Generic;
class C
{
    IEnumerable<int> F
    {
        get { yield return 1; }
    }
    IEnumerable G
    {
        get { yield return 2; }
    }
    int H
    {
        get { return 3; }
    }
}";
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlibAndSystemCore(GetAssembly(source)));
            using (runtime.Load())
            {
                var type = runtime.GetType("C");
                var value = CreateDkmClrValue(type.Instantiate(), type: type);
                var evalResult = FormatResult("o", "o", value);
                Verify(evalResult,
                    EvalResult("o", "{C}", "C", "o", DkmEvaluationResultFlags.Expandable));
                // GetChildren without ResultsOnly
                var children = GetChildren(evalResult, inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.None));
                Verify(children,
                    EvalResult("F", "{C.<get_F>d__1}", "System.Collections.Generic.IEnumerable<int> {C.<get_F>d__1}", "o.F", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly),
                    EvalResult("G", "{C.<get_G>d__3}", "System.Collections.IEnumerable {C.<get_G>d__3}", "o.G", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly),
                    EvalResult("H", "3", "int", "o.H", DkmEvaluationResultFlags.ReadOnly));
                // GetChildren with ResultsOnly
                children = GetChildren(evalResult, inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                Verify(children,
                    EvalResult("F", "{C.<get_F>d__1}", "System.Collections.Generic.IEnumerable<int> {C.<get_F>d__1}", "o.F", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly),
                    EvalResult("G", "{C.<get_G>d__3}", "System.Collections.IEnumerable {C.<get_G>d__3}", "o.G", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly),
                    EvalResult("H", "3", "int", "o.H", DkmEvaluationResultFlags.ReadOnly));
            }
        }

        /// <summary>
        /// [DebuggerTypeProxy] should be ignored.
        /// </summary>
        [Fact]
        public void ResultsView_TypeProxy()
        {
            var source =
@"using System.Collections;
using System.Diagnostics;
[DebuggerTypeProxy(typeof(P))]
class C : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return 1;
    }
}
class P
{
    public P(C c)
    {
    }
    public object F
    {
        get { return 2; }
    }
}";
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlibAndSystemCore(GetAssembly(source)));
            using (runtime.Load())
            {
                var type = runtime.GetType("C");
                var value = CreateDkmClrValue(
                    value: type.Instantiate(),
                    type: type,
                    inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                var evalResult = FormatResult("o", "o, results", value);
                Verify(evalResult,
                    EvalResult("o", "Expanding the Results View will enumerate the IEnumerable", "", "o, results", DkmEvaluationResultFlags.Expandable | DkmEvaluationResultFlags.ReadOnly, DkmEvaluationResultCategory.Method));
            }
        }

        [Fact]
        public void ResultsView_ExceptionThrown()
        {
            var source =
@"using System;
using System.Collections;
class E : Exception, IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        yield return 1;
    }
}
class C
{
    internal ArrayList P
    {
        get { throw new NotImplementedException(); }
    }
    internal ArrayList Q
    {
        get { throw new E(); }
    }
}";
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlibAndSystemCore(GetAssembly(source)));
            using (runtime.Load())
            {
                var type = runtime.GetType("C");
                var value = CreateDkmClrValue(type.Instantiate(), type: type);
                var memberValue = value.GetMemberValue("P", (int)System.Reflection.MemberTypes.Property, "C").
                    WithInspectionContext(CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                var evalResult = FormatResult("o.P", "o.P, results", memberValue);
                Verify(evalResult,
                    EvalFailedResult("o.P", "'o.P' threw an exception of type 'System.NotImplementedException'"));
                memberValue = value.GetMemberValue("Q", (int)System.Reflection.MemberTypes.Property, "C").
                    WithInspectionContext(CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                evalResult = FormatResult("o.Q", "o.Q, results", memberValue);
                Verify(evalResult,
                    EvalFailedResult("o.Q", "'o.Q' threw an exception of type 'E'"));
            }
        }

        /// <summary>
        /// Report the error message for error values, regardless
        /// of whether the value is actually enumerable.
        /// </summary>
        [Fact]
        public void ResultsView_Error()
        {
            var source =
@"using System.Collections;
class C
{
    bool f;
    internal ArrayList P
    {
        get { while (!this.f) { } return new ArrayList(); }
    }
    internal int Q
    {
        get { while (!this.f) { } return 3; }
    }
}";
            DkmClrRuntimeInstance runtime = null;
            GetMemberValueDelegate getMemberValue = (v, m) =>
                {
                    switch (m)
                    {
                        case "P":
                            return CreateErrorValue(runtime.GetType(typeof(System.Collections.ArrayList)), "Property 'P' evaluation timed out");
                        case "Q":
                            return CreateErrorValue(runtime.GetType(typeof(string)), "Property 'Q' evaluation timed out");
                        default:
                            return null;
                    }
                };
            runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlibAndSystemCore(GetAssembly(source)), getMemberValue: getMemberValue);
            using (runtime.Load())
            {
                var type = runtime.GetType("C");
                var value = CreateDkmClrValue(type.Instantiate(), type: type);
                var memberValue = value.GetMemberValue("P", (int)System.Reflection.MemberTypes.Property, "C").
                    WithInspectionContext(CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                var evalResult = FormatResult("o.P", "o.P, results", memberValue);
                Verify(evalResult,
                    EvalFailedResult("o.P", "Property 'P' evaluation timed out"));
                memberValue = value.GetMemberValue("Q", (int)System.Reflection.MemberTypes.Property, "C").
                    WithInspectionContext(CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                evalResult = FormatResult("o.Q", "o.Q, results", memberValue);
                Verify(evalResult,
                    EvalFailedResult("o.Q", "Property 'Q' evaluation timed out"));
            }
        }

        [Fact]
        public void ResultsView_NoSystemCore()
        {
            var source =
@"using System.Collections;
class C : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return 1;
    }
}";
            var runtime = new DkmClrRuntimeInstance(ReflectionUtilities.GetMscorlib(GetAssembly(source)));
            using (runtime.Load())
            {
                var type = runtime.GetType("C");
                var value = CreateDkmClrValue(
                    value: type.Instantiate(),
                    type: type,
                    inspectionContext: CreateDkmInspectionContext(DkmEvaluationFlags.ResultsOnly));
                var evalResult = FormatResult("o", "o, results", value);
                Verify(evalResult,
                    EvalFailedResult("o", "Results View requires System.Core.dll to be referenced"));
            }
        }
    }
}
