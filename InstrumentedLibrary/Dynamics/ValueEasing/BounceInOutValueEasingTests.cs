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
    public static class BounceInOutValueEasingTests
    {
        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in/out:
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
        public static double BounceEaseInOut(double t, double b, double c, double d)
        {
            if (t < d / 2d)
            {
                return (BounceInValueEasingTests.BounceIn(t * 2d, 0d, c, d) * 0.5d) + b;
            }
            else
            {
                return (BounceOutValueEasingTests.BounceOut((t * 2d) - d, 0d, c, d) * 0.5d) + (c * 0.5d) + b;
            }
        }

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in/out:
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
        public static double BounceEaseInOut_0(double t, double b, double c, double d)
        {
            return (t < d / 2d) ? (BounceInValueEasingTests.BounceIn(t * 2d, 0d, c, d) * 0.5d) + b : (BounceOutValueEasingTests.BounceOut((t * 2d) - d, 0d, c, d) * 0.5d) + (c * 0.5d) + b;
        }
    }
}
