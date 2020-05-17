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
    [DisplayName("Matrix Unary Negate 6x6 Tests")]
    [Description("Matrix Unary Negate 6x6 Tests.")]
    [SourceCodeLocationProvider]
    public static class UnaryNegateMatrix6x6Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m1x5, a.m1x6, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m2x5, a.m2x6, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m3x5, a.m3x6, a.m4x1, a.m4x2, a.m4x3, a.m4x4, a.m4x5, a.m4x6, a.m5x1, a.m5x2, a.m5x3, a.m5x4, a.m5x5, a.m5x6, a.m6x1, a.m6x2, a.m6x3, a.m6x4, a.m6x5, a.m6x6 }, new TestCaseResults(description: "Matrix6x6 Elevens Tuple", trials: trials, expectedReturnValue: (-11d, -12d, -13d, -14d, -15d, -16d, -21d, -22d, -23d, -24d, -25d, -26d, -31d, -32d, -33d, -34d, -35d, -36d, -41d, -42d, -43d, -44d, -45d, -46d, -51d, -52d, -53d, -54d, -55d, -56d, -61d, -62d, -63d, -64d, -65d, -66d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m1x5, b.m1x6, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m2x5, b.m2x6, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m3x5, b.m3x6, b.m4x1, b.m4x2, b.m4x3, b.m4x4, b.m4x5, b.m4x6, b.m5x1, b.m5x2, b.m5x3, b.m5x4, b.m5x5, b.m5x6, b.m6x1, b.m6x2, b.m6x3, b.m6x4, b.m6x5, b.m6x6 }, new TestCaseResults(description: "Matrix6x6 Incremental Tuple", trials: trials, expectedReturnValue: (-1d, -2d, -3d, -4d, -5d, -6d, -7d, -8d, -9d, -10d, -11d, -12d, -13d, -14d, -15d, -16d, -17d, -18d, -19d, -20d, -21d, -22d, -23d, -24d, -25d, -26d, -27d, -28d, -29d, -30d, -31d, -32d, -33d, -34d, -35d, -36d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m1x5, c.m1x6, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m2x5, c.m2x6, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m3x5, c.m3x6, c.m4x1, c.m4x2, c.m4x3, c.m4x4, c.m4x5, c.m4x6, c.m5x1, c.m5x2, c.m5x3, c.m5x4, c.m5x5, c.m5x6, c.m6x1, c.m6x2, c.m6x3, c.m6x4, c.m6x5, c.m6x6 }, new TestCaseResults(description: "Matrix6x6 Identity Tuple", trials: trials, expectedReturnValue: (-1d, -0d, -0d, -0d, -0d, -0d, -0d, -1d, -0d, -0d, -0d, -0d, -0d, -0d, -1d, -0d, -0d, -0d, -0d, -0d, -0d, -1d, -0d, -0d, -0d, -0d, -0d, -0d, -1d, -0d, -0d, -0d, -0d, -0d, -0d, -1d), epsilon: double.Epsilon) },
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
        /// Unaries the negate.
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
        public static (double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6) UnaryNegate(double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6)
            => UnaryNegate1(
                 m1x1, m1x2, m1x3, m1x4, m1x5, m1x6,
                 m2x1, m2x2, m2x3, m2x4, m2x5, m2x6,
                 m3x1, m3x2, m3x3, m3x4, m3x5, m3x6,
                 m4x1, m4x2, m4x3, m4x4, m4x5, m4x6,
                 m5x1, m5x2, m5x3, m5x4, m5x5, m5x6,
                 m6x1, m6x2, m6x3, m6x4, m6x5, m6x6);

        /// <summary>
        /// Negates a Matrix6x6D.
        /// </summary>
        /// <param name="sourceM0x0">The source M0X0.</param>
        /// <param name="sourceM0x1">The source M0X1.</param>
        /// <param name="sourceM0x2">The source M0X2.</param>
        /// <param name="sourceM0x3">The source M0X3.</param>
        /// <param name="sourceM0x4">The source M0X4.</param>
        /// <param name="sourceM0x5">The source M0X5.</param>
        /// <param name="sourceM1x0">The source M1X0.</param>
        /// <param name="sourceM1x1">The source M1X1.</param>
        /// <param name="sourceM1x2">The source M1X2.</param>
        /// <param name="sourceM1x3">The source M1X3.</param>
        /// <param name="sourceM1x4">The source M1X4.</param>
        /// <param name="sourceM1x5">The source M1X5.</param>
        /// <param name="sourceM2x0">The source M2X0.</param>
        /// <param name="sourceM2x1">The source M2X1.</param>
        /// <param name="sourceM2x2">The source M2X2.</param>
        /// <param name="sourceM2x3">The source M2X3.</param>
        /// <param name="sourceM2x4">The source M2X4.</param>
        /// <param name="sourceM2x5">The source M2X5.</param>
        /// <param name="sourceM3x0">The source M3X0.</param>
        /// <param name="sourceM3x1">The source M3X1.</param>
        /// <param name="sourceM3x2">The source M3X2.</param>
        /// <param name="sourceM3x3">The source M3X3.</param>
        /// <param name="sourceM3x4">The source M3X4.</param>
        /// <param name="sourceM3x5">The source M3X5.</param>
        /// <param name="sourceM4x0">The source M4X0.</param>
        /// <param name="sourceM4x1">The source M4X1.</param>
        /// <param name="sourceM4x2">The source M4X2.</param>
        /// <param name="sourceM4x3">The source M4X3.</param>
        /// <param name="sourceM4x4">The source M4X4.</param>
        /// <param name="sourceM4x5">The source M4X5.</param>
        /// <param name="sourceM5x0">The source M5X0.</param>
        /// <param name="sourceM5x1">The source M5X1.</param>
        /// <param name="sourceM5x2">The source M5X2.</param>
        /// <param name="sourceM5x3">The source M5X3.</param>
        /// <param name="sourceM5x4">The source M5X4.</param>
        /// <param name="sourceM5x5">The source M5X5.</param>
        /// <returns></returns>
        [DisplayName("Matrix Invert 6x6 Tests")]
        [Description("Matrix Invert 6x6 Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3, double m0x4, double m0x5,
            double m1x0, double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
            double m2x0, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
            double m3x0, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
            double m4x0, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
            double m5x0, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5
            ) UnaryNegate1(
            double sourceM0x0, double sourceM0x1, double sourceM0x2, double sourceM0x3, double sourceM0x4, double sourceM0x5,
            double sourceM1x0, double sourceM1x1, double sourceM1x2, double sourceM1x3, double sourceM1x4, double sourceM1x5,
            double sourceM2x0, double sourceM2x1, double sourceM2x2, double sourceM2x3, double sourceM2x4, double sourceM2x5,
            double sourceM3x0, double sourceM3x1, double sourceM3x2, double sourceM3x3, double sourceM3x4, double sourceM3x5,
            double sourceM4x0, double sourceM4x1, double sourceM4x2, double sourceM4x3, double sourceM4x4, double sourceM4x5,
            double sourceM5x0, double sourceM5x1, double sourceM5x2, double sourceM5x3, double sourceM5x4, double sourceM5x5)
        {
            return (-sourceM0x0, -sourceM0x1, -sourceM0x2, -sourceM0x3, -sourceM0x4, -sourceM0x5,
                    -sourceM1x0, -sourceM1x1, -sourceM1x2, -sourceM1x3, -sourceM1x4, -sourceM1x5,
                    -sourceM2x0, -sourceM2x1, -sourceM2x2, -sourceM2x3, -sourceM2x4, -sourceM2x5,
                    -sourceM3x0, -sourceM3x1, -sourceM3x2, -sourceM3x3, -sourceM3x4, -sourceM3x5,
                    -sourceM4x0, -sourceM4x1, -sourceM4x2, -sourceM4x3, -sourceM4x4, -sourceM4x5,
                    -sourceM5x0, -sourceM5x1, -sourceM5x2, -sourceM5x3, -sourceM5x4, -sourceM5x5);
        }
    }
}
