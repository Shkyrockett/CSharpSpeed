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
    public static class MatrixAdd3x3x3x3Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m2x1, a.m2x2, a.m2x3, a.m3x1, a.m3x2, a.m3x3 }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m2x1, b.m2x2, b.m2x3, b.m3x1, b.m3x2, b.m3x3 }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m2x1, c.m2x2, c.m2x3, c.m3x1, c.m3x2, c.m3x3 }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// <param name="augendM1x0">The augend M1X0.</param>
        /// <param name="augendM1x1">The augend M1X1.</param>
        /// <param name="augendM1x2">The augend M1X2.</param>
        /// <param name="augendM2x0">The augend M2X0.</param>
        /// <param name="augendM2x1">The augend M2X1.</param>
        /// <param name="augendM2x2">The augend M2X2.</param>
        /// <param name="addendM0x0">The addend M0X0.</param>
        /// <param name="addendM0x1">The addend M0X1.</param>
        /// <param name="addendM0x2">The addend M0X2.</param>
        /// <param name="addendM1x0">The addend M1X0.</param>
        /// <param name="addendM1x1">The addend M1X1.</param>
        /// <param name="addendM1x2">The addend M1X2.</param>
        /// <param name="addendM2x0">The addend M2X0.</param>
        /// <param name="addendM2x1">The addend M2X1.</param>
        /// <param name="addendM2x2">The addend M2X2.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2,
            double m1x0, double m1x1, double m1x2,
            double m2x0, double m2x1, double m2x2
            ) Add3x3x3x3(
            double augendM0x0, double augendM0x1, double augendM0x2,
            double augendM1x0, double augendM1x1, double augendM1x2,
            double augendM2x0, double augendM2x1, double augendM2x2,
            double addendM0x0, double addendM0x1, double addendM0x2,
            double addendM1x0, double addendM1x1, double addendM1x2,
            double addendM2x0, double addendM2x1, double addendM2x2)
        {
            return (augendM0x0 + addendM0x0, augendM0x1 + addendM0x1, augendM0x2 + addendM0x2,
                    augendM1x0 + addendM1x0, augendM1x1 + addendM1x1, augendM1x2 + addendM1x2,
                    augendM2x0 + addendM2x0, augendM2x1 + addendM2x1, augendM2x2 + addendM2x2);
        }
    }
}
