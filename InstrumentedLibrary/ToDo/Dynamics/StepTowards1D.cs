using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The step towards1d class.
    /// </summary>
    public static class StepTowards1D
    {
        /// <summary>
        /// The predict vector.
        /// </summary>
        /// <param name="vectorOrigin">The vectorOrigin.</param>
        /// <param name="vectorDirection">The vectorDirection.</param>
        /// <param name="length">The length.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/2a8241f7-7330-4be2-a79b-c7a92c6eb6cf/c-how-can-i-move-an-object-trough-a-point-x-y-for-specific-number-of-px-
        /// </acknowledgment>
        public static double PredictVector(double vectorOrigin, double vectorDirection, double length)
        {
            var delta = vectorDirection - vectorOrigin;
            if (delta == 0) return vectorDirection;
            var deltaLength = Sqrt(delta * delta);
            if (Abs(deltaLength) < length) return vectorDirection;
            var lengthRatio = length / deltaLength;
            var extendedDelta = delta * lengthRatio;
            return vectorOrigin + Round(extendedDelta);
        }

        /// <summary>
        /// Move the point towards.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/4703403
        /// </acknowledgment>
        public static double MovePointTowards(double a, double b, double distance)
        {
            var vector = b - a;
            if (vector == 0) return b;
            var length = Sqrt(vector * vector);
            if (Abs(length) < distance) return b;
            var unitVector = vector / length;
            return a + (unitVector * distance);
        }

        /// <summary>
        /// Move towards a value by a step.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static double MoveTowards1D(double from, double to, double distance)
        {
            var delta = to - from;
            // If the delta between from and to values is 0, then you are already there. Otherwise, calculate the next step.
            return (delta == 0 || Abs(delta) < distance) ? to : from + (delta / Abs(delta) * distance);
        }
    }
}
