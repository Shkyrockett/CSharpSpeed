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
    [DisplayName("Quintic Bezier Interpolate 1D Tests")]
    [Description("Find a point on a 1D Quintic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierQuintic1DTests
    {
        /// <summary>
        /// The interpolate cubic bezier1d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierQuintic1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 3d, 6d, 7d, 9d, 11d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:6.28125d, epsilon: double.Epsilon) },
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
        /// <param name="F"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double InterpolateBezierQuintic1D(double A, double B, double C, double D, double E, double F, double t)
            => BezierQuintic(A, B, C, D, E, F, t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <param name="E"></param>
        /// <param name="F"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Quintic Bezier Interpolate 1")]
        [Description("Simple Quintic Bezier Interpolation.")]
        [Acknowledgment("https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BezierQuintic(double A, double B, double C, double D, double E, double F, double t)
        {
            var ABCDE = InterpolateBezierQuartic1DTests.BezierQuartic(A, B, C, D, E, t);
            var BCDEF = InterpolateBezierQuartic1DTests.BezierQuartic(B, C, D, E, F, t);
            return InterpolateLinear1DTests.BezierLinear(ABCDE, BCDEF, t);
        }
    }
}
