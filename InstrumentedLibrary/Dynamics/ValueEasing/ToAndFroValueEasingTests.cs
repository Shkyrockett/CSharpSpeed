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
    public static class ToAndFroValueEasingTests
    {
        /// <summary>
        /// Ease a value to its target and then back.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToAndFro(double t, double b, double c, double d)
        {
            return (c * (t < 0.5d ? t * 2d : 1d + ((t - 0.5d) / 0.5d * -1d)) / d) + b;
        }
    }
}
