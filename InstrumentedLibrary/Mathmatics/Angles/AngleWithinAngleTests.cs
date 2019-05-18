using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The angle within angle tests class.
    /// </summary>
    [DisplayName("Angle Between Angles")]
    [Description("Determine whether an angle lies within the sweep angle starting from an angle.")]
    [SourceCodeLocationProvider]
    public static class AngleWithinAngleTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate whether a point is within a circle.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(AngleWithinAngleTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 90d.ToRadians(), 0d.ToRadians(), 180d.ToRadians() }, new TestCaseResults(description: "Angle lies inside of sweep angle.", trials: trials, expectedReturnValue: true) },
                { new object[] { 320d.ToRadians(), 0d.ToRadians(), 180d.ToRadians() }, new TestCaseResults(description: "Angle lies outside of sweep angle before.", trials: trials, expectedReturnValue: false) },
                { new object[] { -90d.ToRadians(), 0d.ToRadians(), 180d.ToRadians() }, new TestCaseResults(description: "Angle lies outside of sweep angle after.", trials: trials, expectedReturnValue: false) },
                { new object[] { 0d.ToRadians(), 0d.ToRadians(), 180d.ToRadians() }, new TestCaseResults(description: "Angle lies on the sweep angle start.", trials: trials, expectedReturnValue: true) },
                { new object[] { 180d.ToRadians(), 0d.ToRadians(), 180d.ToRadians() }, new TestCaseResults(description: "Angle lies on the sweep angle end.", trials: trials, expectedReturnValue: true) },
                { new object[] { 180d.ToRadians(), 0d.ToRadians(), 360d.ToRadians() }, new TestCaseResults(description: "Angle lies within the sweep angle of a full 360.", trials: trials, expectedReturnValue: true) },
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
        /// <param name="angle"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool Within(double angle, double startAngle, double sweepAngle)
            => Within0(angle, startAngle, sweepAngle);

        /// <summary>
        /// Check whether an angle lies within the sweep angle.
        /// </summary>
        /// <param name="angle">Angle of rotation to check.</param>
        /// <param name="startAngle">The starting angle.</param>
        /// <param name="sweepAngle">The amount of angle to offset from the start angle.</param>
        /// <returns>A <see cref="bool"/> value indicating whether an angle is between two others.</returns>
        /// <acknowledgment>
        /// http://www.xarg.org/2010/06/is-an-angle-between-two-other-angles/
        /// </acknowledgment>
        [DisplayName("Within 1")]
        [Description("Check whether an angle lies within the sweep angle.")]
        [Acknowledgment("http://www.xarg.org/2010/06/is-an-angle-between-two-other-angles/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Within0(double angle, double startAngle, double sweepAngle)
        {
            // If the sweep angle is greater than 360 degrees it is overlapping, so any angle would intersect the sweep angle.
            if (sweepAngle > Tau)
            {
                return true;
            }

            // Wrap the angles to values between 2PI and -2PI.
            var s = WrapAngleTests.WrapAngle(startAngle);
            var e = WrapAngleTests.WrapAngle(s + sweepAngle);
            var a = WrapAngleTests.WrapAngle(angle);

            // return whether the angle is contained within the sweep angle.
            // The calculations are opposite when the sweep angle is negative.
            return (sweepAngle >= 0d) ?
                (s < e) ? a >= s && a <= e : a >= s || a <= e :
                (s > e) ? a <= s && a >= e : a <= s || a >= e;
        }

        /// <summary>
        /// Return true iff angle c is between angles
        /// a and b, inclusive. b always follows a in
        /// the positive rotational direction. Operations
        /// against an entire circle cannot be defined.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/computer-programming/c/5567955982876672
        /// </acknowledgment>
        [DisplayName("IsAngleBetween")]
        [Description("Check whether an angle lies within the sweep angle.")]
        [Acknowledgment("https://www.khanacademy.org/computer-programming/c/5567955982876672")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAngleBetween(double c, double a, double b)
        {
            /* Make sure that a is in the range [0 .. tau). */
            for (a %= Tau; a < 0; a += Tau) { }
            /* Make sure that both b and c are not less than a. */
            for (b %= Tau; b < a; b += Tau) { }
            for (c %= Tau; c < a; c += Tau) { }
            return c <= b;
        }
    }
}
