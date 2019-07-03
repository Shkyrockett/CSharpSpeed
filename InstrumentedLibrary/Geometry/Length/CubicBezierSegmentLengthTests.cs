using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cubic bezier length tests class.
    /// </summary>
    [DisplayName("Cubic Bezier Curve Segment Length Tests")]
    [Description("Estimations on the length of the Perimeter of an ellipse.")]
    [SourceCodeLocationProvider]
    public static class CubicBezierSegmentLengthTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CubicBezierSegmentLengthTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 20d, 15d, 30d, 5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:Tau, epsilon: double.Epsilon) },
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
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CubicBezierArcLength(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
            => CubicBezierArcLength0(ax, ay, bx, by, cx, cy, dx, dy);

        /// <summary>
        /// Calculates the arc length of a Cubic Bézier curve.
        /// </summary>
        /// <param name="ax">The starting x-coordinate for the Cubic Bezier curve.</param>
        /// <param name="ay">The starting y-coordinate for the Cubic Bezier curve.</param>
        /// <param name="bx">The first x-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="by">The first y-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="cx">The second x-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="cy">The second y-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="dx">The closing x-coordinate for the Cubic Bezier curve.</param>
        /// <param name="dy">The closing y-coordinate for the Cubic Bezier curve.</param>
        /// <returns>Returns the arc length of the Cubic Bézier curve.</returns>
        /// <acknowledgment>
        /// http://steve.hollasch.net/cgindex/curves/cbezarclen.html
        /// </acknowledgment>
        [DisplayName("The cubic bezier arc length")]
        [Description("The cubic bezier arc length.")]
        [Acknowledgment("http://steve.hollasch.net/cgindex/curves/cbezarclen.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicBezierArcLength0(
            double ax, double ay,
            double bx, double by,
            double cx, double cy,
            double dx, double dy)
        {
            var k1 = (X: -ax + (3d * (bx - cx)) + dx, Y: -ay + (3d * (by - cy)) + dy);
            var k2 = (X: (3d * (ax + cx)) - (6d * bx), Y: (3d * (ay + cy)) - (6d * by));
            var k3 = (X: 3d * (bx - ax), Y: 3d * (by - ax));
            //var k4 = (X: ax, y: ay);

            var q1 = 9d * (Sqrt(Abs(k1.X)) + Sqrt(Abs(k1.Y)));
            var q2 = 12d * ((k1.X * k2.X) + (k1.Y * k2.Y));
            var q3 = (3d * ((k1.X * k3.X) + (k1.Y * k3.Y))) + (4d * (Sqrt(Abs(k2.X)) + Sqrt(Abs(k2.Y))));
            var q4 = 4d * ((k2.X * k3.X) + (k2.Y * k3.Y));
            var q5 = Sqrt(Abs(k3.X)) + Sqrt(Abs(k3.Y));

            // Approximation algorithm based on Simpson.
            const double a = 0d;
            const double b = 1d;
            const int n_limit = 1024;
            const double TOLERANCE = 0.001d;

            var n = 1;

            var multiplier = (b - a) / 6d;
            var endsum = CubicBezierArcLengthHelper(ref q1, ref q2, ref q3, ref q4, ref q5, a) + CubicBezierArcLengthHelper(ref q1, ref q2, ref q3, ref q4, ref q5, b);
            var interval = (b - a) * 0.5d;
            var asum = 0d;
            var bsum = CubicBezierArcLengthHelper(ref q1, ref q2, ref q3, ref q4, ref q5, a + interval);
            var est1 = multiplier * (endsum + (2d * asum) + (4d * bsum));
            var est0 = 2d * est1;

            while (n < n_limit && Abs(est1) > 0d && Abs((est1 - est0) / est1) > TOLERANCE)
            {
                n *= 2;
                multiplier /= 2d;
                interval /= 2d;
                asum += bsum;
                bsum = 0d;
                est0 = est1;
                var interval_div_2n = interval / (2d * n);

                for (var i = 1; i < 2 * n; i += 2)
                {
                    var t = a + (i * interval_div_2n);
                    bsum += CubicBezierArcLengthHelper(ref q1, ref q2, ref q3, ref q4, ref q5, t);
                }

                est1 = multiplier * (endsum + (2d * asum) + (4d * bsum));
            }

            return est1 * 10d;
        }

        /// <summary>
        /// Bezier Arc Length Function
        /// </summary>
        /// <param name="t"></param>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <param name="q3"></param>
        /// <param name="q4"></param>
        /// <param name="q5"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://steve.hollasch.net/cgindex/curves/cbezarclen.html
        /// </acknowledgment>
        public static double CubicBezierArcLengthHelper(ref double q1, ref double q2, ref double q3, ref double q4, ref double q5, double t)
        {
            var result = q5 + (t * (q4 + (t * (q3 + (t * (q2 + (t * q1)))))));
            result = Sqrt(Abs(result));
            return result;
        }

        /// <summary>
        /// Approximate length of the Bézier curve which starts at "start" and
        /// is defined by "c". According to Computing the Arc Length of Cubic Bezier Curves
        /// there is no closed form integral for it.
        /// </summary>
        /// <param name="ax">The starting x-coordinate for the Cubic Bezier curve.</param>
        /// <param name="ay">The starting y-coordinate for the Cubic Bezier curve.</param>
        /// <param name="bx">The first x-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="by">The first y-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="cx">The second x-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="cy">The second y-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="dx">The closing x-coordinate for the Cubic Bezier curve.</param>
        /// <param name="dy">The closing y-coordinate for the Cubic Bezier curve.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.lemoda.net/maths/bezier-length/index.html
        /// </acknowledgment>
        [DisplayName("Approximate length of the Bézier curve")]
        [Description("Approximate length of the Bézier curve.")]
        [Acknowledgment("http://www.lemoda.net/maths/bezier-length/index.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicBezierLength(
            double ax, double ay,
            double bx, double by,
            double cx, double cy,
            double dx, double dy)
        {
            const int steps = 10;// Probably should be a parameter.
            double t;
            (double X, double Y) previous_dot = (0d, 0d);
            var length = 0d;
            for (var i = 0; i <= steps; i++)
            {
                t = (double)i / steps;
                var dot = InterpolateCubic2DTests.CubicInterpolate2D(t, ax, ay, bx, by, cx, cy, dx, dy);
                if (i > 0)
                {
                    var x_diff = dot.X - previous_dot.X;
                    var y_diff = dot.Y - previous_dot.Y;
                    length += Sqrt((x_diff * x_diff) + (y_diff * y_diff));
                }
                previous_dot = dot;
            }
            return length;
        }
    }
}
