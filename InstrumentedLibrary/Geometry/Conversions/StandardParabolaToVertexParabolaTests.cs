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
    [DisplayName("Convert a standard in vertex form into Parabola form")]
    [Description("Convert a standard in vertex form into Parabola form.")]
    [SourceCodeLocationProvider]
    public static class StandardParabolaToVertexParabolaTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(HermiteToCubicBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = 0.0125d; // The aspect of the parabola.
            var h = 150d; // The horizontal shift of the vertex.
            var k = 100d; // The vertex height of the parabola.
            var b = -2d * a * h; // Get b from vertex form.
            var c = (b * b / (4 * a)) + k; // get c from vertex form.
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a, b, c }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (a, h, k), epsilon: double.Epsilon) },
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
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double a, double h, double k) StandardParabolaToVertexParabola(double a, double b, double c)
            => StandardParabolaToVertexParabola1(a, b, c);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [DisplayName("Convert a standard in vertex form into Parabola form")]
        [Description("Convert a standard in vertex form into Parabola form.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double h, double k) StandardParabolaToVertexParabola1(double a, double b, double c)
        {
            return (a, -(b / (2 * a)), -(b * b / (4 * a)) + c);
        }
    }
}
