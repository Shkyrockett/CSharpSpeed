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
    public static class BounceInOutValueEasingTests
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
        public static double BounceEaseInOut(double t, double b, double c, double d)
            => BounceEaseInOut1( t,  b,  c,  d);

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
        public static double BounceEaseInOut1(double t, double b, double c, double d)
        {
            if (t < d * OneHalf)
            {
                return (BounceInValueEasingTests.BounceIn(t * 2d, 0d, c, d) * OneHalf) + b;
            }
            else
            {
                return (BounceOutValueEasingTests.BounceOut((t * 2d) - d, 0d, c, d) * OneHalf) + (c * OneHalf) + b;
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
        public static double BounceEaseInOut0(double t, double b, double c, double d)
        {
            return (t < d * OneHalf) ? (BounceInValueEasingTests.BounceIn(t * 2d, 0d, c, d) * OneHalf) + b : (BounceOutValueEasingTests.BounceOut((t * 2d) - d, 0d, c, d) * OneHalf) + (c * OneHalf) + b;
        }
    }
}
