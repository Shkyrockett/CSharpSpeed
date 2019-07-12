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
    [DisplayName("Find a general vertex Parabola from three points")]
    [Description("Find a general vertex Parabola from three points.")]
    [SourceCodeLocationProvider]
    public static class FindVertexParabolaFromThreePointsTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(FindVertexParabolaFromThreePointsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 4.34d, 8d, 6d, 0d, 4.8530d, 10d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (-7.600621260694489d, 4.852968211206897d, 10.000000007680654d), epsilon: double.Epsilon) },
                { new object[] { 4.34d, 8d, 6d, 0d, 2.9970d, 10d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (-1.1089156950338084d, 2.9970317887931044d, 10.000000001120602d), epsilon: double.Epsilon) },
                { new object[] { 2d, 10d, 8d, 10d, 5d, 8d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.2222222222222222d, 5.000000000000001d, 7.999999999999999d), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double a, double h, double k) FindVertexParabolaFromThreePoints(double x1, double y1, double x2, double y2, double x3, double y3)
            => FindVertexParabolaFromThreePoints1(x1, y1, x2, y2, x3, y3);

        /// <summary>
        /// Find a parabola in vertex form from three points on the parabola.
        /// </summary>
        /// <param name="x1">The x component of the first point.</param>
        /// <param name="y1">The y component of the first point.</param>
        /// <param name="x2">The x component of the second point.</param>
        /// <param name="y2">The y component of the second point.</param>
        /// <param name="x3">The x component of the third point.</param>
        /// <param name="y3">The y component of the third point.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/717833
        /// </acknowledgment>
        [DisplayName("Find a general vertex Parabola from three points")]
        [Description("Find a general vertex Parabola from three points.")]
        [Acknowledgment("https://stackoverflow.com/a/717833")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double h, double k) FindVertexParabolaFromThreePoints1(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            var denom = (x1 - x2) * (x1 - x3) * (x2 - x3);
            // ToDo: Work out what to do when denom is 0
            var a = ((x3 * (y2 - y1)) + (x2 * (y1 - y3)) + (x1 * (y3 - y2))) / denom;
            var b = ((x3 * x3 * (y1 - y2)) + (x2 * x2 * (y3 - y1)) + (x1 * x1 * (y2 - y3))) / denom;
            var c = ((x2 * x3 * (x2 - x3) * y1) + (x3 * x1 * (x3 - x1) * y2) + (x1 * x2 * (x1 - x2) * y3)) / denom;

            return (a, -b / (2d * a), c - (b * b / (4d * a)));
        }
    }
}
