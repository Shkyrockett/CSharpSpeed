using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Convert a color in RGBA to HSIA")]
    [Description("Convert a color in RGBA to HSIA.")]
    [SourceCodeLocationProvider]
    public static class RGBAFColorToHSIAColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0f, 0f, 0f, 255f }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (100f, 100f, 100f, 0f), epsilon: 0f) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in HelperExtensions.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// The hsi create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double hue, double saturation, double intensity, double alpha) RGBAFColorToHSIAColor(double red, double green, double blue, double alpha)
            => RGBAFColorToHSIAColor1(red, green, blue, alpha);

        /// <summary>
        /// The hsi create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Convert a color in RGBA to HSIA")]
        [Description("Convert a color in RGBA to HSIA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double intensity, double alpha) RGBAFColorToHSIAColor1(double red, double green, double blue, double alpha)
        {
            (double hue, double saturation, double intensity, double alpha) color = (0d, 0d, 0d, alpha);
            var m = Min3DoubleTests.Min(red, green, blue);
            var M = Max3Double.Max(red, green, blue);
            var c = M - m;
            if (ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha) == true)
            {
                color.intensity = 1d / 3d * (red + green + blue);
                if (c == 0)
                {
                    color.hue = 0d;
                    color.saturation = 0d;
                }
                else
                {
                    if (M == red)
                    {
                        color.hue = IEEERemainder((green - blue) / c, 6d);
                    }
                    else if (M == green)
                    {
                        color.hue = ((blue - red) / c) + 2d;
                    }
                    else if (M == blue)
                    {
                        color.hue = ((red - green) / c) + 4d;
                    }
                    color.hue *= 60d;
                    color.saturation = 1d - (m / color.intensity);
                }
            }
            return color;
        }

        /// <summary>
        /// The hsi create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha">The a.</param>
        /// <returns>The HSIA.</returns>
        /// <acknowledgment>
        /// http://dystopiancode.blogspot.com/2012/02/hsi-rgb-conversion-algorithms-in-c.html
        /// https://github.com/dystopiancode/colorspace-conversions
        /// </acknowledgment>
        [DisplayName("Convert a color in RGBA to HSIA")]
        [Description("Convert a color in RGBA to HSIA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double intensity, double alpha) RGBAFColorToHSIAColor2(double red, double green, double blue, double alpha)
        {
            var m = Min(red, green);
            m = Min(m, blue);
            var M = Max(red, green);
            M = Max(M, blue);
            var c = M - m;

            var i = 1d / 3d * (red + green + blue);
            double h = 0;
            double s;
            if (c == 0)
            {
                h = 0d;
                s = 0d;
            }
            else
            {
                if (M == red)
                {
                    h = IEEERemainder((green - blue) / c, 6d);
                }
                else if (M == green)
                {
                    h = ((blue - red) / c) + 2d;
                }
                else if (M == blue)
                {
                    h = ((red - green) / c) + 4d;
                }

                h *= 60d;
                s = 1d - (m / i);
            }

            return (h, s, i, alpha);
        }

        /// <summary>
        /// The RGB fto HSI v2.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://gist.github.com/rzhukov/9129585</remarks>
        [DisplayName("Convert a color in RGBA to HSIA")]
        [Description("Convert a color in RGBA to HSIA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double intensity, double alpha) RGBAFColorToHSIAColor3(double red, double green, double blue, double alpha)
        {
            var i = (red + green + blue) / 3d;
            var rn = red / (red + green + blue);
            var gn = green / (red + green + blue);
            var bn = blue / (red + green + blue);
            var h = Acos(0.5d * (rn - gn + (rn - bn)) / Sqrt(((rn - gn) * (rn - gn)) + ((rn - bn) * (gn - bn))));
            if (blue > green)
            {
                h = (2d * PI) - h;
            }
            var s = 1d - (3d * Min3DoubleTests.Min(rn, gn, bn));
            return (h, s, i, alpha);
        }
    }
}
