using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.EasingConstants;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class BackOutPercentageEasingtests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double BackOut(double t)
            => BackOut1(t);

        /// <summary>
        /// Back out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BackOut1(double t)
        {
            return 1d - ((--t) * t * ((-BackInKey1 * t) - BackInKey2));
        }
    }
}
