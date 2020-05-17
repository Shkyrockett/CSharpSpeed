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
    public static class CircularInOutPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CircInOut(double t)
            => CircInOut1(t);

        /// <summary>
        /// Circle in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CircInOut1(double t)
        {
            return t <= OneHalf ? (Sqrt(1d - (t * t * 4d)) - 1d) * -OneHalf : (Sqrt(1d - (((t * 2d) - 2d) * ((t * 2d) - 2d))) + 1d) * OneHalf;
        }
    }
}
