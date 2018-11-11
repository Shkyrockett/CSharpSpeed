using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The dot product3vector2d tests class.
    /// </summary>
    [DisplayName("Dot Product Tests")]
    [Description("Returns the Angle of a line that runs between two points.")]
    [Signature("public static double DotProduct2D(double x1, double y1, double x2, double y2, double x3, double y3)")]
    [SourceCodeLocationProvider]
    public static class DotProduct3Vector2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the dot product of three 2D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(DotProduct3Vector2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 0d, 1d, 1d }, new TestCaseResults(description:" 0, 0, 1, 0, 1, 1.", trials:trials, expectedReturnValue:0d, epsilon:double.Epsilon) }
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
        /// Return the dot product AB · BC.
        /// Note that AB · BC = |AB| * |BC| * Cos(theta).
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/
        /// </acknowledgment>
        [DisplayName("Dot Product of three 2D Vectors 1")]
        [Description("Dot Product of three 2D Vectors")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProductVector2D_0(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            return ((x1 - x2) * (x3 - x2)) + ((y1 - y2) * (y3 - y2));
        }

        /// <summary>
        /// Return the dot product AB · BC.
        /// Note that AB · BC = |AB| * |BC| * Cos(theta).
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/
        /// </acknowledgment>
        [DisplayName("Dot Product of three 2D Vectors 1")]
        [Description("Dot Product of three 2D Vectors")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProductVector2D_2(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            // Get the vectors' coordinates.
            var BAx = x1 - x2;
            var BAy = y1 - y2;
            var BCx = x3 - x2;
            var BCy = y3 - y2;

            // Calculate the dot product.
            return (BAx * BCx) + (BAy * BCy);
        }
    }
}
