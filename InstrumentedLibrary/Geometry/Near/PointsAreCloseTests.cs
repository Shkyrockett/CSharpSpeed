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
    /// The points are close tests class.
    /// </summary>
    [DisplayName("Point Near Point Tests")]
    [Description("Determines whether a point near another point.")]
    [SourceCodeLocationProvider]
    public static class PointsAreCloseTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PointsAreCloseTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 2d, 2d, DoubleEpsilon }, new TestCaseResults(description: "1, 2, 3, 4, 5", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PointsAreClose(double x1, double y1, double x2, double y2, double epsilon = DoubleEpsilon)
            => AreClose0(x1, y1, x2, y2, epsilon);

        /// <summary>
        /// Return True if (x1, y1) is within close_distance vertically and horizontally of (x2, y2).
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        [DisplayName("Point Near Point")]
        [Description("Determines whether a point is on a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreClose0(double x1, double y1, double x2, double y2, double epsilon = DoubleEpsilon)
        {
            return (Abs(x2 - x1) <= epsilon) && (Abs(y2 - y1) <= epsilon);
        }

        /// <summary>
        /// Compares two points for fuzzy equality.  This function
        /// helps compensate for the fact that double values can
        /// acquire error when operated upon
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>Whether or not the two points are equal</returns>
        [DisplayName("Point Near Point")]
        [Description("Determines whether a point is on a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreClose1(double x1, double y1, double x2, double y2, double epsilon = DoubleEpsilon)
        {
            return AreCloseTests.AreClose(x1, x2, epsilon)
                && AreCloseTests.AreClose(y1, y2, epsilon);
        }
    }
}
