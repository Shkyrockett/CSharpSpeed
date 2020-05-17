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
    public static class MultiplyMatrix4x4x2x2Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m2x1, a.m2x2 }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m2x1, b.m2x2 }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m2x1, c.m2x2 }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// Used to multiply (concatenate) two <see cref="Matrix4x4D" />s.
        /// </summary>
        /// <param name="leftM0x0">The left M0X0.</param>
        /// <param name="leftM0x1">The left M0X1.</param>
        /// <param name="leftM0x2">The left M0X2.</param>
        /// <param name="leftM0x3">The left M0X3.</param>
        /// <param name="leftM1x0">The left M1X0.</param>
        /// <param name="leftM1x1">The left M1X1.</param>
        /// <param name="leftM1x2">The left M1X2.</param>
        /// <param name="leftM1x3">The left M1X3.</param>
        /// <param name="leftM2x0">The left M2X0.</param>
        /// <param name="leftM2x1">The left M2X1.</param>
        /// <param name="leftM2x2">The left M2X2.</param>
        /// <param name="leftM2x3">The left M2X3.</param>
        /// <param name="leftM3x0">The left M3X0.</param>
        /// <param name="leftM3x1">The left M3X1.</param>
        /// <param name="leftM3x2">The left M3X2.</param>
        /// <param name="leftM3x3">The left M3X3.</param>
        /// <param name="rightM0x0">The right M0X0.</param>
        /// <param name="rightM0x1">The right M0X1.</param>
        /// <param name="rightM1x0">The right M1X0.</param>
        /// <param name="rightM1x1">The right M1X1.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3
            ) Multiply4x4x2x2(
            double leftM0x0, double leftM0x1, double leftM0x2, double leftM0x3,
            double leftM1x0, double leftM1x1, double leftM1x2, double leftM1x3,
            double leftM2x0, double leftM2x1, double leftM2x2, double leftM2x3,
            double leftM3x0, double leftM3x1, double leftM3x2, double leftM3x3,
            double rightM0x0, double rightM0x1,
            double rightM1x0, double rightM1x1)
        {
            return ((leftM0x0 * rightM0x0) + (leftM0x1 * rightM1x0), (leftM0x0 * rightM0x1) + (leftM0x1 * rightM1x1), leftM0x2, leftM0x3,
                    (leftM1x0 * rightM0x0) + (leftM1x1 * rightM1x0), (leftM1x0 * rightM0x1) + (leftM1x1 * rightM1x1), leftM1x2, leftM1x3,
                    (leftM2x0 * rightM0x0) + (leftM2x1 * rightM1x0), (leftM2x0 * rightM0x1) + (leftM2x1 * rightM1x1), leftM2x2, leftM2x3,
                    (leftM3x0 * rightM0x0) + (leftM3x1 * rightM1x0), (leftM3x0 * rightM0x1) + (leftM3x1 * rightM1x1), leftM3x2, leftM3x3);
        }
    }
}
