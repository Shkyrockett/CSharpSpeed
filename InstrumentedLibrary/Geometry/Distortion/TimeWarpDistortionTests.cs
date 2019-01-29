using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class TimeWarpDistortionTests
    {
        /// <summary>
        /// The time warp distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D TimeWarp(Point2D point, Point2D fulcrum, double factor = 10d)
        {
            var dX = point.X - fulcrum.X;
            var dY = point.Y - fulcrum.Y;
            var theta = Atan2(dY, dX); // Might this be simplified by finding the unit of the vector?
            var radius = Sqrt(dX * dX + dY * dY);
            var newRadius = Sqrt(radius) * factor;
            var newX = fulcrum.X + (newRadius * Cos(theta));
            var newY = fulcrum.Y + (newRadius * Sin(theta));
            return new Point2D(newX, newY);
        }
    }
}
