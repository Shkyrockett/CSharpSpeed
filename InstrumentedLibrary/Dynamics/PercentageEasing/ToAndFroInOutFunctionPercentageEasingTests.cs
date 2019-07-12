using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using static InstrumentedLibrary.EasingConstants;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ToAndFroInOutFunctionPercentageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="easer1"></param>
        /// <param name="easer2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Func<double, double> ToAndFro(Func<double, double> easer1, Func<double, double> easer2)
            => ToAndFro1( easer1,  easer2);

        /// <summary>
        /// Ease a value to its target and then back with another easing function. Use this to wrap two other easing functions.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<double, double> ToAndFro1(Func<double, double> easer1, Func<double, double> easer2)
        {
            return t => (t < OneHalf) ? ToAndFroPercentageEasingTests.ToAndFro(easer1(t)) : ToAndFroPercentageEasingTests.ToAndFro(easer2(t));
        }
    }
}
