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
    /// The circle to ellipse tests class.
    /// </summary>
    [DisplayName("Circle to Ellipse Tests")]
    [Description("Convert a Circle to an Ellipse.")]
    [Signature("public static double CircleToEllipse(double v0, double v1, double v2, double v3, double t)")]
    [SourceCodeLocationProvider]
    public static class CircleToEllipseTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CircleToEllipseTests))]
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
        /// Converts a Circle to an ellipse.
        /// </summary>
        /// <param name="x">The x-component of the center point.</param>
        /// <param name="y">The y-component of the center point.</param>
        /// <param name="r">The radius of the circle.</param>
        /// <returns>Returns an ellipse from a circle.</returns>
        [DisplayName("Circle to Ellipse")]
        [Description("Convert a Circle to an Ellipse.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double A, double B, double angle) CircleToEllipse(
            double x, double y,
            double r)
        {
            return (x, y, r, r, 0);
        }
    }
}
