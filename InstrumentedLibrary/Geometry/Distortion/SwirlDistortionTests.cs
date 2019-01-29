using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwirlDistortionTests
    {
        /// <summary>
        /// The swirl distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="degree">The degree.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Swirl(Point2D point, Point2D fulcrum, double degree = OneHalf)
        {
            if (fulcrum == point)
            {
                return point;
            }

            var dX = point.X - fulcrum.X;
            var dY = point.Y - fulcrum.Y;
            var theta = Atan2(dY, dX);
            var radius = Sqrt(dX * dX + dY * dY);
            var newX = fulcrum.X + (radius * Cos(theta + degree * radius));
            var newY = fulcrum.Y + (radius * Sin(theta + degree * radius));
            return new Point2D(newX, newY);
        }
    }
}
