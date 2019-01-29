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
    /// The line segment to Cubic Bézier tests class.
    /// </summary>
    [DisplayName("Line Segment to Cubic Bézier Tests")]
    [Description("Convert a Line Segment to a Cubic Bézier.")]
    [SourceCodeLocationProvider]
    public static class LineSegmentToCubicBezierTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(LineSegmentToCubicBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 1d, 0.666666666666667d, 1.66666666666667d, 1.33333333333333d, 2.33333333333333d, 2d, 3d), epsilon: double.Epsilon) },
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
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) LineSegmentToCubicBezier(double x0, double y0, double x1, double y1)
            => LineSegmentToCubicBezier0(x0, y0, x1, y1);

        /// <summary>
        /// Converts a Line segment to a Cubic Bézier curve.
        /// </summary>
        /// <param name="x0">The x-component of the starting point.</param>
        /// <param name="y0">The y-component of the starting point.</param>
        /// <param name="x1">The x-component of the end point.</param>
        /// <param name="y1">The y-component of the end point.</param>
        /// <returns>Returns a Cubic Bézier curve from the properties of a line segment.</returns>
        [DisplayName("Line Segment to Cubic Bézier Tests")]
        [Description("Raise a Line segment to a Cubic Bézier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) LineSegmentToCubicBezier0(
            double x0, double y0,
            double x1, double y1)
        {
            (double X, double Y) p2 = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, OneThird);
            (double X, double Y) p3 = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, TwoThirds);
            return (x0, y0, p2.X, p2.Y, p3.X, p3.Y, x1, y1);
        }
    }
}
