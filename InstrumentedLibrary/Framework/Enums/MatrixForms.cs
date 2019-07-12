using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// MatrixTypes
    /// </summary>
    [Flags]
    public enum MatrixForms
        : byte
    {
        /// <summary>
        /// The Identity = 0.
        /// </summary>
        Identity = 0,

        /// <summary>
        /// The Translation = 1.
        /// </summary>
        Translation = 1,

        /// <summary>
        /// The Scaling = 2.
        /// </summary>
        Scaling = 2,

        /// <summary>
        /// The Unknown = 4.
        /// </summary>
        Unknown = 4
    }
}
