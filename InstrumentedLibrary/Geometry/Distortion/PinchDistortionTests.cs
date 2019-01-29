using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class PinchDistortionTests
    {
        /// <summary>
        /// The pinch distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="strength">The strength.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Pinch(Point2D point, Point2D fulcrum, double strength = OneHalf)
        {
            if (fulcrum == point)
            {
                return point;
            }

            var dx = point.X - fulcrum.X;
            var dy = point.Y - fulcrum.Y;
            var distanceSquared = dx * dx + dy * dy;
            var sx = point.X;
            var sy = point.Y;
            var distance = Sqrt(distanceSquared);
            if (strength < 0d)
            {
                var r = distance;
                var a = Atan2(dy, dx); // Might this be simplified by finding the unit of the vector?
                var rn = Pow(r, strength) * distance;
                var newX = rn * Cos(a) + fulcrum.X;
                var newY = rn * Sin(a) + fulcrum.Y;
                sx += newX - point.X;
                sy += newY - point.Y;
            }
            else
            {
                var dirX = dx / distance;
                var dirY = dy / distance;
                var alpha = distance;
                var distortionFactor = distance * Pow(1d - alpha, 1d / strength);
                sx -= distortionFactor * dirX;
                sy -= distortionFactor * dirY;
            }

            return new Point2D(sx, sy);
        }
    }
}
