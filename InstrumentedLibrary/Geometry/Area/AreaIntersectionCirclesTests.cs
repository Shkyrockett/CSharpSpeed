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
    [Signature("public static double Normalize(Circle2D a, Circle2D b)")]
    [SourceCodeLocationProvider]
    public static class AreaIntersectionCirclesTests
    {
        /// <summary>
        /// The area intersection circles test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(AreaIntersectionCirclesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Circle2D(0d, 0d, 1d), new Circle2D(1d, 0d, 1d) }, new TestCaseResults(description:"0, 1, 0.", trials:trials, expectedReturnValue:1.2283696986087567d, epsilon:double.Epsilon) }
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
        /// <param name="A">The A.</param>
        /// <param name="B">The B.</param>
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
        public static double Area(Circle2D A, Circle2D B)
        {
            var d = Sqrt(Pow(B.X - A.X, 2) + Pow(B.Y - A.Y, 2));
            if (d < A.Radius + B.Radius)
            {
                var a = A.Radius * A.Radius;
                var b = B.Radius * B.Radius;
                var x = (a - b + (d * d)) / (2 * d);
                var z = x * x;
                var y = Sqrt(a - z);
                if (d < Abs(B.Radius - A.Radius))
                {
                    return PI * Min(a, b);
                }

                return (a * Asin(y / A.Radius)) + (b * Asin(y / B.Radius)) - (y * (x + Sqrt(z + b - a)));
            }

            return 0;
        }
    }
}
