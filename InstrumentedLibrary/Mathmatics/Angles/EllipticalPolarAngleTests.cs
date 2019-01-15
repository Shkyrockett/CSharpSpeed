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
    /// The elliptical polar angle class.
    /// </summary>
    [DisplayName("Elliptical Polar Angle")]
    [Description("Find the elliptical t that matches the coordinates of a circular angle.")]
    [SourceCodeLocationProvider]
    public static class EllipticalPolarAngleTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(EllipticalPolarAngleTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 30d.ToRadians(), 3d, 2d }, new TestCaseResults(description:"Find the angle on a 3:2 ellipse a 30 polar degrees.", trials:trials, expectedReturnValue:0.71372437894476559d, epsilon:DoubleEpsilon) },
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
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double EllipticalPolarAngle(double angle, double rx, double ry)
            => EllipticalPolarAngle0(angle, rx, ry);

        /// <summary>
        /// Find the elliptical t that matches the coordinates of a circular angle.
        /// </summary>
        /// <param name="angle">The angle to transform into elliptic angle.</param>
        /// <param name="rx">The first radius of the ellipse.</param>
        /// <param name="ry">The second radius of the ellipse.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based on the answer by flup at: https://stackoverflow.com/a/17762156/7004229
        /// </acknowledgment>
        [DisplayName("Elliptical Polar Angle 1")]
        [Description("flup's method of finding the polar angle from elliptical angle.")]
        [Acknowledgment("https://stackoverflow.com/a/17762156/7004229")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipticalPolarAngle0(double angle, double rx, double ry)
        {
            // Wrap the angle between -2PI and 2PI.
            var theta = angle % Tau;

            // Find the elliptical t that matches the circular angle.
            if (Abs(theta) == HalfPi || Abs(theta) == Pau)
            {
                return angle;
            }

            if (theta > HalfPi && theta < Pau)
            {
                return Atan(rx * Tan(theta) / ry) + PI;
            }

            if (theta < -HalfPi && theta > -Pau)
            {
                return Atan(rx * Tan(theta) / ry) - PI;
            }

            return Atan(rx * Tan(theta) / ry);
        }

        /// <summary>
        /// Find the elliptical t that matches the coordinates of a circular angle.
        /// </summary>
        /// <param name="angle">The angle to transform into elliptic angle.</param>
        /// <param name="rx">The first radius of the ellipse.</param>
        /// <param name="ry">The second radius of the ellipse.</param>
        /// <returns></returns>
        [DisplayName("Elliptical Polar Angle Vector")]
        [Description("Find the angle of the Elliptical Polar Angle Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipticalPolarAngle1(double angle, double rx, double ry)
        {
            var (cosT, sinT) = EllipticalPolarVectorTests.EllipticalPolarVector(Cos(angle), Sin(angle), rx, ry);
            return Atan2(sinT, cosT);
        }
    }
}
