using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ElasticInOutPercentageEasingTests
    {
        /// <summary>
        /// Elastic in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ElasticInOut(double t)
        {
            return (t < 0.5d) ? (0.5d * Sin(13d * HalfPi * (2d * t)) * Pow(2d, 10d * ((2d * t) - 1d))) : (0.5d * ((Sin(-13d * HalfPi * ((2d * t) - 1 + 1d)) * Pow(2d, -10d * ((2d * t) - 1d))) + 2d));
        }
    }
}
