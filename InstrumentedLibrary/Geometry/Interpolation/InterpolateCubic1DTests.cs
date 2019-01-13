using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate cubic1d tests class.
    /// </summary>
    [DisplayName("Cubic Interpolate Tests")]
    [Description("Find a point on a Cubic curve.")]
    [Signature("public static double CubicInterpolate1D(double v0, double v1, double v2, double v3, double t)")]
    [SourceCodeLocationProvider]
    public static class InterpolateCubic1DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateCubic1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 0.5d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:1.5d, epsilon:DoubleEpsilon) },
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
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CubicInterpolate1D(double v0, double v1, double v2, double v3, double t)
            => EvalBez(v0, v1, v2, v3, t);

        /// <summary>
        /// The cubic interpolate1d.
        /// </summary>
        /// <param name="v0">The v0.</param>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="v3">The v3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Cubic Interpolate 1")]
        [Description("Simple Cubic Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicInterpolate1D_(double v0, double v1, double v2, double v3, double t)
        {
            var mu2 = t * t;
            var a0 = v3 - v2 - v0 + v1;
            var a1 = v0 - v1 - a0;
            var a2 = v2 - v0;
            var a3 = v1;

            return (a0 * t * mu2) + (a1 * mu2) + (a2 * t) + a3;
        }

        /// <summary>
        /// The EvalBez method.
        /// </summary>
        /// <param name="p0">The p0.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="p3">The p3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve
        /// http://floris.briolas.nl/floris/2009/10/bounding-box-of-cubic-bezier/
        /// http://jsfiddle.net/SalixAlba/QQnvm/4/
        /// </acknowledgment>
        [DisplayName("Cubic Interpolate EvalBez")]
        [Description("Simple Cubic Interpolation.")]
        [Acknowledgment("http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve", "http://floris.briolas.nl/floris/2009/10/bounding-box-of-cubic-bezier/", "http://jsfiddle.net/SalixAlba/QQnvm/4/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EvalBez(double p0, double p1, double p2, double p3, double t)
        {
            return (p0 * (1 - t) * (1 - t) * (1 - t)) + (3 * p1 * t * (1 - t) * (1 - t)) + (3 * p2 * t * t * (1 - t)) + (p3 * t * t * t);
        }
    }
}
