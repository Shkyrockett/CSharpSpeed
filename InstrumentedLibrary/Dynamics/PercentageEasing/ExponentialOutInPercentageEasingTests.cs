﻿using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExponentialOutInPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ExpoOutIn(double t)
            => ExpoOutIn1(t);

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ExpoOutIn1(double t)
        {
            return (t < OneHalf) ? ExponentialOutPercentageEasingTests.ExpoOut(t * 2d) : ExponentialInPercentageEasingTests.ExpoIn((t * 2d) - 1d);
        }
    }
}
