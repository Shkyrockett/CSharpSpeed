using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class NearestPointOnQuarticBezierTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (Point2D, double) FindNearestPoint(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double eX, double eY, double x, double y)
        {
            var (a, b, c, d, e, f, g, h) = GetSepticPolynomialFromQuarticBezierAndPointTests.GetQuinticPolynomialFromCubicBezierAndPoint(aX, aY, bX, bY, cX, cY, dX, dY, eX, eY, x, y);
            var candidates = FindAllRealRootsInIntervalTests.FindAllRootsInInterval(0d, 1d, a, b, c, d, e, f, g, h);

            // Find the candidate that yields the closest point on the bezier to the given point.
            var t = double.NaN;
            var output = (double.NaN, double.NaN);
            var minDistance = double.MaxValue;
            foreach (var candidate in candidates)
            {
                var ptAtCandidate = InterpolateBezierQuartic2DTests.QuarticBezierInterpolate2D(candidate, aX, aY, bX, bY, cX, cY, dX, dY, eX, eY);
                var distance = SquareDistanceTests.SquareDistance(ptAtCandidate.X, ptAtCandidate.Y, x, y);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    t = candidate;
                    output = ptAtCandidate;
                }
            }

            return (output, t);
        }
    }
}
