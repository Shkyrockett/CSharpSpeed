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
    [DisplayName("Transpose Matrix.")]
    [Description("Transposes a Matrix.")]
    [SourceCodeLocationProvider]
    public static class GeneralTransposeMatrixTests
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
        /// Transposes the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[,] Transpose(double[,] matrix)
            => Transpose1(matrix);

        /// <summary>
        /// Transpose the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        [DisplayName("Matrix Transpose")]
        [Description("Transpose a matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Transpose0(double[,] matrix)
        {
            switch (matrix?.GetLength(0))
            {
                case null: return null;
                case 2:
                    {
                        var (
                            r1c1, r1c2,
                            r2c1, r2c2
                            ) = MatrixTranspose2x2Tests.Transpose(
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
                            ) = MatrixTranspose3x3Tests.Transpose(
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
                            ) = MatrixTranspose4x4Tests.Transpose(
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
                            ) = MatrixTranspose5x5Tests.Transpose(
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
                            ) = MatrixTranspose6x6Tests.Transpose(
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
                    return Transpose(matrix);
            }
        }

        /// <summary>
        /// Returns the transpose of a matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L100
        /// </acknowledgment>
        [DisplayName("Transpose Matrix.")]
        [Description("Transposes a Matrix.")]
        [Acknowledgment("https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L100")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Transpose1(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var res = new double[cols, rows];
            for (var i = 0; i < cols; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    res[i, j] = matrix[j, i];
                }
            }

            return res;
        }
    }
}
