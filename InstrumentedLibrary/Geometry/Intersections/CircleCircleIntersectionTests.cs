using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The intersection circle, circle tests class.
    /// </summary>
    [DisplayName("Intersection of Two Circles")]
    [Description("Find the intersection points of two Circles.")]
    [SourceCodeLocationProvider]
    public static class CircleCircleIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(CircleCircleIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 1d, 1d, 3d, 1d, Epsilon }, new TestCaseResults(description: "Two circles of the same size, edge intersection 1.", trials: trials, expectedReturnValue: new (double X, double Y)[] { (1d, 2d), (1d, 2d) }, epsilon: double.Epsilon) },
                { new object[] { 1d, 1d, 1d, 3d, 1d, 1d, Epsilon }, new TestCaseResults(description: "Two circles of the same size, edge intersection 2.", trials: trials, expectedReturnValue: new (double X, double Y)[] { (2d, 1d), (2d, 1d) }, epsilon: double.Epsilon) },
                { new object[] { 1d, 1d, 1d, 1.5d, 1d, 1d, Epsilon }, new TestCaseResults(description: "Two circles of the same size, mostly overlapping.", trials: trials, expectedReturnValue: new (double X, double Y)[] { (1.25d, 0.031754163448145745d), (1.25d, 1.9682458365518543d) }, epsilon: double.Epsilon) },
                { new object[] { 1d, 1d, 1d, 2d, 1d, 1d, Epsilon }, new TestCaseResults(description: "Two circles of the same size, centers on edges.", trials: trials, expectedReturnValue: new (double X, double Y)[] { (1.5d, 0.1339745962155614d), (1.5d, 1.8660254037844386d) }, epsilon: double.Epsilon) },
                { new object[] { 1d, 1d, 1d, 4d, 1d, 1d, Epsilon }, new TestCaseResults(description: "Two circles of the same size, no intersection.", trials: trials, expectedReturnValue: Array.Empty<(double X, double Y)>(), epsilon: double.Epsilon) },
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
        /// <param name="cx0"></param>
        /// <param name="cy0"></param>
        /// <param name="radius0"></param>
        /// <param name="cx1"></param>
        /// <param name="cy1"></param>
        /// <param name="radius1"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y)[] FindCircleCircleIntersections(double cx0, double cy0, double radius0, double cx1, double cy1, double radius1, double epsilon = Epsilon)
            => FindCircleCircleIntersections1(cx0, cy0, radius0, cx1, cy1, radius1, epsilon);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cX1"></param>
        /// <param name="cY1"></param>
        /// <param name="r1"></param>
        /// <param name="cX2"></param>
        /// <param name="cY2"></param>
        /// <param name="r2"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [DisplayName("Circle, circle Intersection")]
        [Description("Find the intersection between two Circles.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y)[] IntersectCircleCircleFlat(double cX1, double cY1, double r1, double cX2, double cY2, double r2, double epsilon = double.Epsilon)
        {
            var dist = Sqrt(((cX2 - cX1) * (cX2 - cX1)) + ((cY2 - cY1) * (cY2 - cY1)));
            switch (dist)
            {
                case double o when o > r1 + r2:
                // result = new Intersection(IntersectionState.Outside);
                case double i when i < Abs(r1 - r2):
                    // result = new Intersection(IntersectionState.Inside);
                    return Array.Empty<(double x, double y)>();
                default:
                    // result = new Intersection(IntersectionState.Intersection);
                    var a = ((r1 * r1) - (r2 * r2) + (dist * dist)) / (2d * dist);
                    var x = cX1 + ((cX2 - cX1) * (a / dist));
                    var y = cY1 + ((cY2 - cY1) * (a / dist));
                    var b = Sqrt((r1 * r1) - (a * a)) / dist;
                    // See if we have 1 or 2 solutions.
                    return Abs(dist - r1 + r2) < epsilon
                        ? (new (double X, double Y)[] { (x + (b * (cY2 - cY1)), y - (b * (cX2 - cX1))), })
                        : (new (double x, double y)[] { (x + (b * (cY2 - cY1)), y - (b * (cX2 - cX1))), (x - (b * (cY2 - cY1)), y + (b * (cX2 - cX1))), });
            }
        }

        /// <summary>
        /// Find the points where the two circles intersect.
        /// </summary>
        /// <param name="cx0"></param>
        /// <param name="cy0"></param>
        /// <param name="radius0"></param>
        /// <param name="cx1"></param>
        /// <param name="cy1"></param>
        /// <param name="radius1"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/09/determine-where-two-circles-intersect-in-c/
        /// </acknowledgment>
        [DisplayName("Circle, circle Intersection")]
        [Description("Find the intersection between two Circles.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] FindCircleCircleIntersections1(
            double cx0, double cy0, double radius0,
            double cx1, double cy1, double radius1,
            double epsilon = Epsilon)
        {
            // Find the distance between the centers.
            var dx = cx0 - cx1;
            var dy = cy0 - cy1;
            var dist = Sqrt((dx * dx) + (dy * dy));

            (double X, double Y) intersection1;
            (double X, double Y) intersection2;

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                return Array.Empty<(double X, double Y)>();
            }
            else if (dist < Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                return Array.Empty<(double X, double Y)>();
            }
            else if ((Abs(dist) < epsilon) && (Abs(radius0 - radius1) < epsilon))
            {
                // No solutions, the circles coincide.
                intersection1 = (double.NaN, double.NaN);
                intersection2 = (double.NaN, double.NaN);
                return new (double X, double Y)[] { intersection1, intersection2 };
            }
            else
            {
                // Find a and h.
                var a = ((radius0 * radius0) - (radius1 * radius1) + (dist * dist)) / (2 * dist);
                var h = Sqrt((radius0 * radius0) - (a * a));

                // Find P2.
                var cx2 = cx0 + (a * (cx1 - cx0) / dist);
                var cy2 = cy0 + (a * (cy1 - cy0) / dist);

                // Get the points P3.
                intersection1 = (
                    cx2 + (h * (cy1 - cy0) / dist),
                    cy2 - (h * (cx1 - cx0) / dist));
                intersection2 = (
                    cx2 - (h * (cy1 - cy0) / dist),
                    cy2 + (h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (Abs(dist - radius0 + radius1) < epsilon)
                {
                    return new (double X, double Y)[] { intersection1 };
                }

                return new (double X, double Y)[] { intersection1, intersection2 };
            }
        }

        /// <summary>
        /// The circle circle intersection.
        /// </summary>
        /// <param name="A">The A.</param>
        /// <param name="B">The B.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://www.xarg.org/2016/07/calculate-the-intersection-points-of-two-circles/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y)[] CircleCircleIntersection(Circle2D A, Circle2D B)
        {
            var d = Sqrt(Pow(B.X - A.X, 2) + Pow(B.Y - A.Y, 2));

            if (d <= A.Radius + B.Radius)
            {
                var x = ((A.Radius * A.Radius) - (B.Radius * B.Radius) + (d * d)) / (2 * d);
                var y = Sqrt((A.Radius * A.Radius) - (x * x));

                if (A.Radius < Abs(x))
                {
                    // No intersection, one circle is in the other
                    return null;
                }
                else
                {
                    var e1 = (X: (B.X - A.X) / d, Y: (B.Y - A.Y) / d);
                    var e2 = (X: -e1.X, e1.Y);
                    var P1 = (X: A.X + (x * e1.X) + (y * e2.Y), Y: A.Y + (x * e1.Y) + (y * e2.X));
                    var P2 = (X: A.X + (x * e1.X) - (y * e2.Y), Y: A.Y + (x * e1.Y) - (y * e2.X));
                    return new (double x, double y)[] { P1, P2 };
                }
            }
            else
            {
                // No Intersection, far outside
                return null;
            }
        }
    }
}
