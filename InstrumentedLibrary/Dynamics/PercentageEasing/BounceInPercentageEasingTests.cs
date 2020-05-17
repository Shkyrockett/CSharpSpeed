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
    public static class BounceInPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double BounceIn(double t)
            => BounceIn1(t);

        /// <summary>
        /// Bounce in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BounceIn1(double t)
        {
            t = 1d - t;
            if (t < BounceKey1)
            {
                return 1d - (BounceMultiplier * t * t);
            }

            if (t < BounceKey2)
            {
                return 1d - ((BounceMultiplier * (t - BounceKey3) * (t - BounceKey3)) + ThreeQuarters);
            }

            if (t < BounceKey4)
            {
                return 1d - ((BounceMultiplier * (t - BounceKey5) * (t - BounceKey5)) + FifteenSixteenth);
            }

            return 1d - ((BounceMultiplier * (t - BounceKey6) * (t - BounceKey6)) + SixtythreeSixtyfourth);
        }
    }
}
