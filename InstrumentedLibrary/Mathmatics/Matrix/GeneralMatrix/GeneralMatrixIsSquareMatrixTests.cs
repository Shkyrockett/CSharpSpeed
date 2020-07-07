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
    [DisplayName("Is Matrix Square.")]
    [Description("Determines whether the Matrix is hat the same number of rows as columns.")]
    [SourceCodeLocationProvider]
    public static class GeneralMatrixIsSquareMatrixTests
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
        /// Determines whether [is square matrix] [the specified matrix].
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is square matrix] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsSquareMatrix(double[,] matrix)
            => IsSquareMatrix1(matrix);

        ///// <summary>
        ///// IsSquareMatrix the specified matrix.
        ///// </summary>
        ///// <param name="matrix">The matrix.</param>
        ///// <returns></returns>
        //[DisplayName("Matrix IsSquareMatrix")]
        //[Description("IsSquareMatrix a matrix.")]
        //[SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool IsSquareMatrix0(double[,] matrix)
        //{
        //    switch (matrix?.GetLength(0))
        //    {
        //        case null: return false;
        //        case 2:
        //            {
        //                return IsSquareMatrix2x2Tests.IsSquareMatrix(
        //                    matrix[0, 0], matrix[0, 1],
        //                    matrix[1, 0], matrix[1, 1]);
        //            }
        //        case 3:
        //            {
        //                return IsSquareMatrix3x3Tests.IsSquareMatrix(
        //                    matrix[0, 0], matrix[0, 1], matrix[0, 2],
        //                    matrix[1, 0], matrix[1, 1], matrix[1, 2],
        //                    matrix[2, 0], matrix[2, 1], matrix[2, 2]);
        //            }
        //        case 4:
        //            {
        //                return IsSquareMatrix4x4Tests.IsSquareMatrix(
        //                    matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3],
        //                    matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3],
        //                    matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3],
        //                    matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3]);
        //            }
        //        case 5:
        //            {
        //                return IsSquareMatrix5x5Tests.IsSquareMatrix(
        //                    matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3], matrix[0, 4],
        //                    matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3], matrix[1, 4],
        //                    matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3], matrix[2, 4],
        //                    matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3], matrix[3, 4],
        //                    matrix[4, 0], matrix[4, 1], matrix[4, 2], matrix[4, 3], matrix[4, 4]);
        //            }
        //        case 6:
        //            {
        //                return IsSquareMatrix6x6Tests.IsSquareMatrix(
        //                    matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3], matrix[0, 4], matrix[0, 5],
        //                    matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3], matrix[1, 4], matrix[1, 5],
        //                    matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3], matrix[2, 4], matrix[2, 5],
        //                    matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3], matrix[3, 4], matrix[3, 5],
        //                    matrix[4, 0], matrix[4, 1], matrix[4, 2], matrix[4, 3], matrix[4, 4], matrix[4, 5],
        //                    matrix[5, 0], matrix[5, 1], matrix[5, 2], matrix[5, 3], matrix[5, 4], matrix[5, 5]);
        //            }
        //        default:
        //            return IsSquareMatrix(matrix);
        //    }
        //}

        /// <summary>
        /// Check if a matrix is has the same number of rows as columns.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is square matrix] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L173
        /// </acknowledgment>
        [DisplayName("Is Matrix Square.")]
        [Description("Determines whether the Matrix is hat the same number of rows as columns.")]
        [Acknowledgment("https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L173")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSquareMatrix1(double[,] matrix)
        {
            var rows = matrix?.GetLength(0);
            var cols = matrix?.GetLength(1);
            return rows == cols;
        }
    }
}
