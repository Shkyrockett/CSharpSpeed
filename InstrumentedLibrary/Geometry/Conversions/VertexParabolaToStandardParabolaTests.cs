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
    [DisplayName("Convert a Parabola in vertex form into standard form")]
    [Description("Convert a Parabola in vertex form into standard form.")]
    [SourceCodeLocationProvider]
    public static class VertexParabolaToStandardParabolaTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(HermiteToCubicBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.0125d, 150, 100 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.0125d, -3.75d, 381.25d), epsilon: double.Epsilon) },
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
        /// <param name="a"></param>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double a, double b, double c) VertexParabolaToStandardParabola(double a, double h, double k)
            => VertexParabolaToStandardParabola1(a, h, k);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        [DisplayName("Convert a Parabola in vertex form into standard form")]
        [Description("Convert a Parabola in vertex form into standard form.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c) VertexParabolaToStandardParabola1(double a, double h, double k)
        {
            var b = -2d * a * h;
            return (a, b, (b * b / (4 * a)) + k);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        [DisplayName("Convert a Parabola in vertex form into standard form")]
        [Description("Convert a Parabola in vertex form into standard form.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c) VertexParabolaToStandardParabola2(double a, double h, double k)
        {
            return (a, b: -2d * a * h, (-2d * a * h * (-2d * a * h) / (4 * a)) + k);
        }
    }
}
