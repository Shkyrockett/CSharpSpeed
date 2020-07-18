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
        /// Tests the harness. See: https://www.dcode.fr/matrix-determinant
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(JaggedMatrixCofactorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { MatrixTestCases.MatrixScalarElevens2DArray }, new TestCaseResults(description: "Matrix1x1 Elevens", trials: trials, expectedReturnValue: 11d, epsilon: double.Epsilon) },
                
                //{ new object[] { MatrixTestCases.Matrix2x2Elevens2DArray }, new TestCaseResults(description: "Matrix2x2 Elevens", trials: trials, expectedReturnValue: -10d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix2x2Incremental2DArray }, new TestCaseResults(description: "Matrix2x2 Incremental", trials: trials, expectedReturnValue: -2d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix2x2Identity2DArray }, new TestCaseResults(description: "Matrix2x2 Identity", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix3x3Elevens2DArray }, new TestCaseResults(description: "Matrix3x3 Elevens", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix3x3Incremental2DArray }, new TestCaseResults(description: "Matrix3x3 Incremental", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix3x3Identity2DArray }, new TestCaseResults(description: "Matrix3x3 Identity", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix4x4Elevens2DArray }, new TestCaseResults(description: "Matrix4x4 Elevens", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix4x4Incremental2DArray }, new TestCaseResults(description: "Matrix4x4 Incremental", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix4x4Identity2DArray }, new TestCaseResults(description: "Matrix4x4 Identity", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix5x5Elevens2DArray }, new TestCaseResults(description: "Matrix5x5 Elevens", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix5x5Incremental2DArray }, new TestCaseResults(description: "Matrix5x5 Incremental", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix5x5Identity2DArray }, new TestCaseResults(description: "Matrix5x5 Identity", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix6x6Elevens2DArray }, new TestCaseResults(description: "Matrix6x6 Elevens", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix6x6Incremental2DArray }, new TestCaseResults(description: "Matrix6x6 Incremental", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.Matrix6x6Identity2DArray }, new TestCaseResults(description: "Matrix6x6 Identity", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
            
                { new object[] { MatrixTestCases.MatrixScalarIdentity2DArray }, new TestCaseResults(description: "Matrix1x1 Identity", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.BezierLinear2x2Array }, new TestCaseResults(description: "Bezier Matrix2x2", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.BezierQuadratic3x3Array }, new TestCaseResults(description: "Bezier Matrix3x3", trials: trials, expectedReturnValue: 2d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.BezierCubic4x4Array }, new TestCaseResults(description: "Bezier Matrix4x4", trials: trials, expectedReturnValue: 9d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.BezierQuartic5x5Array }, new TestCaseResults(description: "Bezier Matrix5x5", trials: trials, expectedReturnValue: 96d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.BezierQuintic6x6Array }, new TestCaseResults(description: "Bezier Matrix6x6", trials: trials, expectedReturnValue: 2500d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.BezierSextic7x7Array }, new TestCaseResults(description: "Bezier Matrix7x7", trials: trials, expectedReturnValue: 162000d, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.BezierSeptic8x8Array }, new TestCaseResults(description: "Bezier Matrix8x8", trials: trials, expectedReturnValue: 26471025d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.BezierOctic9x9Array }, new TestCaseResults(description: "Bezier Matrix9x9", trials: trials, expectedReturnValue: 11014635520d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.BezierNonic10x10Array }, new TestCaseResults(description: "Bezier Matrix10x10", trials: trials, expectedReturnValue: 11759522374656d, epsilon: double.Epsilon) },
                //{ new object[] { MatrixTestCases.BezierDecic11x11Array }, new TestCaseResults(description: "Bezier Matrix11x11", trials: trials, expectedReturnValue: 32406091200000000d, epsilon: double.Epsilon) },
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
                case 1:
                    {
                        return matrix[0, 0];
                    }
                case 2:
                    {
                        return MatrixDeterminant2x2Tests.Determinant(
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
        //[DisplayName("Determinant of Matrix.")]
        //[Description("Finds the Determinant of a Matrix.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/determinant-of-a-matrix/", "https://www.geeksforgeeks.org/adjoint-inverse-matrix/")]
        //[SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant1(double[,] matrix)
        {
            // This method is broken. It does not provide the correct values for anything over 2 rows.

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

                // Terms are to be added with alternate sign 
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
        public static double Determinant2(double[,] matrix)
        //{
        //    var result = 0d;
        //    var rows = matrix.GetLength(0);
        //    var cols = matrix.GetLength(1);
        //    if (rows == 1)
        //    {
        //        return matrix[0, 0];
        //    }
        //    else if (rows == 2)
        //    {
        //        return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        //    }
        //    for (var i = 0; i < cols; i++)
        //    {
        //        var temp = new double[rows - 1, cols - 1];
        //        for (var j = 1; j < rows; j++)
        //        {
        //            Array.Copy(matrix, 0, temp[j - 1], 0, i);
        //            Array.Copy(matrix, i + 1, temp[j - 1], i, cols - i - 1);
        //        }

        //        result += matrix[0, i] * Math.Pow(-1, i) * Determinant(temp);
        //    }

        //    return result;
        //}
        => JaggedMatrixDeterminantTests.Determinant(matrix.ToJaggedArray()); // Convert to jagged array until the above copy code can be understood and fixed.

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
        //[DebuggerStepThrough]
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
            var rows = array.GetLength(0);
            if (rows == 1)
            {
                return array[0, 0];
            }
            else if (rows == 2)
            {
                return (array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0]) * scalar * scalar;
            }

            double det = 0;

            // Get minors and recurse down
            for (var i = 0; i < rows; i++)
            {
                // Get the minor
                var minor = GeneralGetMatrixMinorTests.GetMinor(array, i, 0);

                // Find correct sign
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
