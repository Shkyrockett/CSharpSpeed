using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The step towards2d class.
    /// </summary>
    public static class StepTowards2D
    {
        /// <summary>
        /// The predict vector.
        /// </summary>
        /// <param name="vectorOrigin">The vectorOrigin.</param>
        /// <param name="vectorDirection">The vectorDirection.</param>
        /// <param name="length">The length.</param>
        /// <returns>The <see cref="Vector2D"/>.</returns>
        /// <acknowledgment>
        /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/2a8241f7-7330-4be2-a79b-c7a92c6eb6cf/c-how-can-i-move-an-object-trough-a-point-x-y-for-specific-number-of-px-
        /// </acknowledgment>
        public static Vector2D PredictVector(Vector2D vectorOrigin, Vector2D vectorDirection, double length)
        {
            var deltaX = vectorDirection.I - vectorOrigin.I;
            var deltaY = vectorDirection.J - vectorOrigin.J;

            var deltaLength = Sqrt(deltaX * deltaX + deltaY * deltaY);
            if (deltaLength == 0 || Abs(deltaLength) < length) return vectorDirection;
            var lengthRatio = length / deltaLength;

            var extendedDeltaX = deltaX * lengthRatio;
            var extendedDeltaY = deltaY * lengthRatio;

            return new Vector2D(
                vectorOrigin.I + Round(extendedDeltaX),
                vectorOrigin.J + Round(extendedDeltaY)
                );
        }

        /// <summary>
        /// Move the point towards.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/4703403
        /// </acknowledgment>
        public static Point2D MovePointTowards(Point2D a, Point2D b, double distance)
        {
            var vector = new Point2D(b.X - a.X, b.Y - a.Y);
            var length = Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (length == 0 || Abs(length) < distance) return b;
            var unitVector = new Point2D(vector.X / length, vector.Y / length);
            return new Point2D(
                a.X + unitVector.X * distance,
                a.Y + unitVector.Y * distance
                );
        }
    }
}
