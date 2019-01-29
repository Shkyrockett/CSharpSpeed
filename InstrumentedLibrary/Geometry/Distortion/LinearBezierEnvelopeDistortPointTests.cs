using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class LinearBezierEnvelopeDistortPointTests
    {
        /// <summary>
        /// Warp the shape using Linear Envelope distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="topLeft">The topLeft.</param>
        /// <param name="topRight">The topRight.</param>
        /// <param name="bottomRight">The bottomRight.</param>
        /// <param name="bottomLeft">The bottomLeft.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// Based roughly on the ideas presented in: https://web.archive.org/web/20160825211055/http://www.neuroproductions.be:80/experiments/envelope-distort-with-actionscript/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D LinearEnvelope(
            Point2D point,
            Rectangle2D bounds,
            Point2D topLeft, Point2D topRight, Point2D bottomRight, Point2D bottomLeft)
        {
            // topLeft          topRight
            //   0-----------------0
            //   |                 |
            //   |                 |
            //   |                 |
            //   |                 |
            //   |                 |
            //   |                 |
            //   0-----------------0
            // bottomLeft   bottomRight
            // 
            // Install "Match Margin" Extension to enable word match highlighting, to help visualize where a variable resides in the ASCI map. 

            var normal = (X: (point.X - bounds.X) / bounds.Width, Y: (point.Y - bounds.Top) / bounds.Height);
            var leftAnchor = InterpolateLinear2DTests.LinearInterpolate2D(topLeft.X, topLeft.Y, bottomLeft.X, bottomLeft.Y, normal.Y);
            var rightAnchor = InterpolateLinear2DTests.LinearInterpolate2D(topRight.X, topRight.Y, bottomRight.X, bottomRight.Y, normal.Y);
            return new Point2D(InterpolateLinear2DTests.LinearInterpolate2D(leftAnchor.X, leftAnchor.Y, rightAnchor.X, rightAnchor.Y, normal.X));
        }
    }
}
