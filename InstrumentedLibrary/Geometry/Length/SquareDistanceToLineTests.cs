using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The square distance to line tests class.
    /// </summary>
    [DisplayName("Square Distance to line segment from point")]
    [Description("Calculates the square distance from a point to the nearest point on a line segment.")]
    [SourceCodeLocationProvider]
    public static class SquareDistanceToLineTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SquareDistanceToLineTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 2d, 2d, 1.5d, 1.5d }, new TestCaseResults(description: "1, 2, 3, 4, 5", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        public static double SquareDistanceToLine(double x1, double y1, double x2, double y2, double x3, double y3)
            => SquareDistanceToLine0(x1, y1, x2, y2, x3, y3);

        /// <summary>
        /// Find the square of the distance of a point from a line.
        /// </summary>
        /// <param name="x1">The x component of the Point.</param>
        /// <param name="y1">The y component of the Point.</param>
        /// <param name="x2">The x component of the first point on the line.</param>
        /// <param name="y2">The y component of the first point on the line.</param>
        /// <param name="x3">The x component of the second point on the line.</param>
        /// <param name="y3">The y component of the second point on the line.</param>
        /// <returns></returns>
        [DisplayName("Square Distance to line segment from point")]
        [Description("Calculates the square distance from a point to the nearest point on a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SquareDistanceToLine0(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            var A = y2 - y3;
            var B = x3 - x2;
            var C = A * x1 + B * y1 - (A * x2 + B * y2);
            return C * C / (A * A + B * B);
        }
    }
}
