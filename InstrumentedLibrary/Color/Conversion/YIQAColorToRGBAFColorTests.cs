using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class YIQAColorToRGBAFColorTests
    {
        /// <summary>
        /// The rgb f create from yiq.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="i">The i.</param>
        /// <param name="q">The q.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) YIQAColorToRGBAFColor(double y, double i, double q, double alpha)
        {
            if (!ValidateYIQATests.ValidateYIQA(y, i, q, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            return (
                red: y + (0.9563d * i) + (0.6210d * q),
                green: y - (0.2721d * i) - (0.6474d * q),
                blue: y - (1.1070d * i) + (1.7046d * q), alpha
                );
        }
    }
}
