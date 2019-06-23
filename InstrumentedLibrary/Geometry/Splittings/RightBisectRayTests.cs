﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RightBisectRayTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="T:Shape[]"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IShapeSegment RightBisectRay(double x, double y, double i, double j, double t)
        {
            var (X, Y) = InterpolateLinear2DTests.LinearInterpolate2D(x, y, x + i, y + j, t);

            return new Ray2D(X, Y, i, j);
        }
    }
}
