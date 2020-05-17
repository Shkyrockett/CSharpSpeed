using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class LinearPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Linear(double t)
            => Linear1(t);

        /// <summary>
        /// Easing equation function for a simple linear tweening, with no easing.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Linear1(double t)
        {
            return t;
        }
    }
}
