using System;

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