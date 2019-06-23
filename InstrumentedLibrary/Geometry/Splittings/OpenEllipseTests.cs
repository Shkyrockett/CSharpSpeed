using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class OpenEllipseTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="angle"></param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="EllipticalArc2D"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EllipticalArc2D OpenEllipse(double x, double y, double rX, double rY, double angle, double t)
        {
            if (t < 0d || t > 1d)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new EllipticalArc2D(x,y, rX, rY, angle, Maths.Tau * t, Maths.Tau);
        }
    }
}
