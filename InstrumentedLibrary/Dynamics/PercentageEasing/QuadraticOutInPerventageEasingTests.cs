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
    public static class QuadraticOutInPerventageEasingTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double QuadOutIn(double t)
            => QuadOutIn1( t);

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadOutIn1(double t)
        {
            return (t < OneHalf) ? QuadraticOutPercentageEasingTests.QuadOut(t * 2d) : QuadraticInPercentageEasingTests.QuadIn((t * 2d) - 1d);
        }
    }
}
