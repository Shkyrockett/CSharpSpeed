using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RootTests
    {
        /// <summary>
        /// Returns the specified root a specified number.
        /// </summary>
        /// <param name="x">A double-precision floating-point number to find the specified root of.</param>
        /// <param name="y">A double-precision floating-point number that specifies a root.</param>
        /// <returns>
        /// The y root of the number x.
        /// </returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Root(double x, double y) => (x < 0d && Abs((y % 2d) - 1d) < double.Epsilon) ? -Pow(-x, 1d / y) : Pow(x, 1d / y);
    }
}
