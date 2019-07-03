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
    public static class QuarticOutInValueEasingTests
    {
        /// <summary>
        /// Easing equation function for a quartic (t^4) easing out/in:
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
        public static double QuartOutIn(double t, double b, double c, double d)
        {
            return (t < d / 2d) ? QuarticOutValueEasingTests.QuartOut(t * 2d, b, c / 2d, d) : QuarticInValueEasingTests.QuartIn((t * 2d) - d, b + (c / 2d), c / 2d, d);
        }
    }
}
