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
    public static class GeneralMatrixDeterminantTests
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
        /// Recursive function for finding determinant of a matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Determinant(double[,] matrix)
            => Determinant3(matrix);

        /// <summary>
        /// Determinant the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [DisplayName("Matrix Determinant")]
        [Description("Determinant a matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant0(double[,] matrix)
        {
            switch (matrix?.GetLength(0))
            {
                case null: return 0;
                case 2:
                    {
                        return  MatrixDeterminant2x2Tests.Determinant(
                            matrix[0, 0], matrix[0, 1],
                            matrix[1, 0], matrix[1, 1]);
                    }
                case 3:
                    {
                        return MatrixDeterminant3x3Tests.Determinant(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2]);
                    }
                case 4:
                    {
                        return MatrixDeterminant4x4Tests.Determinant(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3]);
                    }
                case 5:
                    {
                        return MatrixDeterminant5x5Tests.Determinant(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3], matrix[0, 4],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3], matrix[1, 4],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3], matrix[2, 4],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3], matrix[3, 4],
                            matrix[4, 0], matrix[4, 1], matrix[4, 2], matrix[4, 3], matrix[4, 4]);
                    }
                case 6:
                    {
                        return MatrixDeterminant6x6Tests.Determinant(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3], matrix[0, 4], matrix[0, 5],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3], matrix[1, 4], matrix[1, 5],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3], matrix[2, 4], matrix[2, 5],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3], matrix[3, 4], matrix[3, 5],
                            matrix[4, 0], matrix[4, 1], matrix[4, 2], matrix[4, 3], matrix[4, 4], matrix[4, 5],
                            matrix[5, 0], matrix[5, 1], matrix[5, 2], matrix[5, 3], matrix[5, 4], matrix[5, 5]);
                    }
                default:
                    return Determinant(matrix);
            }
        }

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
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant1(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rows = matrix.GetLength(0);
            //var cols = matrix.GetLength(1);

            var result = 0d; // Initialize result 

            // Base case : if matrix contains single element 
            if (rows == 1)
            {
                return matrix[0, 0];
            }
            else if (rows == 2)
            {
                result = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
                return result;
            }

            var sign = 1d; // To store sign multiplier 

            // Iterate for each element of first row 
            for (var f = 0; f < rows; f++)
            {
                // Getting Cofactor of A[0,f] 
                var temp = GeneralMatrixSparseCofactorTests.Cofactor(matrix, 0, f);
                result += sign * matrix[0, f] * Determinant(temp);

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
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant2(double[,] matrix)
        //{
        //    var result = 0d;
        //    if (matrix.GetLength(0) == 2)
        //    {
        //        result = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        //        return result;
        //    }
        //    for (var i = 0; i < matrix.GetLength(1); i++)
        //    {
        //        var temp = new double[matrix.Length - 1, matrix.GetLength(1) - 1];
        //        for (var j = 1; j < matrix.Length; j++)
        //        {
        //            Array.Copy(matrix, 0, temp[j - 1], 0, i);
        //            Array.Copy(matrix, i + 1, temp[j - 1], i, matrix.GetLength(1) - i - 1);
        //        }

        //        result += matrix[0, i] * Math.Pow(-1, i) * Determinant(temp);
        //    }

        //    return result;
        //}
        => JaggedMatrixDeterminantTests.Determinant(matrix.ToJaggedArray()); // Convert to jagged array until the above code can be fixed.

        /// <summary>
        /// Optimized version of Determinant, that only uses double[,]
        /// </summary>
        /// <param name="array">Matrix array to compute</param>
        /// <returns>
        /// Determinant of the matrix
        /// </returns>
        [DisplayName("Determinant of Matrix.")]
        [Description("Finds the Determinant of a Matrix.")]
        [Acknowledgment("https://github.com/PigDogBay/MpdbSharedLibrary/blob/master/MpdbSharedLibrary/Maths/Matrix.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double Determinant3(double[,] array) => Determinant3(array, 1);

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
        private static double Determinant3(double[,] array, double scalar = 1)
        {
            var length = array.GetLength(0);
            if (length == 2)
            {
                return (array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0]) * scalar * scalar;
            }
            double det = 0;
            // get minors and recurse down
            for (var i = 0; i < length; i++)
            {
                // get the minor
                var minor = GeneralGetMatrixMinorTests.GetMinor(array, i, 0);
                // find correct sign
                if (i % 2 == 0)
                {
                    det += Determinant3(minor, scalar) * array[0, i] * scalar;
                }
                else
                {
                    det -= Determinant3(minor, scalar) * array[0, i] * scalar;
                }
            }
            return det;
        }
    }
}
