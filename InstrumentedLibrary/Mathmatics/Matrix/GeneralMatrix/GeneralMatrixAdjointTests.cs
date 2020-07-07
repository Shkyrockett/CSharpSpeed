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
    public static class GeneralMatrixAdjointTests
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
                { new object[] { MatrixTestCases.MatrixScalarIdentity2DArray }, new TestCaseResults(description: "Matrix2x2Scalor", trials: trials, expectedReturnValue: new double[,] { {0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.MatrixScalarElevens2DArray }, new TestCaseResults(description: "Matrix2x2Scalor", trials: trials, expectedReturnValue: new double[,] { {0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2Elevens2DArray }, new TestCaseResults(description: "Matrix2x2 Elevens Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d}, { -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2Incremental2DArray }, new TestCaseResults(description: "Matrix2x2 Incremental Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d}, { -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2Identity2DArray }, new TestCaseResults(description: "Matrix2x2 Identity Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d}, { -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Elevens2DArray }, new TestCaseResults(description: "Matrix3x3 Elevens Array", trials: trials, expectedReturnValue: new double[,] { { -10d, 20d, -10d}, { 20d, -40d, 20d}, { -10d, 20d, -10d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Incremental2DArray }, new TestCaseResults(description: "Matrix3x3 Incremental Array", trials: trials, expectedReturnValue: new double[,] { { -3d, 6d, -3d}, { 6d, -12d, 6d}, { -3d, 6d, -3d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Identity2DArray }, new TestCaseResults(description: "Matrix3x3 Identity Array", trials: trials, expectedReturnValue: new double[,] { { 1d, -0d, 0d}, { -0d, 1d, -0d}, { 0d, -0d, 1d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Elevens2DArray }, new TestCaseResults(description: "Matrix4x4 Elevens Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d}, { 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Incremental2DArray }, new TestCaseResults(description: "Matrix4x4 Incremental Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d}, { 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Identity2DArray }, new TestCaseResults(description: "Matrix4x4 Identity Array", trials: trials, expectedReturnValue: new double[,] { { 1d, -0d, 0d, -0d}, { -0d, 1d, -0d, 0d}, { 0d, -0d, 1d, -0d}, { -0d, 0d, -0d, 1d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Elevens2DArray }, new TestCaseResults(description: "Matrix5x5 Elevens Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d, 0d, -0d, 0d}, { -0d, 0d, -0d, 0d, -0d}, { 0d, -0d, 0d, -0d, 0d}, { -0d, 0d, -0d, 0d, -0d}, { 0d, -0d, 0d, -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Incremental2DArray }, new TestCaseResults(description: "Matrix5x5 Incremental Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d, 0d, -0d, 0d}, { -0d, 0d, -0d, 0d, -0d}, { 0d, -0d, 0d, -0d, 0d}, { -0d, 0d, -0d, 0d, -0d}, { 0d, -0d, 0d, -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Identity2DArray }, new TestCaseResults(description: "Matrix5x5 Identity Array", trials: trials, expectedReturnValue: new double[,] { { 1d, -0d, 0d, -0d, 0d}, { -0d, 1d, -0d, 0d, -0d}, { 0d, -0d, 1d, -0d, 0d}, { -0d, 0d, -0d, 1d, -0d}, { 0d, -0d, 0d, -0d, 1d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Elevens2DArray }, new TestCaseResults(description: "Matrix6x6 Elevens Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d, 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d, -0d, 0d}, { 0d, -0d, 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d, -0d, 0d}, { 0d, -0d, 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d, -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Incremental2DArray }, new TestCaseResults(description: "Matrix6x6 Incremental Array", trials: trials, expectedReturnValue: new double[,] { { 0d, -0d, 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d, -0d, 0d}, { 0d, -0d, 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d, -0d, 0d}, { 0d, -0d, 0d, -0d, 0d, -0d}, { -0d, 0d, -0d, 0d, -0d, 0d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Identity2DArray }, new TestCaseResults(description: "Matrix6x6 Identity Array", trials: trials, expectedReturnValue: new double[,] { { 1d, -0d, 0d, -0d, 0d, -0d}, { -0d, 1d, -0d, 0d, -0d, 0d}, { 0d, -0d, 1d, -0d, 0d, -0d}, { -0d, 0d, -0d, 1d, -0d, 0d}, { 0d, -0d, 0d, -0d, 1d, -0d}, { -0d, 0d, -0d, 0d, -0d, 1d} }, epsilon: double.Epsilon) },
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
        public static double[,] Adjoint(double[,] matrix)
            => Adjoint1(matrix);

        /// <summary>
        /// Adjoint0s the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [DisplayName("Matrix Adjoint")]
        [Description("Adjoint a matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Adjoint0(double[,] matrix)
        {
            switch (matrix?.GetLength(0))
            {
                case null: return null;
                case 2:
                    {
                        var (
                            r1c1, r1c2,
                            r2c1, r2c2
                            ) = MatrixAdjoint2x2Tests.Adjoint(
                            matrix[0, 0], matrix[0, 1],
                            matrix[1, 0], matrix[1, 1]);
                        return new double[,]
                        {
                            { r1c1, r1c2 },
                            { r2c1, r2c2 }
                        };
                    }
                case 3:
                    {
                        var (
                            m1x1, m1x2, m1x3,
                            m2x1, m2x2, m2x3,
                            m3x1, m3x2, m3x3
                            ) = MatrixAdjoint3x3Tests.Adjoint(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2]);
                        return new double[,]
                        {
                            { m1x1, m1x2, m1x3 },
                            { m2x1, m2x2, m2x3 },
                            { m3x1, m3x2, m3x3 }
                        };
                    }
                case 4:
                    {
                        var (
                            m1x1, m1x2, m1x3, m1x4,
                            m2x1, m2x2, m2x3, m2x4,
                            m3x1, m3x2, m3x3, m3x4,
                            m4x1, m4x2, m4x3, m4x4
                            ) = MatrixAdjoint4x4Tests.Adjoint(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3]);
                        return new double[,]
                        {
                            { m1x1, m1x2, m1x3, m1x4 },
                            { m2x1, m2x2, m2x3, m2x4 },
                            { m3x1, m3x2, m3x3, m3x4 },
                            { m4x1, m4x2, m4x3, m4x4 }
                        };
                    }
                case 5:
                    {
                        var (
                            m1x1, m1x2, m1x3, m1x4, m1x5,
                            m2x1, m2x2, m2x3, m2x4, m2x5,
                            m3x1, m3x2, m3x3, m3x4, m3x5,
                            m4x1, m4x2, m4x3, m4x4, m4x5,
                            m5x1, m5x2, m5x3, m5x4, m5x5
                            ) = MatrixAdjoint5x5Tests.Adjoint(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3], matrix[0, 4],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3], matrix[1, 4],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3], matrix[2, 4],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3], matrix[3, 4],
                            matrix[4, 0], matrix[4, 1], matrix[4, 2], matrix[4, 3], matrix[4, 4]);
                        return new double[,]
                        {
                            { m1x1, m1x2, m1x3, m1x4, m1x5 },
                            { m2x1, m2x2, m2x3, m2x4, m2x5 },
                            { m3x1, m3x2, m3x3, m3x4, m3x5 },
                            { m4x1, m4x2, m4x3, m4x4, m4x5 },
                            { m5x1, m5x2, m5x3, m5x4, m5x5 }
                        };
                    }
                case 6:
                    {
                        var (
                            m1x1, m1x2, m1x3, m1x4, m1x5, m1x6,
                            m2x1, m2x2, m2x3, m2x4, m2x5, m2x6,
                            m3x1, m3x2, m3x3, m3x4, m3x5, m3x6,
                            m4x1, m4x2, m4x3, m4x4, m4x5, m4x6,
                            m5x1, m5x2, m5x3, m5x4, m5x5, m5x6,
                            m6x1, m6x2, m6x3, m6x4, m6x5, m6x6
                            ) = MatrixAdjoint6x6Tests.Adjoint(
                            matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3], matrix[0, 4], matrix[0, 5],
                            matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3], matrix[1, 4], matrix[1, 5],
                            matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3], matrix[2, 4], matrix[2, 5],
                            matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3], matrix[3, 4], matrix[3, 5],
                            matrix[4, 0], matrix[4, 1], matrix[4, 2], matrix[4, 3], matrix[4, 4], matrix[4, 5],
                            matrix[5, 0], matrix[5, 1], matrix[5, 2], matrix[5, 3], matrix[5, 4], matrix[5, 5]);
                        return new double[,]
                        {
                            { m1x1, m1x2, m1x3, m1x4, m1x5, m1x6 },
                            { m2x1, m2x2, m2x3, m2x4, m2x5, m2x6 },
                            { m3x1, m3x2, m3x3, m3x4, m3x5, m3x6 },
                            { m4x1, m4x2, m4x3, m4x4, m4x5, m4x6 },
                            { m5x1, m5x2, m5x3, m5x4, m5x5, m5x6 },
                            { m6x1, m6x2, m6x3, m6x4, m6x5, m6x6 }
                        };
                    }
                default:
                    return Adjoint(matrix);
            }
        }

        /// <summary>
        /// Function to get adjoint of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [DisplayName("Matrix Adjoint")]
        [Description("Adjoint a matrix.")]
        [Acknowledgment("https://www.geeksforgeeks.org/adjoint-inverse-matrix/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Adjoint1(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (rows == 1)
            {
                return new double[1, 1] { { 1d } };
            }

            var adj = new double[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    // Get cofactor of A[i,j] 
                    var temp = GeneralMatrixSparseCofactorTests.Cofactor(matrix, i, j);

                    // Sign of adj[j,i] positive if sum of row and column indexes is even. 
                    var sign = ((i + j) % 2d == 0d) ? 1d : -1d;

                    // Interchanging rows and columns to get the  transpose of the cofactor matrix 
                    adj[j, i] = sign * GeneralMatrixDeterminantTests.Determinant(temp);
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
        public static double[,] Adjoint2(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            if (cols != rows)
            {
                throw new InvalidOperationException("Matrix must have the same number of rows and columns for the adjoint to be calculated");
            }
            // create array to hold the adjoint elements
            var tmpArray = new double[cols, rows];
            for (var y = 0; y < rows; y++)
            {
                for (var x = 0; x < cols; x++)
                {
                    tmpArray[y, x] = GeneralMatrixSparseCofactorCellTests.CoFactor(matrix, x, y);
                }
            }
            // ignore the scalar, as the CoFactor() will take of that
            return tmpArray;
        }
    }
}
