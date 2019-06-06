using CSharpSpeed;
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
    [DisplayName("Convert a color in RGBA to HSLA")]
    [Description("Convert a color in RGBA to HSLA.")]
    [SourceCodeLocationProvider]
    public static class RGBAByteColorToHSLAColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RGBAByteColorToHSLAColorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (100d, 100d, 100d, 0d), epsilon: 0d) },
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
        /// 
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double hue, double saturation, double luminance, double alpha) RGBAColorToHSLAColor(double red, double green, double blue, double alpha)
            => RGBAColorToHSLAColor1(red, green, blue, alpha);

        /// <summary>
        /// Given a Color (RGB class) in range of 0-255 Return H,S,L in range of 0-1
        /// </summary>
        /// <param name="alpha">Alpha value out.</param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        [DisplayName("Convert a color in RGBA to HSLA")]
        [Description("Convert a color in RGBA to HSLA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double luminance, double alpha) RGBAColorToHSLAColor1(double red, double green, double blue, double alpha)
        {
            var a = alpha / 255d;
            var r = red / 255d;
            var g = green / 255d;
            var b = blue / 255d;
            double vertexMin;

            var h = 0d; // Default to black
            var s = 0d;
            var vertex = Max(Max(r, g), b);
            var min = Min(Min(r, g), b);
            var l = (min + vertex) / 2d;
            if (l <= 0d)
            {
                return (h, s, l, a);
            }

            vertexMin = vertex - min;
            s = vertexMin;
            if (s > 0d)
            {
                s /= (l <= 0.5d) ? (vertex + min) : (2d - vertex - min);
            }
            else
            {
                return (h, s, l, a);
            }

            var red2 = (vertex - r) / vertexMin;
            var green2 = (vertex - g) / vertexMin;
            var blue2 = (vertex - b) / vertexMin;
            if (r == vertex)
            {
                h = g == min ? 5d + blue2 : 1d - green2;
            }
            else
            {
                h = g == vertex ? b == min ? 1d + red2 : 3d - blue2 : r == min ? 3d + green2 : 5d - red2;
            }

            h /= 6d;
            return (h, s, l, a);
        }
    }
}
