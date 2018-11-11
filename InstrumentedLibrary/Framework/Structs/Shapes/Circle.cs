namespace InstrumentedLibrary
{
    /// <summary>
    /// The circle struct.
    /// </summary>
    public struct Circle2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="radius">The radius.</param>
        public Circle2D(double x, double y, double radius)
            : this()
        {
            Radius = radius;
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        public double Radius { get; set; }
    }
}