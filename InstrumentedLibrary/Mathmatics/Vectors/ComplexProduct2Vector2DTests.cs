using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The complex product2vector2d tests class.
    /// </summary>
    [DisplayName("Complex Product 2 Vector2D Tests")]
    [Description("Returns the Complex product of two 2D vectors.")]
    [Signature("public static double ComplexProduct2D(double ia, double ja, double ib, double jb)")]
    [SourceCodeLocationProvider]
    public static class ComplexProduct2Vector2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the complex product of Two 2D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ComplexProduct2Vector2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d }, new TestCaseResults(description:"0, 0, 1, 0, 1, 1.", trials:trials, expectedReturnValue:-1d, epsilon:double.Epsilon) },
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
        /// The complex product.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/1476497/multiply-two-point-objects
        /// </acknowledgment>
        [DisplayName("Complex Product of two 2D Vectors 1")]
        [Description("Complex Product of two 2D Vectors")]
        [Acknowledgment("http://stackoverflow.com/questions/1476497/multiply-two-point-objects")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) ComplexProduct(
            double x0, double y0,
            double x1, double y1)
        {
            return ((x0 * x1) - (y0 * y1), (x0 * y1) + (y0 * x1));
        }
    }
}
