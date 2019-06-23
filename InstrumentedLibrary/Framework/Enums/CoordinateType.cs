namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public enum CoordinateType
    {
        /// <summary>
        /// A single point at a location.
        /// </summary>
        Point,

        /// <summary>
        /// The end of a curve.
        /// </summary>
        End,

        /// <summary>
        /// A point connecting two curves.
        /// </summary>
        Node,

        /// <summary>
        /// A point connecting multiple curves.
        /// </summary>
        Junction,

        /// <summary>
        /// A point that controls the curvature of a curve.
        /// </summary>
        Handle,

        /// <summary>
        /// A direction.
        /// </summary>
        Vector,
    }
}
