using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExponentialOutValueEasingTests
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
        public static double ExpoOut(double t, double b, double c, double d)
            => ExpoOut1(t, b, c, d);

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing out:
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
        public static double ExpoOut1(double t, double b, double c, double d)
        {
            return (t == d) ? b + c : (c * (-Pow(2d, -10d * t / d) + 1d)) + b;
        }
    }
}
