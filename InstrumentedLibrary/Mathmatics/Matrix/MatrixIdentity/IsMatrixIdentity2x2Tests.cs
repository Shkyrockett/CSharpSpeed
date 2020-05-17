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
    public static class IsMatrixIdentity2x2Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m2x1, a.m2x2 }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m2x1, b.m2x2 }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m2x1, c.m2x2 }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="r1c1">The R1C1.</param>
        /// <param name="r1c2">The R1C2.</param>
        /// <param name="r2c1">The R2C1.</param>
        /// <param name="r2c2">The R2C2.</param>
        /// <returns>
        ///   <c>true</c> if the specified R1C1 is identity; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsIdentity(double r1c1, double r1c2, double r2c1, double r2c2)
            => IsIdentity1(r1c1, r1c2, r2c1, r2c2);

        /// <summary>
        /// Tests whether or not a given transform is an identity transform matrix.
        /// </summary>
        /// <param name="m0x0">The M0X0.</param>
        /// <param name="m0x1">The M0X1.</param>
        /// <param name="m1x0">The M1X0.</param>
        /// <param name="m1x1">The M1X1.</param>
        /// <returns>
        ///   <c>true</c> if the specified M0X0 is identity; otherwise, <c>false</c>.
        /// </returns>
        [DisplayName("Is Matrix Identity")]
        [Description("Check whether the Matrix is an Identity Matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity1(
            double m0x0, double m0x1,
            double m1x0, double m1x1)
        {
            return Math.Abs(m0x0 - 1d) < double.Epsilon && Math.Abs(m0x1) < double.Epsilon
                && Math.Abs(m1x0) < double.Epsilon && Math.Abs(m1x1 - 1d) < double.Epsilon;
        }
    }
}
