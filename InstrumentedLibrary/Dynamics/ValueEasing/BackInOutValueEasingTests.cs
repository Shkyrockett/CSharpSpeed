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
    public static class BackInOutValueEasingTests
    {
        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in/out:
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
        public static double BackInOut(double t, double b, double c, double d)
        {
            var s = 1.70158d;
            return ((t /= d / 2d) < 1d) ? (c / 2d * (t * t * ((((s *= 1.525d) + 1d) * t) - s))) + b : (c / 2d * (((t -= 2d) * t * ((((s *= 1.525d) + 1d) * t) + s)) + 2d)) + b;
        }
    }
}
