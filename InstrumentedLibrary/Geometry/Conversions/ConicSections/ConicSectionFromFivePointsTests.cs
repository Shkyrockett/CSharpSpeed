using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConicSectionFromFivePointsTests
    {
        /// <summary>
        /// Finds the conic section.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/select-a-conic-section-in-c/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) FindConicSectionSextic(Point2D a, Point2D b, Point2D c, Point2D d, Point2D e)
        {
            const int rows = 5;
            const int cols = 5;

            // Build the augmented matrix.
            var points = new[] { a, b, c, d, e };
            var arr = new double[rows, cols + 2];
            for (var row = 0; row < rows; row++)
            {
                arr[row, 0] = points[row].X * points[row].X;
                arr[row, 1] = points[row].X * points[row].Y;
                arr[row, 2] = points[row].Y * points[row].Y;
                arr[row, 3] = points[row].X;
                arr[row, 4] = points[row].Y;
                arr[row, 5] = -1;
                arr[row, 6] = 0;
            }

            // Perform Gaussian elimination.
            for (var r = 0; r < rows - 1; r++)
            {
                // Zero out all entries in column r after this row.
                // See if this row has a non-zero entry in column r.
                if (Abs(arr[r, r]) < double.Epsilon)
                {
                    // Too close to zero. Try to swap with a later row.
                    for (var r2 = r + 1; r2 < rows; r2++)
                    {
                        if (Abs(arr[r2, r]) > double.Epsilon)
                        {
                            // This row will work. Swap them.
                            for (var j = 0; j <= cols; j++)
                            {
                                var tmp = arr[r, j];
                                arr[r, j] = arr[r2, j];
                                arr[r2, j] = tmp;
                            }
                            break;
                        }
                    }
                }

                // If this row has a non-zero entry in column r, use it.
                if (Abs(arr[r, r]) > double.Epsilon)
                {
                    // Zero out this column in later rows.
                    for (var r2 = r + 1; r2 < rows; r2++)
                    {
                        var factor = -arr[r2, r] / arr[r, r];
                        for (var j = r; j <= cols; j++)
                        {
                            arr[r2, j] = arr[r2, j] + factor * arr[r, j];
                        }
                    }
                }
            }

            // See if we have a solution.
            if (arr[rows - 1, cols - 1] == 0)
            {
                // We have no solution.
                // See if all of the entries in this row are 0.
                var all_zeros = true;
                for (var j = 0; j <= cols + 1; j++)
                {
                    if (arr[rows - 1, j] != 0)
                    {
                        all_zeros = false;
                        break;
                    }
                }
                if (all_zeros)
                {
                    //MessageBox.Show("The solution is not unique");
                }
                else
                {
                    //MessageBox.Show("There is no solution");
                }
                return (0, 0, 0, 0, 0, 0);
            }
            else
            {
                // Back solve.
                for (var r = rows - 1; r >= 0; r--)
                {
                    var tmp = arr[r, cols];
                    for (var r2 = r + 1; r2 < rows; r2++)
                    {
                        tmp -= arr[r, r2] * arr[r2, cols + 1];
                    }

                    arr[r, cols + 1] = tmp / arr[r, r];
                }

                // Return the results.
                return (arr[0, cols + 1], arr[1, cols + 1], arr[2, cols + 1], arr[3, cols + 1], arr[4, cols + 1], 1);
            }
        }
    }
}
