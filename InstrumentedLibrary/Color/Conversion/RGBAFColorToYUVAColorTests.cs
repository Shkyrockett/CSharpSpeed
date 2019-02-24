using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class RGBAFColorToYUVAColorTests
    {
        /// <summary>
        /// The yuv create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>
        /// https://github.com/dystopiancode/colorspace-conversions/
        /// Correction found at: https://www.fourcc.org/fccyvrgb.php
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double y, double u, double v, double alpha) RGBAFColorToYUVAColor(double red, double green, double blue, double alpha)
        {
            if (!ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            var y = (0.299d * red) + (0.587d * green) + (0.114d * blue);
            return (
                y,
                u: 0.492d * (blue - y), // u: 0.565 * (b - y),
                v: 0.877d * (red - y), // v: 0.713d * (r - y)
                 alpha
                );
        }
    }
}
