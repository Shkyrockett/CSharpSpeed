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
    /// The ellipse area tests class.
    /// </summary>
    [DisplayName("Area of Ellipse")]
    [Description("Find the area of a Ellipse.")]
    [SourceCodeLocationProvider]
    public static class EllipseAreaTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(EllipseAreaTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d }, new TestCaseResults(description: "Unit Circle.", trials: trials, expectedReturnValue: PI, epsilon: double.Epsilon) },
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
        /// <param name="radiusA"></param>
        /// <param name="radiusB"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double EllipseArea(double radiusA, double radiusB)
            => StandardEllipseArea(radiusA, radiusB);

        /// <summary>
        /// Calculates the area of an ellipse.
        /// </summary>
        /// <param name="rX">The horizontal radius.</param>
        /// <param name="rY">The vertical radius.</param>
        /// <returns>Returns the area of the ellipse.</returns>
        [DisplayName("Area of Ellipse")]
        [Description("Find the area of a Ellipse.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double StandardEllipseArea(double rX, double rY)
        {
            return PI * rY * rX;
        }
    }
}
