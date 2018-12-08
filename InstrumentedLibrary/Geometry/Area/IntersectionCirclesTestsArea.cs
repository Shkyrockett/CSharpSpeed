using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The area intersection circles tests class.
    /// </summary>
    [DisplayName("Area Intersection Two Circles")]
    [Description("Find the area of the section of the intersection of two circles.")]
    [Signature("public static double Area(double x1, double y1, double r1, double x2, double y2, double r2)")]
    [SourceCodeLocationProvider]
    public static class IntersectionCirclesTestsArea
    {
        /// <summary>
        /// The area.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="r1">The r1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="r2">The r2.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Area(double x1, double y1, double r1, double x2, double y2, double r2)
            => Area1(x1, y1, r1, x2, y2, r2);

        /// <summary>
        /// The area intersection circles test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(IntersectionCirclesTestsArea))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d, 0d, 1d }, new TestCaseResults(description:"Two unit circles, one at origin, the other shifted to the right one unit.", trials:trials, expectedReturnValue:1.2283696986087567d, epsilon:double.Epsilon) },
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
        /// The area.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="r1">The r1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="r2">The r2.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.xarg.org/2016/07/calculate-the-intersection-area-of-two-circles/
        /// </acknowledgment>
        [DisplayName("Area Intersection Two Circles")]
        [Description("Find the area of the section of the intersection of two circles.")]
        [Acknowledgment("http://www.xarg.org/2016/07/calculate-the-intersection-area-of-two-circles/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Area0(double x1, double y1, double r1, double x2, double y2, double r2)
        {
            var d = Sqrt(Pow(x2 - x1, 2) + Pow(y2 - y1, 2));
            if (d < r1 + r2)
            {
                var a = r1 * r1;
                var b = r2 * r2;
                var x = (a - b + (d * d)) / (2d * d);
                var z = x * x;
                var y = Sqrt(a - z);
                if (d < Abs(r2 - r1))
                {
                    return PI * Min(a, b);
                }

                return (a * Asin(y / r1)) + (b * Asin(y / r2)) - (y * (x + Sqrt(z + b - a)));
            }

            return 0d;
        }

        /// <summary>
        /// The area.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="r1">The r1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="r2">The r2.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.xarg.org/2016/07/calculate-the-intersection-area-of-two-circles/
        /// </acknowledgment>
        [DisplayName("Area Intersection Two Circles")]
        [Description("Find the area of the section of the intersection of two circles.")]
        [Acknowledgment("http://www.xarg.org/2016/07/calculate-the-intersection-area-of-two-circles/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Area1(double x1, double y1, double r1, double x2, double y2, double r2)
        {
            var d = Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            if (d < r1 + r2)
            {
                var a = r1 * r1;
                var b = r2 * r2;
                var x = (a - b + (d * d)) / (2d * d);
                var z = x * x;
                var y = Sqrt(a - z);
                if (d < Abs(r2 - r1))
                {
                    return PI * (a < b ? a : b);
                }

                return (a * Asin(y / r1)) + (b * Asin(y / r2)) - (y * (x + Sqrt(z + b - a)));
            }

            return 0d;
        }
    }
}
