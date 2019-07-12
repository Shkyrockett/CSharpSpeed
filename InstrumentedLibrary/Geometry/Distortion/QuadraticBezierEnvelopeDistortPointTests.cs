using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Envelope Distort Point Tests")]
    [Description("Use a Bezier envelope to distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierEnvelopeDistortPointTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierEnvelopeDistortPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(5d, 5d), new Rectangle2D(0d, 0d, 10d, 10d), new Point2D(0,0), new Point2D(0.5d, 0.5d), new Point2D(10d, 0d), new Point2D(0.5d, 0.5d), new Point2D(10, 10), new Point2D(0.5d, 0.5d), new Point2D(0d, 10d), new Point2D(0.5d, 0.5d) }, new TestCaseResults(description: "Warp a point", trials: trials, expectedReturnValue: new Point2D(0.78125d,  0.40625d), epsilon: double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in HelperExtensions.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="bounds"></param>
        /// <param name="topLeft"></param>
        /// <param name="topHandle"></param>
        /// <param name="topRight"></param>
        /// <param name="rightHandle"></param>
        /// <param name="bottomRight"></param>
        /// <param name="bottomHandle"></param>
        /// <param name="bottomLeft"></param>
        /// <param name="leftHandle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D QuadraticBezierEnvelope(Point2D point, Rectangle2D bounds, Point2D topLeft, Point2D topHandle, Point2D topRight, Point2D rightHandle, Point2D bottomRight, Point2D bottomHandle, Point2D bottomLeft, Point2D leftHandle)
            => QuadraticBezierEnvelope0(point, bounds, topLeft, topHandle, topRight, rightHandle, bottomRight, bottomHandle, bottomLeft, leftHandle);

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
        [DisplayName("Envelope Warp Method All Interpolation Calls")]
        [Description("A method of warping a point using an envelope of Cubic Beziers.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D QuadraticBezierEnvelope0(
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
            var leftAnchor = InterpolateBezierQuadratic2DTests.QuadraticBezierInterpolate2D(normal.Y, topLeft.X, topLeft.Y, leftHandle.X, leftHandle.Y, bottomLeft.X, bottomLeft.Y);
            var handle = InterpolateLinear2DTests.LinearInterpolate2D(normal.Y, topHandle.X, topHandle.Y, bottomHandle.X, bottomHandle.Y);
            var rightAnchor = InterpolateBezierQuadratic2DTests.QuadraticBezierInterpolate2D(normal.Y, topRight.X, topRight.Y, rightHandle.X, rightHandle.Y, bottomRight.X, bottomRight.Y);
            return new Point2D(InterpolateBezierQuadratic2DTests.QuadraticBezierInterpolate2D(normal.X, leftAnchor.X, leftAnchor.Y, handle.X, handle.Y, rightAnchor.X, rightAnchor.Y));
        }
    }
}
