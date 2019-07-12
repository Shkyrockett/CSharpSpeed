using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// Enumeration of the inclusion of a point within a shape.
    /// </summary>
    [Flags]
    public enum Inclusions
        : sbyte
    {
        /// <summary>
        /// Touches the boundary of the shape.
        /// </summary>
        Boundary = -1,

        /// <summary>
        /// Point lies outside the shape.
        /// </summary>
        Outside = 0,

        /// <summary>
        /// Point is contained inside the shape.
        /// </summary>
        Inside = 1,
    }
}
