using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Rotate point About Origin Test")]
    [Description("Rotate point About Origin.")]
    [SourceCodeLocationProvider]
    public static class RotatePointAboutOriginTests
    {
        /// <summary>
        /// Set of tests to run testing methods.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 45d.ToRadians() }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 1.4142135623730951d), epsilon: double.Epsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="theta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double x, double y) RotatePointAboutOrigin(double x, double y, double theta)
            => RotatePoint(x, y, theta);

        /// <summary>
        /// Rotate the point (x, y) by angle theta around the origin.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="theta">The theta.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/computer-programming/c/5567955982876672
        /// </acknowledgment>
        [DisplayName("Rotate point About Origin Test")]
        [Description("Rotate point About Origin.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) RotatePoint(double x, double y, double theta)
                => RotatePoint(x, y, Cos(theta), Sin(theta));

        /// <summary>
        /// Rotate the point (x, y) by angle theta around the origin.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="cosine">The cosine.</param>
        /// <param name="sine">The sine.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/computer-programming/c/5567955982876672
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) RotatePoint(double x, double y, double cosine, double sine)
        {
            return (x: (cosine * x) - (sine * y), y: (sine * x) + (cosine * y));
        }

        /// <summary>
        /// Rotate a point around the world origin.
        /// </summary>
        /// <param name="x">The x component of the point to rotate.</param>
        /// <param name="y">The y component of the point to rotate.</param>
        /// <param name="angle">The angle to rotate in pi radians.</param>
        /// <returns>A point rotated about the origin by the specified pi radian angle.</returns>
        [DisplayName("Rotate point About Origin Test")]
        [Description("Rotate point About Origin.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) RotatePoint2D(double x, double y, double angle)
            => RotatePointAboutPointTests.RotatePointAboutPoint(x, y, angle, 0, 0);
    }
}
