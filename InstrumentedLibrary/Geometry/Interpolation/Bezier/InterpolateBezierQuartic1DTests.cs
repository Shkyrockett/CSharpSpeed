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
    [DisplayName("Quartic Bezier Interpolate 1D Tests")]
    [Description("Find a point on a 1D Quartic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierQuartic1DTests
    {
        /// <summary>
        /// The interpolate cubic bezier1d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierQuartic1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 3d, 6d, 7d, 9d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 5.3125d, epsilon: double.Epsilon) },
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
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <param name="E"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double InterpolateBezierQuartic1D(double A, double B, double C, double D, double E, double t)
            => BezierQuartic(A, B, C, D, E, t);

        /// <summary>
        /// The Quartic bezier curve.
        /// </summary>
        /// <param name="aV"></param>
        /// <param name="bV"></param>
        /// <param name="cV"></param>
        /// <param name="dV"></param>
        /// <param name="eV"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <returns>The <see cref="T:(double X, double Y)"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuarticBezierInterpolateGetValue(double aV, double bV, double cV, double dV, double eV, double t)
        {
            return (aV * (1d - t) * (1d - t) * (1d - t) * (1d - t)) + 4d * bV * t * (1d - t) * (1d - t) * (1d - t) + 6d * cV * t * t * (1d - t) * (1d - t) + 4d * dV * t * t * t * (1d - t) + eV * t * t * t * t;
        }

        /// <summary>
        /// Function to Plot a Quartic Bezier
        /// </summary>
        /// <param name="aV"></param>
        /// <param name="bV"></param>
        /// <param name="cV"></param>
        /// <param name="dV"></param>
        /// <param name="eV"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuarticBezierInterpolate1D(double aV, double bV, double cV, double dV, double eV, double t)
        {
            var v = 1d - t;
            return (aV * v * v * v * v) + (4d * bV * t * v * v * v) + (6d * cV * t * t * v * v) + (4d * dV * t * t * t * v) + (eV * t * t * t * t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <param name="E"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Quartic Bezier Interpolate 1")]
        [Description("Simple Quartic Bezier Interpolation.")]
        [Acknowledgment("https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BezierQuartic(double A, double B, double C, double D, double E, double t)
        {
            var ABCD = InterpolateBezierCubic1DTests.BezierCubic(A, B, C, D, t);
            var BCDE = InterpolateBezierCubic1DTests.BezierCubic(B, C, D, E, t);
            return InterpolateLinear1DTests.BezierLinear(ABCD, BCDE, t);
        }
    }
}
