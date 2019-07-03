using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExponentialInOutPercentageEasingTests
    {
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
        public static double ExpoInOut(double t)
        {
            return (Abs(t - 1d) < double.Epsilon) ? 1d : (t < 0.5d ? Pow(2d, 10d * ((t * 2d) - 1d)) * 0.5d : (-Pow(2d, -10d * ((t * 2d) - 1d)) + 2d) * 0.5d);
        }
    }
}
