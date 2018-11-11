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
    [Signature("public static Inclusion Within(double angle, double startAngle, double sweepAngle)")]
    [SourceCodeLocationProvider]
    public static class AngleWithinAngleTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate whether a point is within a circle.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(Point2DInCircle2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 90d.ToRadians(), 0d.ToRadians(), 180d.ToRadians() }, new TestCaseResults(description:"Angle lies inside of sweep angle.", trials:trials, expectedReturnValue:true) }
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
        public static bool Within(double angle, double startAngle, double sweepAngle)
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
    }
}
