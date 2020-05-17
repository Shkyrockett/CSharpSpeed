using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class NearestPointOnQuarticBezierTests
    {
        /// <summary>
        /// Finds the nearest point.
        /// </summary>
        /// <param name="aX">a x.</param>
        /// <param name="aY">a y.</param>
        /// <param name="bX">The b x.</param>
        /// <param name="bY">The b y.</param>
        /// <param name="cX">The c x.</param>
        /// <param name="cY">The c y.</param>
        /// <param name="dX">The d x.</param>
        /// <param name="dY">The d y.</param>
        /// <param name="eX">The e x.</param>
        /// <param name="eY">The e y.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (Point2D, double) FindNearestPoint(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double eX, double eY, double x, double y)
        {
            var (a, b, c, d, e, f, g, h) = GetSepticPolynomialFromQuarticBezierAndPointTests.GetSepticPolynomialFromQuarticBezierAndPoint(aX, aY, bX, bY, cX, cY, dX, dY, eX, eY, x, y);
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
