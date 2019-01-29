using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class TranslateDistortionTests
    {
        /// <summary>
        /// The Translate distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Translate(Point2D point, Vector2D offset)
        {
            return point + offset;
        }
    }
}
