using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The matrix determinant2x2tests class.
    /// </summary>
    [DisplayName("Determinant of a 2x2 matrix")]
    [Description("Find the determinant of a 2x2 matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixDeterminant2x2Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m2x1, a.m2x2 }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue: -10, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m2x1, b.m2x2 }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue: -2d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m2x1, c.m2x2 }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
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
        /// Determinants the specified R1C1.
        /// </summary>
        /// <param name="r1c1">The R1C1.</param>
        /// <param name="r1c2">The R1C2.</param>
        /// <param name="r2c1">The R2C1.</param>
        /// <param name="r2c2">The R2C2.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Determinant(double r1c1, double r1c2, double r2c1, double r2c2)
            => Determinant0(r1c1, r1c2, r2c1, r2c2);

        /// <summary>
        /// Find the determinant of a 2 by 2 matrix.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
        /// </acknowledgment>
        [DisplayName("Determinant of a 2x2 matrix")]
        [Description("Jerry J. Chen's method for finding the determinant of a 2x2 matrix.")]
        [Acknowledgment("https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant0(
            double m1x1, double m1x2,
            double m2x1, double m2x2)
        {
            return (m1x1 * m2x2) - (m1x2 * m2x1);
        }
    }
}
