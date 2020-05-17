using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ElasticInOutPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ElasticInOut(double t)
            => ElasticInOut1(t);

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
        public static double ElasticInOut1(double t)
        {
            return (t < OneHalf) ? (OneHalf * Sin(13d * HalfPi * (2d * t)) * Pow(2d, 10d * ((2d * t) - 1d))) : (OneHalf * ((Sin(-13d * HalfPi * ((2d * t) - 1 + 1d)) * Pow(2d, -10d * ((2d * t) - 1d))) + 2d));
        }
    }
}
