using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class QuadraticBezierEnvelopeDistortPointTests
    {
        /// <summary>
        /// Warp the shape using Quadratic Bézier Envelope distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="topLeft">The topLeft.</param>
        /// <param name="topHandle">The topLeftH.</param>
        /// <param name="leftHandle">The topLeftV.</param>
        /// <param name="rightHandle">The topRightV.</param>
        /// <param name="topRight">The topRight.</param>
        /// <param name="bottomRight">The bottomRight.</param>
        /// <param name="bottomHandle">The bottomRightH.</param>
        /// <param name="bottomLeft">The bottomLeft.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// Based roughly on the ideas presented in: https://web.archive.org/web/20160825211055/http://www.neuroproductions.be:80/experiments/envelope-distort-with-actionscript/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D QuadraticBezierEnvelope(
            Point2D point,
            Rectangle2D bounds,
            Point2D topLeft, Point2D topHandle, Point2D topRight, Point2D rightHandle,
            Point2D bottomRight, Point2D bottomHandle, Point2D bottomLeft, Point2D leftHandle)
        {
            // topLeft                             topRight
            //   0------------------0------------------0
            //   |              topHandle              |
            //   |                                     |
            //   |                                     |
            //   |                                     |
            //   |                                     |
            //   0 leftHandle              rightHandle 0
            //   |                                     |
            //   |                                     |
            //   |                                     |
            //   |                                     |
            //   |             bottomHandle            |
            //   0------------------0------------------0
            // bottomLeft                       bottomRight
            // 
            // Install "Match Margin" Extension to enable word match highlighting, to help visualize where a variable resides in the ASCI map. 

            var normal = (X: (point.X - bounds.X) / bounds.Width, Y: (point.Y - bounds.Top) / bounds.Height);
            var leftAnchor = InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(topLeft.X, topLeft.Y, leftHandle.X, leftHandle.Y, bottomLeft.X, bottomLeft.Y, normal.Y);
            var handle = InterpolateLinear2DTests.LinearInterpolate2D(topHandle.X, topHandle.Y, bottomHandle.X, bottomHandle.Y, normal.Y);
            var rightAnchor = InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(topRight.X, topRight.Y, rightHandle.X, rightHandle.Y, bottomRight.X, bottomRight.Y, normal.Y);
            return new Point2D(InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(leftAnchor.X, leftAnchor.Y, handle.X, handle.Y, rightAnchor.X, rightAnchor.Y, normal.X));
        }
    }
}
