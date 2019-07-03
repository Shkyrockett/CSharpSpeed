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
    public static class QuarticInOutPercentageEasingTests
    {
        /// <summary>
        /// Quart in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuartInOut(double t)
        {
            return t <= 0.5d ? t * t * t * t * 8d : ((1d - ((t = (t * 2d) - 2d) * t * t * t)) * 0.5d) + 0.5d;
        }
    }
}
