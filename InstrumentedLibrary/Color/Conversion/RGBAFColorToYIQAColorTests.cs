using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class RGBAFColorToYIQAColorTests
    {
        /// <summary>
        /// The yiq create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>
        /// https://github.com/dystopiancode/colorspace-conversions/
        /// Correction from: https://stackoverflow.com/q/22131920
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double y, double i, double q, double alpha) RGBAFColorToYIQAColor(double red, double green, double blue, double alpha)
        {
            if (!ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            return (
                y: (0.299900d * red) + (0.587000d * green) + (0.114000d * blue),
                i: (0.595716d * red) - (0.274453d * green) - (0.321264d * blue),
                q: (0.211456d * red) - (0.522591d * green) + (0.311350d * blue),
                alpha
                );
        }
    }
}
