using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ElasticInOutValueEasingTests
    {
        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing in/out:
        /// acceleration until halfway, then deceleration.
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
        public static double ElasticInOut(double t, double b, double c, double d)
        {
            if ((t /= d / 2d) == 2d)
            {
                return b + c;
            }

            var p = d * (0.3d * 1.5d);
            var s = p / 4d;

            if (t < 1d)
            {
                return (-0.5d * (c * Pow(2d, 10d * (t -= 1d)) * Sin(((t * d) - s) * (2d * PI) / p))) + b;
            }

            return (c * Pow(2d, -10d * (t -= 1)) * Sin(((t * d) - s) * (2d * PI) / p) * 0.5d) + c + b;
        }
    }
}
