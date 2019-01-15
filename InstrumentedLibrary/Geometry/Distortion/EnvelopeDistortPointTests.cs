using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using System.Diagnostics;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The envelope distort point tests class.
    /// </summary>
    [DisplayName("Envelope Distort Point Tests")]
    [Description("Use a Bezier envelope to distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class EnvelopeDistortPointTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(EnvelopeDistortPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(5d, 5d), new Rectangle2D(0d, 0d, 10d, 10d), new Point2D(0,0), new Point2D(0.5d, -0.5d), new Point2D(0.5d, 0.5d), new Point2D(10d, 0d), new Point2D(0.5d, -0.5d), new Point2D(0.5d, 0.5d), new Point2D(10, 10), new Point2D(0.5d, 0.5d), new Point2D(0.5d, 0.5d), new Point2D(0d, 10d), new Point2D(0.5d, 0.5d), new Point2D(0.5d, 0.5d) }, new TestCaseResults(description:"Warp a point", trials:trials, expectedReturnValue:new Point2D(1.625d, 1.25d), epsilon:DoubleEpsilon) },
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
            => Envelope2(point, bounds, topLeft, topLeftH, topLeftV, topRight, topRightH, topRightV, bottomRight, bottomRightH, bottomRightV, bottomLeft, bottomLeftH, bottomLeftV);

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
    }
}
