﻿using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class CircularOutInValueEasingTests
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
        public static double CircOutIn(double t, double b, double c, double d)
            => CircOutIn1(t, b, c, d);

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
        public static double CircOutIn1(double t, double b, double c, double d)
        {
            return (t < d * OneHalf) ? CircularOutValueEasingTests.CircOut(t * 2d, b, c * OneHalf, d) : CircularInValueEasingTests.CircIn((t * 2d) - d, b + (c * OneHalf), c * OneHalf, d);
        }
    }
}
