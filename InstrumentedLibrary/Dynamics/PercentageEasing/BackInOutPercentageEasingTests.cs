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
    public static class BackInOutPercentageEasingTests
    {
        /// <summary>
        /// Back in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BackInOut(double t)
        {
            t *= 2d;
            if (t < 1d)
            {
                return t * t * ((2.70158d * t) - 1.70158d) * 0.5d;
            }

            t--;
            return ((1d - ((--t) * t * ((-2.70158d * t) - 1.70158d))) * 0.5d) + 0.5d;
        }
    }
}
