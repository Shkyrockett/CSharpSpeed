using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpSpeed;
using static System.Math;
using static InstrumentedLibrary.EasingConstants;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class CircularInOutValueEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CircInOut(double t, double b, double c, double d)
            => CircInOut1( t,  b,  c,  d);

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing in/out:
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
        public static double CircInOut1(double t, double b, double c, double d)
        {
            return ((t /= d * OneHalf) < 1d) ? (-c * OneHalf * (Sqrt(1d - (t * t)) - 1d)) + b : (c * OneHalf * (Sqrt(1d - ((t -= 2d) * t)) + 1d)) + b;
        }
    }
}
