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
    public static class BounceOutPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double BounceOut(double t)
            => BounceOut1( t);

        /// <summary>
        /// Bounce out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BounceOut1(double t)
        {
            if (t < BounceKey1)
            {
                return BounceMultiplyer * t * t;
            }

            if (t < BounceKey2)
            {
                return (BounceMultiplyer * (t - BounceKey3) * (t - BounceKey3)) + ThreeQuarters;
            }

            if (t < BounceKey4)
            {
                return (BounceMultiplyer * (t - BounceKey5) * (t - BounceKey5)) + FifteenSixteenth;
            }

            return (BounceMultiplyer * (t - BounceKey6) * (t - BounceKey6)) + SixtythreeSixtyfourth;
        }
    }
}
