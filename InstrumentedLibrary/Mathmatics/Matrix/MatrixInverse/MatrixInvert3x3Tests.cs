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
    [DisplayName("Matrix Invert 3x3 Tests")]
    [Description("Matrix Invert 3x3 Tests.")]
    [SourceCodeLocationProvider]
    public static class MatrixInvert3x3Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixInverseDeterminant3x3Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix3x3ElevensTuple;
            var b = MatrixTestCases.Matrix3x3IncrementalTuple;
            var c = MatrixTestCases.Matrix3x3IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m2x1, a.m2x2, a.m2x3, a.m3x1, a.m3x2, a.m3x3 }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue: (double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m2x1, b.m2x2, b.m2x3, b.m3x1, b.m3x2, b.m3x3 }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue: (double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m2x1, c.m2x2, c.m2x3, c.m3x1, c.m3x2, c.m3x3 }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue: (1d, -0d, 0d, -0d, 1d, -0d, 0d, -0d, 1d), epsilon: double.Epsilon) },
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
        /// Scale4x4s the double.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3) Invert(double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3)
            => InverseMatrix(
                 m1x1, m1x2, m1x3,
                 m2x1, m2x2, m2x3,
                 m3x1, m3x2, m3x3);

        /// <summary>
        /// The invert.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <returns>
        /// The <see cref="Matrix3x3D" />.
        /// </returns>
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// </acknowledgment>
        [DisplayName("Inversion of a 3x3 matrix")]
        [Description("Jonathan Mark Porter's method for finding the inversion of a 3x3 matrix.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3
            ) InverseMatrix(
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
        {
            var m11m22m12m21 = (m2x2 * m3x3) - (m2x3 * m3x2);
            var m10m22m12m20 = (m2x1 * m3x3) - (m2x3 * m3x1);
            var m10m21m11m20 = (m2x1 * m3x2) - (m2x2 * m3x1);

            var detInv = 1d / ((m1x1 * m11m22m12m21) - (m1x2 * m10m22m12m20) + (m1x3 * m10m21m11m20));

            return (
                detInv * m11m22m12m21, detInv * (-((m1x2 * m3x3) - (m1x3 * m3x2))), detInv * ((m1x2 * m2x3) - (m1x3 * m2x2)),
                detInv * (-m10m22m12m20), detInv * ((m1x1 * m3x3) - (m1x3 * m3x1)), detInv * (-((m1x1 * m2x3) - (m1x3 * m2x1))),
                detInv * m10m21m11m20, detInv * (-((m1x1 * m3x2) - (m1x2 * m3x1))), detInv * ((m1x1 * m2x2) - (m1x2 * m2x1)));
        }
    }
}
