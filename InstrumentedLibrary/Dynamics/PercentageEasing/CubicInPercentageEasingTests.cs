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
    public static class CubicInPercentageEasingTests
    {
        /// <summary>
        /// Easing equation function for a cubic (t^3) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicIn(double t)
        {
            return t * t * t;
        }
    }
}