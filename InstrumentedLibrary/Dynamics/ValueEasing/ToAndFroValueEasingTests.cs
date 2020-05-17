using CSharpSpeed;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ToAndFroValueEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ToAndFro(double t, double b, double c, double d)
            => ToAndFro1(t, b, c, d);

        /// <summary>
        /// Ease a value to its target and then back.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToAndFro1(double t, double b, double c, double d)
        {
            return (c * (t < OneHalf ? t * 2d : 1d + ((t - OneHalf) / OneHalf * -1d)) / d) + b;
        }
    }
}
