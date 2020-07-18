using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    public static class GeneralGetMatrixMinorTests
    {
        /// <summary>
        /// Gets the minor.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="xPos">The x position.</param>
        /// <param name="yPos">The y position.</param>
        /// <returns></returns>
        public static double[,] GetMinor(double[,] array, int xPos, int yPos)
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);

            // Get the minor
            var minor = new double[rows - 1, cols - 1];
            var mY = 0;
            for (var i = 0; i < rows; i++)
            {
                if (i == yPos)
                {
                    // Skip this one
                    continue;
                }
                var mX = 0;
                for (var j = 0; j < cols; j++)
                {
                    if (j == xPos)
                    {
                        // Skip this one
                        continue;
                    }

                    minor[mY, mX] = array[i, j];
                    mX++;
                }

                mY++;
            }
            return minor;
        }
    }
}
