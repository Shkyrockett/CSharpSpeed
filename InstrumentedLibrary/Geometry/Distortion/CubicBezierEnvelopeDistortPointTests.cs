using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The envelope distort point tests class.
    /// </summary>
    [DisplayName("Envelope Distort Point Tests")]
    [Description("Use a Bezier envelope to distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class CubicBezierEnvelopeDistortPointTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CubicBezierEnvelopeDistortPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(5d, 5d), new Rectangle2D(0d, 0d, 10d, 10d), new Point2D(0,0), new Point2D(0.5d, -0.5d), new Point2D(0.5d, 0.5d), new Point2D(10d, 0d), new Point2D(0.5d, -0.5d), new Point2D(0.5d, 0.5d), new Point2D(10, 10), new Point2D(0.5d, 0.5d), new Point2D(0.5d, 0.5d), new Point2D(0d, 10d), new Point2D(0.5d, 0.5d), new Point2D(0.5d, 0.5d) }, new TestCaseResults(description: "Warp a point", trials: trials, expectedReturnValue: new Point2D(0.78125d,  0.40625d), epsilon: double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
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
        /// <param name="topLeftH"></param>
        /// <param name="topLeftV"></param>
        /// <param name="topRight"></param>
        /// <param name="topRightH"></param>
        /// <param name="topRightV"></param>
        /// <param name="bottomRight"></param>
        /// <param name="bottomRightH"></param>
        /// <param name="bottomRightV"></param>
        /// <param name="bottomLeft"></param>
        /// <param name="bottomLeftH"></param>
        /// <param name="bottomLeftV"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D EnvelopeDistortPoint(Point2D point, Rectangle2D bounds, Point2D topLeft, Point2D topLeftH, Point2D topLeftV, Point2D topRight, Point2D topRightH, Point2D topRightV, Point2D bottomRight, Point2D bottomRightH, Point2D bottomRightV, Point2D bottomLeft, Point2D bottomLeftH, Point2D bottomLeftV)
            => CubicBezierEnvelope(point, bounds, topLeft, topLeftH, topLeftV, topRight, topRightH, topRightV, bottomRight, bottomRightH, bottomRightV, bottomLeft, bottomLeftH, bottomLeftV);

        /// <summary>
        /// Warp the shape using Envelope distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="topLeft">The topLeft.</param>
        /// <param name="topLeftH">The topLeftH.</param>
        /// <param name="topLeftV">The topLeftV.</param>
        /// <param name="topRight">The topRight.</param>
        /// <param name="topRightH">The topRightH.</param>
        /// <param name="topRightV">The topRightV.</param>
        /// <param name="bottomRight">The bottomRight.</param>
        /// <param name="bottomRightH">The bottomRightH.</param>
        /// <param name="bottomRightV">The bottomRightV.</param>
        /// <param name="bottomLeft">The bottomLeft.</param>
        /// <param name="bottomLeftH">The bottomLeftH.</param>
        /// <param name="bottomLeftV">The bottomLeftV.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Envelope Warp Method All Interpolation Calls")]
        [Description("A method of warping a point using an envelope of Cubic Beziers.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Envelope1(
            Point2D point,
            Rectangle2D bounds,
            Point2D topLeft, Point2D topLeftH, Point2D topLeftV,
            Point2D topRight, Point2D topRightH, Point2D topRightV,
            Point2D bottomRight, Point2D bottomRightH, Point2D bottomRightV,
            Point2D bottomLeft, Point2D bottomLeftH, Point2D bottomLeftV)
        {
            var norm = NormalizeBoundedPoint2DTests.NormalizePoint(bounds, point);
            var left = InterpolateCubicBezier1DTests.CubicBezier(topLeft.X, topLeftV.X, bottomLeftV.X, bottomLeft.X, norm.Y);
            var right = InterpolateCubicBezier1DTests.CubicBezier(topRight.X, topRightV.X, bottomRightV.X, bottomRight.X, norm.Y);
            var top = InterpolateCubicBezier1DTests.CubicBezier(topLeft.Y, topLeftH.Y, topRightH.Y, topRight.Y, norm.X);
            var bottom = InterpolateCubicBezier1DTests.CubicBezier(bottomLeft.Y, bottomLeftH.Y, bottomRightH.Y, bottomRight.Y, norm.X);
            var x = InterpolateLinear1DTests.LinearInterpolate1D(left, right, norm.X);
            var y = InterpolateLinear1DTests.LinearInterpolate1D(top, bottom, norm.Y);
            return new Point2D(x, y);
        }

        /// <summary>
        /// Warp the shape using Envelope distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="topLeft">The topLeft.</param>
        /// <param name="topLeftH">The topLeftH.</param>
        /// <param name="topLeftV">The topLeftV.</param>
        /// <param name="topRight">The topRight.</param>
        /// <param name="topRightH">The topRightH.</param>
        /// <param name="topRightV">The topRightV.</param>
        /// <param name="bottomRight">The bottomRight.</param>
        /// <param name="bottomRightH">The bottomRightH.</param>
        /// <param name="bottomRightV">The bottomRightV.</param>
        /// <param name="bottomLeft">The bottomLeft.</param>
        /// <param name="bottomLeftH">The bottomLeftH.</param>
        /// <param name="bottomLeftV">The bottomLeftV.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Envelope Warp Method Inlined Interpolation")]
        [Description("A method of warping a point using an envelope of Cubic Beziers.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Envelope2(
            Point2D point,
            Rectangle2D bounds,
            Point2D topLeft, Point2D topLeftH, Point2D topLeftV,
            Point2D topRight, Point2D topRightH, Point2D topRightV,
            Point2D bottomRight, Point2D bottomRightH, Point2D bottomRightV,
            Point2D bottomLeft, Point2D bottomLeftH, Point2D bottomLeftV)
        {
            // Normalize the point to the bounding box.
            var (normX, normY) = ((point.X - bounds.X) / bounds.Width, (point.Y - bounds.Top) / bounds.Height);

            // Set up Interpolation variables.
            var (minusNormX, minusNormY) = (1d - normX, 1d - normY);
            var (minusNormXSquared, minusNormYSquared) = (minusNormX * minusNormX, minusNormY * minusNormY);
            var (minusNormXCubed, minusNormYCubed) = (minusNormXSquared * minusNormX, minusNormYSquared * minusNormY);
            var (normXSquared, normYSquared) = (normX * normX, normY * normY);
            var (normXCubed, normYCubed) = (normXSquared * normX, normYSquared * normY);

            // Interpolate the normalized point along the Cubic Bézier curves
            var left = (minusNormYCubed * topLeft.X) + (3d * normY * minusNormYSquared * topLeftV.X) + (3d * normYSquared * minusNormY * bottomLeftV.X) + (normYCubed * bottomLeft.X);
            var right = (minusNormYCubed * topRight.X) + (3d * normY * minusNormYSquared * topRightV.X) + (3d * normYSquared * minusNormY * bottomRightV.X) + (normYCubed * bottomRight.X);
            var top = (minusNormXCubed * topLeft.Y) + (3d * normX * minusNormXSquared * topLeftH.Y) + (3d * normXSquared * minusNormX * topRightH.Y) + (normXCubed * topRight.Y);
            var bottom = (minusNormXCubed * bottomLeft.Y) + (3d * normX * minusNormXSquared * bottomLeftH.Y) + (3d * normXSquared * minusNormX * bottomRightH.Y) + (normXCubed * bottomRight.Y);

            // Linearly interpolate the point between the Bézier curves.
            return new Point2D(
                (minusNormX * left) + (normX * right),
                (minusNormY * top) + (normY * bottom)
                );
        }


        /// <summary>
        /// Warp the shape using Cubic Bézier Envelope distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="topLeft">The topLeft.</param>
        /// <param name="topLeftH">The topLeftH.</param>
        /// <param name="topLeftV">The topLeftV.</param>
        /// <param name="topRight">The topRight.</param>
        /// <param name="topRightH">The topRightH.</param>
        /// <param name="topRightV">The topRightV.</param>
        /// <param name="bottomRight">The bottomRight.</param>
        /// <param name="bottomRightH">The bottomRightH.</param>
        /// <param name="bottomRightV">The bottomRightV.</param>
        /// <param name="bottomLeft">The bottomLeft.</param>
        /// <param name="bottomLeftH">The bottomLeftH.</param>
        /// <param name="bottomLeftV">The bottomLeftV.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// Based roughly on the ideas presented in: https://web.archive.org/web/20160825211055/http://www.neuroproductions.be:80/experiments/envelope-distort-with-actionscript/
        /// </acknowledgment>
        [DisplayName("Envelope Warp Method Inlined Interpolation")]
        [Description("A method of warping a point using an envelope of Cubic Beziers.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D CubicBezierEnvelope(
            Point2D point,
            Rectangle2D bounds,
            Point2D topLeft, Point2D topLeftH, Point2D topLeftV,
            Point2D topRight, Point2D topRightH, Point2D topRightV,
            Point2D bottomRight, Point2D bottomRightH, Point2D bottomRightV,
            Point2D bottomLeft, Point2D bottomLeftH, Point2D bottomLeftV)
        {
            // topLeft                             topRight
            //   0--------0                 0----------0
            //   |   topLeftH             topRightH    |
            //   |                                     |
            //   |                                     |
            //   0 topLeftV                  topRightV 0
            //   
            //   
            //   
            //   0 bottomLeftV            bottomRightV 0
            //   |                                     |
            //   |                                     |
            //   |  bottomLeftH         bottomRightH   |
            //   0--------0                 0----------0
            // bottomLeft                       bottomRight
            // 
            // Install "Match Margin" Extension to enable word match highlighting, to help visualize where a variable resides in the ASCI map. 

            var normal = (X: (point.X - bounds.X) / bounds.Width, Y: (point.Y - bounds.Top) / bounds.Height);
            var normalSquared = (X: normal.X * normal.X, Y: normal.Y * normal.Y);
            var normalCubed = (X: normalSquared.X * normal.X, Y: normalSquared.Y * normal.Y);
            var reverseNormal = (X: 1d - normal.X, Y: 1d - normal.Y);
            var reverseNormalSquared = (X: reverseNormal.X * reverseNormal.X, Y: reverseNormal.Y * reverseNormal.Y);
            var reverseNormalCubed = (X: reverseNormalSquared.X * reverseNormal.X, Y: reverseNormalSquared.Y * reverseNormal.Y);

            // Cubic interpolate the left anchor node.
            var leftAnchor = (
                X: topLeft.X * reverseNormalCubed.Y + 3d * topLeftV.X * normal.Y * reverseNormalSquared.Y + 3d * bottomLeftV.X * normalSquared.Y * reverseNormal.Y + bottomLeft.X * normalCubed.Y,
                Y: topLeft.Y * reverseNormalCubed.Y + 3d * topLeftV.Y * normal.Y * reverseNormalSquared.Y + 3d * bottomLeftV.Y * normalSquared.Y * reverseNormal.Y + bottomLeft.Y * normalCubed.Y
                );
            // Linear interpolate the left handle node.
            var leftHandle = (
                X: topLeftH.X * reverseNormal.Y + bottomLeftH.X * normal.Y,
                Y: topLeftH.Y * reverseNormal.Y + bottomLeftH.Y * normal.Y
                );
            // Linear interpolate the right handle node.
            var rightHandle = (
                X: topRightH.X * reverseNormal.Y + bottomRightH.X * normal.Y,
                Y: topRightH.Y * reverseNormal.Y + bottomRightH.Y * normal.Y
                );
            // Cubic interpolate the right anchor node.
            var rightAnchor = (
                X: topRight.X * reverseNormalCubed.Y + 3d * topRightV.X * normal.Y * reverseNormalSquared.Y + 3d * bottomRightV.X * normalSquared.Y * reverseNormal.Y + bottomRight.X * normalCubed.Y,
                Y: topRight.Y * reverseNormalCubed.Y + 3d * topRightV.Y * normal.Y * reverseNormalSquared.Y + 3d * bottomRightV.Y * normalSquared.Y * reverseNormal.Y + bottomRight.Y * normalCubed.Y
                );
            // Cubic interpolate the final result.
            return new Point2D (
                x: leftAnchor.X * reverseNormalCubed.X + 3d * leftHandle.X * normal.X * reverseNormalSquared.X + 3d * rightHandle.X * normalSquared.X * reverseNormal.X + rightAnchor.X * normalCubed.X,
                y: leftAnchor.Y * reverseNormalCubed.X + 3d * leftHandle.Y * normal.X * reverseNormalSquared.X + 3d * rightHandle.Y * normalSquared.X * reverseNormal.X + rightAnchor.Y * normalCubed.X
                );
        }

        /// <summary>
        /// Warp the shape using Cubic Bézier envelope distortion.
        /// </summary>
        /// <param name="point">The point to move.</param>
        /// <param name="bounds">The bounds of the shape.</param>
        /// <param name="topLeft">The top left anchor point of the envelope.</param>
        /// <param name="topLeftH">The top left horizontal point of the envelope.</param>
        /// <param name="topLeftV">The top left vertical point of the envelope.</param>
        /// <param name="topRight">The top right anchor point of the envelope.</param>
        /// <param name="topRightH">The top right horizontal point of the envelope.</param>
        /// <param name="topRightV">The top right vertical point of the envelope.</param>
        /// <param name="bottomRight">The bottom right anchor point of the envelope.</param>
        /// <param name="bottomRightH">The bottom right horizontal point of the envelope.</param>
        /// <param name="bottomRightV">The bottom right vertical point of the envelope.</param>
        /// <param name="bottomLeft">The bottom left anchor point of the envelope.</param>
        /// <param name="bottomLeftH">The bottom left horizontal point of the envelope.</param>
        /// <param name="bottomLeftV">The bottom left vertical point of the envelope.</param>
        /// <returns>Returns a <see cref="Point2D"/> shifted by the envelope.</returns>
        /// <acknowledgment>
        /// Based roughly on the ideas presented in: https://web.archive.org/web/20160825211055/http://www.neuroproductions.be:80/experiments/envelope-distort-with-actionscript/
        /// </acknowledgment>
        [DisplayName("Envelope Warp Method Inlined Interpolation")]
        [Description("A method of warping a point using an envelope of Cubic Beziers.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D CubicBezierEnvelope0(
            Point2D point,
            Rectangle2D bounds,
            Point2D topLeft, Point2D topLeftH, Point2D topLeftV,
            Point2D topRight, Point2D topRightH, Point2D topRightV,
            Point2D bottomRight, Point2D bottomRightH, Point2D bottomRightV,
            Point2D bottomLeft, Point2D bottomLeftH, Point2D bottomLeftV)
        {
            // topLeft                             topRight
            //   0--------0                 0----------0
            //   |   topLeftH             topRightH    |
            //   |                                     |
            //   |                                     |
            //   0 topLeftV                  topRightV 0
            //   
            //   
            //   
            //   0 bottomLeftV            bottomRightV 0
            //   |                                     |
            //   |                                     |
            //   |  bottomLeftH         bottomRightH   |
            //   0--------0                 0----------0
            // bottomLeft                       bottomRight
            // 
            // Install "Match Margin" Extension to enable word match highlighting, to help visualize where a variable resides in the ASCI map. 

            var normal = (X: (point.X - bounds.X) / bounds.Width, Y: (point.Y - bounds.Top) / bounds.Height);
            var leftAnchor = InterpolateCubicBezier2DTests.CubicBezierCurve(topLeft.X, topLeft.Y, topLeftV.X, topLeftV.Y, bottomLeftV.X, bottomLeftV.Y, bottomLeft.X, bottomLeft.Y, normal.Y);
            var leftHandle = InterpolateLinear2DTests.LinearInterpolate2D(topLeftH.X, topLeftH.Y, bottomLeftH.X, bottomLeftH.Y, normal.Y);
            var rightHandle = InterpolateLinear2DTests.LinearInterpolate2D(topRightH.X, topRightH.Y, bottomRightH.X, bottomRightH.Y, normal.Y);
            var rightAnchor = InterpolateCubicBezier2DTests.CubicBezierCurve(topRight.X, topRight.Y, topRightV.X, topRightV.Y, bottomRightV.X, bottomRightV.Y, bottomRight.X, bottomRight.Y, normal.Y);
            return new Point2D(InterpolateCubicBezier2DTests.CubicBezierCurve(leftAnchor.X, leftAnchor.Y, leftHandle.X, leftHandle.Y, rightHandle.X, rightHandle.Y, rightAnchor.X, rightAnchor.Y, normal.X));
        }
    }
}
