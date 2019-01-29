using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class MatrixDistortTests
    {
        /// <summary>
        /// The matrix distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Matrix(Point2D point, Matrix3x2D matrix)
        {
            return matrix.Transform(point);
        }
    }
}
