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
    public static class BounceInOutPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double BounceInOut(double t)
            => BounceInOut1( t);

        /// <summary>
        /// Bounce in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BounceInOut1(double t)
        {
            if (t < OneHalf)
            {
                t = 1d - (t * 2d);
                if (t < BounceKey1)
                {
                    return (1d - BounceMultiplier * t * t) * OneHalf;
                }

                if (t < BounceKey2)
                {
                    return (1d - (BounceMultiplier * (t - BounceKey3) * (t - BounceKey3) + ThreeQuarters)) * OneHalf;
                }

                if (t < BounceKey4)
                {
                    return (1d - (BounceMultiplier * (t - BounceKey5) * (t - BounceKey5) + FifteenSixteenth)) * OneHalf;
                }

                return (1d - (BounceMultiplier * (t - BounceKey6) * (t - BounceKey6) + SixtythreeSixtyfourth)) * OneHalf;
            }

            t = (t * 2d) - 1d;
            if (t < BounceKey1)
            {
                return BounceMultiplier * t * t * OneHalf + OneHalf;
            }

            if (t < BounceKey2)
            {
                return ((BounceMultiplier * (t - BounceKey3) * (t - BounceKey3) + ThreeQuarters) * OneHalf) + OneHalf;
            }

            if (t < BounceKey4)
            {
                return ((BounceMultiplier * (t - BounceKey5) * (t - BounceKey5) + FifteenSixteenth) * OneHalf) + OneHalf;
            }

            return ((BounceMultiplier * (t - BounceKey6) * (t - BounceKey6) + SixtythreeSixtyfourth) * OneHalf) + OneHalf;
        }
    }
}
