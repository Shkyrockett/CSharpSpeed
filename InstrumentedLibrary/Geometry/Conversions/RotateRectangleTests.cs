using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RotateRectangleTests
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
        /// <param name="cosAngle"></param>
        /// <param name="sinAngle"></param>
        /// <returns>Returns a list of points from the rectangle, rotated about the fulcrum.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<Point2D> RotatedRectangle(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double cosAngle, double sinAngle)
        {
            _ = x;
            _ = y;
            // ToDo: Figure out how to properly include the location point.
            var points = new List<Point2D>();

            var xaxis = new Point2D(cosAngle, sinAngle);
            var yaxis = new Point2D(-sinAngle, cosAngle);

            // Apply the rotation transformation and translate to new center.
            points.Add(new Point2D(
                fulcrumX + ((-width * 0.5d * xaxis.X) + (-height * 0.5d * xaxis.Y)),
                fulcrumY + ((-width * 0.5d * yaxis.X) + (-height * 0.5d * yaxis.Y))
                ));
            points.Add(new Point2D(
                fulcrumX + ((width * 0.5d * xaxis.X) + (-height * 0.5d * xaxis.Y)),
                fulcrumY + ((width * 0.5d * yaxis.X) + (-height * 0.5d * yaxis.Y))
                ));
            points.Add(new Point2D(
                fulcrumX + ((width * 0.5d * xaxis.X) + (height * 0.5d * xaxis.Y)),
                fulcrumY + ((width * 0.5d * yaxis.X) + (height * 0.5d * yaxis.Y))
                ));
            points.Add(new Point2D(
                fulcrumX + ((-width * 0.5d * xaxis.X) + (height * 0.5d * xaxis.Y)),
                fulcrumY + ((-width * 0.5d * yaxis.X) + (height * 0.5d * yaxis.Y))
                ));

            return points;
        }
    }
}
