using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using static InstrumentedLibrary.EasingConstants;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class QuinticOutInValueEasingTests
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
        public static double QuintOutIn(double t, double b, double c, double d)
            => QuintOutIn1( t,  b,  c,  d);

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in/out:
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
        public static double QuintOutIn1(double t, double b, double c, double d)
        {
            return (t < d * OneHalf) ? QuinticOutValueEasingTests.QuintOut(t * 2d, b, c * OneHalf, d) : QuinticInValueEasingTests.QuintIn((t * 2d) - d, b + (c * OneHalf), c * OneHalf, d);
        }
    }
}
