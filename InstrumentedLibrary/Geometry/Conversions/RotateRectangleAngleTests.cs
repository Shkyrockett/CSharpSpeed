using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RotateRectangleAngleTests
    {
        /// <summary>
        /// Rotates the points of the corners of a rectangle about the fulcrum point.
        /// </summary>
        /// <param name="x">The x-component of the top left corner of the rectangle.</param>
        /// <param name="y">The y-component of the top left corner of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="fulcrumX">The x-component of the rotation fulcrum point.</param>
        /// <param name="fulcrumY">The x-component of the rotation fulcrum point.</param>
        /// <param name="angle">The angle to rotate the points.</param>
        /// <returns>Returns a list of points from the rectangle, rotated about the fulcrum.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<Point2D> RotatedRectangle(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
        {
            return RotateRectangleTests.RotatedRectangle(x, y, width, height, fulcrumX, fulcrumY, Cos(angle), Sin(angle));
        }
    }
}
