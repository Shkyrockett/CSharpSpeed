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
    [DisplayName("Matrix Scale 2x2 Tests")]
    [Description("Matrix Scale 2x2 Tests.")]
    [SourceCodeLocationProvider]
    public static class MatrixScale2x2Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m2x1, a.m2x2, 2d }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue: (22d, 24d, 42d, 44d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m2x1, b.m2x2, 2d }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue: (2d, 4d, 6d, 8d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m2x1, c.m2x2, 2d }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue: (2d, 0d, 0d, 2d), epsilon: double.Epsilon) },
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
        public static unsafe (double m1x1, double m1x2, double m2x1, double m2x2) Scale2x2Double(double m1x1, double m1x2, double m2x1, double m2x2, double value2)
            => Scale2x2(
                 m1x1, m1x2,
                 m2x1, m2x2, value2);

        /// <summary>
        /// Used to multiply a Matrix2x2 object by a scalar value.
        /// </summary>
        /// <param name="m0x0">The M0X0.</param>
        /// <param name="m0x1">The M0X1.</param>
        /// <param name="m1x0">The M1X0.</param>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns></returns>
        [DisplayName("Matrix Scale 2x2 Tests")]
        [Description("Matrix Scale 2x2 Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
                double m0x0, double m0x1,
                double m1x0, double m1x1
                ) Scale2x2(
                double m0x0, double m0x1,
                double m1x0, double m1x1,
                double scalar)
        {
            return (m0x0 * scalar, m0x1 * scalar,
                    m1x0 * scalar, m1x1 * scalar);
        }
    }
}
