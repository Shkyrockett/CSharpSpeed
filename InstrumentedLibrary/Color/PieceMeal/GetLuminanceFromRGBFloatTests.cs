using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class GetLuminanceFromRGBFloatTests
    {
        /// <summary>
        /// Get the brightness.
        /// </summary>
        /// <returns>The <see cref="double"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetLuminanceFloat(double red, double green, double blue)
        {
            var max = red;
            if (green > max)
            {
                max = green;
            }

            if (blue > max)
            {
                max = blue;
            }

            var min = red;
            if (green < min)
            {
                min = green;
            }

            if (blue < min)
            {
                min = blue;
            }

            return (max + min) / 2d;
        }
    }
}
