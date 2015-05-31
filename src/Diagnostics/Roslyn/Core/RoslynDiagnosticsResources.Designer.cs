﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Roslyn.Diagnostics.Analyzers {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RoslynDiagnosticsResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RoslynDiagnosticsResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Roslyn.Diagnostics.Analyzers.RoslynDiagnosticsResources", typeof(RoslynDiagnosticsResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CancellationToken parameters must come last.
        /// </summary>
        internal static string CancellationTokenMustBeLastDescription {
            get {
                return ResourceManager.GetString("CancellationTokenMustBeLastDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method &apos;{0}&apos; should take CancellationToken as the last parameter.
        /// </summary>
        internal static string CancellationTokenMustBeLastMessage {
            get {
                return ResourceManager.GetString("CancellationTokenMustBeLastMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PreserveSigAttribute indicates that a method will return an HRESULT, rather than throwing an exception.  Therefore, it is important to consume the HRESULT returned by the method, so that errors can be detected.  Generally, this is done by calling Marshal.ThrowExceptionForHR..
        /// </summary>
        internal static string ConsumePreserveSigDescription {
            get {
                return ResourceManager.GetString("ConsumePreserveSigDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Consume the hresult returned by method &apos;{0}&apos; and call Marshal.ThrowExceptionForHR..
        /// </summary>
        internal static string ConsumePreserveSigMessage {
            get {
                return ResourceManager.GetString("ConsumePreserveSigMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Always consume the value returned by methods marked with PreserveSigAttribute.
        /// </summary>
        internal static string ConsumePreserveSigTitle {
            get {
                return ResourceManager.GetString("ConsumePreserveSigTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All public types and members should be declared in PublicAPI.txt. This draws attention to API changes in the code reviews and source control history, and helps prevent breaking changes..
        /// </summary>
        internal static string DeclarePublicApiDescription {
            get {
                return ResourceManager.GetString("DeclarePublicApiDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Symbol &apos;{0}&apos; is not part of the declared API..
        /// </summary>
        internal static string DeclarePublicApiMessage {
            get {
                return ResourceManager.GetString("DeclarePublicApiMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add public types and members to the declared API.
        /// </summary>
        internal static string DeclarePublicApiTitle {
            get {
                return ResourceManager.GetString("DeclarePublicApiTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Accessing the Descriptor property of Diagnostic in compiler layer leads to unnecessary string allocations for fields of the descriptor that are not utilized in command line compilation. Hence, you should avoid accessing the Descriptor of the compiler diagnostics here. Instead you should directly access these properties off the Diagnostic type..
        /// </summary>
        internal static string DiagnosticDescriptorAccessDescription {
            get {
                return ResourceManager.GetString("DiagnosticDescriptorAccessDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not invoke property &apos;{0}&apos; on type &apos;{1}&apos;, instead directly access the required member{2} on &apos;{1}&apos;.
        /// </summary>
        internal static string DiagnosticDescriptorAccessMessage {
            get {
                return ResourceManager.GetString("DiagnosticDescriptorAccessMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not invoke Diagnostic.Descriptor.
        /// </summary>
        internal static string DiagnosticDescriptorAccessTitle {
            get {
                return ResourceManager.GetString("DiagnosticDescriptorAccessTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not directly await a Task.
        /// </summary>
        internal static string DirectlyAwaitingTaskDescription {
            get {
                return ResourceManager.GetString("DirectlyAwaitingTaskDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not directly await a Task without calling ConfigureAwait.
        /// </summary>
        internal static string DirectlyAwaitingTaskMessage {
            get {
                return ResourceManager.GetString("DirectlyAwaitingTaskMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not call ToImmutableArray on an ImmutableArray&lt;T&gt; value..
        /// </summary>
        internal static string DoNotCallToImmutableArrayMessage {
            get {
                return ResourceManager.GetString("DoNotCallToImmutableArrayMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not create tasks unless you are using one of the overloads that takes a TaskScheduler. The default is to schedule on TaskScheduler.Current, which would lead to deadlocks. Either use TaskScheduler.Default to schedule on the thread pool, or explicitly pass TaskScheduler.Current to make your intentions clear..
        /// </summary>
        internal static string DoNotCreateTasksWithoutTaskSchedulerDescription {
            get {
                return ResourceManager.GetString("DoNotCreateTasksWithoutTaskSchedulerDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not call {0} without passing a TaskScheduler.
        /// </summary>
        internal static string DoNotCreateTasksWithoutTaskSchedulerMessage {
            get {
                return ResourceManager.GetString("DoNotCreateTasksWithoutTaskSchedulerMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not create tasks without passing a TaskScheduler.
        /// </summary>
        internal static string DoNotCreateTasksWithoutTaskSchedulerTitle {
            get {
                return ResourceManager.GetString("DoNotCreateTasksWithoutTaskSchedulerTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This collection is directly indexable.  Going through LINQ here causes unnecessary allocations and CPU work..
        /// </summary>
        internal static string DoNotUseLinqOnIndexableCollectionDescription {
            get {
                return ResourceManager.GetString("DoNotUseLinqOnIndexableCollectionDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not use Enumerable methods on indexable collections.  Instead use the collection directly..
        /// </summary>
        internal static string DoNotUseLinqOnIndexableCollectionMessage {
            get {
                return ResourceManager.GetString("DoNotUseLinqOnIndexableCollectionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not use generic CodeAction.Create to create CodeAction.
        /// </summary>
        internal static string DontUseCodeActionCreateDescription {
            get {
                return ResourceManager.GetString("DontUseCodeActionCreateDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Consider creating unique code action type per different fix. it will help us to see how each code action is used. otherwise, we will only see bunch of generic code actions being used..
        /// </summary>
        internal static string DontUseCodeActionCreateMessage {
            get {
                return ResourceManager.GetString("DontUseCodeActionCreateMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Implement IEquatable&lt;T&gt; when overriding Object.Equals.
        /// </summary>
        internal static string ImplementIEquatableDescription {
            get {
                return ResourceManager.GetString("ImplementIEquatableDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type {0} should implement IEquatable&lt;T&gt; because it overrides Equals.
        /// </summary>
        internal static string ImplementIEquatableMessage {
            get {
                return ResourceManager.GetString("ImplementIEquatableMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parts exported with MEFv2 must be marked as Shared..
        /// </summary>
        internal static string MissingSharedAttributeDescription {
            get {
                return ResourceManager.GetString("MissingSharedAttributeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Part exported with MEFv2 must be marked with the Shared attribute..
        /// </summary>
        internal static string MissingSharedAttributeMessage {
            get {
                return ResourceManager.GetString("MissingSharedAttributeMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not mix attributes from different versions of MEF.
        /// </summary>
        internal static string MixedVersionsOfMefAttributesDescription {
            get {
                return ResourceManager.GetString("MixedVersionsOfMefAttributesDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attribute &apos;{0}&apos; comes from a different version of MEF than the export attribute on &apos;{1}&apos;.
        /// </summary>
        internal static string MixedVersionsOfMefAttributesMessage {
            get {
                return ResourceManager.GetString("MixedVersionsOfMefAttributesMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native does not support array types with more than four dimensions..
        /// </summary>
        internal static string NetNativeArrayMoreThanFourDimensionsMessage {
            get {
                return ResourceManager.GetString("NetNativeArrayMoreThanFourDimensionsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native does not support array types with pointer element types..
        /// </summary>
        internal static string NetNativeArrayPointerElementMessage {
            get {
                return ResourceManager.GetString("NetNativeArrayPointerElementMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native does not support invoking the BeginInvoke or EndInvoke methods of delegate types..
        /// </summary>
        internal static string NetNativeBeginEndInvokeMessage {
            get {
                return ResourceManager.GetString("NetNativeBeginEndInvokeMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native allows only ClassInterfaceType.None as an argument to the constructor of ClassInterfaceAttribute..
        /// </summary>
        internal static string NetNativeClassInterfaceAttributeValueMessage {
            get {
                return ResourceManager.GetString("NetNativeClassInterfaceAttributeValueMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native does not support specifying a value for the LocalizationResources property of an EventSourceAttribute attribute..
        /// </summary>
        internal static string NetNativeEventSourceLocalizationMessage {
            get {
                return ResourceManager.GetString("NetNativeEventSourceLocalizationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native requires that a class that implements System.IEquatable&lt;T&gt; must also override Object.Equals(object)..
        /// </summary>
        internal static string NetNativeIEquatableEqualsMessage {
            get {
                return ResourceManager.GetString("NetNativeIEquatableEqualsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native does not support classes that implement more than one interface that has a Windows.Foundation.Metadata.DefaultAttribute attribute..
        /// </summary>
        internal static string NetNativeMultipleDefaultInterfacesMessage {
            get {
                return ResourceManager.GetString("NetNativeMultipleDefaultInterfacesMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native&apos;s implementation of System.Type.GetRuntimeMethods() does not return hidden methods in base types..
        /// </summary>
        internal static string NetNativeTypeGetRuntimeMethodsMessage {
            get {
                return ResourceManager.GetString("NetNativeTypeGetRuntimeMethodsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native&apos;s implementation of System.Type.GetType(string) searches the System.Runtime assembly only. Use Assembly.GetType(string) to search another assembly..
        /// </summary>
        internal static string NetNativeTypeGetTypeMessage {
            get {
                return ResourceManager.GetString("NetNativeTypeGetTypeMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Net Native&apos;s implementation of System.Reflection.TypeInfo.GUID throws PlatformNotSupportedException if the type does not have a System.Runtime.InteropServices.GuidAttribute attribute..
        /// </summary>
        internal static string NetNativeTypeInfoGUIDMessage {
            get {
                return ResourceManager.GetString("NetNativeTypeInfoGUIDMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Override Object.Equals(object) when implementing IEquatable&lt;T&gt; .
        /// </summary>
        internal static string OverrideObjectEqualsDescription {
            get {
                return ResourceManager.GetString("OverrideObjectEqualsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type {0} should override Equals because it implements IEquatable&lt;T&gt;.
        /// </summary>
        internal static string OverrideObjectEqualsMessage {
            get {
                return ResourceManager.GetString("OverrideObjectEqualsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When removing a public type or member the corresponding entry in PublicAPI.txt should also be removed. This draws attention to API changes in the code reviews and source control history, and helps prevent breaking changes..
        /// </summary>
        internal static string RemoveDeletedApiDescription {
            get {
                return ResourceManager.GetString("RemoveDeletedApiDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Symbol &apos;{0}&apos; is part of the declared API, but is either not public or could not be found.
        /// </summary>
        internal static string RemoveDeletedApiMessage {
            get {
                return ResourceManager.GetString("RemoveDeletedApiMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove deleted types and members from the declared API.
        /// </summary>
        internal static string RemoveDeletedApiTitle {
            get {
                return ResourceManager.GetString("RemoveDeletedApiTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Compilation event queue is required to generate symbol declared events for all declared source symbols. Hence, every source symbol type or one of it&apos;s base types must generate a symbol declared event..
        /// </summary>
        internal static string SymbolDeclaredEventRuleDescription {
            get {
                return ResourceManager.GetString("SymbolDeclaredEventRuleDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Symbol &apos;{0}&apos; seems to be a source symbol, but neither the symbol nor any of it&apos;s base types invoke method &apos;{1}.{2}&apos; to register a symbol declared event..
        /// </summary>
        internal static string SymbolDeclaredEventRuleMessage {
            get {
                return ResourceManager.GetString("SymbolDeclaredEventRuleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SymbolDeclaredEvent must be generated for source symbols.
        /// </summary>
        internal static string SymbolDeclaredEventRuleTitle {
            get {
                return ResourceManager.GetString("SymbolDeclaredEventRuleTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove unused code.
        /// </summary>
        internal static string UnusedDeclarationsCodeFixTitle {
            get {
                return ResourceManager.GetString("UnusedDeclarationsCodeFixTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; is not used in solution..
        /// </summary>
        internal static string UnusedDeclarationsMessage {
            get {
                return ResourceManager.GetString("UnusedDeclarationsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to unused code.
        /// </summary>
        internal static string UnusedDeclarationsTitle {
            get {
                return ResourceManager.GetString("UnusedDeclarationsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid zero-length array allocations..
        /// </summary>
        internal static string UseArrayEmptyDescription {
            get {
                return ResourceManager.GetString("UseArrayEmptyDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid unnecessary zero-length array allocations.  Use Array.Empty&lt;T&gt;() instead..
        /// </summary>
        internal static string UseArrayEmptyMessage {
            get {
                return ResourceManager.GetString("UseArrayEmptyMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use SpecializedCollections.EmptyEnumerable&lt;T&gt;().
        /// </summary>
        internal static string UseEmptyEnumerableDescription {
            get {
                return ResourceManager.GetString("UseEmptyEnumerableDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use SpecializedCollections.EmptyEnumerable&lt;T&gt;().
        /// </summary>
        internal static string UseEmptyEnumerableMessage {
            get {
                return ResourceManager.GetString("UseEmptyEnumerableMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use of cref tags with prefixes should be avoided, since it prevents the compiler from verifying references and the IDE from updating references during refactorings. It is permissible to suppress this error at a single documentation site if the cref must use a prefix because the type being mentioned is not findable by the compiler. For example, if a cref is mentioning a special attribute in the full framework but you’re in a file that compiles against the portable framework, or if you want to reference a typ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string UseProperCrefTagsDescription {
            get {
                return ResourceManager.GetString("UseProperCrefTagsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to cref tag has prefix &apos;{0}&apos;, which should be removed unless the type or member cannot be accessed..
        /// </summary>
        internal static string UseProperCrefTagsMessage {
            get {
                return ResourceManager.GetString("UseProperCrefTagsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid using cref tags with a prefix.
        /// </summary>
        internal static string UseProperCrefTagsTitle {
            get {
                return ResourceManager.GetString("UseProperCrefTagsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use SpecializedCollections.SingletonEnumerable&lt;T&gt;().
        /// </summary>
        internal static string UseSingletonEnumerableDescription {
            get {
                return ResourceManager.GetString("UseSingletonEnumerableDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use SpecializedCollections.SingletonEnumerable&lt;T&gt;().
        /// </summary>
        internal static string UseSingletonEnumerableMessage {
            get {
                return ResourceManager.GetString("UseSingletonEnumerableMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invoke the correct property to ensure correct use site diagnostics..
        /// </summary>
        internal static string UseSiteDiagnosticsCheckerDescription {
            get {
                return ResourceManager.GetString("UseSiteDiagnosticsCheckerDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do not directly invoke the property &apos;{0}&apos;, instead use &apos;{0}NoUseSiteDiagnostics&apos;..
        /// </summary>
        internal static string UseSiteDiagnosticsCheckerMessage {
            get {
                return ResourceManager.GetString("UseSiteDiagnosticsCheckerMessage", resourceCulture);
            }
        }
    }
}
