using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.EasingConstants;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class BackInValueEasingTests
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
        public static double BackIn(double t, double b, double c, double d)
            => BackIn1(t, b, c, d);

        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in:
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
        public static double BackIn1(double t, double b, double c, double d)
        {
            return (c * (t /= d) * t * (((BackInKey2 + 1) * t) - BackInKey2)) + b;
        }
    }
}
