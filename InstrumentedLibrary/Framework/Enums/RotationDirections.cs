namespace InstrumentedLibrary
{
    /// <summary>
    /// The rotation directions enum.
    /// </summary>
    public enum RotationDirection
        : sbyte
    {
        /// <summary>
        /// The object is rotating over the top to the left.
        /// </summary>
        CounterClockwise = -1,

        /// <summary>
        /// The object is rotating over the top to the right.
        /// </summary>
        Clockwise = 1,
    }
}
