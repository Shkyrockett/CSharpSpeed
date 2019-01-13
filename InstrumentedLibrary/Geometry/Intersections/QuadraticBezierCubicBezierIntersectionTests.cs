using CSharpSpeed;
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
    /// The quadratic bezier cubic bezier intersection tests class.
    /// </summary>
    [DisplayName("Intersection of Quadratic Bezier and Cubic Bezier")]
    [Description("Finds the intersection points of a Quadratic Bezier and Cubic Bezier.")]
    [Signature("public static Intersection QuadraticBezierSegmentCubicBezierSegmentIntersection(double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y, double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y, double epsilon = Epsilon)")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierCubicBezierIntersectionTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the Intersection of two Cubic Bézier curves.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierCubicBezierIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 20d, 0d, 5d, 10d, -5d, 20d, 10d, 30d, 5d, 0d, Epsilon }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:15d, epsilon:DoubleEpsilon) },
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
        /// <param name="b4X"></param>
        /// <param name="b4Y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection QuadraticBezierSegmentCubicBezierSegmentIntersection(double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y, double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y, double epsilon = Epsilon)
            => QuadraticBezierSegmentCubicBezierSegmentIntersection1(a1X, a1Y, a2X, a2Y, a3X, a3Y, b1X, b1Y, b2X, b2Y, b3X, b3Y, b4X, b4Y, epsilon);

        /// <summary>
        /// Find the intersection between a quadratic bezier and a cubic bezier.
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
        /// <param name="b4X"></param>
        /// <param name="b4Y"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Intersection of Quadratic Bezier and Cubic Bezier")]
        [Description("Finds the intersection points of a Quadratic Bezier and Cubic Bezier.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentCubicBezierSegmentIntersection1(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y,
            double epsilon = Epsilon)
        {
            var a = new Vector2D(a2X, a2Y) * -2;
            var c12 = new Vector2D(a1X, a1Y) + a + new Vector2D(a3X, a3Y);
            a = new Vector2D(a1X, a1Y) * -2;
            var b = new Vector2D(a2X, a2Y) * 2;
            var c11 = a + b;
            var c10 = new Vector2D(a1X, a1Y);
            a = new Vector2D(b1X, b1Y) * -1;
            b = new Vector2D(b2X, b2Y) * 3;
            var c = new Vector2D(b3X, b3Y) * -3;
            var d = a + b + c + new Vector2D(b4X, b4Y);
            var c23 = new Vector2D(d.I, d.J);
            a = new Vector2D(b1X, b1Y) * 3;
            b = new Vector2D(b2X, b2Y) * -6;
            c = new Vector2D(b3X, b3Y) * 3;
            d = a + b + c;
            var c22 = new Vector2D(d.I, d.J);
            a = new Vector2D(b1X, b1Y) * -3;
            b = new Vector2D(b2X, b2Y) * 3;
            c = a + b;
            var c21 = new Vector2D(c.I, c.J);
            var c20 = new Vector2D(b1X, b1Y);

            var c10x2 = c10.I * c10.I;
            var c10y2 = c10.J * c10.J;
            var c11x2 = c11.I * c11.I;
            var c11y2 = c11.J * c11.J;
            var c12x2 = c12.I * c12.I;
            var c12y2 = c12.J * c12.J;
            var c20x2 = c20.I * c20.I;
            var c20y2 = c20.J * c20.J;
            var c21x2 = c21.I * c21.I;
            var c21y2 = c21.J * c21.J;
            var c22x2 = c22.I * c22.I;
            var c22y2 = c22.J * c22.J;
            var c23x2 = c23.I * c23.I;
            var c23y2 = c23.J * c23.J;

            var roots = new Polynomial(
                -2 * c12.I * c12.J * c22.I * c23.J - 2 * c12.I * c12.J * c22.J * c23.I + 2 * c12y2 * c22.I * c23.I + 2 * c12x2 * c22.J * c23.J,
                -2 * c12.I * c12.J * c23.I * c23.J + c12x2 * c23y2 + c12y2 * c23x2,
                -2 * c12.I * c21.I * c12.J * c23.J - 2 * c12.I * c12.J * c21.J * c23.I - 2 * c12.I * c12.J * c22.I * c22.J + 2 * c21.I * c12y2 * c23.I + c12y2 * c22x2 + c12x2 * (2 * c21.J * c23.J + c22y2),
                2 * c10.I * c12.I * c12.J * c23.J + 2 * c10.J * c12.I * c12.J * c23.I + c11.I * c11.J * c12.I * c23.J + c11.I * c11.J * c12.J * c23.I - 2 * c20.I * c12.I * c12.J * c23.J - 2 * c12.I * c20.J * c12.J * c23.I - 2 * c12.I * c21.I * c12.J * c22.J - 2 * c12.I * c12.J * c21.J * c22.I - 2 * c10.I * c12y2 * c23.I - 2 * c10.J * c12x2 * c23.J + 2 * c20.I * c12y2 * c23.I + 2 * c21.I * c12y2 * c22.I - c11y2 * c12.I * c23.I - c11x2 * c12.J * c23.J + c12x2 * (2 * c20.J * c23.J + 2 * c21.J * c22.J),
                2 * c10.I * c12.I * c12.J * c22.J + 2 * c10.J * c12.I * c12.J * c22.I + c11.I * c11.J * c12.I * c22.J + c11.I * c11.J * c12.J * c22.I - 2 * c20.I * c12.I * c12.J * c22.J - 2 * c12.I * c20.J * c12.J * c22.I - 2 * c12.I * c21.I * c12.J * c21.J - 2 * c10.I * c12y2 * c22.I - 2 * c10.J * c12x2 * c22.J + 2 * c20.I * c12y2 * c22.I - c11y2 * c12.I * c22.I - c11x2 * c12.J * c22.J + c21x2 * c12y2 + c12x2 * (2 * c20.J * c22.J + c21y2),
                2 * c10.I * c12.I * c12.J * c21.J + 2 * c10.J * c12.I * c21.I * c12.J + c11.I * c11.J * c12.I * c21.J + c11.I * c11.J * c21.I * c12.J - 2 * c20.I * c12.I * c12.J * c21.J - 2 * c12.I * c20.J * c21.I * c12.J - 2 * c10.I * c21.I * c12y2 - 2 * c10.J * c12x2 * c21.J + 2 * c20.I * c21.I * c12y2 - c11y2 * c12.I * c21.I - c11x2 * c12.J * c21.J + 2 * c12x2 * c20.J * c21.J,
                -2 * c10.I * c10.J * c12.I * c12.J - c10.I * c11.I * c11.J * c12.J - c10.J * c11.I * c11.J * c12.I + 2 * c10.I * c12.I * c20.J * c12.J + 2 * c10.J * c20.I * c12.I * c12.J + c11.I * c20.I * c11.J * c12.J + c11.I * c11.J * c12.I * c20.J - 2 * c20.I * c12.I * c20.J * c12.J - 2 * c10.I * c20.I * c12y2 + c10.I * c11y2 * c12.I + c10.J * c11x2 * c12.J - 2 * c10.J * c12x2 * c20.J - c20.I * c11y2 * c12.I - c11x2 * c20.J * c12.J + c10x2 * c12y2 + c10y2 * c12x2 + c20x2 * c12y2 + c12x2 * c20y2
                ).RootsInInterval();

            var result = new Intersection(IntersectionState.NoIntersection);

            for (var i = 0; i < roots.Length; i++)
            {
                var s = roots[i];
                var xRoots = QuadraticRootsTests.QuadraticRootsKevinLinDev(
                    c12.I,
                    c11.I,
                    c10.I - c20.I - s * c21.I - s * s * c22.I - s * s * s * c23.I,
                    epsilon);
                var yRoots = QuadraticRootsTests.QuadraticRootsKevinLinDev(
                    c12.J,
                    c11.J,
                    c10.J - c20.J - s * c21.J - s * s * c22.J - s * s * s * c23.J,
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
                                    result.Points.Add((Point2D)c23 * s * s * s + (c22 * s * s + (c21 * s + c20)));
                                    goto checkRoots;
                                }
                            }
                        }
                    }
                checkRoots:;
                }
            }

            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }

        /// <summary>
        /// Find the intersection between a quadratic bezier and a cubic bezier.
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
        /// <param name="b4X"></param>
        /// <param name="b4Y"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// This is a performance improved rewrite of a method ported from: http://www.kevlindev.com/ also found at: https://github.com/thelonious/kld-intersections/
        /// </acknowledgment>
        [DisplayName("Intersection of Quadratic Bezier and Cubic Bezier")]
        [Description("Finds the intersection points of a Quadratic Bezier and Cubic Bezier.")]
        [Acknowledgment("http://www.kevlindev.com/", "https://github.com/thelonious/kld-intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentCubicBezierSegmentIntersection2(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // ToDo: Break early if the AABB bounding box of the curve does not intersect.

            var c12 = new Vector2D(a1X - a2X * 2 + a3X, a1Y - a2Y * 2 + a3Y);
            var c11 = new Vector2D(2 * (a2X - a1X), 2 * (a2Y - a1Y));
            var c23 = new Vector2D(b4X - b3X * 3 + b2X * 3 - b1X * 1, b4Y - b3Y * 3 + b2Y * 3 - b1Y * 1);
            var c22 = new Vector2D(3 * (b3X - b2X * 2 + b1X), 3 * (b3Y - b2Y * 2 + b1Y));
            var c21 = new Vector2D(3 * (b2X - b1X), 3 * (b2Y - b1Y));

            var c10x2 = a1X * a1X;
            var c10y2 = a1Y * a1Y;
            var c11x2 = c11.I * c11.I;
            var c11y2 = c11.J * c11.J;
            var c12x2 = c12.I * c12.I;
            var c12y2 = c12.J * c12.J;

            var c20x2 = b1X * b1X;
            var c20y2 = b1Y * b1Y;
            var c21x2 = c21.I * c21.I;
            var c21y2 = c21.J * c21.J;
            var c22x2 = c22.I * c22.I;
            var c22y2 = c22.J * c22.J;
            var c23x2 = c23.I * c23.I;
            var c23y2 = c23.J * c23.J;

            var roots = new Polynomial(
                /* t^0 */ -2 * c12.I * c12.J * c22.I * c23.J - 2 * c12.I * c12.J * c22.J * c23.I + 2 * c12y2 * c22.I * c23.I + 2 * c12x2 * c22.J * c23.J,
                /* t^1 */ -2 * c12.I * c12.J * c23.I * c23.J + c12x2 * c23y2 + c12y2 * c23x2,
                /* t^2 */ -2 * c12.I * c21.I * c12.J * c23.J - 2 * c12.I * c12.J * c21.J * c23.I - 2 * c12.I * c12.J * c22.I * c22.J + 2 * c21.I * c12y2 * c23.I + c12y2 * c22x2 + c12x2 * (2 * c21.J * c23.J + c22y2),
                /* t^3 */ 2 * a1X * c12.I * c12.J * c23.J + 2 * a1Y * c12.I * c12.J * c23.I + c11.I * c11.J * c12.I * c23.J + c11.I * c11.J * c12.J * c23.I - 2 * b1X * c12.I * c12.J * c23.J - 2 * c12.I * b1Y * c12.J * c23.I - 2 * c12.I * c21.I * c12.J * c22.J - 2 * c12.I * c12.J * c21.J * c22.I - 2 * a1X * c12y2 * c23.I - 2 * a1Y * c12x2 * c23.J + 2 * b1X * c12y2 * c23.I + 2 * c21.I * c12y2 * c22.I - c11y2 * c12.I * c23.I - c11x2 * c12.J * c23.J + c12x2 * (2 * b1Y * c23.J + 2 * c21.J * c22.J),
                /* t^4 */ 2 * a1X * c12.I * c12.J * c22.J + 2 * a1Y * c12.I * c12.J * c22.I + c11.I * c11.J * c12.I * c22.J + c11.I * c11.J * c12.J * c22.I - 2 * b1X * c12.I * c12.J * c22.J - 2 * c12.I * b1Y * c12.J * c22.I - 2 * c12.I * c21.I * c12.J * c21.J - 2 * a1X * c12y2 * c22.I - 2 * a1Y * c12x2 * c22.J + 2 * b1X * c12y2 * c22.I - c11y2 * c12.I * c22.I - c11x2 * c12.J * c22.J + c21x2 * c12y2 + c12x2 * (2 * b1Y * c22.J + c21y2),
                /* t^5 */ 2 * a1X * c12.I * c12.J * c21.J + 2 * a1Y * c12.I * c21.I * c12.J + c11.I * c11.J * c12.I * c21.J + c11.I * c11.J * c21.I * c12.J - 2 * b1X * c12.I * c12.J * c21.J - 2 * c12.I * b1Y * c21.I * c12.J - 2 * a1X * c21.I * c12y2 - 2 * a1Y * c12x2 * c21.J + 2 * b1X * c21.I * c12y2 - c11y2 * c12.I * c21.I - c11x2 * c12.J * c21.J + 2 * c12x2 * b1Y * c21.J,
                /* t^6 */ -2 * a1X * a1Y * c12.I * c12.J - a1X * c11.I * c11.J * c12.J - a1Y * c11.I * c11.J * c12.I + 2 * a1X * c12.I * b1Y * c12.J + 2 * a1Y * b1X * c12.I * c12.J + c11.I * b1X * c11.J * c12.J + c11.I * c11.J * c12.I * b1Y - 2 * b1X * c12.I * b1Y * c12.J - 2 * a1X * b1X * c12y2 + a1X * c11y2 * c12.I + a1Y * c11x2 * c12.J - 2 * a1Y * c12x2 * b1Y - b1X * c11y2 * c12.I - c11x2 * b1Y * c12.J + c10x2 * c12y2 + c10y2 * c12x2 + c20x2 * c12y2 + c12x2 * c20y2
                ).RootsInInterval(0, 1);

            foreach (var s in roots)
            {
                var point = new Point2D(c23.I * s * s * s + c22.I * s * s + c21.I * s + b1X, c23.J * s * s * s + c22.J * s * s + c21.J * s + b1Y);
                var xRoots = QuadraticRootsTests.QuadraticRootsKevinLinDev(
                    /* c */ c12.I,
                    /* t^1 */ c11.I,
                    /* t^2 */ a1X - point.X,
                    epsilon);
                var yRoots = QuadraticRootsTests.QuadraticRootsKevinLinDev(
                    /* c */ c12.J,
                    /* t^1 */ c11.J,
                    /* t^2 */ a1Y - point.Y,
                    epsilon);
                if (xRoots.Count > 0 && yRoots.Count > 0)
                {
                    foreach (var xRoot in xRoots)
                    {
                        if (0 <= xRoot && xRoot <= 1)
                        {
                            foreach (var yRoot in yRoots)
                            {
                                var t = xRoot - yRoot;
                                if ((t >= 0 ? t : -t) < epsilon)
                                {
                                    result.Points.Add(point);
                                    goto checkRoots;
                                }
                            }
                        }
                    }
                checkRoots:;
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
