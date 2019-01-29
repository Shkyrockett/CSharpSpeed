using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class FlipDistortionTests
    {
        /// <summary>
        /// The flip distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="flipHorz">The bHorz.</param>
        /// <param name="flipVert">The bVert.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Flip(Point2D point, Point2D fulcrum, bool flipHorz, bool flipVert)
        {
            var x = flipHorz ? fulcrum.X - (point.X - fulcrum.X + 1d) : point.X;
            var y = flipVert ? fulcrum.Y - (point.Y - fulcrum.Y + 1d) : point.Y;
            return new Point2D(x, y);
        }
    }
}
