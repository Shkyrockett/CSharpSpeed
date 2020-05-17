using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class SineOutInPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double SineOutIn(double t)
            => SineOutIn1(t);

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in/out:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SineOutIn1(double t)
        {
            return (t < OneHalf) ? SineOutPercentageEasingTests.SineOut(t * 2d) : SineInPercentageEasingTests.SineIn((t * 2d) - 1d);
        }
    }
}
