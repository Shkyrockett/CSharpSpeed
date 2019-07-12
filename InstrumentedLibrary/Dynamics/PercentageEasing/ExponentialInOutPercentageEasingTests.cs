using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpSpeed;
using static System.Math;
using static InstrumentedLibrary.EasingConstants;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExponentialInOutPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ExpoInOut(double t)
            => ExpoInOut1( t);

        /// <summary>
        /// Exponential in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ExpoInOut1(double t)
        {
            return (Abs(t - 1d) < double.Epsilon) ? 1d : (t < OneHalf ? Pow(2d, 10d * ((t * 2d) - 1d)) * OneHalf : (-Pow(2d, -10d * ((t * 2d) - 1d)) + 2d) * OneHalf);
        }
    }
}
