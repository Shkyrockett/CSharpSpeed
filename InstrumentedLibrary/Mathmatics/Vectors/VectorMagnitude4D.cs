using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class VectorMagnitude4D
    {
        /// <summary>
        /// The Magnitude of a four dimensional Vector.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        /// <param name="l">The l.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Magnitude(double i, double j, double k, double l)
        {
            return Math.Sqrt((i * i) + (j * j) + (k * k) + (l * l));
        }
    }
}
