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
    public static class IsMatrixIdentity3x3Tests
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
            var a = MatrixTestCases.Matrix3x3ElevensTuple;
            var b = MatrixTestCases.Matrix3x3IncrementalTuple;
            var c = MatrixTestCases.Matrix3x3IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m2x1, a.m2x2, a.m2x3, a.m3x1, a.m3x2, a.m3x3 }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m2x1, b.m2x2, b.m2x3, b.m3x1, b.m3x2, b.m3x3 }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m2x1, c.m2x2, c.m2x3, c.m3x1, c.m3x2, c.m3x3 }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// Determines whether the specified R1C1 is identity.
        /// </summary>
        /// <param name="m1x1">The R1C1.</param>
        /// <param name="m1x2">The R1C2.</param>
        /// <param name="m1x3">The R1C3.</param>
        /// <param name="m2x1">The R2C1.</param>
        /// <param name="m2x2">The R2C2.</param>
        /// <param name="m2x3">The R2C3.</param>
        /// <param name="m3x1">The R3C1.</param>
        /// <param name="m3x2">The R3C2.</param>
        /// <param name="m3x3">The R3C3.</param>
        /// <returns>
        ///   <c>true</c> if the specified R1C1 is identity; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsIdentity(double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3)
            => IsIdentity1(m1x1, m1x2, m1x3, m2x1, m2x2, m2x3, m3x1, m3x2, m3x3);

        /// <summary>
        /// Tests whether or not a given transform is an identity transform matrix.
        /// </summary>
        /// <param name="m0x0">The M0X0.</param>
        /// <param name="m0x1">The M0X1.</param>
        /// <param name="m0x2">The M0X2.</param>
        /// <param name="m1x0">The M1X0.</param>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m2x0">The M2X0.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <returns>
        ///   <c>true</c> if the specified M0X0 is identity; otherwise, <c>false</c>.
        /// </returns>
        [DisplayName("Is Matrix Identity")]
        [Description("Check whether the Matrix is an Identity Matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity1(
            double m0x0, double m0x1, double m0x2,
            double m1x0, double m1x1, double m1x2,
            double m2x0, double m2x1, double m2x2)
        {
            return Math.Abs(m0x0 - 1d) < double.Epsilon && Math.Abs(m0x1) < double.Epsilon && Math.Abs(m0x2) < double.Epsilon
                && Math.Abs(m1x0) < double.Epsilon && Math.Abs(m1x1 - 1d) < double.Epsilon && Math.Abs(m1x2) < double.Epsilon
                && Math.Abs(m2x0) < double.Epsilon && Math.Abs(m2x1) < double.Epsilon && Math.Abs(m2x2 - 1d) < double.Epsilon;
        }
    }
}
