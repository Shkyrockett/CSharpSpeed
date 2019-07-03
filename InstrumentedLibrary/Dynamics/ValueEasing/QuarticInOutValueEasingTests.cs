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
    public static class QuarticInOutValueEasingTests
    {
        /// <summary>
        /// Easing equation function for a quartic (t^4) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuartInOut(double t, double b, double c, double d)
        {
            return ((t /= d / 2d) < 1d) ? (c / 2d * t * t * t * t) + b : (-c / 2d * (((t -= 2d) * t * t * t) - 2d)) + b;
        }
    }
}
