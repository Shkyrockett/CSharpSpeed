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
    public static class SineOutPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double SineOut(double t)
            => SineOut1(t);

        /// <summary>
        /// Sine out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SineOut1(double t)
        {
            return Sin(HalfPi * t);
        }
    }
}
