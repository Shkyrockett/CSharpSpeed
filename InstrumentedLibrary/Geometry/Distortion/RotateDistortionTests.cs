using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RotateDistortionTests
    {
        /// <summary>
        /// Rotate a point about a center point.
        /// </summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="fulcrum">The center axis point.</param>
        /// <param name="xAxis">The Sine and Cosine of the angle on the x-axis.</param>
        /// <param name="yAxis">The Sine and Cosine of the angle on the y-axis.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Rotate(Point2D point, Point2D fulcrum, Vector2D xAxis, Vector2D yAxis)
        {
            return new Point2D(
                           fulcrum.X + ((point.X - fulcrum.X) * xAxis.I + (point.Y - fulcrum.Y) * xAxis.J),
                           fulcrum.Y + ((point.X - fulcrum.X) * yAxis.I + (point.Y - fulcrum.Y) * yAxis.J));
        }
    }
}
