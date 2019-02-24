using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class YUVAColorToRGBAFColorTests
    {
        /// <summary>
        /// The rgb f create from yuv.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="u">The u.</param>
        /// <param name="v">The v.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) YUVAColorToRGBAFColor(double y, double u, double v, double alpha)
        {
            if (!ValidateYUVATests.ValidateYUVA(y, u, v, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            return (
                red: y + (1.140d * v),
                green: y - (0.395d * u) - (0.581d * v),
                blue: y + (2.032d * u), alpha
                );
        }
    }
}
