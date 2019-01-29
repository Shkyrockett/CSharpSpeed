using System;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    public static class RGBAFColorToHSVAColorTests
    {
        /// <summary>
        /// The hsv create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double value, double alpha) RGBAFColorToHSVAColor(double red, double green, double blue, double alpha)
        {
            (double hue, double saturation, double value, double alpha) color = (0d, 0d, 0d, alpha);
            if (ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha) == true)
            {
                var M = Max3Double.Max(red, green, blue);
                var m = Min3DoubleTests.Min(red, green, blue);
                var c = M - m;
                color.value = M;
                if (c != 0d)
                {
                    if (M == red)
                    {
                        color.hue = IEEERemainder((green - blue) / c, 6d);
                    }
                    else if (M == green)
                    {
                        color.hue = ((blue - red) / c) + 2d;
                    }
                    else /*if(M==b)*/
                    {
                        color.hue = ((red - green) / c) + 4d;
                    }
                    color.hue *= 60d;
                    color.saturation = c / color.value;
                }
            }
            return color;
        }
    }
}
