﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class QuinticInValueEasingTests
    {
        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuintIn(double t, double b, double c, double d)
        {
            return (c * (t /= d) * t * t * t * t) + b;
        }
    }
}
