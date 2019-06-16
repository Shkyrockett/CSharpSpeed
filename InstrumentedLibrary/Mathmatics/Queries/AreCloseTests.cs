using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The are close tests class.
    /// </summary>
    [DisplayName("Are Values Near Each Other Query")]
    [Description("Determines whether a value is near another.")]
    [SourceCodeLocationProvider]
    public static class AreCloseTests
    {
        /// <summary>
        /// Set of tests to run testing methods that determine whether values are close.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(AreCloseTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, NearZeroEpsilon, double.Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool AreClose(double value1, double value2, double epsilon = DoubleEpsilon)
            => AreClose0(value1, value2, epsilon);

        /// <summary>
        /// AreClose - Returns whether or not two doubles are "close".  That is, whether or
        /// not they are within epsilon of each other.  Note that this epsilon is proportional
        /// to the numbers themselves to that AreClose survives scalar multiplication.
        /// There are plenty of ways for this to return false even for numbers which
        /// are theoretically identical, so no code calling this should fail to work if this
        /// returns false.  This is important enough to repeat:
        /// NB: NO CODE CALLING THIS FUNCTION SHOULD DEPEND ON ACCURATE RESULTS - this should be
        /// used for optimizations *only*.
        /// </summary>
        /// <returns>
        /// bool - the result of the AreClose comparison.
        /// </returns>
        /// <param name="value1"> The first double to compare. </param>
        /// <param name="value2"> The second double to compare. </param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        [DisplayName("Are Values Near Each Other")]
        [Description("Determines whether a value is near another.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreClose0(double value1, double value2, double epsilon = DoubleEpsilon)
        {
            // in case they are Infinities (then epsilon check does not work)
            if (Abs(value1 - value2) < DoubleEpsilon)
            {
                return true;
            }

            // This computes (|value1-value2| / (|value1| + |value2| + 10.0)) < DBL_EPSILON
            var eps = (Abs(value1) + Abs(value2) + 10d) * epsilon;
            var delta = value1 - value2;
            return (-eps < delta) && (eps > delta);
        }
    }
}
