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
    [DisplayName("Matrix Scale 3x3 Tests")]
    [Description("Matrix Scale 3x3 Tests.")]
    [SourceCodeLocationProvider]
    public static class MatrixScale3x3Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m2x1, a.m2x2, a.m2x3, a.m3x1, a.m3x2, a.m3x3, 2D }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue: (22d, 24d, 26d, 42d, 44d, 46d, 62d, 64d, 66d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m2x1, b.m2x2, b.m2x3, b.m3x1, b.m3x2, b.m3x3, 2D }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue: (2d, 4d, 6d, 8d, 10d, 12d, 14d, 16d, 18d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m2x1, c.m2x2, c.m2x3, c.m3x1, c.m3x2, c.m3x3, 2D }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue: (2d, 0d, 0d, 0d, 2d, 0d, 0d, 0d, 2d), epsilon: double.Epsilon) },
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
        /// Scale2x2s the double.
        /// </summary>
        /// <param name="m1x1">The M11.</param>
        /// <param name="m1x2">The M12.</param>
        /// <param name="m2x1">The M21.</param>
        /// <param name="m2x2">The M22.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static unsafe (double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3) Scale3x3Double(double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3, double value2)
            => Scale3x3(
                 m1x1, m1x2, m1x3,
                 m2x1, m2x2, m2x3,
                 m3x1, m3x2, m3x3, value2);

        /// <summary>
        /// Used to multiply a Matrix3x3 object by a scalar value.
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
        /// <param name="scalar">The scalar.</param>
        /// <returns></returns>
        [DisplayName("Matrix Scale 3x3 Tests")]
        [Description("Matrix Scale 3x3 Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
                double m0x0, double m0x1, double m0x2,
                double m1x0, double m1x1, double m1x2,
                double m2x0, double m2x1, double m2x2
                ) Scale3x3(
                double m0x0, double m0x1, double m0x2,
                double m1x0, double m1x1, double m1x2,
                double m2x0, double m2x1, double m2x2,
                double scalar)
        {
            return (m0x0 * scalar, m0x1 * scalar, m0x2 * scalar,
                    m1x0 * scalar, m1x1 * scalar, m1x2 * scalar,
                    m2x0 * scalar, m2x1 * scalar, m2x2 * scalar);
        }
    }
}
