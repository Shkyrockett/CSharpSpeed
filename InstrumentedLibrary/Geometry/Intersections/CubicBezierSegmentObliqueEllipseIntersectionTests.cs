using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class CubicBezierSegmentObliqueEllipseIntersectionTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="b3X"></param>
        /// <param name="b3Y"></param>
        /// <param name="b4X"></param>
        /// <param name="b4Y"></param>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="cos"></param>
        /// <param name="sin"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierSegmentObliqueEllipseIntersection(
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y,
            double h, double k, double a, double b, double cos, double sin, double epsilon = double.Epsilon)
        {
            // Rotate the points of the Bezier in the reverse angle about the center of the ellipse to align with it.
            (b1X, b1Y) = RotatePointAboutPointTests.RotatePoint(b1X, b1Y, cos, -sin, h, k);
            (b2X, b2Y) = RotatePointAboutPointTests.RotatePoint(b2X, b2Y, cos, -sin, h, k);
            (b3X, b3Y) = RotatePointAboutPointTests.RotatePoint(b3X, b3Y, cos, -sin, h, k);
            (b4X, b4Y) = RotatePointAboutPointTests.RotatePoint(b4X, b4Y, cos, -sin, h, k);

            // Find the points of intersection.
            var intersection = CubicBezierSegmentOrthogonalEllipseIntersectionTests.CubicBezierSegmentOrthogonalEllipseIntersection(b1X, b1Y, b2X, b2Y, b3X, b3Y, b4X, b4Y, h, k, a, b, epsilon);

            // Rotate the points back forwards to the locations of the intersection.
            for (var i = 0; i < intersection.Items.Count; i++)
            {
                // Rotate point.
                intersection.Items[i] = RotatePointAboutPointTests.RotatePoint(intersection.Items[i].X, intersection.Items[i].Y, cos, sin, h, k);
            }

            // Return result.
            return intersection;
        }
    }
}
