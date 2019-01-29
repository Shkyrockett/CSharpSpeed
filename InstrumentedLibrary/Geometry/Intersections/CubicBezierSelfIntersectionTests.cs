using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cubic bezier self intersection tests class.
    /// </summary>
    [DisplayName("Self Intersection of Cubic Bezier")]
    [Description("Finds the self intersection points of a Cubic Bezier.")]
    [SourceCodeLocationProvider]
    public static class CubicBezierSelfIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CubicBezierSelfIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 20d, 0d, 5d, 10d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y)? CubicBezierSelfIntersection(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
            => CubicBezierSelfIntersectionX(x0, y0, x1, y1, x2, y2, x3, y3);

        /// <summary>
        /// The cubic bezier self intersection x.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <returns>returns null if the curve is self-intersecting, or the point of intersection if it is.</returns>
        [DisplayName("Self Intersection of Cubic Bezier")]
        [Description("Finds the self intersection points of a Cubic Bezier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)? CubicBezierSelfIntersectionX(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return CubicBezierSelfIntersectionX(
                CubicBezierCoefficientsTests.CubicBezierCoefficients(x0, x1, x2, x3),
                CubicBezierCoefficientsTests.CubicBezierCoefficients(y0, y1, y2, y3));
        }

        /// <summary>
        /// https://groups.google.com/d/msg/comp.graphics.algorithms/SRm97nRWlw4/R1Rn38ep8n0J
        /// </summary>
        /// <param name="xCurve"></param>
        /// <param name="yCurve"></param>
        /// <returns></returns>
        //[DisplayName("Self Intersection of Cubic Bezier")]
        //[Description("Finds the self intersection points of a Cubic Bezier.")]
        //[Acknowledgment("https://groups.google.com/d/msg/comp.graphics.algorithms/SRm97nRWlw4/R1Rn38ep8n0J")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)? CubicBezierSelfIntersectionX(Polynomial xCurve, Polynomial yCurve)
        {
            (var a, var b) = (xCurve[0] == 0d) ? (xCurve[1], xCurve[2]) : (xCurve[1] / xCurve[0], xCurve[2] / xCurve[0]);
            (var p, var q) = (yCurve[0] == 0d) ? (yCurve[1], yCurve[2]) : (yCurve[1] / yCurve[0], yCurve[2] / yCurve[0]);

            if (a == p || q == b)
            {
                return null;
            }

            var k = (q - b) / (a - p);

            var poly = new Polynomial(
                2,
                -3 * k,
                3 * k * k + 2 * k * a + 2 * b,
                -k * k * k - a * k * k - b * k);

            var r = poly.Roots().OrderByDescending(c => c).ToArray();
            if (r.Length != 3)
            {
                return null;
            }

            if (r[0] >= 0.0 && r[0] <= 1.0 && r[2] >= 0.0 && r[2] <= 1.0)
            {
                var s = r[0];
                return new Point2D(
                    xCurve[0] * s * s * s + xCurve[1] * s * s + xCurve[2] * s + xCurve[3],
                    yCurve[0] * s * s * s + yCurve[1] * s * s + yCurve[2] * s + yCurve[3]);
            }

            return null;
        }

        /// <summary>
        /// https://groups.google.com/d/msg/comp.graphics.algorithms/SRm97nRWlw4/R1Rn38ep8n0J
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns>returns null if the curve is self-intersecting, or the point of intersection if it is.</returns>
        [DisplayName("Self Intersection of Cubic Bezier")]
        [Description("Finds the self intersection points of a Cubic Bezier.")]
        [Acknowledgment("https://groups.google.com/d/msg/comp.graphics.algorithms/SRm97nRWlw4/R1Rn38ep8n0J")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)? CubicBezierSelfIntersection_(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
        {
            var (xCurveA, xCurveB, xCurveC, xCurveD) = CubicBezierCoefficientsTests.CubicBezierCoefficients(x0, x1, x2, x3);
            (var a, var b) = (xCurveD == 0d) ? (xCurveC, xCurveB) : (xCurveC / xCurveD, xCurveB / xCurveD);
            var (yCurveA, yCurveB, yCurveC, yCurveD) = CubicBezierCoefficientsTests.CubicBezierCoefficients(y0, y1, y2, y3);
            (var p, var q) = (yCurveD == 0d) ? (yCurveC, yCurveB) : (yCurveC / yCurveD, yCurveB / yCurveD);

            if (a == p || q == b)
            {
                return null;
            }

            var k = (q - b) / (a - p);

            var poly = new double[]
            {
                -k * k * k - a * k * k - b * k,
                3 * k * k + 2 * k * a + 2 * b,
                -3 * k,
                2
            };

            var roots = CubicRootsTests.CubicRoots(poly[3], poly[2], poly[1], poly[0])
                .OrderByDescending(c => c).ToArray();
            if (roots.Length != 3)
            {
                return null;
            }

            if (roots[0] >= 0d && roots[0] <= 1d && roots[2] >= 0d && roots[2] <= 1d)
            {
                return InterpolateCubic2DTests.CubicInterpolate2D(x0, y0, x1, y1, x2, y2, x3, y3, roots[0]);
            }

            return null;
        }
    }
}
