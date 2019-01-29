using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class WaterDistortionTests
    {
        /// <summary>
        /// The water distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="nWave">The nWave.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Water(Point2D point, Point2D fulcrum, double nWave = 1)
        {
            var xo = nWave * Sin(2d * PI * point.Y / 128d);
            var yo = nWave * Cos(2d * PI * point.X / 128d);
            var newX = point.X + xo;
            var newY = point.Y + yo;
            return new Point2D(newX, newY);
        }
    }
}
