using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ScaleDistortionTests
    {
        /// <summary>
        /// The scale distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="factors">The factors.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Scale(Point2D point, Size2D factors)
        {
            return new Point2D(point.X * factors.Width, point.Y * factors.Height);
        }
    }
}
