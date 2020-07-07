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
    [DisplayName("Decompose Matrix.")]
    [Description("Decomposes a Matrix to upper and lower matrices.")]
    [SourceCodeLocationProvider]
    public static class GeneralMatrixDecomposeToLowerUpperTests
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
        /// Decomposes to lower upper.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double[,] Lower, double[,] Upper) DecomposeToLowerUpper(double[,] matrix)
            => DecomposeToLowerUpper1(matrix);

        /// <summary>
        /// Compute LU decomposition on a squared matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [DisplayName("Decompose Matrix.")]
        [Description("Decomposes a Matrix to upper and lower matrices.")]
        [Acknowledgment("https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double[,] Lower, double[,] Upper) DecomposeToLowerUpper1(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (!GeneralMatrixIsSquareMatrixTests.IsSquareMatrix(matrix))
            {
                return (new double[1, 1], new double[1, 1]);
            }
            else
            {
                var lower = new double[rows, cols];
                var upper = new double[rows, cols];

                for (var i = 0; i < rows; i++)
                {
                    lower[i, i] = 1;
                }

                for (var i = 0; i < rows; i++)
                {
                    for (var j = i; j < rows; j++)
                    {
                        var sumU = 0d;
                        for (var k = 0; k < i; k++)
                        {
                            sumU += lower[i, k] * upper[k, j];
                        }

                        upper[i, j] = matrix[i, j] - sumU;
                    }

                    for (var j = i; j < rows; j++)
                    {
                        var sumL = 0d;
                        for (var k = 0; k < i; k++)
                        {
                            sumL += lower[j, k] * upper[k, i];
                        }

                        lower[j, i] = (matrix[j, i] - sumL) / upper[i, i];
                    }
                }

                return (lower, upper);
            }
        }
    }
}
