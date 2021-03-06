﻿using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ElasticOutValueEasingTests
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
        public static double ElasticOut(double t, double b, double c, double d)
            => ElasticOut1(t, b, c, d);

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing out:
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
        public static double ElasticOut1(double t, double b, double c, double d)
        {
            if ((t /= d) == 1d)
            {
                return b + c;
            }

            var p = d * 0.3d;
            var s = p * OneQuarter;

            return (c * Pow(2d, -10d * t) * Sin(((t * d) - s) * (2d * PI) / p)) + c + b;
        }
    }
}
