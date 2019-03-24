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
    /// 
    /// </summary>
    [DisplayName("SubtendedToParametric")]
    [Description("Subtended To Parametric.")]
    [SourceCodeLocationProvider]
    public static class SubtendedToParametricTests
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
                { new object[] { 30d.ToRadians(), 3d, 2d }, new TestCaseResults(description: "Find the angle on a 3:2 ellipse a 30 polar degrees.", trials: trials, expectedReturnValue:0.71372437894476559d, epsilon: double.Epsilon) },
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
        /// Return a "correction" angle that converts a subtended angle to a parametric angle for an
        /// ellipse with radii a and b.
        /// </summary>
        /// <param name="subtended"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double SubtendedToParametric(double subtended, double a, double b)
            => SubtendedToParametric1(subtended, a, b);

        /// <summary>
        /// Return a "correction" angle that converts a subtended angle to a parametric angle for an
        /// ellipse with radii a and b.
        /// </summary>
        /// <param name="subtended"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Code ported from: https://www.khanacademy.org/computer-programming/e/6221186997551104
        /// Math from: http://mathworld.wolfram.com/Ellipse-LineIntersection.html
        /// </acknowledgment>
        [DisplayName("SubtendedToParametric")]
        [Description("Subtended To Parametric.")]
        [Acknowledgment("https://www.khanacademy.org/computer-programming/e/6221186997551104", "http://mathworld.wolfram.com/Ellipse-LineIntersection.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SubtendedToParametric1(double subtended, double a, double b)
        {
            if (a == b)
            {
                return 0;  /* circle needs no correction */
            }

            var rx = Cos(subtended);  /* ray from the origin */
            var ry = Sin(subtended);
            var e = a * b / Sqrt((a * a * ry * ry) + (b * b * rx * rx));
            var ex = e * rx;  /* where ray intersects ellipse */
            var ey = e * ry;
            var parametric = Atan2(a * ey, b * ex);
            subtended = Atan2(ry, rx);  /* Normalized! */
            return parametric - subtended;
        }
    }
}
