using System;
using System.Runtime.CompilerServices;

namespace CSharpSpeed
{
    /// <summary>
    /// The provide source location class.
    /// https://stackoverflow.com/a/26431841
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class SourceCodeLocationProviderAttribute
        : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceCodeLocationProviderAttribute" /> class.
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
        /// Gets the line.
        /// </summary>
        /// <value>
        /// The line.
        /// </value>
        public int Line { get; }

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public string Member { get; }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <value>
        /// The file.
        /// </value>
        public string File { get; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        public override string ToString() => $"{File}({Line}):{Member}";
    }
}
