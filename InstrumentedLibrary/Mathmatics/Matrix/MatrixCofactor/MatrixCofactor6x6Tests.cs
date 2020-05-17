using CSharpSpeed;
using System;
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
    //[DisplayName("Cofactor of a 6x6 matrix")]
    //[Description("Find the cofactor of a 6x6 matrix.")]
    //[SourceCodeLocationProvider]
    public static class MatrixCofactor6x6Tests
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
            var a = MatrixTestCases.Matrix6x6ElevensTuple;
            var b = MatrixTestCases.Matrix6x6IncrementalTuple;
            var c = MatrixTestCases.Matrix6x6IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m1x5, a.m1x6, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m2x5, a.m2x6, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m3x5, a.m3x6, a.m4x1, a.m4x2, a.m4x3, a.m4x4, a.m4x5, a.m4x6, a.m5x1, a.m5x2, a.m5x3, a.m5x4, a.m5x5, a.m5x6, a.m6x1, a.m6x2, a.m6x3, a.m6x4, a.m6x5, a.m6x6 }, new TestCaseResults(description: "Matrix6x6 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m1x5, b.m1x6, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m2x5, b.m2x6, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m3x5, b.m3x6, b.m4x1, b.m4x2, b.m4x3, b.m4x4, b.m4x5, b.m4x6, b.m5x1, b.m5x2, b.m5x3, b.m5x4, b.m5x5, b.m5x6, b.m6x1, b.m6x2, b.m6x3, b.m6x4, b.m6x5, b.m6x6 }, new TestCaseResults(description: "Matrix6x6 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m1x5, c.m1x6, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m2x5, c.m2x6, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m3x5, c.m3x6, c.m4x1, c.m4x2, c.m4x3, c.m4x4, c.m4x5, c.m4x6, c.m5x1, c.m5x2, c.m5x3, c.m5x4, c.m5x5, c.m5x6, c.m6x1, c.m6x2, c.m6x3, c.m6x4, c.m6x5, c.m6x6 }, new TestCaseResults(description: "Matrix6x6 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// Determinants the specified matrix.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m1x4">The M1X4.</param>
        /// <param name="m1x5">The M1X5.</param>
        /// <param name="m1x6">The M1X6.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m2x4">The M2X4.</param>
        /// <param name="m2x5">The M2X5.</param>
        /// <param name="m2x6">The M2X6.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <param name="m3x4">The M3X4.</param>
        /// <param name="m3x5">The M3X5.</param>
        /// <param name="m3x6">The M3X6.</param>
        /// <param name="m4x1">The M4X1.</param>
        /// <param name="m4x2">The M4X2.</param>
        /// <param name="m4x3">The M4X3.</param>
        /// <param name="m4x4">The M4X4.</param>
        /// <param name="m4x5">The M4X5.</param>
        /// <param name="m4x6">The M4X6.</param>
        /// <param name="m5x1">The M5X1.</param>
        /// <param name="m5x2">The M5X2.</param>
        /// <param name="m5x3">The M5X3.</param>
        /// <param name="m5x4">The M5X4.</param>
        /// <param name="m5x5">The M5X5.</param>
        /// <param name="m5x6">The M5X6.</param>
        /// <param name="m6x1">The M6X1.</param>
        /// <param name="m6x2">The M6X2.</param>
        /// <param name="m6x3">The M6X3.</param>
        /// <param name="m6x4">The M6X4.</param>
        /// <param name="m6x5">The M6X5.</param>
        /// <param name="m6x6">The M6X6.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6) Cofactor(double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6)
            => CofactorMatrix(
                 m1x1, m1x2, m1x3, m1x4, m1x5, m1x6,
                 m2x1, m2x2, m2x3, m2x4, m2x5, m2x6,
                 m3x1, m3x2, m3x3, m3x4, m3x5, m3x6,
                 m4x1, m4x2, m4x3, m4x4, m4x5, m4x6,
                 m5x1, m5x2, m5x3, m5x4, m5x5, m5x6,
                 m6x1, m6x2, m6x3, m6x4, m6x5, m6x6);

        /// <summary>
        /// Cofactors the matrix.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m1x4">The M1X4.</param>
        /// <param name="m1x5">The M1X5.</param>
        /// <param name="m1x6">The M1X6.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m2x4">The M2X4.</param>
        /// <param name="m2x5">The M2X5.</param>
        /// <param name="m2x6">The M2X6.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <param name="m3x4">The M3X4.</param>
        /// <param name="m3x5">The M3X5.</param>
        /// <param name="m3x6">The M3X6.</param>
        /// <param name="m4x1">The M4X1.</param>
        /// <param name="m4x2">The M4X2.</param>
        /// <param name="m4x3">The M4X3.</param>
        /// <param name="m4x4">The M4X4.</param>
        /// <param name="m4x5">The M4X5.</param>
        /// <param name="m4x6">The M4X6.</param>
        /// <param name="m5x1">The M5X1.</param>
        /// <param name="m5x2">The M5X2.</param>
        /// <param name="m5x3">The M5X3.</param>
        /// <param name="m5x4">The M5X4.</param>
        /// <param name="m5x5">The M5X5.</param>
        /// <param name="m5x6">The M5X6.</param>
        /// <param name="m6x1">The M6X1.</param>
        /// <param name="m6x2">The M6X2.</param>
        /// <param name="m6x3">The M6X3.</param>
        /// <param name="m6x4">The M6X4.</param>
        /// <param name="m6x5">The M6X5.</param>
        /// <param name="m6x6">The M6X6.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //[DisplayName("Cofactor of a 6x6 matrix")]
        //[Description("Find the cofactor of a 6x6 matrix.")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6
            ) CofactorMatrix(
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6)
        {
            var m = GeneralMatrixCofactorTests.Cofactor(new double[,]
                {
                    {m1x1, m1x2, m1x3, m1x4, m1x5, m1x6},
                    {m2x1, m2x2, m2x3, m2x4, m2x5, m2x6},
                    {m3x1, m3x2, m3x3, m3x4, m3x5, m3x6},
                    {m4x1, m4x2, m4x3, m4x4, m4x5, m4x6},
                    {m5x1, m5x2, m5x3, m5x4, m5x5, m5x6},
                    {m6x1, m6x2, m6x3, m6x4, m6x5, m6x6}
                });
            return (m[0, 0], m[0, 1], m[0, 2], m[0, 3], m[0, 4], m[0, 5],
                    m[1, 0], m[1, 1], m[1, 2], m[1, 3], m[1, 4], m[1, 5],
                    m[2, 0], m[2, 1], m[2, 2], m[2, 3], m[2, 4], m[2, 5],
                    m[3, 0], m[3, 1], m[3, 2], m[3, 3], m[3, 4], m[3, 5],
                    m[4, 0], m[4, 1], m[4, 2], m[4, 3], m[4, 4], m[4, 5],
                    m[5, 0], m[5, 1], m[5, 2], m[5, 3], m[5, 4], m[5, 5]);
        }
    }
}
