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
    public static class BackInOutPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double BackInOut(double t)
            => BackInOut1(t);

        /// <summary>
        /// Back in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BackInOut1(double t)
        {
            t *= 2d;
            if (t < 1d)
            {
                return t * t * ((BackInKey1 * t) - BackInKey2) * OneHalf;
            }

            t--;
            return ((1d - ((--t) * t * ((-BackInKey1 * t) - BackInKey2))) * OneHalf) + OneHalf;
        }
    }
}
