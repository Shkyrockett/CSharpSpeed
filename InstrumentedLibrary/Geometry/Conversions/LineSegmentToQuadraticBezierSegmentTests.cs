using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static InstrumentedLibrary.Maths;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The line segment to Quadratic Bézier segment tests class.
    /// </summary>
    [DisplayName("Line Segment to Quadratic Bézier Tests")]
    [Description("Convert a Line Segment to a Quadratic Bézier.")]
    [Signature("public static double LineSegmentToQuadraticBezier(double v0, double v1, double v2, double v3, double t)")]
    [SourceCodeLocationProvider]
    public static class LineSegmentToQuadraticBezierSegmentTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(LineSegmentToQuadraticBezierSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue: (0d, 1d, 1.33333333333333d, 2.33333333333333d, 4.66666666666667d, 5.66666666666667d, 6d, 7d), epsilon:DoubleEpsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double aX, double aY, double bX, double bY, double cX, double cY) LineSegmentToQuadraticBezier(double x0, double y0, double x1, double y1)
            => LineSegmentToQuadraticBezier0(x0, y0, x1, y1);

        /// <summary>
        /// Converts a line segment to a Quadratic Bézier curve.
        /// </summary>
        /// <param name="x0">The x-component of the first point of a line segment.</param>
        /// <param name="y0">The y-component of the first point of a line segment.</param>
        /// <param name="x1">The x-component of the second point of a line segment.</param>
        /// <param name="y1">The y-component of the second point of a line segment.</param>
        /// <returns>Returns a Quadratic Bézier with the properties of a line segment.</returns>
        [DisplayName("Line Segment to Quadratic Bézier Tests")]
        [Description("Raise a Line segment to a Quadratic Bézier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY) LineSegmentToQuadraticBezier0(
            double x0, double y0,
            double x1, double y1)
        {
            (double X, double Y) p = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, OneHalf);
            return (x0, y0, p.X, p.Y, x1, y1);
        }
    }
}
