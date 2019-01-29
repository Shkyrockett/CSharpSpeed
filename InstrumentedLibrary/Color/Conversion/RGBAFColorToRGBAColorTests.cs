using System;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    public static class RGBAFColorToRGBAColorTests
    {
        /// <summary>
        /// Convert an red green blue alpha color from double floating point format to byte.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) RGBAFColorToRGBAColor(double red, double green, double blue, double alpha)
        {
            if (!ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            var d = RGBMax + 0.5d;
            return (
                red: (byte)(red * d),
                green: (byte)(green * d),
                blue: (byte)(blue * d),
                alpha: (byte)(alpha * d)
                );
        }

        /// <summary>
        /// Convert an red green blue alpha color from double floating point format to byte.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) RGBAFColorToRGBAColor((double red, double green, double blue, double alpha) tuple)
        {
            if (!ValidateRGBAFloatTests.ValidateRGBAF(tuple.red, tuple.green, tuple.blue, tuple.alpha))
            {
                throw new ArgumentOutOfRangeException(nameof(tuple), "A parameter is out of range.");
            }

            var d = RGBMax + 0.5d;
            return (
                red: (byte)(tuple.red * d),
                green: (byte)(tuple.green * d),
                blue: (byte)(tuple.blue * d),
                alpha: (byte)(tuple.alpha * d)
                );
        }
    }
}
