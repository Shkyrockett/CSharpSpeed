using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class CubicOutInValueEasingTests
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
        public static double CubicOutIn(double t, double b, double c, double d)
            => CubicOutIn1(t, b, c, d);

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing out/in:
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
        public static double CubicOutIn1(double t, double b, double c, double d)
        {
            return (t < d * OneHalf) ? CubicOutValueTests.CubicOut(t * 2d, b, c * OneHalf, d) : CubicInValueEasingTests.CubicIn((t * 2d) - d, b + (c * OneHalf), c * OneHalf, d);
        }
    }
}
