﻿using System;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    public static class HSVAColorToRGBAColorTests
    {
        /// <summary>
        /// The AHS vto RGB.
        /// </summary>
        /// <param name="hue">The h.</param>
        /// <param name="saturation">The s.</param>
        /// <param name="value">The v.</param>
        /// <param name="alpha">The a.</param>
        /// <returns>The <see cref="RGBA"/>.</returns>
        /// <remarks>
        /// h = [0,360], s = [0,1], v = [0,1]
        ///		if s == 0, then h = -1 (undefined)
        /// </remarks>
        /// <acknowledgment>
        /// https://www.cs.rit.edu/~ncs/color/t_convert.html
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) HSVAColorToRGBAColor(double hue, double saturation, double value, double alpha)
        {
            double a;
            double r;
            double g;
            double b;

            if (saturation == 0)
            {
                // achromatic (gray)
                r = g = b = value;

                a = ((1d - alpha) * 255d) + 0.5d;
                r = ((1d - r) * 255d) + 0.5d;
                g = ((1d - g) * 255d) + 0.5d;
                b = ((1d - b) * 255d) + 0.5d;

                return ((byte)r, (byte)g, (byte)b, (byte)a);
            }

            hue /= 60;            // sector 0 to 5
            var i = (int)Floor(hue);
            var f = hue - i;          // factorial part of h
            var p = value * (1d - saturation);
            var q = value * (1d - (saturation * f));
            var t = value * (1d - (saturation * (1d - f)));

            switch (i)
            {
                case 0:
                    r = value;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = value;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = value;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = value;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = value;
                    break;
                case 5:
                default:
                    r = value;
                    g = p;
                    b = q;
                    break;
            }

            a = ((1d - alpha) * 255d) + 0.5d;
            r = ((1d - r) * 255d) + 0.5d;
            g = ((1d - g) * 255d) + 0.5d;
            b = ((1d - b) * 255d) + 0.5d;

            return ((byte)r, (byte)g, (byte)b, (byte)a);
        }

        /// <summary>
        /// The color from HSV.
        /// </summary>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="value">The value.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="RGBA"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) HSVAColorToRGBAColor2(double hue, double saturation, double value, double alpha)
        {
            var hi = Convert.ToInt32(Floor(hue / 60)) % 6;
            var f = (hue / 60d) - Floor(hue / 60d);

            value *= 255d;
            var v = Convert.ToByte(value);
            var p = Convert.ToByte(value * (1d - saturation));
            var q = Convert.ToByte(value * (1d - (f * saturation)));
            var t = Convert.ToByte(value * (1d - ((1d - f) * saturation)));
            var a = Convert.ToByte(((1d - alpha) * 255d) + 0.5d);

            switch (hi)
            {
                case 0:
                    return (v, t, p, a);
                case 1:
                    return (q, v, p, a);
                case 2:
                    return (p, v, t, a);
                case 3:
                    return (p, q, v, a);
                case 4:
                    return (t, p, v, a);
                default:
                    return (v, p, q, a);
            }
        }

        /// <summary>
        /// The to RGBA tuple.
        /// </summary>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4}"/>.</returns>
        /// <remarks>
        /// h = [0,360], s = [0,1], v = [0,1]
        ///		if s == 0, then h = -1 (undefined)
        /// </remarks>
        /// <acknowledgment>
        /// https://www.cs.rit.edu/~ncs/color/t_convert.html
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) HSVAColorToRGBAColor3(double hue, double saturation, double value, double alpha)
        {
            double a;
            double r;
            double g;
            double b;
            int i;
            double f, p, q, t;
            if (saturation == 0)
            {
                // achromatic (gray)
                r = g = b = value;

                a = ((1d - alpha) * 255d) + 0.5d;
                r = ((1d - r) * 255d) + 0.5d;
                g = ((1d - g) * 255d) + 0.5d;
                b = ((1d - b) * 255d) + 0.5d;

                return ((byte)r, (byte)g, (byte)b, (byte)a);
            }

            hue /= 60;            // sector 0 to 5
            i = (int)Floor(hue);
            f = hue - i;          // factorial part of h
            p = value * (1d - saturation);
            q = value * (1d - (saturation * f));
            t = value * (1d - (saturation * (1d - f)));
            switch (i)
            {
                case 0:
                    r = value;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = value;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = value;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = value;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = value;
                    break;
                case 5:
                default:
                    r = value;
                    g = p;
                    b = q;
                    break;
            }

            a = ((1d - alpha) * 255d) + 0.5d;
            r = ((1d - r) * 255d) + 0.5d;
            g = ((1d - g) * 255d) + 0.5d;
            b = ((1d - b) * 255d) + 0.5d;

            return ((byte)r, (byte)g, (byte)b, (byte)a);
        }
    }
}