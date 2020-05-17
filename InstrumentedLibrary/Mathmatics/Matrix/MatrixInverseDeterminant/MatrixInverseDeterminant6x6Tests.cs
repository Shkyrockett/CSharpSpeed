using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The matrix inverse determinant 6x6 tests class.
    /// </summary>
    [DisplayName("Inverse Determinant of a 6x6 matrix")]
    [Description("Find the inverse determinant of a 6x6 matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixInverseDeterminant6x6Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixInverseDeterminant6x6Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix6x6ElevensTuple;
            var b = MatrixTestCases.Matrix6x6IncrementalTuple;
            var c = MatrixTestCases.Matrix6x6IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m1x5, a.m1x6, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m2x5, a.m2x6, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m3x5, a.m3x6, a.m4x1, a.m4x2, a.m4x3, a.m4x4, a.m4x5, a.m4x6, a.m5x1, a.m5x2, a.m5x3, a.m5x4, a.m5x5, a.m5x6, a.m6x1, a.m6x2, a.m6x3, a.m6x4, a.m6x5, a.m6x6 }, new TestCaseResults(description: "Matrix6x6 Elevens Tuple", trials: trials, expectedReturnValue: double.PositiveInfinity, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m1x5, b.m1x6, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m2x5, b.m2x6, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m3x5, b.m3x6, b.m4x1, b.m4x2, b.m4x3, b.m4x4, b.m4x5, b.m4x6, b.m5x1, b.m5x2, b.m5x3, b.m5x4, b.m5x5, b.m5x6, b.m6x1, b.m6x2, b.m6x3, b.m6x4, b.m6x5, b.m6x6 }, new TestCaseResults(description: "Matrix6x6 Incremental Tuple", trials: trials, expectedReturnValue: double.PositiveInfinity, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m1x5, c.m1x6, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m2x5, c.m2x6, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m3x5, c.m3x6, c.m4x1, c.m4x2, c.m4x3, c.m4x4, c.m4x5, c.m4x6, c.m5x1, c.m5x2, c.m5x3, c.m5x4, c.m5x5, c.m5x6, c.m6x1, c.m6x2, c.m6x3, c.m6x4, c.m6x5, c.m6x6 }, new TestCaseResults(description: "Matrix6x6 Identity Tuple", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
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
        /// Inverses the determinant.
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
        /// <param name="z">The z.</param>
        /// <param name="aa">The aa.</param>
        /// <param name="bb">The bb.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="dd">The dd.</param>
        /// <param name="ee">The ee.</param>
        /// <param name="ff">The ff.</param>
        /// <param name="gg">The gg.</param>
        /// <param name="hh">The hh.</param>
        /// <param name="ii">The ii.</param>
        /// <param name="jj">The jj.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double InverseDeterminant(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m, double n, double o, double p, double q, double r, double s, double t, double u, double v, double w, double x, double y, double z, double aa, double bb, double cc, double dd, double ee, double ff, double gg, double hh, double ii, double jj)
            => InverseDeterminant0(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj);

        /// <summary>
        /// Find the inverse of the determinant of a 6 by 6 matrix.
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
        /// <param name="z">The z.</param>
        /// <param name="aa">The aa.</param>
        /// <param name="bb">The bb.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="dd">The dd.</param>
        /// <param name="ee">The ee.</param>
        /// <param name="ff">The ff.</param>
        /// <param name="gg">The gg.</param>
        /// <param name="hh">The hh.</param>
        /// <param name="ii">The ii.</param>
        /// <param name="jj">The jj.</param>
        /// <returns></returns>
        [DisplayName("Inverse Determinant of a 6x6 matrix")]
        [Description("Jerry J. Chen's method for finding the inverse determinant of a 6x6 matrix.")]
        [Acknowledgment("https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InverseDeterminant0(
            double a, double b, double c, double d, double e, double f,
            double g, double h, double i, double j, double k, double l,
            double m, double n, double o, double p, double q, double r,
            double s, double t, double u, double v, double w, double x,
            double y, double z, double aa, double bb, double cc, double dd,
            double ee, double ff, double gg, double hh, double ii, double jj)
        {
            return 1d / ((a * MatrixDeterminant5x5Tests.Determinant(h, i, j, k, l, n, o, p, q, r, t, u, v, w, x, z, aa, bb, cc, dd, ff, gg, hh, ii, jj))
                    - (b * MatrixDeterminant5x5Tests.Determinant(g, i, j, k, l, m, o, p, q, r, s, u, v, w, x, y, aa, bb, cc, dd, ee, gg, hh, ii, jj))
                    + (c * MatrixDeterminant5x5Tests.Determinant(g, h, j, k, l, m, n, p, q, r, s, t, v, w, x, y, z, bb, cc, dd, ee, ff, hh, ii, jj))
                    - (d * MatrixDeterminant5x5Tests.Determinant(g, h, i, k, l, m, n, o, q, r, s, t, u, w, x, y, z, aa, cc, dd, ee, ff, gg, ii, jj))
                    + (e * MatrixDeterminant5x5Tests.Determinant(g, h, i, j, l, m, n, o, p, r, s, t, u, v, x, y, z, aa, bb, dd, ee, ff, gg, hh, jj))
                    - (f * MatrixDeterminant5x5Tests.Determinant(g, h, i, j, k, m, n, o, p, q, s, t, u, v, w, y, z, aa, bb, cc, ee, ff, gg, hh, ii)));
        }
    }
}
