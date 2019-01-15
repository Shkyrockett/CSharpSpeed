using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class VectorMagnitude2D
    {
        /// <summary>
        /// The Magnitude of a two dimensional Vector.
        /// </summary>
        /// <param name="i">The i component of the vector.</param>
        /// <param name="j">The j component of the vector.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Magnitude(double i, double j)
        {
            return Math.Sqrt((i * i) + (j * j));
        }
    }
}
