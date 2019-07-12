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
    /// The point near ellipse tests class.
    /// </summary>
    [DisplayName("Point Near Orthogonal Ellipse Tests")]
    [Description("Determines whether a point is near an Orthogonal Ellipse.")]
    [SourceCodeLocationProvider]
    public static class PointNearUnrotatedEllipseTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(PointNearUnrotatedEllipseTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 0.5d, 0.5d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <param name="closeDistance"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PointNearEllipse(double x1, double y1, double x2, double y2, double px, double py, double closeDistance)
            => PointNearEllipse0(x1, y1, x2, y2, px, py, closeDistance);

        /// <summary>
        /// Return True if the point is inside the ellipse
        /// (expanded by distance close_distance vertically
        /// and horizontally).
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <param name="closeDistance"></param>
        /// <returns></returns>
        [DisplayName("Point Near Unrotated Ellipse Tests")]
        [Description("Determines whether a point is near an Unrotated Ellipse.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointNearEllipse0(double x1, double y1, double x2, double y2, double px, double py, double closeDistance)
        {
            var a = (Abs(x2 - x1) / 2d) + closeDistance;
            var b = (Abs(y2 - y1) / 2d) + closeDistance;
            var x = px - (x2 + x1) / 2d;
            var y = py - (y2 + y1) / 2d;
            return (x * x / (a * a)) + (y * y / (b * b)) <= 1d;
        }
    }
}
