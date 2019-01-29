using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cross product2vector2d tests class.
    /// </summary>
    [DisplayName("Cross Product 2 Vector2D Tests")]
    [Description("Returns the cross product of two 2D vectors.")]
    [SourceCodeLocationProvider]
    public static class CrossProduct2Vector2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the cross product of two 2D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CrossProduct2Vector2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CrossProduct2Vector2D(double x1, double y1, double x2, double y2)
            => CrossProduct2Vector2D_0(x1, y1, x2, y2);

        /// <summary>
        /// Cross Product of two vectors.
        /// </summary>
        /// <param name="x1">First Point X component.</param>
        /// <param name="y1">First Point Y component.</param>
        /// <param name="x2">Second Point X component.</param>
        /// <param name="y2">Second Point Y component.</param>
        /// <returns>the cross product AB · BC.</returns>
        /// <acknowledgment>
        /// Note that AB · BC = |AB| * |BC| * Cos(theta). http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
        /// </acknowledgment>
        [DisplayName("Cross Product of two 2D Vectors 1")]
        [Description("Cross Product of two 2D Vectors")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct2Vector2D_0(
            double x1, double y1,
            double x2, double y2)
        {
            return (x1 * y2) - (y1 * x2);
        }
    }
}
