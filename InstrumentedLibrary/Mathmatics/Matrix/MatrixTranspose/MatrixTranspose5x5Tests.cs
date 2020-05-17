using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class MatrixTranspose5x5Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixInverseDeterminant5x5Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix5x5ElevensTuple;
            var b = MatrixTestCases.Matrix5x5IncrementalTuple;
            var c = MatrixTestCases.Matrix5x5IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m1x5, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m2x5, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m3x5, a.m4x1, a.m4x2, a.m4x3, a.m4x4, a.m4x5, a.m5x1, a.m5x2, a.m5x3, a.m5x4, a.m5x5 }, new TestCaseResults(description: "Matrix5x5 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m1x5, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m2x5, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m3x5, b.m4x1, b.m4x2, b.m4x3, b.m4x4, b.m4x5, b.m5x1, b.m5x2, b.m5x3, b.m5x4, b.m5x5 }, new TestCaseResults(description: "Matrix5x5 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m1x5, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m2x5, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m3x5, c.m4x1, c.m4x2, c.m4x3, c.m4x4, c.m4x5, c.m5x1, c.m5x2, c.m5x3, c.m5x4, c.m5x5 }, new TestCaseResults(description: "Matrix5x5 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// Swap the rows of the matrix with the columns.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="g">The g.</param>
        /// <param name="h">The h.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        /// <param name="l">The l.</param>
        /// <param name="m">The m.</param>
        /// <param name="n">The n.</param>
        /// <param name="o">The o.</param>
        /// <param name="p">The p.</param>
        /// <param name="q">The q.</param>
        /// <param name="r">The r.</param>
        /// <param name="s">The s.</param>
        /// <param name="t">The t.</param>
        /// <param name="u">The u.</param>
        /// <param name="v">The v.</param>
        /// <param name="w">The w.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// A transposed Matrix.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double a, double b, double c, double d, double e,
            double f, double g, double h, double i, double j,
            double k, double l, double m, double n, double o,
            double p, double q, double r, double s, double t,
            double u, double v, double w, double x, double y
            ) Transpose(
            double a, double b, double c, double d, double e,
            double f, double g, double h, double i, double j,
            double k, double l, double m, double n, double o,
            double p, double q, double r, double s, double t,
            double u, double v, double w, double x, double y)
        {
            return (
                a, f, k, p, u,
                b, g, l, q, v,
                c, h, m, r, w,
                d, i, n, s, x,
                e, j, o, t, y
            );
        }
    }
}
