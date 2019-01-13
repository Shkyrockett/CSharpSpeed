using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The step towards3d class.
    /// </summary>
    public static class StepTowards3D
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
        public static Vector3D PredictVector(Vector3D vectorOrigin, Vector3D vectorDirection, double length)
        {
            var deltaX = vectorDirection.I - vectorOrigin.I;
            var deltaY = vectorDirection.J - vectorOrigin.J;
            var deltaZ = vectorDirection.K - vectorOrigin.K;

            var deltaLength = Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            if (deltaLength == 0 || Abs(deltaLength) < length) return vectorDirection;
            var lengthRatio = length / deltaLength;

            var extendedDeltaX = deltaX * lengthRatio;
            var extendedDeltaY = deltaY * lengthRatio;
            var extendedDeltaZ = deltaZ * lengthRatio;

            return new Vector3D(
                vectorOrigin.I + Round(extendedDeltaX),
                vectorOrigin.J + Round(extendedDeltaY),
                vectorOrigin.K + Round(extendedDeltaZ)
                );
        }

        /// <summary>
        /// Move the point towards.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>The <see cref="Point3D"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/4703403
        /// </acknowledgment>
        public static Point3D MovePointTowards(Point3D a, Point3D b, double distance)
        {
            var vector = new Vector3D(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
            var length = Sqrt(vector.I * vector.I + vector.J * vector.J + vector.K * vector.K);
            if (length == 0 || Abs(length) < distance) return b;
            var unitVector = new Vector3D(vector.I / length, vector.J / length, vector.K / length);
            return new Point3D(
                a.X + unitVector.I * distance,
                a.Y + unitVector.J * distance,
                a.Z + unitVector.K * distance
                );
        }
    }
}
