using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class CubicBezierSegmentOrthogonalEllipseIntersectionTests
    {
        /// <summary>
        /// Find the intersection between a cubic Bézier and an orthogonal ellipse.
        /// </summary>
        /// <param name="b1X">The b1X.</param>
        /// <param name="b1Y">The b1Y.</param>
        /// <param name="b2X">The b2X.</param>
        /// <param name="b2Y">The b2Y.</param>
        /// <param name="b3X">The b3X.</param>
        /// <param name="b3Y">The b3Y.</param>
        /// <param name="b4X">The b4X.</param>
        /// <param name="b4Y">The b4Y.</param>
        /// <param name="h">The ecX.</param>
        /// <param name="k">The ecY.</param>
        /// <param name="a">The rx.</param>
        /// <param name="b">The ry.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>Returns an <see cref="Intersection"/> struct with a <see cref="Intersection.State"/>, and an array of <see cref="Point2D"/> structs containing any points of intersection found.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierSegmentOrthogonalEllipseIntersection(double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y, double h, double k, double a, double b, double epsilon = double.Epsilon) => BernsteinCubicBezierSegmentOrthogonalEllipseIntersectionTests.CubicBezierSegmentOrthogonalEllipseIntersection(CubicBezierBernsteinBasisTests.CubicBezierBernsteinBasis(b1X, b2X, b3X, b4X), CubicBezierBernsteinBasisTests.CubicBezierBernsteinBasis(b1Y, b2Y, b3Y, b4Y), h, k, a, b, epsilon);
    }
}
