using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class MultiDimentional3DArrayToJaggedArrayTests
    {
        /// <summary>
        /// Converts to jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="threeDimensionalArray">The three dimensional array.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/25995025
        /// </acknowledgment>
        public static T[][][] ToJaggedArray<T>(this T[,,] threeDimensionalArray)
        {
            var rowsFirstIndex = threeDimensionalArray.GetLowerBound(0);
            var rowsLastIndex = threeDimensionalArray.GetUpperBound(0);
            var numberOfRows = rowsLastIndex + 1;

            var columnsFirstIndex = threeDimensionalArray.GetLowerBound(1);
            var columnsLastIndex = threeDimensionalArray.GetUpperBound(1);
            var numberOfColumns = columnsLastIndex + 1;

            var dFirstIndex = threeDimensionalArray.GetLowerBound(2);
            var dLastIndex = threeDimensionalArray.GetUpperBound(2);
            var numberOfD = dLastIndex + 1;

            var jaggedArray = new T[numberOfRows][][];
            for (var i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns][];
                for (var j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = new T[numberOfD];
                    for (var k = dFirstIndex; k <= dLastIndex; k++)
                    {
                        jaggedArray[i][j][k] = threeDimensionalArray[i, j, k];

                    }
                }
            }

            return jaggedArray;
        }
    }
}
