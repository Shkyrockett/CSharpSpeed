using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class OpenCircleTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CircularArc2D OpenCircle(double x, double y, double radius, double t)
        {
            if (t < 0d || t > 1d)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new CircularArc2D(x, y, radius, Maths.Tau * t, Maths.Tau);
        }
    }
}
