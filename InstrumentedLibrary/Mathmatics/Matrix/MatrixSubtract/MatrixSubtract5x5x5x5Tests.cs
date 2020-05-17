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
    public static class MatrixSubtract5x5x5x5Tests
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
        /// Used to subtract two matrices.
        /// </summary>
        /// <param name="minuendM0x0">The minuend M0X0.</param>
        /// <param name="minuendM0x1">The minuend M0X1.</param>
        /// <param name="minuendM0x2">The minuend M0X2.</param>
        /// <param name="minuendM0x3">The minuend M0X3.</param>
        /// <param name="minuendM0x4">The minuend M0X4.</param>
        /// <param name="minuendM1x0">The minuend M1X0.</param>
        /// <param name="minuendM1x1">The minuend M1X1.</param>
        /// <param name="minuendM1x2">The minuend M1X2.</param>
        /// <param name="minuendM1x3">The minuend M1X3.</param>
        /// <param name="minuendM1x4">The minuend M1X4.</param>
        /// <param name="minuendM2x0">The minuend M2X0.</param>
        /// <param name="minuendM2x1">The minuend M2X1.</param>
        /// <param name="minuendM2x2">The minuend M2X2.</param>
        /// <param name="minuendM2x3">The minuend M2X3.</param>
        /// <param name="minuendM2x4">The minuend M2X4.</param>
        /// <param name="minuendM3x0">The minuend M3X0.</param>
        /// <param name="minuendM3x1">The minuend M3X1.</param>
        /// <param name="minuendM3x2">The minuend M3X2.</param>
        /// <param name="minuendM3x3">The minuend M3X3.</param>
        /// <param name="minuendM3x4">The minuend M3X4.</param>
        /// <param name="minuendM4x0">The minuend M4X0.</param>
        /// <param name="minuendM4x1">The minuend M4X1.</param>
        /// <param name="minuendM4x2">The minuend M4X2.</param>
        /// <param name="minuendM4x3">The minuend M4X3.</param>
        /// <param name="minuendM4x4">The minuend M4X4.</param>
        /// <param name="subtrahendM0x0">The subtrahend M0X0.</param>
        /// <param name="subtrahendM0x1">The subtrahend M0X1.</param>
        /// <param name="subtrahendM0x2">The subtrahend M0X2.</param>
        /// <param name="subtrahendM0x3">The subtrahend M0X3.</param>
        /// <param name="subtrahendM0x4">The subtrahend M0X4.</param>
        /// <param name="subtrahendM1x0">The subtrahend M1X0.</param>
        /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
        /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
        /// <param name="subtrahendM1x3">The subtrahend M1X3.</param>
        /// <param name="subtrahendM1x4">The subtrahend M1X4.</param>
        /// <param name="subtrahendM2x0">The subtrahend M2X0.</param>
        /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
        /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
        /// <param name="subtrahendM2x3">The subtrahend M2X3.</param>
        /// <param name="subtrahendM2x4">The subtrahend M2X4.</param>
        /// <param name="subtrahendM3x0">The subtrahend M3X0.</param>
        /// <param name="subtrahendM3x1">The subtrahend M3X1.</param>
        /// <param name="subtrahendM3x2">The subtrahend M3X2.</param>
        /// <param name="subtrahendM3x3">The subtrahend M3X3.</param>
        /// <param name="subtrahendM3x4">The subtrahend M3X4.</param>
        /// <param name="subtrahendM4x0">The subtrahend M4X0.</param>
        /// <param name="subtrahendM4x1">The subtrahend M4X1.</param>
        /// <param name="subtrahendM4x2">The subtrahend M4X2.</param>
        /// <param name="subtrahendM4x3">The subtrahend M4X3.</param>
        /// <param name="subtrahendM4x4">The subtrahend M4X4.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3, double m0x4,
            double m1x0, double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x0, double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x0, double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x0, double m4x1, double m4x2, double m4x3, double m4x4
            ) Subtract5x5x5x5(
            double minuendM0x0, double minuendM0x1, double minuendM0x2, double minuendM0x3, double minuendM0x4,
            double minuendM1x0, double minuendM1x1, double minuendM1x2, double minuendM1x3, double minuendM1x4,
            double minuendM2x0, double minuendM2x1, double minuendM2x2, double minuendM2x3, double minuendM2x4,
            double minuendM3x0, double minuendM3x1, double minuendM3x2, double minuendM3x3, double minuendM3x4,
            double minuendM4x0, double minuendM4x1, double minuendM4x2, double minuendM4x3, double minuendM4x4,
            double subtrahendM0x0, double subtrahendM0x1, double subtrahendM0x2, double subtrahendM0x3, double subtrahendM0x4,
            double subtrahendM1x0, double subtrahendM1x1, double subtrahendM1x2, double subtrahendM1x3, double subtrahendM1x4,
            double subtrahendM2x0, double subtrahendM2x1, double subtrahendM2x2, double subtrahendM2x3, double subtrahendM2x4,
            double subtrahendM3x0, double subtrahendM3x1, double subtrahendM3x2, double subtrahendM3x3, double subtrahendM3x4,
            double subtrahendM4x0, double subtrahendM4x1, double subtrahendM4x2, double subtrahendM4x3, double subtrahendM4x4)
        {
            return (minuendM0x0 - subtrahendM0x0, minuendM0x1 - subtrahendM0x1, minuendM0x2 - subtrahendM0x2, minuendM0x3 - subtrahendM0x3, minuendM0x4 - subtrahendM0x4,
                    minuendM1x0 - subtrahendM1x0, minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2, minuendM1x3 - subtrahendM1x3, minuendM1x4 - subtrahendM1x4,
                    minuendM2x0 - subtrahendM2x0, minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2, minuendM2x3 - subtrahendM2x3, minuendM2x4 - subtrahendM2x4,
                    minuendM3x0 - subtrahendM3x0, minuendM3x1 - subtrahendM3x1, minuendM3x2 - subtrahendM3x2, minuendM3x3 - subtrahendM3x3, minuendM3x4 - subtrahendM3x4,
                    minuendM4x0 - subtrahendM4x0, minuendM4x1 - subtrahendM4x1, minuendM4x2 - subtrahendM4x2, minuendM4x3 - subtrahendM4x3, minuendM4x4 - subtrahendM4x4);
        }
    }
}
