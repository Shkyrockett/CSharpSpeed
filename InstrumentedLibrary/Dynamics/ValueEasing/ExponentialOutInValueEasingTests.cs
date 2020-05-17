using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExponentialOutInValueEasingTests
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
        public static double ExpoOutIn(double t, double b, double c, double d)
            => ExpoOutIn1(t, b, c, d);

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing out/in:
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
        public static double ExpoOutIn1(double t, double b, double c, double d)
        {
            return (t < d * OneHalf) ? ExponentialOutValueEasingTests.ExpoOut(t * 2d, b, c * OneHalf, d) : ExponentialInValueEasingTests.ExpoIn((t * 2d) - d, b + (c * OneHalf), c * OneHalf, d);
        }
    }
}
