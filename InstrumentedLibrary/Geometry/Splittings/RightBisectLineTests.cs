using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RightBisectLineTests
    {
        /// <summary>
        /// Splits a line into two rays.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="t">The t.</param>
        /// <returns>The two Rays.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Ray2D RightBisectLine(double x, double y, double i, double j, double t)
        {
            var (hX, hY) = InterpolateLinear2DTests.LinearInterpolate2D(x, y, x + i, y + j, t);

            return new Ray2D(hX, hY, i, j);
        }
    }
}
