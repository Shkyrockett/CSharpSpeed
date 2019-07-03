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
    public static class BounceOutPercentageEasingTests
    {
        #region Constants
        /// <summary>
        /// The bounce key1 (const). Value: 1d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        private const double bounceKey1 = 1d / 2.75d;

        /// <summary>
        /// The bounce key2 (const). Value: 2d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        private const double bounceKey2 = 2d / 2.75d;

        /// <summary>
        /// The bounce key3 (const). Value: 1.5d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        private const double bounceKey3 = 1.5d / 2.75d;

        /// <summary>
        /// The bounce key4 (const). Value: 2.5d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        private const double bounceKey4 = 2.5d / 2.75d;

        /// <summary>
        /// The bounce key5 (const). Value: 2.25d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        private const double bounceKey5 = 2.25d / 2.75d;

        /// <summary>
        /// The bounce key6 (const). Value: 2.625d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        private const double bounceKey6 = 2.625d / 2.75d;
        #endregion Constants

        /// <summary>
        /// Bounce out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://bitbucket.org/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BounceOut(double t)
        {
            if (t < bounceKey1)
            {
                return 7.5625d * t * t;
            }

            if (t < bounceKey2)
            {
                return (7.5625d * (t - bounceKey3) * (t - bounceKey3)) + 0.75d;
            }

            if (t < bounceKey4)
            {
                return (7.5625d * (t - bounceKey5) * (t - bounceKey5)) + 0.9375d;
            }

            return (7.5625d * (t - bounceKey6) * (t - bounceKey6)) + 0.984375d;
        }
    }
}
