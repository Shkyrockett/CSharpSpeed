﻿using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class CubicInValueEasingTests
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
        public static double CubicIn(double t, double b, double c, double d)
            => CubicIn1(t, b, c, d);

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing in:
        /// accelerating from zero velocity.
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
        public static double CubicIn1(double t, double b, double c, double d)
        {
            return (c * (t /= d) * t * t) + b;
        }
    }
}
