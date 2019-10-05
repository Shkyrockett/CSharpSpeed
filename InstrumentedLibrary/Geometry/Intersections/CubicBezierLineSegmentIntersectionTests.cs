using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cubic bezier line segment intersection tests class.
    /// </summary>
    [DisplayName("Intersection of Cubic Bezier and Line Segment")]
    [Description("Finds the intersection points of a Cubic Bezier and Line Segment.")]
    [SourceCodeLocationProvider]
    public static class CubicBezierLineSegmentIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(CubicBezierLineSegmentIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 20d, 0d, 5d, 10d, -5d, 20d, 10d, 30d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        /// <param name="p0x"></param>
        /// <param name="p0y"></param>
        /// <param name="p1x"></param>
        /// <param name="p1y"></param>
        /// <param name="p2x"></param>
        /// <param name="p2y"></param>
        /// <param name="p3x"></param>
        /// <param name="p3y"></param>
        /// <param name="l0x"></param>
        /// <param name="l0y"></param>
        /// <param name="l1x"></param>
        /// <param name="l1y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection CubicBezierLineSegmentIntersection(double p0x, double p0y, double p1x, double p1y, double p2x, double p2y, double p3x, double p3y, double l0x, double l0y, double l1x, double l1y, double epsilon = Epsilon)
            => CubicBezierLineSegmentIntersection1(p0x, p0y, p1x, p1y, p2x, p2y, p3x, p3y, l0x, l0y, l1x, l1y, epsilon);

        /// <summary>
        /// The cubic bezier line segment intersection1.
        /// This method has an error where it does not return an intersection with a horizontal line and the end points of the curve share the same y value, as well as the handles sharing another y value.
        /// </summary>
        /// <param name="p0x">The p0x.</param>
        /// <param name="p0y">The p0y.</param>
        /// <param name="p1x">The p1x.</param>
        /// <param name="p1y">The p1y.</param>
        /// <param name="p2x">The p2x.</param>
        /// <param name="p2y">The p2y.</param>
        /// <param name="p3x">The p3x.</param>
        /// <param name="p3y">The p3y.</param>
        /// <param name="l0x">The l0x.</param>
        /// <param name="l0y">The l0y.</param>
        /// <param name="l1x">The l1x.</param>
        /// <param name="l1y">The l1y.</param>
        /// <param name="epsilon"></param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// Found at: https://www.particleincell.com/2013/cubic-line-intersection/
        /// Based on code now found at: http://www.abecedarical.com/javascript/script_cubic.html
        /// </acknowledgment>
        [DisplayName("Intersection of Cubic Bezier and Line Segment")]
        [Description("Finds the intersection points of a Cubic Bezier and Line Segment.")]
        [Acknowledgment("https://www.particleincell.com/2013/cubic-line-intersection/", "http://www.abecedarical.com/javascript/script_cubic.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierLineSegmentIntersection1(
            double p0x, double p0y,
            double p1x, double p1y,
            double p2x, double p2y,
            double p3x, double p3y,
            double l0x, double l0y,
            double l1x, double l1y,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            // ToDo: Figure out why this can't handle intersection with horizontal lines.
            var I = new Intersection(IntersectionStates.NoIntersection);

            var A = l1y - l0y;      //A=y2-y1
            var B = l0x - l1x;      //B=x1-x2
            var C = l0x * (l0y - l1y) + l0y * (l1x - l0x);  //C=x1*(y1-y2)+y1*(x2-x1)

            var xCoeff = BernsteinCubicBezierPolynomialTests.CubicBezierCoefficients(p0x, p1x, p2x, p3x);
            var yCoeff = BernsteinCubicBezierPolynomialTests.CubicBezierCoefficients(p0y, p1y, p2y, p3y);

            var r = CubicRootsTests.CubicRoots(
                /* t^3 */ A * xCoeff.D + B * yCoeff.D,
                /* t^2 */ A * xCoeff.C + B * yCoeff.C,
                /* t^1 */ A * xCoeff.B + B * yCoeff.B,
                /* 1 */ A * xCoeff.A + B * yCoeff.A + C
                );

            /*verify the roots are in bounds of the linear segment*/
            for (var i = 0; i < 3; i++)
            {
                var t = r[i];

                var x = xCoeff.D * t * t * t + xCoeff.C * t * t + xCoeff.B * t + xCoeff.A;
                var y = yCoeff.D * t * t * t + yCoeff.C * t * t + yCoeff.B * t + yCoeff.A;

                /*above is intersection point assuming infinitely long line segment,
                  make sure we are also in bounds of the line*/
                double m;
                m = (l1x - l0x) != 0 ? (x - l0x) / (l1x - l0x) : (y - l0y) / (l1y - l0y);

                /*in bounds?*/
                if (t < 0 || t > 1d || m < 0 || m > 1d)
                {
                    x = 0;// -100;  /*move off screen*/
                    y = 0;// -100;
                }
                else
                {
                    /*intersection point*/
                    I.AppendPoint(new Point2D(x, y));
                    I.State = IntersectionStates.Intersection;
                }
            }
            return I;
        }

        /// <summary>
        /// The cubic bezier line segment intersection.
        /// </summary>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <param name="p4X">The p4X.</param>
        /// <param name="p4Y">The p4Y.</param>
        /// <param name="a1X">The a1X.</param>
        /// <param name="a1Y">The a1Y.</param>
        /// <param name="a2X">The a2X.</param>
        /// <param name="a2Y">The a2Y.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Intersection of Cubic Bezier and Line Segment")]
        [Description("Finds the intersection points of a Cubic Bezier and Line Segment.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierLineSegmentIntersection2(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double p4X, double p4Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            Vector2D a, b, c, d;
            Vector2D c3, c2, c1, c0;
            double cl;
            Vector2D n;
            var min = MinPointTests.MinPoint(a1X, a1Y, a2X, a2Y);
            var max = MaxPointTests.MaxPoint(a1X, a1Y, a2X, a2Y);
            var result = new Intersection(IntersectionStates.NoIntersection);
            a = new Vector2D(p1X, p1Y) * (-1);
            b = new Vector2D(p2X, p2Y) * 3;
            c = new Vector2D(p3X, p3Y) * (-3);
            d = a + (b + (c + new Vector2D(p4X, p4Y)));
            c3 = new Vector2D(d.I, d.J);
            a = new Vector2D(p1X, p1Y) * 3;
            b = new Vector2D(p2X, p2Y) * (-6);
            c = new Vector2D(p3X, p3Y) * 3;
            d = a + (b + c);
            c2 = new Vector2D(d.I, d.J);
            a = new Vector2D(p1X, p1Y) * (-3);
            b = new Vector2D(p2X, p2Y) * 3;
            c = a + b;
            c1 = new Vector2D(c.I, c.J);
            c0 = new Vector2D(p1X, p1Y);
            n = new Vector2D(a1Y - a2Y, a2X - a1X);
            cl = a1X * a2Y - a2X * a1Y;
            var roots = CubicRootsTests.CubicRoots(
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c3.I, c3.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c2.I, c2.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c1.I, c1.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c0.I + cl, c0.J + cl),
                epsilon);
            for (var i = 0; i < roots.Count; i++)
            {
                var t = roots[i];
                if (0 <= t && t <= 1)
                {
                    var p5 = InterpolateLinear2DTests.LinearInterpolate2D(t, p1X, p1Y, p2X, p2Y);
                    var p6 = InterpolateLinear2DTests.LinearInterpolate2D(t, p2X, p2Y, p3X, p3Y);
                    var p7 = InterpolateLinear2DTests.LinearInterpolate2D(t, p3X, p3Y, p4X, p4Y);
                    var p8 = InterpolateLinear2DTests.LinearInterpolate2D(t, p5.X, p5.Y, p6.X, p6.Y);
                    var p9 = InterpolateLinear2DTests.LinearInterpolate2D(t, p6.X, p6.Y, p7.X, p7.Y);
                    var p10 = InterpolateLinear2DTests.LinearInterpolate2D(t, p8.X, p8.Y, p9.X, p9.Y);
                    if (a1X == a2X)
                    {
                        if (min.Y <= p10.Y && p10.Y <= max.Y)
                        {
                            result.State = IntersectionStates.Intersection;
                            result.AppendPoint(p10);
                        }
                    }
                    else if (a1Y == a2Y)
                    {
                        if (min.X <= p10.X && p10.X <= max.X)
                        {
                            result.State = IntersectionStates.Intersection;
                            result.AppendPoint(p10);
                        }
                    }
                    else if (GreaterThanOrEqualTests.GreaterThanOrEqual(p10.X, p10.X, min.Y, min.Y) && LessThanOrEqualTests.LessThanOrEqual(p10.X, p10.Y, max.X, max.Y))
                    {
                        result.State = IntersectionStates.Intersection;
                        result.AppendPoint(p10);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// The line cubic bezier intersection0.
        /// </summary>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <param name="p4X">The p4X.</param>
        /// <param name="p4Y">The p4Y.</param>
        /// <param name="a1X">The a1X.</param>
        /// <param name="a1Y">The a1Y.</param>
        /// <param name="a2X">The a2X.</param>
        /// <param name="a2Y">The a2Y.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Intersection of Cubic Bezier and Line Segment")]
        [Description("Finds the intersection points of a Cubic Bezier and Line Segment.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierLineIntersection0(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double p4X, double p4Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            Vector2D a, b, c, d;
            Vector2D c3, c2, c1, c0;
            double cl;
            Vector2D n;
            var min = MinPointTests.MinPoint(a1X, a1Y, a2X, a2Y);
            var max = MaxPointTests.MaxPoint(a1X, a1Y, a2X, a2Y);
            var result = new Intersection(IntersectionStates.NoIntersection);
            a = new Vector2D(p1X, p1Y) * (-1);
            b = new Vector2D(p2X, p2Y) * 3;
            c = new Vector2D(p3X, p3Y) * (-3);
            d = a + (b + (c + new Vector2D(p4X, p4Y)));
            c3 = new Vector2D(d.I, d.J);
            a = new Vector2D(p1X, p1Y) * 3;
            b = new Vector2D(p2X, p2Y) * (-6);
            c = new Vector2D(p3X, p3Y) * 3;
            d = a + (b + c);
            c2 = new Vector2D(d.I, d.J);
            a = new Vector2D(p1X, p1Y) * (-3);
            b = new Vector2D(p2X, p2Y) * 3;
            c = a + b;
            c1 = new Vector2D(c.I, c.J);
            c0 = new Vector2D(p1X, p1Y);
            n = new Vector2D(a1Y - a2Y, a2X - a1X);
            cl = a1X * a2Y - a2X * a1Y;
            var roots = CubicRootsTests.CubicRoots(
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c3.I, c3.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c2.I, c2.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c1.I, c1.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c0.I + cl, c0.J + cl),
                epsilon);
            for (var i = 0; i < roots.Count; i++)
            {
                var t = roots[i];
                if (0 <= t && t <= 1)
                {
                    var p5 = InterpolateLinear2DTests.LinearInterpolate2D(t, p1X, p1Y, p2X, p2Y);
                    var p6 = InterpolateLinear2DTests.LinearInterpolate2D(t, p2X, p2Y, p3X, p3Y);
                    var p7 = InterpolateLinear2DTests.LinearInterpolate2D(t, p3X, p3Y, p4X, p4Y);
                    var p8 = InterpolateLinear2DTests.LinearInterpolate2D(t, p5.X, p5.Y, p6.X, p6.Y);
                    var p9 = InterpolateLinear2DTests.LinearInterpolate2D(t, p6.X, p6.Y, p7.X, p7.Y);
                    var p10 = InterpolateLinear2DTests.LinearInterpolate2D(t, p8.X, p8.Y, p9.X, p9.Y);
                    if (a1X == a2X)
                    {
                        result.State = IntersectionStates.Intersection;
                        result.AppendPoint(p10);
                    }
                    else if (a1Y == a2Y)
                    {
                        result.State = IntersectionStates.Intersection;
                        result.AppendPoint(p10);
                    }
                    else if (GreaterThanOrEqualTests.GreaterThanOrEqual(p10.X, p10.Y, min.X, min.Y) && LessThanOrEqualTests.LessThanOrEqual(p10.X, p10.Y, max.X, max.Y))
                    {
                        result.State = IntersectionStates.Intersection;
                        result.AppendPoint(p10);
                    }
                }
            }

            return result;
        }
    }
}
