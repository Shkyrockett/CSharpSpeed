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
    [DisplayName("Determinant of Matrix.")]
    [Description("Finds the Determinant of a Matrix.")]
    [SourceCodeLocationProvider]
    public static class JaggedMatrixDeterminantTests
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
        /// Recursive function for finding determinant of a matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Determinant(double[][] matrix)
            => Determinant2(matrix);

        /// <summary>
        /// Recursive function for finding determinant of matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [DisplayName("Determinant of Matrix.")]
        [Description("Finds the Determinant of a Matrix.")]
        [Acknowledgment("https://www.geeksforgeeks.org/determinant-of-a-matrix/", "https://www.geeksforgeeks.org/adjoint-inverse-matrix/")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant0(double[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rows = matrix.Length;
            //var cols = matrix[0].Length;

            var result = 0d; // Initialize result 

            // Base case : if matrix contains single element 
            if (rows == 1)
            {
                return matrix[0][0];
            }
            else if (rows == 2)
            {
                result = matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
                return result;
            }

            var sign = 1d; // To store sign multiplier 

            // Iterate for each element of first row 
            for (var f = 0; f < rows; f++)
            {
                // Getting Cofactor of A[0][f] 
                var temp = JaggedMatrixSparseCofactorTests.Cofactor(matrix, 0, f);
                result += sign * matrix[0][f] * Determinant(temp);

                // terms are to be added with alternate sign 
                sign = -sign;
            }

            return result;
        }

        /// <summary>
        /// Recursive function for finding determinant of a matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.answers.com/Q/Determinant_of_matrix_in_java
        /// </acknowledgment>
        [DisplayName("Determinant of Matrix.")]
        [Description("Finds the Determinant of a Matrix.")]
        [Acknowledgment("https://www.answers.com/Q/Determinant_of_matrix_in_java")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant1(double[][] matrix)
        {
            var result = 0d;
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            if (rows == 1)
            {
                return matrix[0][0];
            }
            else if (rows == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            }
            for (var i = 0; i < cols; i++)
            {
                var temp = new double[rows - 1][];
                for (var j = 1; j < rows; j++)
                {
                    temp[j - 1] = new double[cols - 1];
                    Array.Copy(matrix[j], 0, temp[j - 1], 0, i);
                    Array.Copy(matrix[j], i + 1, temp[j - 1], i, cols - i - 1);
                }

                result += matrix[0][i] * Math.Pow(-1, i) * Determinant(temp);
            }

            return result;
        }

        /// <summary>
        /// Optimized version of Determinant, that only uses double[][]
        /// </summary>
        /// <param name="array">Matrix array to compute</param>
        /// <returns>
        /// Determinant of the matrix
        /// </returns>
        [DisplayName("Determinant of Matrix.")]
        [Description("Finds the Determinant of a Matrix.")]
        [Acknowledgment("https://github.com/PigDogBay/MpdbSharedLibrary/blob/master/MpdbSharedLibrary/Maths/Matrix.cs")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double Determinant2(double[][] array) => Determinant2(array, 1);

        /// <summary>
        /// Optimized version of Determinant, that only uses double[,]
        /// </summary>
        /// <param name="array">Matrix array to compute</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns>
        /// Determinant of the matrix
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/PigDogBay/MpdbSharedLibrary/blob/master/MpdbSharedLibrary/Maths/Matrix.cs
        /// </acknowledgment>
        private static double Determinant2(double[][] array, double scalar = 1)
        {
            var length = array.GetLength(0);
            if (length == 1)
            {
                return array[0][0];
            }
            else if (length == 2)
            {
                return (array[0][0] * array[1][1] - array[0][1] * array[1][0]) * scalar * scalar;
            }
            double det = 0;
            // get minors and recurse down
            for (var i = 0; i < length; i++)
            {
                // get the minor
                var minor = JaggedGetMatrixMinorTests.GetMinor(array, i, 0);
                // find correct sign
                if (i % 2 == 0)
                {
                    det += Determinant2(minor, scalar) * array[0][i] * scalar;
                }
                else
                {
                    det -= Determinant2(minor, scalar) * array[0][i] * scalar;
                }
            }
            return det;
        }
    }
}
