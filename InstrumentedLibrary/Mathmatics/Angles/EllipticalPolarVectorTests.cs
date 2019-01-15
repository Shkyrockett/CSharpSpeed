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
    /// The elliptical polar vector tests class.
    /// </summary>
    [DisplayName("Elliptical Polar Angle Vector")]
    [Description("Find the Cos and Sin of the Elliptical Polar Angle Vector.")]
    [SourceCodeLocationProvider]
    public static class EllipticalPolarVectorTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(EllipticalPolarVectorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { Cos(ToRadiansTests.ToRadians(45)), Sin(ToRadiansTests.ToRadians(45)), 2d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon:DoubleEpsilon) },
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
        /// <param name="cosA"></param>
        /// <param name="sinA"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double cosT, double sinT) EllipticalPolarVector(double cosA, double sinA, double rx, double ry)
            => EllipticalPolarVector0(cosA, sinA, rx, ry);

        /// <summary>
        /// Find the elliptical (cos(t), sin(t)) that matches the coordinates of a circular angle.
        /// </summary>
        /// <param name="cosA"></param>
        /// <param name="sinA"></param>
        /// <param name="rx">The first radius of the ellipse.</param>
        /// <param name="ry">The second radius of the ellipse.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Vectorized version of the answer by flup at: https://stackoverflow.com/a/17762156/7004229
        /// </acknowledgment>
        [DisplayName("Elliptical Polar Angle Vector")]
        [Description("Find the Cos and Sin of the Elliptical Polar Angle Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double cosT, double sinT) EllipticalPolarVector0(double cosA, double sinA, double rx, double ry)
        {
            // Find the elliptical t that matches the circular angle.
            if (cosA > -1 && cosA < 0 || cosA > 0 && cosA < 1)
            {
                var d = Sign(cosA);
                return (d / Sqrt(1d + rx * rx * sinA * sinA / (ry * ry * cosA * cosA)),
                        d * (rx * sinA / (ry * cosA * Sqrt(1 + rx * rx * sinA * sinA / (ry * ry * cosA * cosA)))));
            }

            return (cosA, sinA);
        }

        /// <summary>
        /// Find the elliptical (cos(t), sin(t)) that matches the coordinates of a circular angle.
        /// </summary>
        /// <param name="cosA"></param>
        /// <param name="sinA"></param>
        /// <param name="rx">The first radius of the ellipse.</param>
        /// <param name="ry">The second radius of the ellipse.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based on the answer by flup at: https://stackoverflow.com/a/17762156/7004229
        /// </acknowledgment>
        [DisplayName("Elliptical Polar Angle Vector")]
        [Description("Find the Cos and Sin of the Elliptical Polar Angle Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double cosT, double sinT) EllipticalPolarAngleVector0(double cosA, double sinA, double rx, double ry)
        {
            // Get angle.
            var angle = Atan2(sinA, cosA);

            // Wrap the angle between -2PI and 2PI.
            var theta = angle % Tau;

            // Find the elliptical t that matches the circular angle.
            if (cosA == 1d)
            {
                return (cosA, sinA);
            }
            if (cosA < 0d)
            {
                var t = Atan(rx * Tan(theta) / ry) + PI;
                return (Cos(t), Sin(t));
            }
            if (cosA > 0d)
            {
                var t = Atan(rx * Tan(theta) / ry) - PI;
                return (Cos(t), Sin(t));
            }
            {
                var t = Atan(rx * Tan(theta) / ry);
                return (Cos(t), Sin(t));
            }
        }
    }
}
