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
    [DisplayName("Matrix Unary Negate 3x3 Tests")]
    [Description("Matrix Unary Negate 3x3 Tests.")]
    [SourceCodeLocationProvider]
    public static class UnaryNegateMatrix3x3Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m2x1, a.m2x2, a.m2x3, a.m3x1, a.m3x2, a.m3x3 }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue: (-11d, -12d, -13d, -21d, -22d, -23d, -31d, -32d, -33d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m2x1, b.m2x2, b.m2x3, b.m3x1, b.m3x2, b.m3x3 }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue: (-1d, -2d, -3d, -4d, -5d, -6d, -7d, -8d, -9d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m2x1, c.m2x2, c.m2x3, c.m3x1, c.m3x2, c.m3x3 }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue: (-1d, -0d, -0d, -0d, -1d, -0d, -0d, -0d, -1d), epsilon: double.Epsilon) },
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
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3) UnaryNegate(double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3)
            => UnaryNegate1(
                 m1x1, m1x2, m1x3,
                 m2x1, m2x2, m2x3,
                 m3x1, m3x2, m3x3);

        /// <summary>
        /// Negates a <see cref="Matrix3x3D" />.
        /// </summary>
        /// <param name="sourceM0x0">The source M0X0.</param>
        /// <param name="sourceM0x1">The source M0X1.</param>
        /// <param name="sourceM0x2">The source M0X2.</param>
        /// <param name="sourceM1x0">The source M1X0.</param>
        /// <param name="sourceM1x1">The source M1X1.</param>
        /// <param name="sourceM1x2">The source M1X2.</param>
        /// <param name="sourceM2x0">The source M2X0.</param>
        /// <param name="sourceM2x1">The source M2X1.</param>
        /// <param name="sourceM2x2">The source M2X2.</param>
        /// <returns></returns>
        [DisplayName("Matrix Unary Negate 3x3 Tests")]
        [Description("Matrix Unary Negate 3x3 Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
                double m0x0, double m0x1, double m0x2,
                double m1x0, double m1x1, double m1x2,
                double m2x0, double m2x1, double m2x2
                ) UnaryNegate1(
                double sourceM0x0, double sourceM0x1, double sourceM0x2,
                double sourceM1x0, double sourceM1x1, double sourceM1x2,
                double sourceM2x0, double sourceM2x1, double sourceM2x2)
        {
            return (-sourceM0x0, -sourceM0x1, -sourceM0x2,
                    -sourceM1x0, -sourceM1x1, -sourceM1x2,
                    -sourceM2x0, -sourceM2x1, -sourceM2x2);
        }
    }
}
