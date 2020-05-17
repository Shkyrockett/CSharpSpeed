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
    public static class ElasticInPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ElasticIn(double t)
            => ElasticIn1(t);

        /// <summary>
        /// Elastic in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ElasticIn1(double t)
        {
            return Sin(13d * HalfPi * t) * Pow(2d, 10d * (t - 1d));
        }
    }
}
