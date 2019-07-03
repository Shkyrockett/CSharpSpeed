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
    public static class BounceOutValueEasingTests
    {
        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out:
        /// decelerating from zero velocity.
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
        public static double BounceOut(double t, double b, double c, double d)
        {
            if ((t /= d) < (1d / 2.75d))
            {
                return (c * (7.5625d * t * t)) + b;
            }
            else if (t < (2d / 2.75d))
            {
                return (c * ((7.5625d * (t -= 1.5d / 2.75d) * t) + 0.75d)) + b;
            }
            else if (t < (2.5d / 2.75d))
            {
                return (c * ((7.5625d * (t -= 2.25d / 2.75d) * t) + 0.9375d)) + b;
            }
            else
            {
                return (c * ((7.5625d * (t -= 2.625d / 2.75d) * t) + 0.984375d)) + b;
            }
        }
    }
}
