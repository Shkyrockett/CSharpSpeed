using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class GetLuminanceFromRGBByteTests
    {
        /// <summary>
        /// Get the brightness.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetLuminance(byte red, byte green, byte blue)
        {
            var r = red / 255d;
            var g = green / 255d;
            var b = blue / 255d;

            var max = r;
            if (g > max)
            {
                max = g;
            }

            if (b > max)
            {
                max = b;
            }

            var min = r;
            if (g < min)
            {
                min = g;
            }

            if (b < min)
            {
                min = b;
            }

            return (max + min) / 2d;
        }
    }
}
