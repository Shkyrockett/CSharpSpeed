using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class QuadraticBezierSegmentObliqueEllipseIntersectionAngleTests
    {
        /// <summary>
        /// Quadratics the bezier segment orthogonal ellipse intersection.
        /// </summary>
        /// <param name="xCurve">The x curve.</param>
        /// <param name="yCurve">The y curve.</param>
        /// <param name="h">The h.</param>
        /// <param name="k">The k.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentObliqueEllipseIntersection(Polynomial xCurve, Polynomial yCurve, double h, double k, double a, double b, double angle, double epsilon = double.Epsilon) => QuadraticBezierSegmentObliqueEllipseIntersectionTests.QuadraticBezierSegmentObliqueEllipseIntersection(xCurve, yCurve, h, k, a, b, Cos(angle), Sin(angle), epsilon);
    }
}
