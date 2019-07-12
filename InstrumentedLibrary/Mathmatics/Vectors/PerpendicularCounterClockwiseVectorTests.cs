using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The perpendicular counter clockwise vector tests class.
    /// </summary>
    [DisplayName("Counter Clockwise Perpendicular Vector")]
    [Description("Find the counter clockwise perpendicular of a Vector.")]
    [SourceCodeLocationProvider]
    public static class PerpendicularCounterClockwiseVectorTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(PerpendicularCounterClockwiseVectorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.5d, -0d) , epsilon: double.Epsilon) },
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
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double I, double J) PerpendicularCounterClockwiseVector(double i, double j)
            => PerpendicularCounterClockwiseVector0(i, j);

        /// <summary>
        /// Find the Counter Clockwise Perpendicular of a Vector.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        /// <remarks>
        /// To get the perpendicular vector in two dimensions use I = -J, J = I
        /// </remarks>
        [DisplayName("Counter Clockwise Perpendicular Vector")]
        [Description("Find the counter clockwise perpendicular of a Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J) PerpendicularCounterClockwiseVector0(double i, double j)
        {
            return (j, -i);
        }
    }
}
