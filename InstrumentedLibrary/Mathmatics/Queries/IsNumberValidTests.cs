using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The is number valid tests class.
    /// </summary>
    [DisplayName("Is Number Valid")]
    [Description("Determines whether a number is a valid number. Not NAN or infinite.")]
    [SourceCodeLocationProvider]
    public static class IsNumberValidTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 3D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(IsNumberValidTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { double.NaN }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
                { new object[] { double.NegativeInfinity }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { double.MaxValue }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
                { new object[] { double.PositiveInfinity }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { double.MinValue }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsNumberValid(double value)
            => IsNumber(value);

        /// <summary>
        /// Return true if the number is not infinity or NaN.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [DisplayName("Is Number Valid")]
        [Description("Determines whether a number is a valid number. Not NAN or infinite.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumber(double number)
        {
            return !(double.IsNaN(number) || double.IsInfinity(number));
        }

        /// <summary>
        /// Make sure that a double number is not a NaN or infinity.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        /// true if the specified value is valid; otherwise, returns false.
        /// </returns>
        [DisplayName("Is Number Valid")]
        [Description("Determines whether a number is a valid number. Not NAN or infinite.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        /// <summary>
        /// This function is used to ensure that a floating point number is
        /// not a NaN or infinity.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// 	<c>true</c> if the specified x is valid; otherwise, <c>false</c>.
        /// </returns>
        [DisplayName("Is Number Valid")]
        [Description("Determines whether a number is a valid number. Not NAN or infinite.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid1(double x)
        {
            if (double.IsNaN(x))
            {
                // NaN.
                return false;
            }

            return !double.IsInfinity(x);
        }
    }
}
