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
    [DisplayName("Quartic Bezier Interpolate 2D Tests")]
    [Description("Find a point on a 2D Quartic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierQuartic2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierQuartic2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(4d, 5d), epsilon: double.Epsilon) },
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
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) QuarticBezierInterpolateGetPoint(double t, double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double eX, double eY)
            => QuarticBezierInterpolateGetPoint1(t, aX, aY, bX, bY, cX, cY, dX, dY, eX, eY);

        /// <summary>
        /// The Quartic bezier curve.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <returns></returns>
        /// <returns>The <see cref="T:(double X, double Y)"/>.</returns>
        [DisplayName("Quartic Bezier Interpolate 1")]
        [Description("Simple Quartic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) QuarticBezierInterpolateGetPoint1(double t, double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double eX, double eY)
        {
            return (
                (aX * (1d - t) * (1d - t) * (1d - t) * (1d - t)) + 4d * bX * t * (1d - t) * (1d - t) * (1d - t) + 6d * cX * t * t * (1d - t) * (1d - t) + 4d * dX * t * t * t * (1d - t) + eX * t * t * t * t,
                (aY * (1d - t) * (1d - t) * (1d - t) * (1d - t)) + 4d * bY * t * (1d - t) * (1d - t) * (1d - t) + 6d * cY * t * t * (1d - t) * (1d - t) + 4d * dY * t * t * t * (1d - t) + eY * t * t * t * t
                );
        }

        /// <summary>
        /// Function to Plot a Quartic Bezier
        /// </summary>
        /// <param name="t"></param>
        /// <param name="aX">the starting point, or A in the above diagram</param>
        /// <param name="aY">the starting point, or A in the above diagram</param>
        /// <param name="bX">the first control point, or B</param>
        /// <param name="bY">the first control point, or B</param>
        /// <param name="cX">the second control point, or C</param>
        /// <param name="cY">the second control point, or C</param>
        /// <param name="dX">the end point, or D</param>
        /// <param name="dY">the end point, or D</param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <returns></returns>
        [DisplayName("Quartic Bezier Interpolate 1")]
        [Description("Simple Quartic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) QuarticBezierInterpolate2D(double t, double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double eX, double eY)
        {
            var v = 1d - t;
            return (
                (aX * v * v * v * v) + (4d * bX * t * v * v * v) + (6d * cX * t * t * v * v) + (4d * dX * t * t * t * v) + (eX * t * t * t * t),
                (aY * v * v * v * v) + (4d * bY * t * v * v * v) + (6d * cY * t * t * v * v) + (4d * dY * t * t * t * v) + (eY * t * t * t * t)
                );
        }
    }
}
