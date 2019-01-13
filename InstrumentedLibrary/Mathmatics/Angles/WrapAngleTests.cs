using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The wrap angle tests class.
    /// </summary>
    [DisplayName("Wrap Angle Tests")]
    [Description("Reduces a given angle to a value between 2π and -2π.")]
    [Signature("public static double WrapAngle(double angle)")]
    [SourceCodeLocationProvider]
    public static class WrapAngleTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the wrapped angle of an angle.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(WrapAngleTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 100000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 480d.ToRadians() }, new TestCaseResults(description:"An angle that wraps more than 360 degrees.", trials:trials, expectedReturnValue:-4.1887902047863914d, epsilon:DoubleEpsilon) },
                { new object[] { 45d.ToRadians() }, new TestCaseResults(description:"An angle that wraps less than 360 degrees.", trials:trials, expectedReturnValue:-5.497787143782138d, epsilon:DoubleEpsilon) },
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
        /// <param name="angle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double WrapAngle(this double angle)
            => WrapAngle00(angle);

        /// <summary>
        /// Reduces a given angle to a value between 2π and -2π.
        /// </summary>
        /// <param name="angle">The angle to reduce, in radians.</param>
        /// <returns>The new angle, in radians.</returns>
        [DisplayName("Wrap Angle 1")]
        [Description("Reduces a given angle to a value between 2π and -2π.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle00(double angle)
        {
            if (double.IsNaN(angle))
            {
                return angle;
            }

            // The IEEERemainder method works better than the % modulus operator in this case, even if it is slower.
            //double value = IEEERemainder(angle, Tau);
            // The active ingredient of the IEEERemainder method is extracted here for performance reasons.
            var value = angle - (Tau * Round(angle * InverseTau));
            return (value <= -PI) ? value + Tau : value - Tau;
        }

        /// <summary>
        /// Reduces a given angle to a value between π and -π.
        /// </summary>
        /// <param name="angle">The angle to reduce, in radians.</param>
        /// <returns>The new angle, in radians.</returns>
        [DisplayName("Wrap Angle 2")]
        [Description("Reduces a given angle to a value between 2π and -2π.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle0(double angle)
        {
            // The IEEERemainder method works better than the % modulus operator in this case, even if it is slower.
            var value = IEEERemainder(angle, Tau);
            return (value <= -PI) ? value + Tau : value - Tau;
        }

        /// <summary>
        /// Reduces a given angle to a value between 2π and -2π.
        /// </summary>
        /// <param name="angle">The angle to reduce, in radians.</param>
        /// <returns>The new angle, in radians.</returns>
        [DisplayName("Wrap Angle 3")]
        [Description("Reduces a given angle to a value between 2π and -2π.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle1(double angle)
        {
            // The active ingredient of the IEEERemainder method.
            var value = angle - (Tau * Round(angle * InverseTau));
            return (value <= -PI) ? value + Tau : value - Tau;
        }

        /// <summary>
        /// Reduces a given angle to a value between π and -π.
        /// </summary>
        /// <param name="angle">The angle to reduce, in radians.</param>
        /// <returns>The new angle, in radians.</returns>
        [DisplayName("Wrap Angle 4")]
        [Description("Reduces a given angle to a value between 2π and -2π.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle2(double angle)
        {
            var test = IEEERemainder(angle, Tau);
            if (test <= -PI)
            {
                test += Tau;
            }
            else if (test > PI)
            {
                test -= Tau;
            }

            return test;
        }

        /// <summary>
        /// Reduces a given angle to a value between π and -π.
        /// </summary>
        /// <param name="angle">The angle to reduce, in radians.</param>
        /// <returns>The new angle, in radians.</returns>
        [DisplayName("Wrap Angle 5")]
        [Description("Reduces a given angle to a value between 2π and -2π.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle3(double angle)
        {
            var test = angle % Tau;
            return (test <= -PI) ? test + Tau : test - Tau;
        }
    }
}
