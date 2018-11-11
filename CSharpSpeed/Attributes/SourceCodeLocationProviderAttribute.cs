using System;
using System.Runtime.CompilerServices;

namespace CSharpSpeed
{
    /// <summary>
    /// The provide source location class.
    /// https://stackoverflow.com/a/26431841
    /// </summary>
    public class SourceCodeLocationProviderAttribute
        : Attribute
    {
        /// <summary>
        /// The file (readonly).
        /// </summary>
        public readonly string File;

        /// <summary>
        /// The member (readonly).
        /// </summary>
        public readonly string Member;

        /// <summary>
        /// The line (readonly).
        /// </summary>
        public readonly int Line;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceCodeLocationProviderAttribute"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="member">The member.</param>
        /// <param name="line">The line.</param>
        public SourceCodeLocationProviderAttribute([CallerFilePath] string file = default, [CallerMemberName] string member = default, [CallerLineNumber] int line = default)
        {
            File = file;
            Member = member;
            Line = line;
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString() => $"{File}({Line}):{Member}";
    }
}
