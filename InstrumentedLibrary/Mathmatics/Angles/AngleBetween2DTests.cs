using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The angle between tests class.
    /// </summary>
    [DisplayName("Angle Between 2D Vectors Tests")]
    [Description("Find the angle between two 2D vectors.")]
    [SourceCodeLocationProvider]
    public static class AngleBetween2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 2D vectors.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(AngleBetween2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d }, new TestCaseResults(description:" 0, 0, 1, 1.", trials:trials, expectedReturnValue:double.NaN, epsilon:DoubleEpsilon) },
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
        /// <param name="uX"></param>
        /// <param name="uY"></param>
        /// <param name="vX"></param>
        /// <param name="vY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double AngleBetween(double uX, double uY, double vX, double vY)
            => AngleBetween0(uX, uY, vX, vY);

        /// <summary>
        /// Finds the angle between two vectors.
        /// </summary>
        /// <param name="uX">The uX.</param>
        /// <param name="uY">The uY.</param>
        /// <param name="vX">The vX.</param>
        /// <param name="vY">The vY.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://james-ramsden.com/angle-between-two-vectors/
        /// </acknowledgment>
        [DisplayName("AngleBetween 1")]
        [Description("James Ramsden's method of finding the angle between two 2D vectors.")]
        [Acknowledgment("http://james-ramsden.com/angle-between-two-vectors/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AngleBetween0(
            double uX, double uY,
            double vX, double vY)
        {
            return Acos(((uX * vX) + (uY * vY)) / Sqrt(((uX * uX) + (uY * uY)) * ((vX * vX) + (vY * vY))));
        }
    }
}
