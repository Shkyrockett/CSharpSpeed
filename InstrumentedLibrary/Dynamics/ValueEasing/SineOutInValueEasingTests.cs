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
    public static class SineOutInValueEasingTests
    {
        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in/out:
        /// deceleration until halfway, then acceleration.
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
        public static double SineOutIn(double t, double b, double c, double d)
        {
            return (t < d * 0.5d) ? SineOutValueEasingTests.SineOut(t * 2, b, c * 0.5d, d) : SineInValueEasingTests.SineIn((t * 2) - d, b + (c * 0.5d), c * 0.5d, d);
        }
    }
}
