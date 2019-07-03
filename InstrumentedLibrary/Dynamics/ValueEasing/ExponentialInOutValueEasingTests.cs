using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExponentialInOutValueEasingTests
    {
        /// <summary>
        /// Easing equation function for an exponential (2^t) easing in/out:
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
        public static double ExpoInOut(double t, double b, double c, double d)
        {
            if (t == 0)
            {
                return b;
            }

            if (t == d)
            {
                return b + c;
            }

            if ((t /= d / 2d) < 1d)
            {
                return (c / 2d * Pow(2d, 10d * (t - 1d))) + b;
            }

            return (c / 2d * (-Pow(2d, -10d * --t) + 2d)) + b;
        }

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing in/out:
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
        public static double ExpoInOut_0(double t, double b, double c, double d)
        {
            return (t == 0d) ? b : (t == d) ? b + c : ((t /= d / 2d) < 1d) ? (c / 2d * Pow(2d, 10d * (t - 1d))) + b : (c / 2d * (-Pow(2d, -10d * --t) + 2d)) + b;
        }
    }
}
