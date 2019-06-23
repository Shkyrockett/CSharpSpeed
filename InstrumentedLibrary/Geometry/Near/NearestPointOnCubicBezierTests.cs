using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class NearestPointOnCubicBezierTests
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (Point2D, double) FindNearestPoint(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double x, double y)
        {
            var (a, b, c, d, e, f) = GetQuinticPolynomialFromCubicBezierAndPointTests.GetQuinticPolynomialFromCubicBezierAndPoint(aX, aY, bX, bY, cX, cY, dX, dY, x, y);
            var candidates = FindAllRealRootsInIntervalTests.FindAllRootsInInterval(0d, 1d, a, b, c, d, e, f);

            // Find the candidate that yields the closest point on the bezier to the given point.
            var t = double.NaN;
            var output = (double.NaN, double.NaN);
            var minDistance = double.MaxValue;
            foreach (var candidate in candidates)
            {
                var ptAtCandidate = BezierInterpolateCubic2DTests.CubicBezierInterpolate2D(aX, aY, bX, bY, cX, cY, dX, dY, candidate);
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
