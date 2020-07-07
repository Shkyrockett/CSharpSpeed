using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Is Matrix Identity.")]
    [Description("Determines whether the Matrix is an Identity Matrix.")]
    [SourceCodeLocationProvider]
    public static class GeneralMatrixIsIdentityTests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(JaggedMatrixCofactorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { MatrixTestCases.Matrix2x2Elevens2DArray }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2Incremental2DArray }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2Identity2DArray }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Elevens2DArray }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Incremental2DArray }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Identity2DArray }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Elevens2DArray }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Incremental2DArray }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Identity2DArray }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Elevens2DArray }, new TestCaseResults(description: "Matrix5x5 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Incremental2DArray }, new TestCaseResults(description: "Matrix5x5 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Identity2DArray }, new TestCaseResults(description: "Matrix5x5 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Elevens2DArray }, new TestCaseResults(description: "Matrix6x6 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Incremental2DArray }, new TestCaseResults(description: "Matrix6x6 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Identity2DArray }, new TestCaseResults(description: "Matrix6x6 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// Determines whether the specified matrix is identity.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified matrix is identity; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsIdentity(double[,] matrix)
            => IsIdentity1(matrix);

        /// <summary>
        /// IsIdentity the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [DisplayName("Matrix IsIdentity")]
        [Description("IsIdentity a matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity0(double[,] matrix)
        {
            switch (matrix?.GetLength(0))
            {
                case null: return false;
                case 2:
                    {
                        return IsMatrixIdentity2x2Tests.IsIdentity(
                            matrix[0, 0], matrix[0, 1],
                            matrix[1, 0], matrix[1, 1]);
                    }
                case 3:
                    {
                        return IsMatrixIdentity3x3Tests.IsIdentity(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2]);
                    }
                case 4:
                    {
                        return IsMatrixIdentity4x4Tests.IsIdentity(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3]);
                    }
                case 5:
                    {
                        return IsMatrixIdentity5x5Tests.IsIdentity(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3], matrix[0, 4],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3], matrix[1, 4],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3], matrix[2, 4],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3], matrix[3, 4],
                            matrix[4, 0], matrix[4, 1], matrix[4, 2], matrix[4, 3], matrix[4, 4]);
                    }
                case 6:
                    {
                        return IsMatrixIdentity6x6Tests.IsIdentity(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3], matrix[0, 4], matrix[0, 5],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3], matrix[1, 4], matrix[1, 5],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3], matrix[2, 4], matrix[2, 5],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3], matrix[3, 4], matrix[3, 5],
                            matrix[4, 0], matrix[4, 1], matrix[4, 2], matrix[4, 3], matrix[4, 4], matrix[4, 5],
                            matrix[5, 0], matrix[5, 1], matrix[5, 2], matrix[5, 3], matrix[5, 4], matrix[5, 5]);
                    }
                default:
                    return IsIdentity(matrix);
            }
        }

        /// <summary>
        /// Determines whether the specified matrix is identity.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <c>true</c> if the specified matrix is identity; otherwise, <c>false</c>.
        /// </returns>
        /// <acknowledgment>
        /// https://www.tutorialgateway.org/c-program-to-check-matrix-is-an-identity-matrix/
        /// </acknowledgment>
        [DisplayName("Is Matrix Identity.")]
        [Description("Determines whether the Matrix is an Identity Matrix.")]
        [Acknowledgment("https://www.tutorialgateway.org/c-program-to-check-matrix-is-an-identity-matrix/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity1(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 1 && matrix[j, i] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
