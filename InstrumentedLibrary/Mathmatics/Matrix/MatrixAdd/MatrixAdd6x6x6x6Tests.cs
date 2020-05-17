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
    public static class MatrixAdd6x6x6x6Tests
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
        /// Used to add two matrices together.
        /// </summary>
        /// <param name="augendM0x0">The augend M0X0.</param>
        /// <param name="augendM0x1">The augend M0X1.</param>
        /// <param name="augendM0x2">The augend M0X2.</param>
        /// <param name="augendM0x3">The augend M0X3.</param>
        /// <param name="augendM0x4">The augend M0X4.</param>
        /// <param name="augendM0x5">The augend M0X5.</param>
        /// <param name="augendM1x0">The augend M1X0.</param>
        /// <param name="augendM1x1">The augend M1X1.</param>
        /// <param name="augendM1x2">The augend M1X2.</param>
        /// <param name="augendM1x3">The augend M1X3.</param>
        /// <param name="augendM1x4">The augend M1X4.</param>
        /// <param name="augendM1x5">The augend M1X5.</param>
        /// <param name="augendM2x0">The augend M2X0.</param>
        /// <param name="augendM2x1">The augend M2X1.</param>
        /// <param name="augendM2x2">The augend M2X2.</param>
        /// <param name="augendM2x3">The augend M2X3.</param>
        /// <param name="augendM2x4">The augend M2X4.</param>
        /// <param name="augendM2x5">The augend M2X5.</param>
        /// <param name="augendM3x0">The augend M3X0.</param>
        /// <param name="augendM3x1">The augend M3X1.</param>
        /// <param name="augendM3x2">The augend M3X2.</param>
        /// <param name="augendM3x3">The augend M3X3.</param>
        /// <param name="augendM3x4">The augend M3X4.</param>
        /// <param name="augendM3x5">The augend M3X5.</param>
        /// <param name="augendM4x0">The augend M4X0.</param>
        /// <param name="augendM4x1">The augend M4X1.</param>
        /// <param name="augendM4x2">The augend M4X2.</param>
        /// <param name="augendM4x3">The augend M4X3.</param>
        /// <param name="augendM4x4">The augend M4X4.</param>
        /// <param name="augendM4x5">The augend M4X5.</param>
        /// <param name="augendM5x0">The augend M5X0.</param>
        /// <param name="augendM5x1">The augend M5X1.</param>
        /// <param name="augendM5x2">The augend M5X2.</param>
        /// <param name="augendM5x3">The augend M5X3.</param>
        /// <param name="augendM5x4">The augend M5X4.</param>
        /// <param name="augendM5x5">The augend M5X5.</param>
        /// <param name="addendM0x0">The addend M0X0.</param>
        /// <param name="addendM0x1">The addend M0X1.</param>
        /// <param name="addendM0x2">The addend M0X2.</param>
        /// <param name="addendM0x3">The addend M0X3.</param>
        /// <param name="addendM0x4">The addend M0X4.</param>
        /// <param name="addendM0x5">The addend M0X5.</param>
        /// <param name="addendM1x0">The addend M1X0.</param>
        /// <param name="addendM1x1">The addend M1X1.</param>
        /// <param name="addendM1x2">The addend M1X2.</param>
        /// <param name="addendM1x3">The addend M1X3.</param>
        /// <param name="addendM1x4">The addend M1X4.</param>
        /// <param name="addendM1x5">The addend M1X5.</param>
        /// <param name="addendM2x0">The addend M2X0.</param>
        /// <param name="addendM2x1">The addend M2X1.</param>
        /// <param name="addendM2x2">The addend M2X2.</param>
        /// <param name="addendM2x3">The addend M2X3.</param>
        /// <param name="addendM2x4">The addend M2X4.</param>
        /// <param name="addendM2x5">The addend M2X5.</param>
        /// <param name="addendM3x0">The addend M3X0.</param>
        /// <param name="addendM3x1">The addend M3X1.</param>
        /// <param name="addendM3x2">The addend M3X2.</param>
        /// <param name="addendM3x3">The addend M3X3.</param>
        /// <param name="addendM3x4">The addend M3X4.</param>
        /// <param name="addendM3x5">The addend M3X5.</param>
        /// <param name="addendM4x0">The addend M4X0.</param>
        /// <param name="addendM4x1">The addend M4X1.</param>
        /// <param name="addendM4x2">The addend M4X2.</param>
        /// <param name="addendM4x3">The addend M4X3.</param>
        /// <param name="addendM4x4">The addend M4X4.</param>
        /// <param name="addendM4x5">The addend M4X5.</param>
        /// <param name="addendM5x0">The addend M5X0.</param>
        /// <param name="addendM5x1">The addend M5X1.</param>
        /// <param name="addendM5x2">The addend M5X2.</param>
        /// <param name="addendM5x3">The addend M5X3.</param>
        /// <param name="addendM5x4">The addend M5X4.</param>
        /// <param name="addendM5x5">The addend M5X5.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3, double m0x4, double m0x5,
            double m1x0, double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
            double m2x0, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
            double m3x0, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
            double m4x0, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
            double m5x0, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5
            ) Add6x6x6x6(
            double augendM0x0, double augendM0x1, double augendM0x2, double augendM0x3, double augendM0x4, double augendM0x5,
            double augendM1x0, double augendM1x1, double augendM1x2, double augendM1x3, double augendM1x4, double augendM1x5,
            double augendM2x0, double augendM2x1, double augendM2x2, double augendM2x3, double augendM2x4, double augendM2x5,
            double augendM3x0, double augendM3x1, double augendM3x2, double augendM3x3, double augendM3x4, double augendM3x5,
            double augendM4x0, double augendM4x1, double augendM4x2, double augendM4x3, double augendM4x4, double augendM4x5,
            double augendM5x0, double augendM5x1, double augendM5x2, double augendM5x3, double augendM5x4, double augendM5x5,
            double addendM0x0, double addendM0x1, double addendM0x2, double addendM0x3, double addendM0x4, double addendM0x5,
            double addendM1x0, double addendM1x1, double addendM1x2, double addendM1x3, double addendM1x4, double addendM1x5,
            double addendM2x0, double addendM2x1, double addendM2x2, double addendM2x3, double addendM2x4, double addendM2x5,
            double addendM3x0, double addendM3x1, double addendM3x2, double addendM3x3, double addendM3x4, double addendM3x5,
            double addendM4x0, double addendM4x1, double addendM4x2, double addendM4x3, double addendM4x4, double addendM4x5,
            double addendM5x0, double addendM5x1, double addendM5x2, double addendM5x3, double addendM5x4, double addendM5x5)
        {
            return (augendM0x0 + addendM0x0, augendM0x1 + addendM0x1, augendM0x2 + addendM0x2, augendM0x3 + addendM0x3, augendM0x4 + addendM0x4, augendM0x5 + addendM0x5,
                    augendM1x0 + addendM1x0, augendM1x1 + addendM1x1, augendM1x2 + addendM1x2, augendM1x3 + addendM1x3, augendM1x4 + addendM1x4, augendM1x5 + addendM1x5,
                    augendM2x0 + addendM2x0, augendM2x1 + addendM2x1, augendM2x2 + addendM2x2, augendM2x3 + addendM2x3, augendM2x4 + addendM2x4, augendM2x5 + addendM2x5,
                    augendM3x0 + addendM3x0, augendM3x1 + addendM3x1, augendM3x2 + addendM3x2, augendM3x3 + addendM3x3, augendM3x4 + addendM3x4, augendM3x5 + addendM3x5,
                    augendM4x0 + addendM4x0, augendM4x1 + addendM4x1, augendM4x2 + addendM4x2, augendM4x3 + addendM4x3, augendM4x4 + addendM4x4, augendM4x5 + addendM4x5,
                    augendM5x0 + addendM5x0, augendM5x1 + addendM5x1, augendM5x2 + addendM5x2, augendM5x3 + addendM5x3, augendM5x4 + addendM5x4, augendM5x5 + addendM5x5);
        }
    }
}
