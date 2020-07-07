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
    [DisplayName("Invert Matrix.")]
    [Description("Finds the Inverse of a Matrix.")]
    [SourceCodeLocationProvider]
    public static class JaggedMatrixInverseTests
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
                { new object[] { MatrixTestCases.Matrix2x2ElevensJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2IdentityJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3ElevensJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3IdentityJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4ElevensJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4IdentityJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5ElevensJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5IdentityJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6ElevensJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6IdentityJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// Inverses the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[][] Inverse(double[][] matrix)
            => Inverse1(matrix);

        /// <summary>
        /// Function to calculate the inverse of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Singular matrix, can't find its inverse</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [DisplayName("Invert Matrix.")]
        [Description("Finds the Inverse of a Matrix.")]
        [Acknowledgment("https://www.geeksforgeeks.org/adjoint-inverse-matrix/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Inverse1(double[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            // Find determinant of [][]A 
            var det = JaggedMatrixDeterminantTests.Determinant(matrix);
            if (det == 0)
            {
                return default;
                //throw new Exception("Singular matrix, can't find its inverse");
            }

            // Find adjoint 
            var adj = JaggedMatrixAdjointTests.Adjoint(matrix);

            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var inverse = new double[rows][];

            // Find Inverse using formula "inverse(A) = adj(A)/det(A)" 
            for (var i = 0; i < rows; i++)
            {
                inverse[i] = new double[cols];
                for (var j = 0; j < cols; j++)
                {
                    inverse[i][j] = adj[i][j] / det;
                }
            }

            return inverse;
        }
    }
}
