using System;
using System.Runtime.CompilerServices;

namespace CSharpSpeed
{
    /// <summary>
    /// The signature attribute class.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Method)]
    public class SignatureAttribute
        : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureAttribute" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="member">The member.</param>
        /// <param name="line">The line.</param>
        public SignatureAttribute([CallerFilePath] string file = default, [CallerMemberName] string member = default, [CallerLineNumber] int line = default)
        {
            _ = member;
            MethodSignature = SpeedTester.GetMethodCodeSignature(file, line);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureAttribute" /> class.
        /// </summary>
        /// <param name="methodSignature">The methodSignature.</param>
        public SignatureAttribute(string methodSignature)
        {
            MethodSignature = methodSignature;
        }

        /// <summary>
        /// Gets or sets the method signature.
        /// </summary>
        /// <value>
        /// The method signature.
        /// </value>
        public string MethodSignature { get; set; }
    }
}