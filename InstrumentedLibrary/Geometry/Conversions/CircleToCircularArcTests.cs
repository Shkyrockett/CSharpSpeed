using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static InstrumentedLibrary.Maths;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The circle to circular arc tests class.
    /// </summary>
    [DisplayName("Circle to Circular Arc Tests")]
    [Description("Convert a Circle to a Circular Arc.")]
    [SourceCodeLocationProvider]
    public static class CircleToCircularArcTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CircleToCircularArcTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue: (0d, 1d, 1.33333333333333d, 2.33333333333333d, 4.66666666666667d, 5.66666666666667d, 6d, 7d), epsilon:DoubleEpsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double R, double startEngle, double SweepAngle) CircleToCircularArc(double x, double y, double r)
            => CircleToCircularArc0(x, y, r);

        /// <summary>
        /// Converts a Circle to a Circular arc.
        /// </summary>
        /// <param name="x">The x-component of the center point.</param>
        /// <param name="y">The y-component of the center point.</param>
        /// <param name="r">The radius of circle.</param>
        /// <returns>Returns a circular arc from a circle.</returns>
        [DisplayName("Circle to Circular Arc")]
        [Description("Convert a Circle to a Circular Arc.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double R, double startEngle, double SweepAngle) CircleToCircularArc0(
            double x, double y,
            double r)
        {
            return (x, y, r, 0, Tau);
        }
    }
}
