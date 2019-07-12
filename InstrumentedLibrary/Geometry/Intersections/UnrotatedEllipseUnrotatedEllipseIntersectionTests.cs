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
    /// The unrotated ellipse unrotated ellipse intersection tests class.
    /// </summary>
    [DisplayName("Ellipse, Ellipse Intersection Tests")]
    [Description("Finds the intersection points of two Ellipse.")]
    [SourceCodeLocationProvider]
    public static class UnrotatedEllipseUnrotatedEllipseIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(UnrotatedEllipseUnrotatedEllipseIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 1d, 0d, 2d, 2d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="acX"></param>
        /// <param name="acY"></param>
        /// <param name="arX"></param>
        /// <param name="arY"></param>
        /// <param name="bcX"></param>
        /// <param name="bcY"></param>
        /// <param name="brX"></param>
        /// <param name="brY"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection UnrotatedEllipseUnrotatedEllipseIntersection(double acX, double acY, double arX, double arY, double bcX, double bcY, double brX, double brY, double epsilon = Epsilon)
            => Intersect(acX, acY, arX, arY, bcX, bcY, brX, brY, epsilon);

        /// <summary>
        /// Finds Intersection of two Ellipse'
        /// </summary>
        /// <param name="acX"></param>
        /// <param name="acY"></param>
        /// <param name="arX"></param>
        /// <param name="arY"></param>
        /// <param name="bcX"></param>
        /// <param name="bcY"></param>
        /// <param name="brX"></param>
        /// <param name="brY"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [DisplayName("Ellipse, Ellipse Intersection Tests")]
        [Description("Finds the intersection points of two Ellipse.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection Intersect(
            double acX, double acY, double arX, double arY,
            double bcX, double bcY, double brX, double brY,
            double epsilon = Epsilon)
        {
            var ellipseA = (Center: (X: acX, Y: acY), MajorRadius: Max(arX, arY));
            var ellipseB = (Center: (X: bcX, Y: bcY), MajorRadius: Max(brX, brY));

            var result = new Intersection(IntersectionStates.NoIntersection);

            var d = ellipseB.Center.X * ellipseB.Center.X - ellipseA.Center.X * ellipseA.Center.X - ellipseB.MajorRadius * ellipseB.MajorRadius - Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2) + ellipseA.MajorRadius * ellipseA.MajorRadius;
            var a = Pow(2d * ellipseA.Center.X - 2d * ellipseB.Center.X, 2d) + 4d * Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2d);
            var b = 2d * d * (2d * ellipseA.Center.X - 2d * ellipseB.Center.X) - 8d * ellipseB.Center.X * Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2d);
            var C = 4d * ellipseB.Center.X * ellipseB.Center.X * Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2d) + d * d - 4d * Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2d) * ellipseB.MajorRadius * ellipseB.MajorRadius;
            var XA = (-b + Sqrt(b * b - 4d * a * C)) / (2d * a);
            var XB = (-b - Sqrt(b * b - 4d * a * C)) / (2d * a);
            var YA = Sqrt(ellipseA.MajorRadius * ellipseA.MajorRadius - Pow(XA - ellipseA.Center.X, 2)) + ellipseA.Center.Y;
            var YB = -Sqrt(ellipseA.MajorRadius * ellipseA.MajorRadius - Pow(XA - ellipseA.Center.X, 2)) + ellipseA.Center.Y;
            var YC = Sqrt(ellipseA.MajorRadius * ellipseA.MajorRadius - Pow(XB - ellipseA.Center.X, 2)) + ellipseA.Center.Y;
            var YD = -Sqrt(ellipseA.MajorRadius * ellipseA.MajorRadius - Pow(XB - ellipseA.Center.X, 2)) + ellipseA.Center.Y;
            var e = XA - ellipseB.Center.X + Pow(YA - ellipseB.Center.Y, 2) - ellipseB.MajorRadius * ellipseB.MajorRadius;
            var F = XA - ellipseB.Center.X + Pow(YB - ellipseB.Center.Y, 2) - ellipseB.MajorRadius * ellipseB.MajorRadius;
            var g = XB - ellipseB.Center.X + Pow(YC - ellipseB.Center.Y, 2) - ellipseB.MajorRadius * ellipseB.MajorRadius;
            var H = XB - ellipseB.Center.X + Pow(YD - ellipseB.Center.Y, 2) - ellipseB.MajorRadius * ellipseB.MajorRadius;
            if (Abs(F) < Abs(e))
            {
                YA = YB;
            }

            if (Abs(H) < Abs(g))
            {
                YC = YD;
            }

            if (Abs(ellipseA.Center.Y - ellipseB.Center.Y) < epsilon)
            {
                YC = 2 * ellipseA.Center.Y - YA;
            }

            result.AppendPoint((XA, YA));
            result.AppendPoint((XB, YC));
            result.State = IntersectionStates.Intersection;
            return result;
        }

        /// <summary>
        /// The intersect.
        /// </summary>
        /// <param name="acX">The acX.</param>
        /// <param name="acY">The acY.</param>
        /// <param name="arX">The arX.</param>
        /// <param name="arY">The arY.</param>
        /// <param name="bcX">The bcX.</param>
        /// <param name="bcY">The bcY.</param>
        /// <param name="brX">The brX.</param>
        /// <param name="brY">The brY.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [DisplayName("Ellipse, Ellipse Intersection Tests")]
        [Description("Finds the intersection points of two Ellipse.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection IntersecttionUsingNewtonsMethod(
            double acX, double acY, double arX, double arY,
            double bcX, double bcY, double brX, double brY,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionStates.NoIntersection);

            (var Dx1, var Dy1, var Rx1, var Ry1, var A1, var B1, var C1, var D1, var E1, var F1) = GetEllipseFormula(acX, acY, arX, arY, epsilon);
            var Ellipse1 = new Rectangle2D(acX - arX, acY - arY, arX * 2d, arY * 2d);
            (var Dx2, var Dy2, var Rx2, var Ry2, var A2, var B2, var C2, var D2, var E2, var F2) = GetEllipseFormula(bcX, bcY, brX, brY, epsilon);
            var Ellipse2 = new Rectangle2D(bcX - brX, bcY - brY, brX * 2d, brY * 2d);

            // Find the difference tangents.
            var TangentX = 184d;
            (var TangentCenters, var TangentP1, var TangentP2) = FindDifferenceTangents(TangentX, A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2);

            // Find the roots of the difference equations
            // and thus the points of intersection.
            var xmin = Max(Ellipse1.Left, Ellipse2.Left);
            var xmax = Min(Ellipse1.Right, Ellipse2.Right);
            (var Roots, var RootSign1, var RootSign2, var PointsOfIntersection) = FindPointsOfIntersectionNewtonsMethod(xmin, xmax, A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2);

            result.AppendPoints(PointsOfIntersection);

            return result;
        }

        /// <summary>
        /// Find the points of intersection.
        /// </summary>
        /// <param name="xmin"></param>
        /// <param name="xmax"></param>
        /// <param name="a1"></param>
        /// <param name="b1"></param>
        /// <param name="c1"></param>
        /// <param name="d1"></param>
        /// <param name="e1"></param>
        /// <param name="f1"></param>
        /// <param name="a2"></param>
        /// <param name="b2"></param>
        /// <param name="c2"></param>
        /// <param name="d2"></param>
        /// <param name="e2"></param>
        /// <param name="f2"></param>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (List<(double X, double Y)> Roots, List<double> RootSign1, List<double> RootSign2, List<(double X, double Y)> PointsOfIntersection) FindPointsOfIntersectionNewtonsMethod(
            double xmin, double xmax,
            double a1, double b1, double c1, double d1, double e1, double f1,
            double a2, double b2, double c2, double d2, double e2, double f2)
        {
            (var Roots, var RootSign1, var RootSign2, var PointsOfIntersection) = (new List<(double X, double Y)>(), new List<double>(), new List<double>(), new List<(double X, double Y)>());

            // Find roots for each of the difference equations.
            double[] signs = { +1d, -1d };
            foreach (var sign1 in signs)
            {
                foreach (var sign2 in signs)
                {
                    var points = FindRootsUsingNewtonsMethod(
                        xmin, xmax,
                        a1, b1, c1, d1, e1, f1, sign1,
                        a2, b2, c2, d2, e2, f2, sign2);
                    if (points.Count > 0)
                    {
                        Roots.AddRange(points);
                        for (var i = 0; i < points.Count; i++)
                        {
                            RootSign1.Add(sign1);
                            RootSign2.Add(sign2);
                        }
                    }
                }
            }

            // Find corresponding points of intersection.
            for (var i = 0; i < Roots.Count; i++)
            {
                var y1 = G1(Roots[i].X, a1, b1, c1, d1, e1, f1, RootSign1[i]);
                var y2 = G1(Roots[i].X, a2, b2, c2, d2, e2, f2, RootSign2[i]);
                PointsOfIntersection.Add(new Point2D(Roots[i].X, y1));

                // Validation.
                //Debug.Assert(Abs(y1 - y2) < DoubleEpsilon);
            }

            return (Roots, RootSign1, RootSign2, PointsOfIntersection);
        }

        /// <summary>
        /// Find roots by using Newton's method.
        /// </summary>
        /// <param name="xmin"></param>
        /// <param name="xmax"></param>
        /// <param name="A1"></param>
        /// <param name="B1"></param>
        /// <param name="C1"></param>
        /// <param name="D1"></param>
        /// <param name="E1"></param>
        /// <param name="F1"></param>
        /// <param name="sign1"></param>
        /// <param name="A2"></param>
        /// <param name="B2"></param>
        /// <param name="C2"></param>
        /// <param name="D2"></param>
        /// <param name="E2"></param>
        /// <param name="F2"></param>
        /// <param name="sign2"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<(double X, double Y)> FindRootsUsingNewtonsMethod(double xmin, double xmax,
            double A1, double B1, double C1, double D1, double E1, double F1, double sign1,
            double A2, double B2, double C2, double D2, double E2, double F2, double sign2,
            double epsilon = DoubleEpsilon)
        {
            var roots = new List<(double X, double Y)>();
            const int num_tests = 1000;
            var delta_x = (xmax - xmin) / (num_tests - 1d);

            // Loop over the possible x values looking for roots.
            var x0 = xmin;
            for (var i = 0; i < num_tests; i++)
            {
                // Try to find a root at this position.
                (var x, var y) = UseNewtonsMethod(x0,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);

                // See if we have already found this root.
                if (IsNumberValidTests.IsNumberValid(y))
                {
                    var is_new = true;
                    foreach (var pt in roots)
                    {
                        if (Abs(pt.X - x) < epsilon)
                        {
                            is_new = false;
                            break;
                        }
                    }

                    // If this is a new point, save it.
                    if (is_new)
                    {
                        roots.Add((x, y));

                        // If we've found two roots, we won't find any more.
                        if (roots.Count > 1)
                        {
                            return roots;
                        }
                    }
                }

                x0 += delta_x;
            }

            return roots;
        }

        /// <summary>
        /// Find a root by using Newton's method.
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="A1"></param>
        /// <param name="B1"></param>
        /// <param name="C1"></param>
        /// <param name="D1"></param>
        /// <param name="E1"></param>
        /// <param name="F1"></param>
        /// <param name="sign1"></param>
        /// <param name="A2"></param>
        /// <param name="B2"></param>
        /// <param name="C2"></param>
        /// <param name="D2"></param>
        /// <param name="E2"></param>
        /// <param name="F2"></param>
        /// <param name="sign2"></param>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) UseNewtonsMethod(double x0,
            double A1, double B1, double C1, double D1, double E1, double F1, double sign1,
            double A2, double B2, double C2, double D2, double E2, double F2, double sign2)
        {
            const double cutoff = 0.0000001d;
            const double tiny = 0.00001d;
            const int max_iterations = 100;
            double epsilon;
            var iterations = 0;

            do
            {
                // Display this guess x0.
                iterations++;

                // Make sure x0 isn't on a flat spot.
                var g_prime = GPrime(x0,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);
                while (Abs(g_prime) < tiny)
                {
                    x0 += tiny;
                    g_prime = GPrime(x0,
                        A1, B1, C1, D1, E1, F1, sign1,
                        A2, B2, C2, D2, E2, F2, sign2);
                }

                // Calculate the next estimate for x0.
                var g = G(x0,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);
                epsilon = -g / g_prime;
                x0 += epsilon;
            } while ((Abs(epsilon) > cutoff) && (iterations < max_iterations));

            //Console.WriteLine("G1(" + x + ") = " + y +
            //    ", Epsilon: " + epsilon +
            //    ", Iterations: " + iterations);
            return (x0,
                G(x0,
                A1, B1, C1, D1, E1, F1, sign1,
                A2, B2, C2, D2, E2, F2, sign2)
                );
        }

        /// <summary>
        /// Calculate G'(x).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="A1"></param>
        /// <param name="B1"></param>
        /// <param name="C1"></param>
        /// <param name="D1"></param>
        /// <param name="E1"></param>
        /// <param name="F1"></param>
        /// <param name="sign1"></param>
        /// <param name="A2"></param>
        /// <param name="B2"></param>
        /// <param name="C2"></param>
        /// <param name="D2"></param>
        /// <param name="E2"></param>
        /// <param name="F2"></param>
        /// <param name="sign2"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GPrime(double x,
            double A1, double B1, double C1, double D1, double E1, double F1, double sign1,
            double A2, double B2, double C2, double D2, double E2, double F2, double sign2)
            => G1Prime(x, A1, B1, C1, D1, E1, F1, sign1)
            - G1Prime(x, A2, B2, C2, D2, E2, F2, sign2);

        /// <summary>
        /// Calculate G1'(x). root_sign is -1 or 1.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="rootSign"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double G1Prime(double x, double a, double b, double c, double d, double e, double f, double rootSign)
        {
            var numerator = 2d * (b * x + e) * b - 4d * c * (2d * a * x + d);
            var denominator = 2d * Sqrt((b * x + e) * (b * x + e) - 4d * c * (a * x * x + d * x + f));
            var result = -b + rootSign * numerator / denominator;
            result = result / 2d / c;
            return result;
        }

        /// <summary>
        /// The intersect.
        /// </summary>
        /// <param name="acX">The acX.</param>
        /// <param name="acY">The acY.</param>
        /// <param name="arX">The arX.</param>
        /// <param name="arY">The arY.</param>
        /// <param name="bcX">The bcX.</param>
        /// <param name="bcY">The bcY.</param>
        /// <param name="brX">The brX.</param>
        /// <param name="brY">The brY.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [DisplayName("Ellipse, Ellipse Intersection Tests")]
        [Description("Finds the intersection points of two Ellipse.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection IntersecttionUsingBinaryDivision(
            double acX, double acY, double arX, double arY,
            double bcX, double bcY, double brX, double brY,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionStates.NoIntersection);

            (var Dx1, var Dy1, var Rx1, var Ry1, var A1, var B1, var C1, var D1, var E1, var F1) = GetEllipseFormula(acX, acY, arX, arY, epsilon);
            var Ellipse1 = new Rectangle2D(acX - arX, acY - arY, arX * 2d, arY * 2d);
            (var Dx2, var Dy2, var Rx2, var Ry2, var A2, var B2, var C2, var D2, var E2, var F2) = GetEllipseFormula(bcX, bcY, brX, brY, epsilon);
            var Ellipse2 = new Rectangle2D(bcX - brX, bcY - brY, brX * 2d, brY * 2d);

            // Find the difference tangents.
            var TangentX = 184d;
            (var TangentCenters, var TangentP1, var TangentP2) = FindDifferenceTangents(TangentX, A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2);

            // Find the roots of the difference equations
            // and thus the points of intersection.
            var xmin = Max(Ellipse1.Left, Ellipse2.Left);
            var xmax = Min(Ellipse1.Right, Ellipse2.Right);
            (var Roots, var RootSign1, var RootSign2, var PointsOfIntersection) = FindPointsOfIntersectionUsingBinaryDivision(xmin, xmax, A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2);

            return result;
        }

        /// <summary>
        /// Find the points of intersection.
        /// </summary>
        /// <param name="xmin"></param>
        /// <param name="xmax"></param>
        /// <param name="a1"></param>
        /// <param name="b1"></param>
        /// <param name="c1"></param>
        /// <param name="d1"></param>
        /// <param name="e1"></param>
        /// <param name="f1"></param>
        /// <param name="a2"></param>
        /// <param name="b2"></param>
        /// <param name="c2"></param>
        /// <param name="d2"></param>
        /// <param name="e2"></param>
        /// <param name="f2"></param>
        /// <param name="epsilon"></param>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-4/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (List<(double X, double Y)> Roots, List<double> RootSign1, List<double> RootSign2, List<(double X, double Y)> PointsOfIntersection) FindPointsOfIntersectionUsingBinaryDivision(
            double xmin, double xmax,
            double a1, double b1, double c1, double d1, double e1, double f1,
            double a2, double b2, double c2, double d2, double e2, double f2,
            double epsilon = DoubleEpsilon)
        {
            (var Roots, var RootSign1, var RootSign2, var PointsOfIntersection) = (new List<(double X, double Y)>(), new List<double>(), new List<double>(), new List<(double X, double Y)>());

            // Find roots for each of the difference equations.
            double[] signs = { +1d, -1d };
            foreach (var sign1 in signs)
            {
                foreach (var sign2 in signs)
                {
                    var points = FindRootsUsingBinaryDivision(
                        xmin, xmax,
                        a1, b1, c1, d1, e1, f1, sign1,
                        a2, b2, c2, d2, e2, f2, sign2);
                    if (points.Count > 0)
                    {
                        Roots.AddRange(points);
                        for (var i = 0; i < points.Count; i++)
                        {
                            RootSign1.Add(sign1);
                            RootSign2.Add(sign2);
                        }
                    }
                }
            }

            // Find corresponding points of intersection.
            for (var i = 0; i < Roots.Count; i++)
            {
                var y1 = G1(Roots[i].X, a1, b1, c1, d1, e1, f1, RootSign1[i]);
                var y2 = G1(Roots[i].X, a2, b2, c2, d2, e2, f2, RootSign2[i]);
                PointsOfIntersection.Add((Roots[i].X, y1));

                // Validation.
                Debug.Assert(Abs(y1 - y2) < epsilon);
            }

            return (Roots, RootSign1, RootSign2, PointsOfIntersection);
        }

        /// <summary>
        /// Find roots by using binary division.
        /// </summary>
        /// <param name="xmin"></param>
        /// <param name="xmax"></param>
        /// <param name="A1"></param>
        /// <param name="B1"></param>
        /// <param name="C1"></param>
        /// <param name="D1"></param>
        /// <param name="E1"></param>
        /// <param name="F1"></param>
        /// <param name="sign1"></param>
        /// <param name="A2"></param>
        /// <param name="B2"></param>
        /// <param name="C2"></param>
        /// <param name="D2"></param>
        /// <param name="E2"></param>
        /// <param name="F2"></param>
        /// <param name="sign2"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-4/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<(double X, double Y)> FindRootsUsingBinaryDivision(double xmin, double xmax,
            double A1, double B1, double C1, double D1, double E1, double F1, double sign1,
            double A2, double B2, double C2, double D2, double E2, double F2, double sign2,
            double epsilon = DoubleEpsilon)
        {
            var roots = new List<(double X, double Y)>();
            const int num_tests = 10;
            var delta_x = (xmax - xmin) / (num_tests - 1);

            // Loop over the possible x values looking for roots.
            var x0 = xmin;
            for (var i = 0; i < num_tests; i++)
            {
                // Try to find a root in this range.
                (var x, var y) = UseBinaryDivision(x0, delta_x,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);

                // See if we have already found this root.
                if (IsNumberValidTests.IsNumberValid(y))
                {
                    var is_new = true;
                    foreach (var pt in roots)
                    {
                        if (Abs(pt.X - x) < epsilon)
                        {
                            is_new = false;
                            break;
                        }
                    }

                    // If this is a new point, save it.
                    if (is_new)
                    {
                        roots.Add((x, y));

                        // If we've found two roots, we won't find any more.
                        if (roots.Count > 1)
                        {
                            return roots;
                        }
                    }
                }

                x0 += delta_x;
            }

            return roots;
        }

        /// <summary>
        /// Find a root by using binary division.
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="deltaX"></param>
        /// <param name="A1"></param>
        /// <param name="B1"></param>
        /// <param name="C1"></param>
        /// <param name="D1"></param>
        /// <param name="E1"></param>
        /// <param name="F1"></param>
        /// <param name="sign1"></param>
        /// <param name="A2"></param>
        /// <param name="B2"></param>
        /// <param name="C2"></param>
        /// <param name="D2"></param>
        /// <param name="E2"></param>
        /// <param name="F2"></param>
        /// <param name="sign2"></param>
        /// <param name="epsilon"></param>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-4/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) UseBinaryDivision(double x0, double deltaX,
            double A1, double B1, double C1, double D1, double E1, double F1, double sign1,
            double A2, double B2, double C2, double D2, double E2, double F2, double sign2,
            double epsilon = DoubleEpsilon)
        {
            const int num_trials = 200;
            const int sgn_nan = -2;

            // Get G(x) for the bounds.
            var xmin = x0;
            var g_xmin = G(xmin,
                A1, B1, C1, D1, E1, F1, sign1,
                A2, B2, C2, D2, E2, F2, sign2);
            if (Abs(g_xmin) < epsilon)
            {
                return (xmin, g_xmin);
            }

            var xmax = xmin + deltaX;
            var g_xmax = G(xmax,
                A1, B1, C1, D1, E1, F1, sign1,
                A2, B2, C2, D2, E2, F2, sign2);
            if (Abs(g_xmax) < epsilon)
            {
                return (xmax, g_xmax);
            }

            // Get the sign of the values.
            int sgn_min, sgn_max;
            sgn_min = IsNumberValidTests.IsNumberValid(g_xmin) ? Sign(g_xmin) : sgn_nan;
            sgn_max = IsNumberValidTests.IsNumberValid(g_xmax) ? Sign(g_xmax) : sgn_nan;

            // If the two values have the same sign,
            // then there is no root here.
            if (sgn_min == sgn_max)
            {
                return (1d, double.NaN);
            }

            // Use binary division to find the point of intersection.
            var xmid = 0d;
            var g_xmid = 0d;
            var sgn_mid = 0;
            for (var i = 0; i < num_trials; i++)
            {
                // Get values for the midpoint.
                xmid = (xmin + xmax) / 2d;
                g_xmid = G(xmid,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);
                sgn_mid = IsNumberValidTests.IsNumberValid(g_xmid) ? Sign(g_xmid) : sgn_nan;

                // If sgn_mid is 0, gxmid is 0 so this is the root.
                if (sgn_mid == 0)
                {
                    break;
                }

                // See which half contains the root.
                if (sgn_mid == sgn_min)
                {
                    // The min and mid values have the same sign.
                    // Search the right half.
                    xmin = xmid;
                    g_xmin = g_xmid;
                }
                else if (sgn_mid == sgn_max)
                {
                    // The max and mid values have the same sign.
                    // Search the left half.
                    xmax = xmid;
                    g_xmax = g_xmid;
                }
                else
                {
                    // The three values have different signs.
                    // Assume min or max is NaN.
                    if (sgn_min == sgn_nan)
                    {
                        // Value g_xmin is NaN. Use the right half.
                        xmin = xmid;
                        g_xmin = g_xmid;
                    }
                    else if (sgn_max == sgn_nan)
                    {
                        // Value g_xmax is NaN. Use the right half.
                        xmax = xmid;
                        g_xmax = g_xmid;
                    }
                    else
                    {
                        // This is a weird case. Just trap it.
                        throw new InvalidOperationException($"Unexpected difference curve. Cannot find a root between X = {xmin} and X = {xmax}");
                    }
                }
            }

            if (IsNumberValidTests.IsNumberValid(g_xmid) && (Abs(g_xmid) < epsilon))
            {
                return (xmid, g_xmid);
            }
            else if (IsNumberValidTests.IsNumberValid(g_xmin) && (Abs(g_xmin) < epsilon))
            {
                return (xmin, g_xmin);
            }
            else if (IsNumberValidTests.IsNumberValid(g_xmax) && (Abs(g_xmax) < epsilon))
            {
                return (xmax, g_xmax);
            }
            else
            {
                return (xmid, double.NaN);
            }
        }

        /// <summary>
        /// Calculate G(x).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="A1"></param>
        /// <param name="B1"></param>
        /// <param name="C1"></param>
        /// <param name="D1"></param>
        /// <param name="E1"></param>
        /// <param name="F1"></param>
        /// <param name="sign1"></param>
        /// <param name="A2"></param>
        /// <param name="B2"></param>
        /// <param name="C2"></param>
        /// <param name="D2"></param>
        /// <param name="E2"></param>
        /// <param name="F2"></param>
        /// <param name="sign2"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double G(double x,
            double A1, double B1, double C1, double D1, double E1, double F1, double sign1,
            double A2, double B2, double C2, double D2, double E2, double F2, double sign2)
            => G1(x, A1, B1, C1, D1, E1, F1, sign1)
            - G1(x, A2, B2, C2, D2, E2, F2, sign2);

        /// <summary>
        /// Calculate G1(x). root_sign is -1 or 1.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="rootSign"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double G1(double x, double a, double b, double c, double d, double e, double f, double rootSign)
        {
            var result = b * x + e;
            result *= result;
            result -= 4d * c * (a * x * x + d * x + f);
            result = rootSign * Sqrt(result);
            result = -(b * x + e) + result;
            result = result / 2d / c;

            return result;
        }

        /// <summary>
        /// Get points representing the difference between the two ellipses' equations.
        /// </summary>
        /// <param name="xmin1"></param>
        /// <param name="xmax1"></param>
        /// <param name="xmin2"></param>
        /// <param name="xmax2"></param>
        /// <param name="A1"></param>
        /// <param name="B1"></param>
        /// <param name="C1"></param>
        /// <param name="D1"></param>
        /// <param name="E1"></param>
        /// <param name="F1"></param>
        /// <param name="A2"></param>
        /// <param name="B2"></param>
        /// <param name="C2"></param>
        /// <param name="D2"></param>
        /// <param name="E2"></param>
        /// <param name="F2"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<List<(double X, double Y)>> GetDifferencePoints(
            double xmin1, double xmax1,
            double xmin2, double xmax2,
            double A1, double B1, double C1, double D1, double E1, double F1,
            double A2, double B2, double C2, double D2, double E2, double F2)
        {
            var xmin = Min(xmin1, xmin2);
            var xmax = Max(xmax1, xmax2);
            var result = new List<List<(double X, double Y)>>();

            double[] signs = { -1d, +1d };
            foreach (var sign1 in signs)
            {
                foreach (var sign2 in signs)
                {
                    var points = new List<(double X, double Y)>();
                    result.Add(points);
                    for (var x = xmin; x <= xmax; x++)
                    {
                        var y1 = G1(A1, B1, C1, D1, E1, F1, x, sign1);
                        if (IsNumberValidTests.IsNumberValid(y1))
                        {
                            var y2 = G1(A2, B2, C2, D2, E2, F2, x, sign2);
                            if (IsNumberValidTests.IsNumberValid(y2))
                            {
                                points.Add((x, y1 - y2));
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Find tangents to the difference functions.
        /// </summary>
        /// <param name="TangentX"></param>
        /// <param name="a1"></param>
        /// <param name="b1"></param>
        /// <param name="c1"></param>
        /// <param name="d1"></param>
        /// <param name="e1"></param>
        /// <param name="f1"></param>
        /// <param name="a2"></param>
        /// <param name="b2"></param>
        /// <param name="c2"></param>
        /// <param name="d2"></param>
        /// <param name="e2"></param>
        /// <param name="f2"></param>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (List<(double X, double Y)> TangentCenters, List<(double X, double Y)> TangentP1, List<(double X, double Y)> TangentP2) FindDifferenceTangents(
            double TangentX,
            double a1, double b1, double c1, double d1, double e1, double f1,
            double a2, double b2, double c2, double d2, double e2, double f2)
        {
            const double tangent_length = 50d;

            (var TangentCenters, var TangentP1, var TangentP2) = (new List<(double X, double Y)>(), new List<(double X, double Y)>(), new List<(double X, double Y)>());

            //++
            var tangent_y = G(TangentX,
                a1, b1, c1, d1, e1, f1, +1d,
                a2, b2, c2, d2, e2, f2, +1d);
            if (IsNumberValidTests.IsNumberValid(tangent_y))
            {
                var slope =
                    G1Prime(TangentX, a1, b1, c1, d1, e1, f1, +1d)
                    - G1Prime(TangentX, a2, b2, c2, d2, e2, f2, +1d);
                if (IsNumberValidTests.IsNumberValid(slope))
                {
                    var delta_x = Sqrt(
                        tangent_length * tangent_length / (1d + slope * slope)) / 2d;
                    TangentCenters.Add((TangentX, tangent_y));
                    TangentP1.Add((TangentX - delta_x, tangent_y - slope * delta_x));
                    TangentP2.Add((TangentX + delta_x, tangent_y + slope * delta_x));
                }
            }

            //+-
            tangent_y = G(TangentX,
                a1, b1, c1, d1, e1, f1, +1d,
                a2, b2, c2, d2, e2, f2, -1d);
            if (IsNumberValidTests.IsNumberValid(tangent_y))
            {
                var slope =
                    G1Prime(TangentX, a1, b1, c1, d1, e1, f1, +1d)
                    - G1Prime(TangentX, a2, b2, c2, d2, e2, f2, -1d);
                if (IsNumberValidTests.IsNumberValid(slope))
                {
                    var delta_x = Sqrt(tangent_length * tangent_length / (1d + slope * slope)) / 2d;
                    TangentCenters.Add((TangentX, tangent_y));
                    TangentP1.Add((TangentX - delta_x, tangent_y - slope * delta_x));
                    TangentP2.Add((TangentX + delta_x, tangent_y + slope * delta_x));
                }
            }

            //-+
            tangent_y = G(TangentX,
                a1, b1, c1, d1, e1, f1, -1d,
                a2, b2, c2, d2, e2, f2, +1d);
            if (IsNumberValidTests.IsNumberValid(tangent_y))
            {
                var slope =
                    G1Prime(TangentX, a1, b1, c1, d1, e1, f1, -1d)
                    - G1Prime(TangentX, a2, b2, c2, d2, e2, f2, +1d);
                if (IsNumberValidTests.IsNumberValid(slope))
                {
                    var delta_x = Sqrt(
                        tangent_length * tangent_length / (1d + slope * slope)) / 2d;
                    TangentCenters.Add((TangentX, tangent_y));
                    TangentP1.Add((TangentX - delta_x, tangent_y - slope * delta_x));
                    TangentP2.Add((TangentX + delta_x, tangent_y + slope * delta_x));
                }
            }

            //--
            tangent_y = G(TangentX,
                a1, b1, c1, d1, e1, f1, -1d,
                a2, b2, c2, d2, e2, f2, -1d);
            if (IsNumberValidTests.IsNumberValid(tangent_y))
            {
                var slope =
                    G1Prime(TangentX, a1, b1, c1, d1, e1, f1, -1d)
                    - G1Prime(TangentX, a2, b2, c2, d2, e2, f2, -1d);
                if (IsNumberValidTests.IsNumberValid(slope))
                {
                    var delta_x = Sqrt(
                        tangent_length * tangent_length / (1d + slope * slope)) / 2d;
                    TangentCenters.Add((TangentX, tangent_y));
                    TangentP1.Add((TangentX - delta_x, tangent_y - slope * delta_x));
                    TangentP2.Add((TangentX + delta_x, tangent_y + slope * delta_x));
                }
            }

            return (TangentCenters, TangentP1, TangentP2);
        }

        /// <summary>
        /// Get the equation for this ellipse.
        /// </summary>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="epsilon"></param>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Dx, double Dy, double Rx, double Ry, double a, double b, double c, double d, double e, double f) GetEllipseFormula(
            double cX, double cY, double rX, double rY,
            double epsilon = Epsilon)
        {
            var a = 1d / rX / rX;
            var b = 0d;
            var c = 1d / rY / rY;
            var d = -2d * cX / rX / rX;
            var e = -2d * cY / rY / rY;
            var f = cX * cX / rX / rX + cY * cY / rY / rY - 1d;

            // Verify the parameters.
            var rect = new Rectangle2D(cX - rX, cY - rY, rX * 2d, rY * 2d);
            var xmid = rect.Left + rect.Width / 2d;
            var ymid = rect.Top + rect.Height / 2d;

            //Console.WriteLine($"VerifyEquation ({x}, {y}) = {total}");
            var v = VerifyEquation(a, b, c, d, e, f, rect.Left, ymid, epsilon);
            Debug.Assert(v.Item1, $"VerifyEquation ({rect.Left}, {ymid}) = {v.total}");

            v = VerifyEquation(a, b, c, d, e, f, rect.Right, ymid, epsilon);
            Debug.Assert(v.Item1, $"VerifyEquation ({rect.Right}, {ymid}) = {v.total}");

            v = VerifyEquation(a, b, c, d, e, f, xmid, rect.Top, epsilon);
            Debug.Assert(v.Item1, $"VerifyEquation ({xmid}, {rect.Top}) = {v.total}");

            v = VerifyEquation(a, b, c, d, e, f, xmid, rect.Bottom, epsilon);
            Debug.Assert(v.Item1, $"VerifyEquation ({xmid}, {rect.Bottom}) = {v.total}");

            return (cX, cY, rX, rY, a, b, c, d, e, f);
        }

        /// <summary>
        /// Verify that the equation gives a value close to 0 for the given point (x, y).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="epsilon"></param>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, double total) VerifyEquation(
            double a, double b, double c, double d, double e, double f, double x, double y,
            double epsilon = Epsilon)
        {
            var total = a * x * x + b * x * y + c * y * y + d * x + e * y + f;
            return (Abs(total) < epsilon, total);
        }

        /// <summary>
        /// Get an ellipse's points from its equation.
        /// </summary>
        /// <param name="xmin"></param>
        /// <param name="xmax"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/see-where-two-ellipses-intersect-in-c-part-1/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<Point2D> GetPointsFromEquation(double xmin, double xmax,
            double a, double b, double c, double d, double e, double f)
        {
            var points = new List<Point2D>();
            for (var x = xmin; x <= xmax; x++)
            {
                var y = G1(a, b, c, d, e, f, x, +1d);
                if (IsNumberValidTests.IsNumberValid(y))
                {
                    points.Add(new Point2D(x, y));
                }
            }
            for (var x = xmax; x >= xmin; x--)
            {
                var y = G1(a, b, c, d, e, f, x, -1d);
                if (IsNumberValidTests.IsNumberValid(y))
                {
                    points.Add(new Point2D(x, y));
                }
            }
            return points;
        }
    }
}
