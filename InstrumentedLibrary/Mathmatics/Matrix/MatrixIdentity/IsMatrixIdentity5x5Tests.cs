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
    [DisplayName("Is Matrix Identity")]
    [Description("Check whether the Matrix is an Identity Matrix.")]
    [SourceCodeLocationProvider]
    public static class IsMatrixIdentity5x5Tests
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
            var a = MatrixTestCases.Matrix5x5ElevensTuple;
            var b = MatrixTestCases.Matrix5x5IncrementalTuple;
            var c = MatrixTestCases.Matrix5x5IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m1x5, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m2x5, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m3x5, a.m4x1, a.m4x2, a.m4x3, a.m4x4, a.m4x5, a.m5x1, a.m5x2, a.m5x3, a.m5x4, a.m5x5 }, new TestCaseResults(description: "Matrix5x5 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m1x5, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m2x5, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m3x5, b.m4x1, b.m4x2, b.m4x3, b.m4x4, b.m4x5, b.m5x1, b.m5x2, b.m5x3, b.m5x4, b.m5x5 }, new TestCaseResults(description: "Matrix5x5 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m1x5, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m2x5, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m3x5, c.m4x1, c.m4x2, c.m4x3, c.m4x4, c.m4x5, c.m5x1, c.m5x2, c.m5x3, c.m5x4, c.m5x5 }, new TestCaseResults(description: "Matrix5x5 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// Determines whether the specified M1X1 is identity.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m1x4">The M1X4.</param>
        /// <param name="m1x5">The M1X5.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m2x4">The M2X4.</param>
        /// <param name="m2x5">The M2X5.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <param name="m3x4">The M3X4.</param>
        /// <param name="m3x5">The M3X5.</param>
        /// <param name="m4x1">The M4X1.</param>
        /// <param name="m4x2">The M4X2.</param>
        /// <param name="m4x3">The M4X3.</param>
        /// <param name="m4x4">The M4X4.</param>
        /// <param name="m4x5">The M4X5.</param>
        /// <param name="m5x1">The M5X1.</param>
        /// <param name="m5x2">The M5X2.</param>
        /// <param name="m5x3">The M5X3.</param>
        /// <param name="m5x4">The M5X4.</param>
        /// <param name="m5x5">The M5X5.</param>
        /// <returns>
        ///   <c>true</c> if the specified M1X1 is identity; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsIdentity(double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5)
            => IsIdentity1(m1x1, m1x2, m1x3, m1x4, m1x5, m2x1, m2x2, m2x3, m2x4, m2x5, m3x1, m3x2, m3x3, m3x4, m3x5, m4x1, m4x2, m4x3, m4x4, m4x5, m5x1, m5x2, m5x3, m5x4, m5x5);

        /// <summary>
        /// Tests whether or not a given transform is an identity transform matrix.
        /// </summary>
        /// <param name="m0x0">The M0X0.</param>
        /// <param name="m0x1">The M0X1.</param>
        /// <param name="m0x2">The M0X2.</param>
        /// <param name="m0x3">The M0X3.</param>
        /// <param name="m0x4">The M0X4.</param>
        /// <param name="m1x0">The M1X0.</param>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m1x4">The M1X4.</param>
        /// <param name="m2x0">The M2X0.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m2x4">The M2X4.</param>
        /// <param name="m3x0">The M3X0.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <param name="m3x4">The M3X4.</param>
        /// <param name="m4x0">The M4X0.</param>
        /// <param name="m4x1">The M4X1.</param>
        /// <param name="m4x2">The M4X2.</param>
        /// <param name="m4x3">The M4X3.</param>
        /// <param name="m4x4">The M4X4.</param>
        /// <returns>
        ///   <c>true</c> if the specified M0X0 is identity; otherwise, <c>false</c>.
        /// </returns>
        [DisplayName("Is Matrix Identity")]
        [Description("Check whether the Matrix is an Identity Matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity1(
            double m0x0, double m0x1, double m0x2, double m0x3, double m0x4,
            double m1x0, double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x0, double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x0, double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x0, double m4x1, double m4x2, double m4x3, double m4x4)
        {
            return Math.Abs(m0x0 - 1d) < double.Epsilon && Math.Abs(m0x1) < double.Epsilon && Math.Abs(m0x2) < double.Epsilon && Math.Abs(m0x3) < double.Epsilon && Math.Abs(m0x4) < double.Epsilon
                && Math.Abs(m1x0) < double.Epsilon && Math.Abs(m1x1 - 1d) < double.Epsilon && Math.Abs(m1x2) < double.Epsilon && Math.Abs(m1x3) < double.Epsilon && Math.Abs(m1x4) < double.Epsilon
                && Math.Abs(m2x0) < double.Epsilon && Math.Abs(m2x1) < double.Epsilon && Math.Abs(m2x2 - 1d) < double.Epsilon && Math.Abs(m2x3) < double.Epsilon && Math.Abs(m2x4) < double.Epsilon
                && Math.Abs(m3x0) < double.Epsilon && Math.Abs(m3x1) < double.Epsilon && Math.Abs(m3x2) < double.Epsilon && Math.Abs(m3x3 - 1d) < double.Epsilon && Math.Abs(m3x4) < double.Epsilon
                && Math.Abs(m4x0) < double.Epsilon && Math.Abs(m4x1) < double.Epsilon && Math.Abs(m4x2) < double.Epsilon && Math.Abs(m4x3) < double.Epsilon && Math.Abs(m4x4 - 1d) < double.Epsilon;
        }
    }
}
