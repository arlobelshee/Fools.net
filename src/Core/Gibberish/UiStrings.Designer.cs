﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gibberish {
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
    internal class UiStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UiStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Gibberish.UiStrings", typeof(UiStrings).Assembly);
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
        ///   Looks up a localized string similar to We might have found the end of your multi-line comment, but we can&apos;t be sure. A multi-line comment must end with `&quot;&quot;&quot;` on its own line. We found something similar: `{0}`. Please end the comment properly..
        /// </summary>
        internal static string ErrorAtEndOfMultilineComment {
            get {
                return ResourceManager.GetString("ErrorAtEndOfMultilineComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We were confused by a tab used for something other than indentation. Each line must start with the right number of indentations, each a single tab character. Tabs may also be used to separate the code line from a comment reference. Tabs are not allowed in any other place. Please clean up your tabs..
        /// </summary>
        internal static string IllegalTabInLine {
            get {
                return ResourceManager.GetString("IllegalTabInLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We were confused by whitespace `{0}` at the end of line. Each line must end with a newline and no other whitespace. Please double-check your whitespace..
        /// </summary>
        internal static string IllegalWhitespaceAtEnd {
            get {
                return ResourceManager.GetString("IllegalWhitespaceAtEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We were confused by whitespace `{0}` at the start of line. Each line must start with the right number of indentations, each a single tab character, and no other whitespace. Please double-check your whitespace..
        /// </summary>
        internal static string IllegalWhitespaceAtStart {
            get {
                return ResourceManager.GetString("IllegalWhitespaceAtStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We found bad whitespace on a blank line. Blank lines must either consist of just a newline, or must be indented the current indentation level and then have a newline. This blank line has the whitespace `{0}`. Please remove it..
        /// </summary>
        internal static string IllegalWhitespaceOnBlankLine {
            get {
                return ResourceManager.GetString("IllegalWhitespaceOnBlankLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We found a nearly-valid comment definition, but it had the wrong whitespace between the ID and the content. Comment definitions must begin with `#[44]: `. Yours is like that, but instead of a single space after the colon you have `{0}`. Please fix it..
        /// </summary>
        internal static string IncorrectCommentDefinitionSeparator {
            get {
                return ResourceManager.GetString("IncorrectCommentDefinitionSeparator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We were confused by a comment. Comments must all be formatted like `#[4], [9], [2]`. This comment was `#{0}`. Please fix it..
        /// </summary>
        internal static string IncorrectCommentFormat {
            get {
                return ResourceManager.GetString("IncorrectCommentFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We found what we think was intended to be a comment, but it had the wrong separator. Comments must begin with `		#`. This possible comment started with `{0}`. Please fix it..
        /// </summary>
        internal static string IncorrectCommentSeparator {
            get {
                return ResourceManager.GetString("IncorrectCommentSeparator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We found a comment defintion but couldn&apos;t find its ID. Each comment must begin with an ID in the form `#[23]: `. Your comment starts with `{0}`..
        /// </summary>
        internal static string MissingIdInCommentDefinition {
            get {
                return ResourceManager.GetString("MissingIdInCommentDefinition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We couldn&apos;t find a name for your {0} block. Please name your new thunk..
        /// </summary>
        internal static string MissingNameForBlock {
            get {
                return ResourceManager.GetString("MissingNameForBlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We couldn&apos;t find the newline at the end of the file. Each file is required to end with a newline. Please add it..
        /// </summary>
        internal static string MissingNewlineAtEndOfFile {
            get {
                return ResourceManager.GetString("MissingNewlineAtEndOfFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We tried our best, but just couldn&apos;t find the end of this multi-line comment. Multi-line comments must end with a line containing just `&quot;&quot;&quot;`. Please end your comment..
        /// </summary>
        internal static string MultilineCommentWithoutEnd {
            get {
                return ResourceManager.GetString("MultilineCommentWithoutEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We couldn&apos;t recognize the language specified in the use language statement. You used language `{0}`. We only recognize the languages `{1}`..
        /// </summary>
        internal static string UnknownLanguage {
            get {
                return ResourceManager.GetString("UnknownLanguage", resourceCulture);
            }
        }
    }
}