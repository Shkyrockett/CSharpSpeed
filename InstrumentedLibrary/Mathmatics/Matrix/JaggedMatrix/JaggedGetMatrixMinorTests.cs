using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    public static class JaggedGetMatrixMinorTests
    {
        /// <summary>
        /// Gets the minor.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="xPos">The x position.</param>
        /// <param name="yPos">The y position.</param>
        /// <returns></returns>
        public static double[][] GetMinor(double[][] array, int xPos, int yPos)
        {
            var length = array.Length;
            // get the minor
            var minor = new double[length - 1][];
            for (var y = 0; y < length - 1; y++)
            {
                minor[y] = new double[length - 1];
            }
            var mY = 0;
            for (var y = 0; y < length; y++)
            {
                if (y == yPos)
                {
                    // skip this one
                    continue;
                }
                var mX = 0;
                for (var x = 0; x < length; x++)
                {
                    if (x == xPos)
                    {
                        // skip this one
                        continue;
                    }
                    minor[mY][mX] = array[y][x];
                    mX++;
                }
                mY++;
            }
            return minor;
        }
    }
}
