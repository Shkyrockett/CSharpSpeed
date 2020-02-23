using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The bounds of cubic bezier segment tests class.
    /// </summary>
    [DisplayName("Cubic Bezier Segment Bounds Tests")]
    [Description("Calculate bounding rectangle of a cubic bezier curve segment.")]
    [SourceCodeLocationProvider]
    public static class BoundsOfCubicBezierSegmentTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(BoundsOfCubicBezierSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 20d, 15d, 30d, 5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new Rectangle2D(10d, 15d, 9.4036865234375d, 2.5d), epsilon: double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in HelperExtensions.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Rectangle2D CubicBezierBounds(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
            => CubicBezierBounds2(ax, ay, bx, by, cx, cy, dx, dy);

        /// <summary>
        /// The cubic bezier bounds.
        /// </summary>
        /// <param name="ax">The starting x-coordinate for the Cubic Bezier curve.</param>
        /// <param name="ay">The starting y-coordinate for the Cubic Bezier curve.</param>
        /// <param name="bx">The first x-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="by">The first y-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="cx">The second x-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="cy">The second y-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="dx">The closing x-coordinate for the Cubic Bezier curve.</param>
        /// <param name="dy">The closing y-coordinate for the Cubic Bezier curve.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DisplayName("Cubic Bezier Bounds")]
        [Description("Find bounds of a Cubic Bezier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D CubicBezierBounds1(
            double ax, double ay,
            double bx, double by,
            double cx, double cy,
            double dx, double dy)
        {
            var sortOfCloseLength = (int)CubicBezierSegmentLengthTests.CubicBezierArcLength(ax, ay, bx, by, cx, cy, dx, dy);
            var points = new List<(double X, double Y)>(FunctionalInterpolationTests.Interpolate0to1(sortOfCloseLength, (i) => InterpolateCubic2DTests.CubicInterpolate2D(i, ax, ay, bx, by, cx, cy, dx, dy)));

            var left = points[0].X;
            var top = points[0].Y;
            var right = points[0].X;
            var bottom = points[0].Y;

            foreach (var (X, Y) in points)
            {
                // ToDo: Measure performance impact of overwriting each time.
                left = X <= left ? X : left;
                top = Y <= top ? Y : top;
                right = X >= right ? X : right;
                bottom = Y >= bottom ? Y : bottom;
            }

            return Rectangle2D.FromLTRB(left, top, right, bottom);
        }

        /// <summary>
        /// The cubic bezier bounds2.
        /// </summary>
        /// <param name="ax">The starting x-coordinate for the Cubic Bezier curve.</param>
        /// <param name="ay">The starting y-coordinate for the Cubic Bezier curve.</param>
        /// <param name="bx">The first x-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="by">The first y-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="cx">The second x-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="cy">The second y-coordinate for the tangent control node for the Cubic Bezier curve.</param>
        /// <param name="dx">The closing x-coordinate for the Cubic Bezier curve.</param>
        /// <param name="dy">The closing y-coordinate for the Cubic Bezier curve.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve
        /// http://floris.briolas.nl/floris/2009/10/bounding-box-of-cubic-bezier/
        /// http://jsfiddle.net/SalixAlba/QQnvm/4/
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Bounds")]
        [Description("Find bounds of a Cubic Bezier.")]
        [Acknowledgment("http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve", "http://floris.briolas.nl/floris/2009/10/bounding-box-of-cubic-bezier/", "http://jsfiddle.net/SalixAlba/QQnvm/4/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D CubicBezierBounds2(
            double ax, double ay,
            double bx, double by,
            double cx, double cy,
            double dx, double dy)
        {
            var a = (3 * dx) - (9d * cx) + (9d * bx) - (3d * ax);
            var b = (6d * ax) - (12d * bx) + (6d * cx);
            var c = (3d * bx) - (3d * ax);

            var disc = (b * b) - (4d * a * c);
            var xl = ax;
            var xh = ax;
            if (dx < xl)
            {
                xl = dx;
            }

            if (dx > xh)
            {
                xh = dx;
            }

            if (disc >= 0d)
            {
                var t1 = (-b + Sqrt(disc)) / (2d * a);

                if (t1 > 0d && t1 < 1d)
                {
                    var x1 = InterpolateCubic1DTests.CubicInterpolate1D(t1, ax, bx, cx, dx);
                    if (x1 < xl)
                    {
                        xl = x1;
                    }

                    if (x1 > xh)
                    {
                        xh = x1;
                    }
                }

                var t2 = (-b - Sqrt(disc)) / (2d * a);

                if (t2 > 0d && t2 < 1d)
                {
                    var x2 = InterpolateCubic1DTests.CubicInterpolate1D(t2, ax, bx, cx, dx);
                    if (x2 < xl)
                    {
                        xl = x2;
                    }

                    if (x2 > xh)
                    {
                        xh = x2;
                    }
                }
            }

            a = (3d * dy) - (9d * cy) + (9d * by) - (3d * ay);
            b = (6d * ay) - (12d * by) + (6d * cy);
            c = (3d * by) - (3d * ay);
            disc = (b * b) - (4d * a * c);
            var yl = ay;
            var yh = ay;
            if (dy < yl)
            {
                yl = dy;
            }

            if (dy > yh)
            {
                yh = dy;
            }

            if (disc >= 0d)
            {
                var t1 = (-b + Sqrt(disc)) / (2d * a);

                if (t1 > 0d && t1 < 1d)
                {
                    var y1 = InterpolateCubic1DTests.CubicInterpolate1D(t1, ay, by, cy, dy);
                    if (y1 < yl)
                    {
                        yl = y1;
                    }

                    if (y1 > yh)
                    {
                        yh = y1;
                    }
                }

                var t2 = (-b - Sqrt(disc)) / (2d * a);

                if (t2 > 0 && t2 < 1)
                {
                    var y2 = InterpolateCubic1DTests.CubicInterpolate1D(t2, ay, by, cy, dy);
                    if (y2 < yl)
                    {
                        yl = y2;
                    }

                    if (y2 > yh)
                    {
                        yh = y2;
                    }
                }
            }

            return new Rectangle2D(xl, xh, yl, yh);
        }

        ///// <summary>
        ///// Calculates the Axis Aligned Bounding Box (AABB) rectangle of a Cubic Bézier curve.
        ///// </summary>
        ///// <param name="ax">The x-component of the starting point.</param>
        ///// <param name="ay">The y-component of the starting point.</param>
        ///// <param name="bx">The x-component of the first handle point.</param>
        ///// <param name="by">The y-component of the first handle point.</param>
        ///// <param name="cx">The x-component of the second handle point.</param>
        ///// <param name="cy">The y-component of the second handle point.</param>
        ///// <param name="dx">The x-component of the end point.</param>
        ///// <param name="dy">The y-component of the end point.</param>
        ///// <returns>Returns an Axis Aligned Bounding Box (AABB) rectangle that bounds the Cubic Bézier curve.</returns>
        ///// <acknowledgment>
        ///// This method has an error where if the end nodes are horizontal to each other, while the handles are also horizontal to each other the bounds are not correctly calculated.
        ///// </acknowledgment>
        ///// <acknowledgment>
        ///// Method created using the following resources.
        ///// http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve
        ///// http://nishiohirokazu.blogspot.com/2009/06/how-to-calculate-bezier-curves-bounding.html
        ///// http://jsfiddle.net/SalixAlba/QQnvm/4/
        ///// </acknowledgment>
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Rectangle2D CubicBezierBounds(
        //    double ax, double ay,
        //    double bx, double by,
        //    double cx, double cy,
        //    double dx, double dy)
        //{
        //    // Calculate the polynomial of the cubic.
        //    var a = -3 * ax + 9 * bx - 9 * cx + 3 * dx;
        //    var b = 6 * ax - 12 * bx + 6 * cx;
        //    var c = -3 * ax + 3 * bx;

        //    // Calculate the discriminant of the polynomial.
        //    var discriminant = b * b - 4 * a * c;

        //    // Find the high and low x ends.
        //    var xlow = (dx < ax) ? dx : ax;
        //    var xhigh = (dx > ax) ? dx : ax;

        //    if (discriminant >= 0)
        //    {
        //        // Find the positive solution using the quadratic formula.
        //        var t1 = (-b + Sqrt(discriminant)) / (2 * a);

        //        if (t1 > 0 && t1 < 1)
        //        {
        //            var x1 = Interpolators.Cubic(ax, bx, cx, dx, t1);
        //            if (x1 < xlow) xlow = x1;
        //            if (x1 > xhigh) xhigh = x1;
        //        }

        //        // Find the negative solution using the quadratic formula.
        //        var t2 = (-b - Sqrt(discriminant)) / (2 * a);

        //        if (t2 > 0 && t2 < 1)
        //        {
        //            var x2 = Interpolators.Cubic(ax, bx, cx, dx, t2);
        //            if (x2 < xlow) xlow = x2;
        //            if (x2 > xhigh) xhigh = x2;
        //        }
        //    }

        //    a = -3 * ay + 9 * by - 9 * cy + 3 * dy;
        //    b = 6 * ay - 12 * by + 6 * cy;
        //    c = -3 * ay + 3 * by;

        //    discriminant = b * b - 4 * a * c;

        //    var yl = ay;
        //    var yh = ay;
        //    if (dy < yl) yl = dy;
        //    if (dy > yh) yh = dy;
        //    if (discriminant >= 0)
        //    {
        //        var t1 = (-b + Sqrt(discriminant)) / (2 * a);

        //        if (t1 > 0 && t1 < 1)
        //        {
        //            var y1 = Interpolators.Cubic(ay, by, cy, dy, t1);
        //            if (y1 < yl) yl = y1;
        //            if (y1 > yh) yh = y1;
        //        }

        //        var t2 = (-b - Sqrt(discriminant)) / (2 * a);

        //        if (t2 > 0 && t2 < 1)
        //        {
        //            var y2 = Interpolators.Cubic(ay, by, cy, dy, t2);
        //            if (y2 < yl) yl = y2;
        //            if (y2 > yh) yh = y2;
        //        }
        //    }

        //    return new Rectangle2D(xlow, xhigh, yl, yh);
        //}
    }
}
