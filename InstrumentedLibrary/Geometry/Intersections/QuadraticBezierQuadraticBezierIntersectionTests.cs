using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The intersection quadratic bezier quadratic bezier tests class.
    /// </summary>
    [DisplayName("Circle center from Three Points Tests")]
    [Description("Find the center of a circle that intersects three points.")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierQuadraticBezierIntersectionTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the Intersection of two Quadratic Bézier curves.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierQuadraticBezierIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 20d, 5d,  0d, 5d, 10d, -5d, 20d, 5d, Epsilon }, new TestCaseResults(description:"Circle test case.", trials:trials, expectedReturnValue:new Intersection(), epsilon:double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="a3X"></param>
        /// <param name="a3Y"></param>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="b3X"></param>
        /// <param name="b3Y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection QuadraticBezierSegmentQuadraticBezierSegmentIntersection(double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y, double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double epsilon = Epsilon)
            => QuadraticBezierSegmentQuadraticBezierSegmentIntersection00(a1X, a1Y, a2X, a2Y, a3X, a3Y, b1X, b1Y, b2X, b2Y, b3X, b3Y, epsilon);

        /// <summary>
        /// Find the intersection between two quadratic beziers.
        /// </summary>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="a3X"></param>
        /// <param name="a3Y"></param>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="b3X"></param>
        /// <param name="b3Y"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// A combination of the method ideas found at: https://www.particleincell.com/2013/cubic-line-intersection/
        /// and the intersections methods at: http://www.kevlindev.com/ also found at: https://github.com/thelonious/kld-intersections/
        /// </acknowledgment>
        [DisplayName("Quadratic Bezier Segment Quadratic Bezier Segment Intersection")]
        [Description("Find the intersection between two quadratic beziers.")]
        [Acknowledgment("https://www.particleincell.com/2013/cubic-line-intersection/", "http://www.kevlindev.com/", "https://github.com/thelonious/kld-intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentQuadraticBezierSegmentIntersection00(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y,
            double epsilon = Epsilon)
        {
            // Initialize the intersection.
            var result = new Intersection(IntersectionState.NoIntersection);

            // ToDo: Break early if the AABB of the ends and handles do not intersect.
            // ToDo: Break early if the AABB of the curve does not intersect.

            // Parametric matrix form of the Bézier curve
            var xCoeffA = QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(a1X, a2X, a3X);
            var yCoeffA = QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(a1Y, a2Y, a3Y);
            var xCoeffB = QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(b1X, b2X, b3X);
            var yCoeffB = QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(b1Y, b2Y, b3Y);

            IList<double> roots = new List<double>();

            if (yCoeffA.C == 0)
            {
                var v0 = xCoeffA.C * (yCoeffA.A - yCoeffB.A);
                var v1 = v0 - (xCoeffA.B * yCoeffA.B);
                var v2 = v0 + v1;
                var v3 = yCoeffA.B * yCoeffA.B;

                roots = QuarticRootsTests.QuarticRoots(
                    /* t^4 */ xCoeffA.C * yCoeffB.C * yCoeffB.C,
                    /* t^3 */ 2 * xCoeffA.C * yCoeffB.B * yCoeffB.C,
                    /* t^2 */ (xCoeffA.C * yCoeffB.B * yCoeffB.B) - (xCoeffB.C * v3) - (yCoeffB.C * v0) - (yCoeffB.C * v1),
                    /* t^1 */ (-xCoeffB.B * v3) - (yCoeffB.B * v0) - (yCoeffB.B * v1),
                    /* C^0 */ ((xCoeffA.A - xCoeffB.A) * v3) + ((yCoeffA.A - yCoeffB.A) * v1),
                    epsilon);
            }
            else
            {
                var v0 = (xCoeffA.C * yCoeffB.C) - (yCoeffA.C * xCoeffB.C);
                var v1 = (xCoeffA.C * yCoeffB.B) - (xCoeffB.B * yCoeffA.C);
                var v2 = (xCoeffA.B * yCoeffA.C) - (yCoeffA.B * xCoeffA.C);
                var v3 = yCoeffA.A - yCoeffB.A;
                var v4 = (yCoeffA.C * (xCoeffA.A - xCoeffB.A)) - (xCoeffA.C * v3);
                var v5 = (-yCoeffA.B * v2) + (yCoeffA.C * v4);
                var v6 = v2 * v2;
                roots = QuarticRootsTests.QuarticRoots(
                    /* t^4 */ v0 * v0,
                    /* t^3 */ 2 * v0 * v1,
                    /* t^2 */ ((-yCoeffB.C * v6) + (yCoeffA.C * v1 * v1) + (yCoeffA.C * v0 * v4) + (v0 * v5)) / yCoeffA.C,
                    /* t^1 */ ((-yCoeffB.B * v6) + (yCoeffA.C * v1 * v4) + (v1 * v5)) / yCoeffA.C,
                    /* C^0 */ ((v3 * v6) + (v4 * v5)) / yCoeffA.C,
                    epsilon);
            }

            foreach (var s in roots)
            {
                var point = new Point2D(
                    (xCoeffB.C * s * s) + (xCoeffB.B * s) + xCoeffB.A,
                    (yCoeffB.C * s * s) + (yCoeffB.B * s) + yCoeffB.A);
                if (s >= 0 && s <= 1)
                {
                    var xRoots = QuadraticRootsTests.QuadraticRoots(
                        /* t^2 */ -xCoeffA.C,
                        /* t^1 */ -xCoeffA.B,
                        /* C^0 */ -xCoeffA.A + point.X,
                        epsilon);
                    var yRoots = QuadraticRootsTests.QuadraticRoots(
                        /* t^2 */ -yCoeffA.C,
                        /* t^1 */ -yCoeffA.B,
                        /* C^0 */ -yCoeffA.A + point.Y,
                        epsilon);

                    if (xRoots.Count > 0 && yRoots.Count > 0)
                    {
                        // Find the nearest matching x and y roots in the ranges 0 < x < 1; 0 < y < 1.
                        foreach (var xRoot in xRoots)
                        {
                            if (xRoot >= 0 && xRoot <= 1)
                            {
                                foreach (var yRoot in yRoots)
                                {
                                    var t = xRoot - yRoot;
                                    if ((t >= 0 ? t : -t) < epsilon)
                                    {
                                        result.AppendPoint(point);
                                        goto checkRoots; // Break through two levels of foreach loops to exit early. Using goto for performance.
                                    }
                                }
                            }
                        }
                    checkRoots:;
                    }
                }
            }

            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }

        /// <summary>
        /// Find the intersection between two quadratic beziers.
        /// </summary>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="a3X"></param>
        /// <param name="a3Y"></param>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="b3X"></param>
        /// <param name="b3Y"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// A combination of the method ideas found at: https://www.particleincell.com/2013/cubic-line-intersection/
        /// and the intersections methods at: http://www.kevlindev.com/ also found at: https://github.com/thelonious/kld-intersections/
        /// </acknowledgment>
        [DisplayName("Quadratic Bezier Segment Quadratic Bezier Segment Intersection")]
        [Description("Find the intersection between two quadratic beziers.")]
        [Acknowledgment("https://www.particleincell.com/2013/cubic-line-intersection/", "http://www.kevlindev.com/", "https://github.com/thelonious/kld-intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentQuadraticBezierSegmentIntersection0(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y,
            double epsilon = Epsilon)
        {
            // Initialize the intersection.
            var result = new Intersection(IntersectionState.NoIntersection);

            var xCoeffA = QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(a1X, a2X, a3X);
            var yCoeffA = QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(a1Y, a2Y, a3Y);
            var xCoeffB = QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(b1X, b2X, b3X);
            var yCoeffB = QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(b1Y, b2Y, b3Y);

            var a = (xCoeffA.C * yCoeffA.B) - (xCoeffA.B * yCoeffA.C);
            var b = (xCoeffB.C * yCoeffA.B) - (xCoeffA.B * yCoeffB.C);

            var c = (xCoeffB.B * yCoeffA.B) - (xCoeffA.B * yCoeffB.B);
            var d = (xCoeffA.B * (yCoeffA.A - yCoeffB.A)) - (yCoeffA.B * (xCoeffB.A - xCoeffA.A));
            var e = (xCoeffB.C * yCoeffA.C) - (xCoeffA.C * yCoeffB.C);
            var f = (xCoeffB.B * yCoeffA.C) - (xCoeffA.C * yCoeffB.B);
            var g = (xCoeffA.C * (yCoeffA.A - yCoeffB.A)) - (yCoeffA.C * (yCoeffB.A - xCoeffA.A));

            var roots = QuarticRootsTests.QuarticRoots(
                    /* t^4 */ e * e,
                    /* t^3 */ 2 * e * f,
                    /* t^2 */ (-a * b) + (f * f) + (2 * e * g),
                    /* t^1 */ (-a * c) + (2 * f * g),
                    /* C */ (-a * d) + (g * g),
                    epsilon);

            foreach (var s in roots)
            {
                var point = new Point2D(
                    (xCoeffB.C * s * s) + (xCoeffB.B * s) + xCoeffB.A,
                    (yCoeffB.C * s * s) + (yCoeffB.B * s) + yCoeffB.A);
                if (s >= 0 && s <= 1)
                {
                    var xRoots = QuadraticRootsTests.QuadraticRoots(
                        /* t^2 */ -xCoeffA.C,
                        /* t^1 */ -xCoeffA.B,
                        /* C */ -xCoeffA.A + point.X,
                        epsilon);
                    var yRoots = QuadraticRootsTests.QuadraticRoots(
                        /* t^2 */ -yCoeffA.C,
                        /* t^1 */ -yCoeffA.B,
                        /* C */ -yCoeffA.A + point.Y,
                        epsilon);

                    if (xRoots.Count > 0 && yRoots.Count > 0)
                    {
                        // Find the nearest matching x and y roots in the ranges 0 < x < 1; 0 < y < 1.
                        foreach (var xRoot in xRoots)
                        {
                            if (xRoot >= 0 && xRoot <= 1)
                            {
                                foreach (var yRoot in yRoots)
                                {
                                    var t = xRoot - yRoot;
                                    if ((t >= 0 ? t : -t) < 0.06) // ToDo: Find the error and replace 0.06 with epsilon.
                                    {
                                        result.AppendPoint(point);
                                        goto checkRoots; // Break through two levels of foreach loops. Using goto for performance.
                                    }
                                }
                            }
                        }
                    checkRoots:;
                    }
                }
            }

            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }

        /// <summary>
        /// Find the intersection between two quadratic beziers.
        /// </summary>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="a3X"></param>
        /// <param name="a3Y"></param>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="b3X"></param>
        /// <param name="b3Y"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// This is a performance improved rewrite of a method ported from: http://www.kevlindev.com/ also found at: https://github.com/thelonious/kld-intersections/
        /// </acknowledgment>
        [DisplayName("Quadratic Bezier Segment Quadratic Bezier Segment Intersection")]
        [Description("Find the intersection between two quadratic beziers.")]
        [Acknowledgment("https://www.particleincell.com/2013/cubic-line-intersection/", "http://www.kevlindev.com/", "https://github.com/thelonious/kld-intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentQuadraticBezierSegmentIntersection1(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // ToDo: Break early if the AABB bounding box of the curve does not intersect.
            // ToDo: Figure out if the following can be broken out of the vector structs.

            var c12 = new Vector2D(a1X - (a2X * 2) + a3X, a1Y - (a2Y * 2) + a3Y);
            var c11 = new Vector2D(2 * (a2X - a1X), 2 * (a2Y - a1Y));
            // c10 is a1X and a1Y

            var c22 = new Vector2D(b1X - (b2X * 2) + b3X, b1Y - (b2Y * 2) + b3Y);
            var c21 = new Vector2D(2 * (b2X - b1X), 2 * (b2Y - b1Y));
            // c20 is b1X and b1Y

            var a = (c12.I * c11.J) - (c11.I * c12.J);

            var b = (c22.I * c11.J) - (c11.I * c22.J);
            var c = (c21.I * c11.J) - (c11.I * c21.J);
            var d = (c11.I * (a1Y - b1Y)) - (c11.J * (b1X - a1X));

            var e = (-c22.I * c12.J) - (c12.I * c22.J);
            var f = (c21.I * c12.J) - (c12.I * c21.J);
            var g = (c12.I * (a1Y - b1Y)) - (c12.J * (b1X - a1X));

            IList<double> roots = new List<double>();
            if ((a * d) - (g * g) == 0)
            {
                var v0 = (a * c) - (2 * f * g);
                var v1 = (a * b) - (f * f) - (2 * e * g);
                var v2 = -2 * e * f;
                var v3 = -e * e;
                roots = CubicRootsTests.CubicRoots(
                    /* t^3 */ -v3,
                    /* t^2 */ -v2,
                    /* t^1 */ -v1,
                    /* C */ -v0,
                    epsilon);
            }
            else
            {
                var v0 = (a * d) - (g * g);
                var v1 = (a * c) - (2 * f * g);
                var v2 = (a * b) - (f * f) - (2 * e * g);
                var v3 = -2 * e * f;
                var v4 = -e * e;
                roots = QuarticRootsTests.QuarticRoots(
                    /* t^4 */ -v4,
                    /* t^3 */ -v3,
                    /* t^2 */ -v2,
                    /* t^1 */ -v1,
                    /* C */ -v0,
                    epsilon);
            }

            //roots.Reverse();
            foreach (var s in roots)
            {
                var point = new Point2D(
                    (c22.I * s * s) + (c21.I * s) + b1X,
                    (c22.J * s * s) + (c21.J * s) + b1Y);
                if (s >= 0 && s <= 1)
                {
                    var v0 = a1X - point.X;
                    var v1 = c11.I;
                    var v2 = c12.I;
                    var xRoots = QuadraticRootsTests.QuadraticRoots(
                        /* t^2 */ -v2,
                        /* t^1 */ -v1,
                        /* C */ -v0,
                        epsilon);
                    v0 = a1Y - point.Y;
                    v1 = c11.J;
                    v2 = c12.J;
                    var yRoots = QuadraticRootsTests.QuadraticRoots(
                        /* t^2 */ -v2,
                        /* t^1 */ -v1,
                        /* C */ -v0,
                        epsilon);

                    if (xRoots.Count > 0 && yRoots.Count > 0)
                    {
                        // Find the nearest matching x and y roots in the ranges 0 < x < 1; 0 < y < 1.
                        foreach (var xRoot in xRoots)
                        {
                            if (xRoot >= 0 && xRoot <= 1)
                            {
                                foreach (var yRoot in yRoots)
                                {
                                    var t = xRoot - yRoot;
                                    if ((t >= 0 ? t : -t) < 0.1)
                                    {
                                        result.AppendPoint(point);
                                        goto checkRoots; // Break through two levels of foreach loops. Using goto for performance.
                                    }
                                }
                            }
                        }
                    checkRoots:;
                    }
                }
            }

            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }

        /// <summary>
        /// Find the intersection between two quadratic beziers.
        /// </summary>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="a3X"></param>
        /// <param name="a3Y"></param>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="b3X"></param>
        /// <param name="b3Y"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Quadratic Bezier Segment Quadratic Bezier Segment Intersection")]
        [Description("Find the intersection between two quadratic beziers.")]
        [Acknowledgment("http://www.kevlindev.com/", "https://github.com/thelonious/kld-intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentQuadraticBezierSegmentIntersection2(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y,
            double epsilon = Epsilon)
        {
            var va = new Vector2D(a2X, a2Y) * -2;
            var c12 = new Vector2D(a1X, a1Y) + va + new Vector2D(a3X, a3Y);
            va = new Vector2D(a1X, a1Y) * -2;
            var vb = new Vector2D(a2X, a2Y) * 2;
            var c11 = va + vb;
            var c10 = new Vector2D(a1X, a1Y);
            va = new Vector2D(b2X, b2Y) * -2;
            var c22 = new Vector2D(b1X, b1Y) + va + new Vector2D(b3X, b3Y);
            va = new Vector2D(b1X, b1Y) * -2;
            vb = new Vector2D(b2X, b2Y) * 2;
            var c21 = va + vb;
            var c20 = new Vector2D(b1X, b1Y);

            var a = (c12.I * c11.J) - (c11.I * c12.J);
            var b = (c22.I * c11.J) - (c11.I * c22.J);
            var c = (c21.I * c11.J) - (c11.I * c21.J);
            var d = (c11.I * (c10.J - c20.J)) + (c11.J * (-c10.I + c20.I));
            var e = (c22.I * c12.J) - (c12.I * c22.J);
            var f = (c21.I * c12.J) - (c12.I * c21.J);
            var g = (c12.I * (c10.J - c20.J)) + (c12.J * (-c10.I + c20.I));

            var roots = QuarticRootsTests.QuarticRoots(
                -e * e,
                -2 * e * f,
                (a * b) - (f * f) - (2 * e * g),
                (a * c) - (2 * f * g),
                (a * d) - (g * g),
                epsilon);

            var result = new Intersection(IntersectionState.NoIntersection);

            for (var i = 0; i < roots.Count; i++)
            {
                var s = roots[i];
                if (0 <= s && s <= 1)
                {
                    var xRoots = QuadraticRootsTests.QuadraticRoots(
                        -c12.I,
                        -c11.I,
                        -c10.I + c20.I + (s * c21.I) + (s * s * c22.I),
                        epsilon);
                    var yRoots = QuadraticRootsTests.QuadraticRoots(
                        -c12.J,
                        -c11.J,
                        -c10.J + c20.J + (s * c21.J) + (s * s * c22.J),
                        epsilon);
                    if (xRoots.Count > 0 && yRoots.Count > 0)
                    {
                        for (var j = 0; j < xRoots.Count; j++)
                        {
                            var xRoot = xRoots[j];
                            if (0 <= xRoot && xRoot <= 1)
                            {
                                for (var k = 0; k < yRoots.Count; k++)
                                {
                                    if (Abs(xRoot - yRoots[k]) < epsilon)
                                    {
                                        result.Points.Add(((Point2D)c22 * s * s) + ((c21 * s) + c20));
                                        goto checkRoots;
                                    }
                                }
                            }
                        }
                    checkRoots:;
                    }
                }
            }

            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }

        /// <summary>
        /// Find the intersection between two quadratic beziers.
        /// </summary>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="a3X"></param>
        /// <param name="a3Y"></param>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="b3X"></param>
        /// <param name="b3Y"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// This is a performance improved rewrite of a method ported from: http://www.kevlindev.com/ also found at: https://github.com/thelonious/kld-intersections/
        /// </acknowledgment>
        [DisplayName("Quadratic Bezier Segment Quadratic Bezier Segment Intersection")]
        [Description("Find the intersection between two quadratic beziers.")]
        [Acknowledgment("http://www.kevlindev.com/", "https://github.com/thelonious/kld-intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentQuadraticBezierSegmentIntersection3(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // ToDo: Break early if the AABB bounding box of the curve does not intersect.

            var c12 = new Vector2D(a1X - (a2X * 2) + a3X, a1Y - (a2Y * 2) + a3Y);
            var c11 = new Vector2D(2 * (a2X - a1X), 2 * (a2Y - a1Y));
            var c22 = new Vector2D(b1X - (b2X * 2) + b3X, b1Y - (b2Y * 2) + b3Y);
            var c21 = new Vector2D(2 * (b2X - b1X), 2 * (b2Y - b1Y));

            var a = (c12.I * c11.J) - (c11.I * c12.J);
            var b = (c22.I * c11.J) - (c11.I * c22.J);
            var c = (c21.I * c11.J) - (c11.I * c21.J);
            var d = (c11.I * (a1Y - b1Y)) + (c11.J * (b1X - a1X));

            var e = (c22.I * c12.J) - (c12.I * c22.J);
            var f = (c21.I * c12.J) - (c12.I * c21.J);
            var g = (c12.I * (a1Y - b1Y)) + (c12.J * (b1X - a1X));

            var roots = QuarticRootsTests.QuarticRoots(
                /* C */ -e * e,
                /* t^1 */ -2 * e * f,
                /* t^2 */ (a * b) - (f * f) - (2 * e * g),
                /* t^3 */ (a * c) - (2 * f * g),
                /* t^4 */ (a * d) - (g * g),
                epsilon);

            foreach (var s in roots)
            {
                var point = new Point2D((c22.I * s * s) + (c21.I * s) + b1X, (c22.J * s * s) + (c21.J * s) + b1Y);
                if (0 <= s && s <= 1)
                {
                    var xRoots = QuadraticRootsTests.QuadraticRoots(
                        /* C */ -c12.I,
                        /* t^1 */ -c11.I,
                        /* t^2 */ -a1X + point.X,
                        epsilon);
                    var yRoots = QuadraticRootsTests.QuadraticRoots(
                        /* C */ -c12.J,
                        /* t^1 */ -c11.J,
                        /* t^2 */ -a1Y + point.Y,
                        epsilon);

                    if (xRoots.Count > 0 && yRoots.Count > 0)
                    {
                        // Find the nearest matching x and y roots in the ranges 0 < x < 1; 0 < y < 1.
                        foreach (var xRoot in xRoots)
                        {
                            if (xRoot >= 0 && xRoot <= 1)
                            {
                                foreach (var yRoot in yRoots)
                                {
                                    var t = xRoot - yRoot;
                                    if ((t >= 0 ? t : -t) < epsilon)
                                    {
                                        result.Points.Add(point);
                                        goto checkRoots; // Break through two levels of foreach loops. Using goto for performance.
                                    }
                                }
                            }
                        }
                    checkRoots:;
                    }
                }
            }

            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }
    }
}
