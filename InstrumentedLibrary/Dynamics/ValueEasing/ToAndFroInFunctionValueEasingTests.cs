using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ToAndFroInFunctionValueEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="easer"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Func<double, double> ToAndFro(Func<double, double> easer, double b, double c, double d)
            => ToAndFro1(easer, b, c, d);

        /// <summary>
        /// Ease a value to its target and then back. Use this to wrap another easing function.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<double, double> ToAndFro1(Func<double, double> easer, double b, double c, double d)
        {
            return t => ToAndFroValueEasingTests.ToAndFro(easer(t), b, c, d);
        }
    }
}
