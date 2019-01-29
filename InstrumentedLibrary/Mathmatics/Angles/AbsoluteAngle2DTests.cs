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
    /// The absolute angle tests class.
    /// </summary>
    [DisplayName("2D Absolute Angle Tests")]
    [Description("Find the absolute angle of two points.")]
    [SourceCodeLocationProvider]
    public static class AbsoluteAngle2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the absolute angle of Two 2D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(AbsoluteAngle2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d }, new TestCaseResults(description: " 0d, 0d, 1d, 1d.", trials: trials, expectedReturnValue:2.3561944901923448d, epsilon: double.Epsilon * 2d) },
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
        public static double AbsoluteAngle(double aX, double aY, double bX, double bY)
            => AbsoluteAngle1(aX, aY, bX, bY);

        /// <summary>
        /// Find the absolute positive value of a radian angle from two points.
        /// </summary>
        /// <param name="aX">Horizontal Component of Point Starting Point</param>
        /// <param name="aY">Vertical Component of Point Starting Point</param>
        /// <param name="bX">Horizontal Component of Ending Point</param>
        /// <param name="bY">Vertical Component of Ending Point</param>
        /// <returns>The absolute angle of a line in radians.</returns>
        [DisplayName("Absolute Angle Idea 1")]
        [Description("This one uses a while loop.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AbsoluteAngle1(double aX, double aY, double bX, double bY)
        {
            // Find the angle of point a and point b.
            var test = -Angle2DTests.Angle2D(aX, aY, bX, bY) % PI;

            // This should only loop once using the modulus of pi.
            while (test < 0d)
            {
                test += PI;
            }

            return test;
        }

        /// <summary>
        /// Find the absolute positive value of a radian angle from two points.
        /// </summary>
        /// <param name="aX">Horizontal Component of Point Starting Point</param>
        /// <param name="aY">Vertical Component of Point Starting Point</param>
        /// <param name="bX">Horizontal Component of Ending Point</param>
        /// <param name="bY">Vertical Component of Ending Point</param>
        /// <returns>The absolute angle of a line in radians.</returns>
        [DisplayName("Absolute Angle Idea 2")]
        [Description("Mostly inlined absolute angle method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AbsoluteAngle2(double aX, double aY, double bX, double bY)
        {
            // Find the angle of point a and point b.
            var test = -Angle2DTests.Angle2D(aX, aY, bX, bY) % PI;
            return test < 0d ? test += PI : test;
        }
    }
}
