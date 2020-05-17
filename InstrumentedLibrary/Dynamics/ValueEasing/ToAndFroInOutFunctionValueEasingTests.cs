using CSharpSpeed;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ToAndFroInOutFunctionValueEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="easer1"></param>
        /// <param name="easer2"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Func<double, double> ToAndFro(Func<double, double> easer1, Func<double, double> easer2, double b, double c, double d)
            => ToAndFro1(easer1, easer2, b, c, d);

        /// <summary>
        /// Ease a value to its target and then back with another easing function. Use this to wrap two other easing functions.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<double, double> ToAndFro1(Func<double, double> easer1, Func<double, double> easer2, double b, double c, double d)
        {
            return t => (t < OneHalf) ? ToAndFroValueEasingTests.ToAndFro(easer1(t), b, c, d) : ToAndFroValueEasingTests.ToAndFro(easer2(t), b, c, d);
        }
    }
}
