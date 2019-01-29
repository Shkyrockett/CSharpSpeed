using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The less than or equal tests class.
    /// </summary>
    [DisplayName("Less Than Or Equal Point")]
    [Description("Less Than Or Equal Points.")]
    [SourceCodeLocationProvider]
    public static class LessThanOrEqualTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(LessThanOrEqualTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool LessThanOrEqual(double aX, double aY, double bX, double bY)
            => LessThanOrEqual0(aX, aY, bX, bY);

        /// <summary>
        /// The less than or equal.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Greater Than Or Equal Point")]
        [Description("Greater Than Or Equal Points.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessThanOrEqual0(double aX, double aY, double bX, double bY)
        {
            return aX <= bX && aY <= bY;
        }
    }
}
