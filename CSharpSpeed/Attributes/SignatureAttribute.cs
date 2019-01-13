using System;
using System.Runtime.CompilerServices;

namespace CSharpSpeed
{
    /// <summary>
    /// The signature attribute class.
    /// </summary>
    public class SignatureAttribute
        : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureAttribute"/> class.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="member"></param>
        /// <param name="line"></param>
        public SignatureAttribute([CallerFilePath] string file = default, [CallerMemberName] string member = default, [CallerLineNumber] int line = default)
        {
            var File = file;
            var Member = member;
            var Line = line;

            MethodSignature = SpeedTester.GetMethodCodeSignature(file, line);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureAttribute"/> class.
        /// </summary>
        /// <param name="methodSignature">The methodSignature.</param>
        public SignatureAttribute(string methodSignature)
        {
            MethodSignature = methodSignature;
        }

        /// <summary>
        /// Gets or sets the method signature.
        /// </summary>
        public string MethodSignature { get; set; }
    }
}