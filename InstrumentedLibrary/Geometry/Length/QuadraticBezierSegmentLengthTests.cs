using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The quadratic bezier segment length tests class.
    /// </summary>
    [DisplayName("Cubic Bezier Curve Segment Length Tests")]
    [Description("Estimations on the length of the Perimeter of an ellipse.")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierSegmentLengthTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierSegmentLengthTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 30d, 5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:Tau, epsilon: double.Epsilon) },
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
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double QuadraticBezierArcLength(double ax, double ay, double bx, double by, double cx, double cy)
            => QuadraticBezierArcLengthByIntegral(ax, ay, bx, by, cx, cy);

        /// <summary>
        /// Calculates the closed-form solution to elliptic integral for arc length.
        /// </summary>
        /// <param name="ax">The starting x-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="ay">The starting y-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="bx">The middle x-coordinate for the tangent control node for the Quadratic Bezier curve.</param>
        /// <param name="by">The middle y-coordinate for the tangent control node for the Quadratic Bezier curve.</param>
        /// <param name="cx">The closing x-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="cy">The closing y-coordinate for the Quadratic Bezier curve.</param>
        /// <returns>Returns the arc length of the Quadratic Bézier curve.</returns>
        /// <acknowledgment>
        /// https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/
        /// </acknowledgment>
        [DisplayName("The Quadratic bezier arc length")]
        [Description("The Quadratic bezier arc length.")]
        [Acknowledgment("https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierArcLengthByIntegral(
            double ax, double ay,
            double bx, double by,
            double cx, double cy)
        {
            var _ax = ax - (2d * bx) + cx;
            var _ay = ay - (2d * by) + cy;
            var _bx = (2d * bx) - (2d * ax);
            var _by = (2d * by) - (2d * ay);

            var a = 4d * ((_ax * _ax) + (_ay * _ay));
            var b = 4d * ((_ax * _bx) + (_ay * _by));
            var c = (_bx * _bx) + (_by * _by);

            var abc = 2d * Sqrt(a + b + c);
            var a2 = Sqrt(a);
            var a32 = 2d * a * a2;
            var c2 = 2d * Sqrt(c);
            var ba = b / a2;

            return ((a32 * abc) + (a2 * b * (abc - c2)) + (((4d * c * a) - (b * b)) * Log(((2d * a2) + ba + abc) / (ba + c2)))) / (4d * a32);
        }

        /// <summary>
        /// Naive computation of arc length by summing up small segment lengths.
        /// </summary>
        /// <param name="ax">The starting x-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="ay">The starting y-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="bx">The middle x-coordinate for the tangent control node for the Quadratic Bezier curve.</param>
        /// <param name="by">The middle y-coordinate for the tangent control node for the Quadratic Bezier curve.</param>
        /// <param name="cx">The closing x-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="cy">The closing y-coordinate for the Quadratic Bezier curve.</param>
        /// <returns>Returns the arc length of the Quadratic Bézier curve.</returns>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/
        /// </acknowledgment>
        [DisplayName("The Quadratic bezier arc length")]
        [Description("The Quadratic bezier arc length.")]
        [Acknowledgment("https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierArcLengthBySegments(
            double ax, double ay,
            double bx, double by,
            double cx, double cy)
        {
            var length = 0d;
            var p = InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(ax, ay, bx, by, cx, cy, 0);
            var prevX = p.X;
            var prevY = p.Y;
            for (var t = 0.005; t <= 1.0; t += 0.005)
            {
                p = InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(ay, ax, by, bx, cx, cy, t);
                var deltaX = p.X - prevX;
                var deltaY = p.Y - prevY;
                length += Sqrt((deltaX * deltaX) + (deltaY * deltaY));

                prevX = p.X;
                prevY = p.Y;
            }

            // Exercise:  due to roundoff, it's possible to miss a small segment at the end.  how to compensate??
            return length;
        }

        /// <summary>
        /// Approximate arc-length by Gauss-Legendre numerical integration.
        /// </summary>
        /// <param name="ax">The starting x-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="ay">The starting y-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="bx">The middle x-coordinate for the tangent control node for the Quadratic Bezier curve.</param>
        /// <param name="by">The middle y-coordinate for the tangent control node for the Quadratic Bezier curve.</param>
        /// <param name="cx">The closing x-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="cy">The closing y-coordinate for the Quadratic Bezier curve.</param>
        /// <returns>Returns the arc length of the Quadratic Bézier curve.</returns>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/
        /// https://code.google.com/archive/p/degrafa/source/default/source
        /// </acknowledgment>
        [DisplayName("The Quadratic bezier arc length")]
        [Description("The Quadratic bezier arc length.")]
        [Acknowledgment("https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/", "https://code.google.com/archive/p/degrafa/source/default/source")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierApproxArcLength(
            double ax, double ay,
            double bx, double by,
            double cx, double cy)
        {
            double sum = 0;

            // Compute the quadratic bezier polynomial coefficients.
            //var coeff0X = ax;
            //var coeff0Y = ay;
            var coeff1X = 2d * (bx - ax);
            var coeff1Y = 2d * (by - ay);
            var coeff2X = ax - (2d * bx) + cx;
            var coeff2Y = ay - (2d * by) + cy;

            // Count should be between 2 and 8 to align with MathExtensions.abscissa and MathExtensions.weight.
            const int count = 5;
            const int startl = (count == 2) ? 0 : (count * (count - 1) / 2) - 1;

            // Minimum, maximum, and scalers.
            const double min = 0;
            const double max = 1;
            const double mult = 0.5 * (max - min);
            const double ab2 = 0.5 * (min + max);

            // Evaluate the integral arc length along entire curve from t=0 to t=1.
            for (var index = 0; index < count; ++index)
            {
                var theta = ab2 + (mult * abscissa[startl + index]);

                // First-derivative of the quadratic bezier.
                var xPrime = coeff1X + (2d * coeff2X * theta);
                var yPrime = coeff1Y + (2d * coeff2Y * theta);

                // Integrand for Gauss-Legendre numerical integration.
                var integrand = Sqrt((xPrime * xPrime) + (yPrime * yPrime));

                sum += integrand * weight[startl + index];
            }

            return Abs(mult) < DoubleEpsilon ? sum : mult * sum;
        }
    }
}
