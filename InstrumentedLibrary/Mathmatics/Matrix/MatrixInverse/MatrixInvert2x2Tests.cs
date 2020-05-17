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
    [DisplayName("Matrix Invert 2x2 Tests")]
    [Description("Matrix Invert 2x2 Tests.")]
    [SourceCodeLocationProvider]
    public static class MatrixInvert2x2Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixDeterminant2x2Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix2x2ElevensTuple;
            var b = MatrixTestCases.Matrix2x2IncrementalTuple;
            var c = MatrixTestCases.Matrix2x2IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m2x1, a.m2x2 }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue: (-2.2d, 1.2000000000000002d, 2.1d, -1.1d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m2x1, b.m2x2 }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue: (-2d, 1d, 1.5d, -0.5d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m2x1, c.m2x2 }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue: (1d, -0d, -0d, 1d), epsilon: double.Epsilon) },
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
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double m1x1, double m1x2, double m2x1, double m2x2) Inverse(double m1x1, double m1x2, double m2x1, double m2x2)
            => InverseMatrix(
                 m1x1, m1x2,
                 m2x1, m2x2);

        /// <summary>
        /// The invert.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <returns>
        /// The <see cref="Matrix2x2D" />.
        /// </returns>
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// </acknowledgment>
        [DisplayName("Inversion of a 2x2 matrix")]
        [Description("Jonathan Mark Porter's method for finding the inversion of a 2x2 matrix.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2,
            double m2x1, double m2x2
            ) InverseMatrix(
            double m1x1, double m1x2,
            double m2x1, double m2x2)
        {
            var detInv = 1d / ((m1x1 * m2x2) - (m1x2 * m2x1));
            return (
                detInv * m2x2, detInv * -m1x2,
                detInv * -m2x1, detInv * m1x1);
        }
    }
}
