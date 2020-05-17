using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.EasingConstants;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class BackInPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double BackIn(double t)
            => BackIn1(t);

        /// <summary>
        /// Back in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BackIn1(double t)
        {
            return t * t * ((BackInKey1 * t) - BackInKey2);
        }
    }
}
