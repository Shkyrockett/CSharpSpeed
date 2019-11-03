using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class QuadraticBezierSegmentOrthogonalEllipseIntersectionTests
    {
        /// <summary>
        /// Find the intersection between a quadratic Bézier and an orthogonal ellipse.
        /// </summary>
        /// <param name="b1X">The b1X.</param>
        /// <param name="b1Y">The b1Y.</param>
        /// <param name="b2X">The b2X.</param>
        /// <param name="b2Y">The b2Y.</param>
        /// <param name="b3X">The b3X.</param>
        /// <param name="b3Y">The b3Y.</param>
        /// <param name="ecX">The ecX.</param>
        /// <param name="ecY">The ecY.</param>
        /// <param name="rx">The rx.</param>
        /// <param name="ry">The ry.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>Returns an <see cref="Intersection"/> struct with a <see cref="Intersection.State"/>, and an array of <see cref="Point2D"/> structs containing any points of intersection found.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentOrthogonalEllipseIntersection(double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double ecX, double ecY, double rx, double ry, double epsilon = double.Epsilon) => BernsteinQuadraticBezierSegmentOrthogonalEllipseIntersectionTests.QuadraticBezierSegmentOrthogonalEllipseIntersection(QuadraticBezierBernsteinBasisTests.QuadraticBezierBernsteinBasis(b1X, b2X, b3X), QuadraticBezierBernsteinBasisTests.QuadraticBezierBernsteinBasis(b1Y, b2Y, b3Y), ecX, ecY, rx, ry, epsilon);
    }
}
