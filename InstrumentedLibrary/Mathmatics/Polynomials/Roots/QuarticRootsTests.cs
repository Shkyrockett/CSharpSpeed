using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The quartic roots tests class.
    /// </summary>
    [DisplayName("Quartic Roots")]
    [Description("Find the real roots of a Quartic polynomial.")]
    [SourceCodeLocationProvider]
    public static class QuarticRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(QuarticRootsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<double> {}, epsilon: double.Epsilon) },
                { new object[] { 5d, 4d, 3d, 2d, 1d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<double> {}, epsilon: double.Epsilon) },
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static IList<double> QuarticRoots(double a, double b, double c, double d, double e, double epsilon = Epsilon)
            => QuarticRoots0(a, b, c, d, e, epsilon);

        /// <summary>
        /// The quartic roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="IList{T}"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/geometry/2D/intersections/
        /// </acknowledgment>
        [DisplayName("Quartic Roots")]
        [Description("Find real Quartic Roots.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuarticRoots0(double a, double b, double c, double d, double e, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is cubic.
            if (a is 0d)
            {
                return CubicRootsTests.CubicRoots(b, c, d, e, epsilon);
            }

            var A = b / a;
            var B = c / a;
            var C = d / a;
            var D = e / a;

            var resolveRoots = CubicRootsTests.CubicRoots(
                (-A * A * D) + (4d * B * D) - (C * C),
                (A * C) - (4d * D),
                -B,
                1d,
                epsilon);
            var y = resolveRoots[0];
            var discriminant = (A * A * OneQuarter) - B + y;

            // ToDo: May need to switch from a hash set to a list for scan-beams.
            var results = new HashSet<double>();

            if (Abs(discriminant) <= epsilon)
            {
                discriminant = 0d;
            }

            if (discriminant > 0d)
            {
                var ee = Sqrt(discriminant);
                var t1 = (3d * A * A * OneQuarter) - (ee * ee) - (2d * B);
                var t2 = ((4d * A * B) - (8d * C) - (A * A * A)) / (4d * ee);
                var plus = t1 + t2;
                var minus = t1 - t2;
                if (Abs(plus) <= epsilon)
                {
                    plus = 0d;
                }

                if (Abs(minus) <= epsilon)
                {
                    minus = 0d;
                }

                if (plus >= 0d)
                {
                    var f = Sqrt(plus);
                    results.Add((-A * OneQuarter) + ((ee + f) * OneHalf));
                    results.Add((-A * OneQuarter) + ((ee - f) * OneHalf));
                }
                if (minus >= 0d)
                {
                    var f = Sqrt(minus);
                    results.Add((-A * OneQuarter) + ((f - ee) * OneHalf));
                    results.Add((-A * OneQuarter) - ((f + ee) * OneHalf));
                }
            }
            else if (discriminant < 0d)
            {
            }
            else
            {
                var t2 = (y * y) - (4d * D);
                if (t2 >= -epsilon)
                {
                    if (t2 < 0)
                    {
                        t2 = 0d;
                    }

                    t2 = 2d * Sqrt(t2);
                    var t1 = (3d * A * A * OneQuarter) - (2d * B);
                    if (t1 + t2 >= epsilon)
                    {
                        var d0 = Sqrt(t1 + t2);
                        results.Add((-A * OneQuarter) + (d0 * OneHalf));
                        results.Add((-A * OneQuarter) - (d0 * OneHalf));
                    }
                    if (t1 - t2 >= epsilon)
                    {
                        var d1 = Sqrt(t1 - t2);
                        results.Add((-A * OneQuarter) + (d1 * OneHalf));
                        results.Add((-A * OneQuarter) - (d1 * OneHalf));
                    }
                }
            }

            return results.ToList();
        }

        //**
        //    Calculates roots of quartic polynomial. <br/>
        //    First, derivative roots are found, then used to split quartic polynomial
        //    into segments, each containing one root of quartic polynomial.
        //    Segments are then passed to newton's method to find roots.

        //    @returns {Array<Number>} roots
        //*/
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public List<double> QuarticRoots0(, double epsilon = Epsilon)
        //{
        //    var coefficients = new List<double>();
        //    var results = new List<double>();

        //    var n = (int)Degree;
        //    if (n == 4)
        //    {
        //        var poly = new Polynomial()
        //        {
        //            coefficients = coefficients.Slice()
        //        };
        //        poly.Divide(poly.coefficients[n]);
        //        var ERRF = 1e-15;
        //        if (Abs(poly.coefficients[0]) < 10 * ERRF * Abs(poly.coefficients[3]))
        //            poly.coefficients[0] = 0;
        //        var poly_d = poly.Derivate();
        //        List<double> derrt = poly_d.Roots();
        //        derrt.Sort((a, b) => (int)(a - b));
        //        var dery = new List<double>();
        //        var nr = derrt.Count - 1;
        //        var i = 0;
        //        var rb = Bounds();
        //        var maxabsX = Max(Abs(rb.minX), Abs(rb.maxX));
        //        var ZEROepsilon = ZeroErrorEstimate(maxabsX);

        //        for (i = 0; i <= nr; i++)
        //        {
        //            dery.Add(poly.Evaluate(derrt[i]));
        //        }

        //        for (i = 0; i <= nr; i++)
        //        {
        //            if (Abs(dery[i]) < ZEROepsilon)
        //                dery[i] = 0;
        //        }

        //        i = 0;
        //        var dx = Max(0.1 * (rb.maxX - rb.minX) / n, ERRF);
        //        var guesses = new List<double>();
        //        var minmax = new List<(double, double)>();
        //        if (nr > -1)
        //        {
        //            if (dery[0] != 0)
        //            {
        //                if (Sign(dery[0]) != Sign(poly.Evaluate(derrt[0] - dx) - dery[0]))
        //                {
        //                    guesses.Add(derrt[0] - dx);
        //                    minmax.Add((rb.minX, derrt[0]));
        //                }
        //            }
        //            else
        //            {
        //                results.AddRange(new[] { derrt[0], derrt[0] });
        //                i++;
        //            }

        //            for (; i < nr; i++)
        //            {
        //                if (dery[i + 1] == 0)
        //                {
        //                    results.AddRange(new[] { derrt[i + 1], derrt[i + 1] });
        //                    i++;
        //                }
        //                else if (Sign(dery[i]) != Sign(dery[i + 1]))
        //                {
        //                    guesses.Add((derrt[i] + derrt[i + 1]) / 2);
        //                    minmax.Add((derrt[i], derrt[i + 1]));
        //                }
        //            }
        //            if (dery[nr] != 0 && Sign(dery[nr]) != Sign(poly.Evaluate(derrt[nr] + dx) - dery[nr]))
        //            {
        //                guesses.Add(derrt[nr] + dx);
        //                minmax.Add((derrt[nr], rb.maxX));
        //            }
        //        }

        //        if (guesses.Count > 0)
        //        {
        //            for (i = 0; i < guesses.Count; i++)
        //            {
        //                guesses[i] = Newton_secant_bisection(guesses[i], (x) => poly.Evaluate(x), (x) => poly_d.Evaluate(x), 32, minmax[i].Item1, minmax[i].Item2);
        //            }
        //        }

        //        results = results.Concat(guesses).ToList();
        //    }
        //    return results;
        //}

        /// <summary>
        /// This basically calculates the rational roots of the quartic.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="Array"/>.</returns>
        /// <acknowledgment>
        /// https://gist.github.com/drawable/92792f59b6ff8869d8b1
        /// </acknowledgment>
        [DisplayName("Quartic Roots Stephan Smola")]
        [Description("Stephan Smola's method for finding real Quartic Roots.")]
        [Acknowledgment("https://gist.github.com/drawable/92792f59b6ff8869d8b1")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuarticRootsStephanSmola(double a, double b, double c, double d, double e, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is cubic.
            if (a is 0d)
            {
                return CubicRootsTests.CubicRoots(b, c, d, e, epsilon);
            }

            var delta = (256d * a * a * a * e * e * e) - (192d * a * a * b * d * e * e) - (128d * a * a * c * c * e * e) + (144d * a * a * c * d * d * e) - (27d * a * a * d * d * d * d) + (144d * a * b * b * c * e * e) - (6d * a * b * b * d * d * e) - (80d * a * b * c * c * d * e) + (18d * a * b * c * d * d * d) + (16d * a * c * c * c * c * e) - (4d * a * c * c * c * d * d) - (27d * b * b * b * b * e * e) + (18d * b * b * b * c * d * e) - (4d * b * b * b * d * d * d) - (4d * b * b * c * c * c * e) + (b * b * c * c * d * d);
            var P = (8d * a * c) - (3d * b * b);
            var D = (64d * a * a * a * e) - (16d * a * a * c * c) + (16d * a * b * b * c) - (16d * a * a * b * d) - (3d * b * b * b * b);
            var d0 = (c * c) - (3d * b * d) + (12d * a * e);
            var d1 = (2d * c * c * c) - (9d * b * c * d) + (27d * b * b * e) + (27d * a * d * d) - (72d * a * c * e);
            var p = ((8 * a * c) - (3d * b * b)) / (8d * a * a);
            var q = ((b * b * b) - (4d * a * b * c) + (8 * a * a * d)) / (8d * a * a * a);
            var Q = 0d;
            var S = 0d;

            var phi = Acos(d1 / (2d * Sqrt(d0 * d0 * d0)));

            if (double.IsNaN(phi) && (d1 == 0d))
            {
                // if (delta < 0) I guess the new test is ok because we're only interested in real roots
                Q = d1 + Sqrt((d1 * d1) - (4d * d0 * d0 * d0));
                Q /= 2d;
                Q = Cbrt(Q);
                S = 0.5d * Sqrt((-2d / 3d * p) + (1d / (3d * a) * (Q + (d0 / Q))));
            }
            else
            {
                S = 0.5d * Sqrt((-2d / 3d * p) + (2d / (3d * a) * Sqrt(d0) * Cos(phi / 3d)));
            }

            var y = new List<double>();
            if (S != 0d)
            {
                var R = (-4d * S * S) - (2d * p) + (q / S);

                if (Abs(R) < epsilon)
                {
                    R = 0d;
                }

                if (R > 0d)
                {
                    R = 0.5d * Sqrt(R);
                    y.Add((-b / (4 * a)) - S + R);
                    y.Add((-b / (4 * a)) - S - R);
                }
                else if (Abs(R) < epsilon)
                {
                    y.Add((-b / (4d * a)) - S);
                }

                R = (-4d * S * S) - (2d * p) - (q / S);

                if (Abs(R) < epsilon)
                {
                    R = 0d;
                }

                if (R > 0d)
                {
                    R = 0.5d * Sqrt(R);
                    y.Add((-b / (4d * a)) + S + R);
                    y.Add((-b / (4d * a)) + S - R);
                }
                else if (R == 0d)
                {
                    y.Add((-b / (4d * a)) + S);
                }
            }

            return y;
        }
    }
}
