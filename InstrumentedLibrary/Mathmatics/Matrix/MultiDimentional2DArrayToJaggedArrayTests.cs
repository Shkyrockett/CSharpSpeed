using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Convert a 2D array to a Jagged array")]
    [Description("Convert a 2D array to a Jagged array.")]
    [SourceCodeLocationProvider]
    public static class MultiDimentional2DArrayToJaggedArrayTests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MultiDimentional2DArrayToJaggedArrayTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { MatrixTestCases.MatrixScalarIdentity2DArray }, new TestCaseResults(description: "Matrix2x2Scalor", trials: trials, expectedReturnValue: new double[][] { new double[] {1d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.MatrixScalarElevens2DArray }, new TestCaseResults(description: "Matrix2x2Scalor", trials: trials, expectedReturnValue: new double[][] { new double[] {11d} }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2Elevens2DArray }, new TestCaseResults(description: "Matrix2x2 Elevens", trials: trials, expectedReturnValue: new double[][] { new double[] { 11d, 12d }, new double[] { 21d, 22d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2Incremental2DArray }, new TestCaseResults(description: "Matrix2x2 Incremental", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 2d }, new double[] { 3d, 4d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2Identity2DArray }, new TestCaseResults(description: "Matrix2x2 Identity", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 0d }, new double[] { 0d, 1d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Elevens2DArray }, new TestCaseResults(description: "Matrix3x3 Elevens", trials: trials, expectedReturnValue: new double[][] { new double[] { 11d, 12d, 13d }, new double[] { 21d, 22d, 23d }, new double[] { 31d, 32d, 33d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Incremental2DArray }, new TestCaseResults(description: "Matrix3x3 Incremental", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 2d, 3d }, new double[] { 4d, 5d, 6d }, new double[] { 7d, 8d, 9d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3Identity2DArray }, new TestCaseResults(description: "Matrix3x3 Identity", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 0d, 0d }, new double[] { 0d, 1d, 0d }, new double[] { 0d, 0d, 1d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Elevens2DArray }, new TestCaseResults(description: "Matrix4x4 Elevens", trials: trials, expectedReturnValue: new double[][] { new double[] { 11d, 12d, 13d, 14d }, new double[] { 21d, 22d, 23d, 24d }, new double[] { 31d, 32d, 33d, 34d }, new double[] { 41d, 42d, 43d, 44d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Incremental2DArray }, new TestCaseResults(description: "Matrix4x4 Incremental", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 2d, 3d, 4d }, new double[] { 5d, 6d, 7d, 8d }, new double[] { 9d, 10d, 11d, 12d }, new double[] { 13d, 14d, 15d, 16d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4Identity2DArray }, new TestCaseResults(description: "Matrix4x4 Identity", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 0d, 0d, 0d }, new double[] { 0d, 1d, 0d, 0d }, new double[] { 0d, 0d, 1d, 0d }, new double[] { 0d, 0d, 0d, 1d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Elevens2DArray }, new TestCaseResults(description: "Matrix5x5 Elevens", trials: trials, expectedReturnValue: new double[][] { new double[] { 11d, 12d, 13d, 14d, 15d }, new double[] { 21d, 22d, 23d, 24d, 25d }, new double[] { 31d, 32d, 33d, 34d, 35d }, new double[] { 41d, 42d, 43d, 44d, 45d }, new double[] { 51d, 52d, 53d, 54d, 55d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Incremental2DArray }, new TestCaseResults(description: "Matrix5x5 Incremental", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 2d, 3d, 4d, 5d }, new double[] { 6d, 7d, 8d, 9d, 10d }, new double[] { 11d, 12d, 13d, 14d, 15d }, new double[] { 16d, 17d, 18d, 19d, 20d }, new double[] { 21d, 22d, 23d, 24d, 25d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5Identity2DArray }, new TestCaseResults(description: "Matrix5x5 Identity", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 0d, 0d, 0d, 0d }, new double[] { 0d, 1d, 0d, 0d, 0d }, new double[] { 0d, 0d, 1d, 0d, 0d }, new double[] { 0d, 0d, 0d, 1d, 0d }, new double[] { 0d, 0d, 0d, 0d, 1d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Elevens2DArray }, new TestCaseResults(description: "Matrix6x6 Elevens", trials: trials, expectedReturnValue: new double[][] { new double[] { 11d, 12d, 13d, 14d, 15d, 16d }, new double[] { 21d, 22d, 23d, 24d, 25d, 26d }, new double[] { 31d, 32d, 33d, 34d, 35d, 36d }, new double[] { 41d, 42d, 43d, 44d, 45d, 46d }, new double[] { 51d, 52d, 53d, 54d, 55d, 56d }, new double[] { 61d, 62d, 63d, 64d, 65d, 66d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Incremental2DArray }, new TestCaseResults(description: "Matrix6x6 Incremental", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 2d, 3d, 4d, 5d, 6d }, new double[] { 7d, 8d, 9d, 10d, 11d, 12d }, new double[] { 13d, 14d, 15d, 16d, 17d, 18d }, new double[] { 19d, 20d, 21d, 22d, 23d, 24d }, new double[] { 25d, 26d, 27d, 28d, 29d, 30d }, new double[] { 31d, 32d, 33d, 34d, 35d, 36d } }, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6Identity2DArray }, new TestCaseResults(description: "Matrix6x6 Identity", trials: trials, expectedReturnValue: new double[][] { new double[] { 1d, 0d, 0d, 0d, 0d, 0d }, new double[] { 0d, 1d, 0d, 0d, 0d, 0d }, new double[] { 0d, 0d, 1d, 0d, 0d, 0d }, new double[] { 0d, 0d, 0d, 1d, 0d, 0d }, new double[] { 0d, 0d, 0d, 0d, 1d, 0d }, new double[] { 0d, 0d, 0d, 0d, 0d, 1d } }, epsilon: double.Epsilon) },
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
        /// Converts to jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The two dimensional array.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[][] ToJaggedArray(this double[,] array)
            => ToJaggedArray00(array);

        /// <summary>
        /// Converts to jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The two dimensional array.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/25995025
        /// </acknowledgment>
        [DisplayName("Convert a 2D array to a Jagged array")]
        [Description("Convert a 2D array to a Jagged array.")]
        [Acknowledgment("https://stackoverflow.com/a/25995025")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] ToJaggedArray0(this double[,] array)
            => ToJaggedArray00(array);

        /// <summary>
        /// Converts to jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The two dimensional array.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/25995025
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[][] ToJaggedArray00<T>(this T[,] array)
        {
            var rowsFirstIndex = array.GetLowerBound(0);
            var rowsLastIndex = array.GetUpperBound(0);
            var numberOfRows = rowsLastIndex + 1;

            var columnsFirstIndex = array.GetLowerBound(1);
            var columnsLastIndex = array.GetUpperBound(1);
            var numberOfColumns = columnsLastIndex + 1;

            var jaggedArray = new T[numberOfRows][];
            for (var i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (var j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = array[i, j];
                }
            }

            return jaggedArray;
        }

        /// <summary>
        /// Converts to jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/YanjieHe/MatrixLibrary/blob/master/LinearAlgebra/LinearAlgebra/MatrixAlgebra/Matrix.cs
        /// </acknowledgment>
        [DisplayName("Convert a 2D array to a Jagged array")]
        [Description("Convert a 2D array to a Jagged array.")]
        [Acknowledgment("https://github.com/YanjieHe/MatrixLibrary/blob/master/LinearAlgebra/LinearAlgebra/MatrixAlgebra/Matrix.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe double[][] ToJaggedArray1(this double[,] array)
            => ToJaggedArray10(array);

        /// <summary>
        /// Converts to jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/YanjieHe/MatrixLibrary/blob/master/LinearAlgebra/LinearAlgebra/MatrixAlgebra/Matrix.cs
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T[][] ToJaggedArray10<T>(this T[,] array)
        {
            var size = Marshal.SizeOf(default(T));
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);
            var arr = new T[rows][];
            for (var i = 0; i < rows; i++)
            {
                arr[i] = new T[cols];
                Buffer.BlockCopy(array, i * cols * size, arr[i], 0, cols * size);
            }

            return arr;
        }

        ///// <summary>
        ///// Converts to jagged array.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        ///// <acknowledgment>
        ///// https://github.com/YanjieHe/MatrixLibrary/blob/master/LinearAlgebra/LinearAlgebra/MatrixAlgebra/Matrix.cs
        ///// </acknowledgment>
        //[DisplayName("Convert a 2D array to a Jagged array")]
        //[Description("Convert a 2D array to a Jagged array.")]
        //[Acknowledgment("https://github.com/YanjieHe/MatrixLibrary/blob/master/LinearAlgebra/LinearAlgebra/MatrixAlgebra/Matrix.cs")]
        //[SourceCodeLocationProvider]
        ////[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static double[][] ToJaggedArray2(this double[,] array)
        //    => ToJaggedArray20(array);

        ///// <summary>
        ///// Converts to jagged array.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        ///// <acknowledgment>
        ///// https://github.com/YanjieHe/MatrixLibrary/blob/master/LinearAlgebra/LinearAlgebra/MatrixAlgebra/Matrix.cs
        ///// </acknowledgment>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[][] ToJaggedArray20<T>(this T[,] array)
        //{
        //    var rows = array.GetLength(0);
        //    var cols = array.GetLength(1);
        //    var arr = new T[rows][];
        //    for (var i = 0; i < rows; i++)
        //    {
        //        arr[i] = new T[cols];
        //        Array.Copy(array, i * cols, arr[i], 0, cols);
        //    }

        //    return arr;
        //}
    }
}
