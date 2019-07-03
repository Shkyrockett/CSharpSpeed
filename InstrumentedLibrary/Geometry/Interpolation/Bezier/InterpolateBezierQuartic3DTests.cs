using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Quartic Bezier Interpolate 3D Tests")]
    [Description("Find a point on a 3D Quartic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierQuartic3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 3D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierQuartic3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d, 1d, 2d, 3d, 3d, 4d, 5d, 5d, 6d, 7d, 7d, 8d, 9d, 9d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(4d, 5d, 5d), epsilon: double.Epsilon) },
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
        /// <param name="t"></param>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="aZ"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="bZ"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="cZ"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="dZ"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <param name="eZ"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) QuarticBezierInterpolateGetPoint(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ, double eX, double eY, double eZ)
            => QuarticBezierInterpolateGetPoint1(t, aX, aY, aZ, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ, eX, eY, eZ);

        /// <summary>
        /// The Quartic bezier curve.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="aZ"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="bZ"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="cZ"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="dZ"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <param name="eZ"></param>
        /// <returns></returns>
        /// <returns>The <see cref="T:(double X, double Y)"/>.</returns>
        [DisplayName("Quartic Bezier Interpolate 1")]
        [Description("Simple Quartic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) QuarticBezierInterpolateGetPoint1(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ, double eX, double eY, double eZ)
        {
            return (
                (aX * (1d - t) * (1d - t) * (1d - t) * (1d - t)) + 4d * bX * t * (1d - t) * (1d - t) * (1d - t) + 6d * cX * t * t * (1d - t) * (1d - t) + 4d * dX * t * t * t * (1d - t) + eX * t * t * t * t,
                (aY * (1d - t) * (1d - t) * (1d - t) * (1d - t)) + 4d * bY * t * (1d - t) * (1d - t) * (1d - t) + 6d * cY * t * t * (1d - t) * (1d - t) + 4d * dY * t * t * t * (1d - t) + eY * t * t * t * t,
                (aZ * (1d - t) * (1d - t) * (1d - t) * (1d - t)) + 4d * bZ * t * (1d - t) * (1d - t) * (1d - t) + 6d * cZ * t * t * (1d - t) * (1d - t) + 4d * dZ * t * t * t * (1d - t) + eZ * t * t * t * t
                );
        }

        /// <summary>
        /// Function to Plot a Quartic Bezier
        /// </summary>
        /// <param name="t"></param>
        /// <param name="aX">the starting point, or A in the above diagram</param>
        /// <param name="aY">the starting point, or A in the above diagram</param>
        /// <param name="aZ"></param>
        /// <param name="bX">the first control point, or B</param>
        /// <param name="bY">the first control point, or B</param>
        /// <param name="bZ"></param>
        /// <param name="cX">the second control point, or C</param>
        /// <param name="cY">the second control point, or C</param>
        /// <param name="cZ"></param>
        /// <param name="dX">the end point, or D</param>
        /// <param name="dY">the end point, or D</param>
        /// <param name="dZ"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <param name="eZ"></param>
        /// <returns></returns>
        [DisplayName("Quartic Bezier Interpolate 1")]
        [Description("Simple Quartic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) QuarticBezierInterpolate3D(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ, double eX, double eY, double eZ)
        {
            var v = 1d - t;
            return (
                (aX * v * v * v * v) + (4d * bX * t * v * v * v) + (6d * cX * t * t * v * v) + (4d * dX * t * t * t * v) + (eX * t * t * t * t),
                (aY * v * v * v * v) + (4d * bY * t * v * v * v) + (6d * cY * t * t * v * v) + (4d * dY * t * t * t * v) + (eY * t * t * t * t),
                (aZ * v * v * v * v) + (4d * bZ * t * v * v * v) + (6d * cZ * t * t * v * v) + (4d * dZ * t * t * t * v) + (eZ * t * t * t * t)
                );
        }
    }
}
