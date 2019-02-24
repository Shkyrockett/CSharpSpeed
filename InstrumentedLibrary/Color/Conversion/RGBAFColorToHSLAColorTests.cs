using System;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class RGBAFColorToHSLAColorTests
    {
        /// <summary>
        /// The hsl create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double lumanance, double alpha) RGBAFColorToHSLAColor(double red, double green, double blue, double alpha)
        {
            (double hue, double saturation, double lumanance, double alpha) color = (0d, 0d, 0d, alpha);
            if (ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha) == true)
            {
                var M = Max3Double.Max(red, green, blue);
                var m = Min3DoubleTests.Min(red, green, blue);
                var c = M - m;
                color.lumanance = 0.5d * (M + m);
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
                    else/*if(M==b)*/
                    {
                        color.hue = ((red - green) / c) + 4d;
                    }
                    color.hue *= 60d;
                    color.saturation = c / (1d - Abs((2d * color.lumanance) - 1d));
                }
            }
            return color;
        }
    }
}
