using System;

namespace CSharpSpeed
{
    /// <summary>
    /// The acknowledgment attribute class.
    /// </summary>
    public class AcknowledgmentAttribute
        : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcknowledgmentAttribute"/> class.
        /// </summary>
        /// <param name="urls">The <paramref name="urls"/>.</param>
        public AcknowledgmentAttribute(params string[] urls)
        {
            Urls = urls;
        }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string[] Urls { get; set; }
    }
}