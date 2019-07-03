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
    public static class QuinticOutInPercentageEasingTests
    {
        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuintOutIn(double t)
        {
            return (t < 0.5d) ? QuinticOutPercentageEasingTests.QuintOut(t * 2d) : QuinticInPercentageEasingTests.QuintIn((t * 2d) - 1d);
        }
    }
}
