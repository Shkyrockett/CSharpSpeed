using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.EasingConstants;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class BounceOutValueEasingTests
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
        public static double BounceOut(double t, double b, double c, double d)
            => BounceOut1(t, b, c, d);

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out:
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
        public static double BounceOut1(double t, double b, double c, double d)
        {
            if ((t /= d) < (BounceKey1))
            {
                return (c * (BounceMultiplier * t * t)) + b;
            }
            else if (t < (BounceKey2))
            {
                return (c * ((BounceMultiplier * (t -= BounceKey3) * t) + ThreeQuarters)) + b;
            }
            else if (t < (BounceKey4))
            {
                return (c * ((BounceMultiplier * (t -= BounceKey5) * t) + FifteenSixteenth)) + b;
            }
            else
            {
                return (c * ((BounceMultiplier * (t -= BounceKey6) * t) + SixtythreeSixtyfourth)) + b;
            }
        }
    }
}
