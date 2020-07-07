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
    [DisplayName("Matrix Adjoint")]
    [Description("Adjoint a matrix.")]
    [SourceCodeLocationProvider]
    public static class JaggedMatrixAdjointTests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(GeneralMatrixAdjointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { MatrixTestCases.Matrix2x2ElevensJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue: new double[][]{ new double[] { 0, -0}, new double[] { -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue: new double[][]{ new double[] { 0, -0}, new double[] { -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2IdentityJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0}, new double[] { -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3ElevensJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0}, new double[] { -0, 0, -0}, new double[] { 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0}, new double[] { -0, 0, -0}, new double[] { 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3IdentityJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0}, new double[] { -0, 0, -0}, new double[] { 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4ElevensJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0}, new double[] { -0, 0, -0, 0}, new double[] { 0, -0, 0, -0}, new double[] { -0, 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0}, new double[] { -0, 0, -0, 0}, new double[] { 0, -0, 0, -0}, new double[] { -0, 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4IdentityJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0}, new double[] { -0, 0, -0, 0}, new double[] { 0, -0, 0, -0}, new double[] { -0, 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5ElevensJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Elevens Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0, 0}, new double[] { -0, 0, -0, 0, -0}, new double[] { 0, -0, 0, -0, 0}, new double[] { -0, 0, -0, 0, -0}, new double[] { 0, -0, 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Incremental Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0, 0}, new double[] { -0, 0, -0, 0, -0}, new double[] { 0, -0, 0, -0, 0}, new double[] { -0, 0, -0, 0, -0}, new double[] { 0, -0, 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5IdentityJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Identity Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0, 0}, new double[] { -0, 0, -0, 0, -0}, new double[] { 0, -0, 0, -0, 0}, new double[] { -0, 0, -0, 0, -0}, new double[] { 0, -0, 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6ElevensJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Elevens Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0}, new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0}, new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Incremental Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0}, new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0}, new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6IdentityJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Identity Tuple", trials: trials, expectedReturnValue: new double[][] { new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0}, new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0}, new double[] { 0, -0, 0, -0, 0, -0}, new double[] { -0, 0, -0, 0, -0, 0} }, epsilon: double.Epsilon) },
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
        /// Adjoints the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[][] Adjoint(double[][] matrix)
            => Adjoint1(matrix);

        /// <summary>
        /// Function to get adjoint of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        //[DisplayName("Matrix Adjoint")]
        //[Description("Adjoint a matrix.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/adjoint-inverse-matrix/")]
        //[SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Adjoint1(double[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rows = matrix.Length;
            var cols = matrix[0].Length;

            if (rows == 1)
            {
                return new double[][] { new double[] { 1d } };
            }

            var adj = new double[rows][];
            for (var i = 0; i < rows; i++)
            {
                adj[i] = new double[cols];
            }
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    // Get cofactor of A[i,j] 
                    var temp = JaggedMatrixSparseCofactorTests.Cofactor(matrix, i, j);

                    // Sign of adj[j,i] positive if sum of row and column indexes is even. 
                    var sign = ((i + j) % 2d == 0d) ? 1d : -1d;

                    // Interchanging rows and columns to get the  transpose of the cofactor matrix 
                    adj[j][i] = sign * JaggedMatrixDeterminantTests.Determinant(temp);
                }
            }

            return adj;
        }

        /// <summary>
        /// The adjoint of a matrix is defined as the transpose of the matrix of its co-factors
        /// </summary>
        /// <returns>The adjoint of the matrix</returns>
        /// <returns>
        /// Determinant of the matrix
        /// </returns>
        [DisplayName("Matrix Adjoint")]
        [Description("Adjoint a matrix.")]
        [Acknowledgment("https://github.com/PigDogBay/MpdbSharedLibrary/blob/master/MpdbSharedLibrary/Maths/Matrix.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Adjoint2(double[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            if (cols != rows)
            {
                throw new InvalidOperationException("Matrix must have the same number of rows and columns for the adjoint to be calculated");
            }
            // create array to hold the adjoint elements
            var tmpArray = new double[cols][];
            for (var y = 0; y < rows; y++)
            {
                tmpArray[y] = new double[rows];
                for (var x = 0; x < cols; x++)
                {
                    tmpArray[y][x] = JaggedMatrixSparseCofactorCellTests.CoFactor(matrix, x, y);
                }
            }
            // ignore the scalar, as the CoFactor() will take of that
            return tmpArray;
        }
    }
}
