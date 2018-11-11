using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static InstrumentedLibrary.Maths;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate cubic3d tests class.
    /// </summary>
    [DisplayName("Cubic Interpolate 3D Tests")]
    [Description("Find a point on a 3D cubic curve.")]
    [Signature("public static (double X, double Y, double Z) CubicInterpolate3D(double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double t)")]
    [SourceCodeLocationProvider]
    public static class InterpolateCubic3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 3D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateLinear3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d, 0.5d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:(4.5d, 5.5d, 6.5d), epsilon:DoubleEpsilon) }
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
        /// The cubic interpolate3d.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="z0">The z0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="z3">The z3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Cubic Interpolate 1")]
        [Description("Simple Cubic Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CubicInterpolate3D(
            double x0, double y0, double z0,
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3,
            double t)
        {
            var mu2 = t * t;

            var aX0 = x3 - x2 - x0 + x1;
            var aY0 = y3 - y2 - y0 + y1;
            var aZ0 = z3 - z2 - z0 + z1;
            var aX1 = x0 - x1 - aX0;
            var aY1 = y0 - y1 - aY0;
            var aZ1 = z0 - z1 - aZ0;
            var aX2 = x2 - x0;
            var aY2 = y2 - y0;
            var aZ2 = z2 - z0;

            return (
                (aX0 * t * mu2) + (aX1 * mu2) + (aX2 * t) + x1,
                (aY0 * t * mu2) + (aY1 * mu2) + (aY2 * t) + y1,
                (aZ0 * t * mu2) + (aZ1 * mu2) + (aZ2 * t) + z1);
        }
    }
}
