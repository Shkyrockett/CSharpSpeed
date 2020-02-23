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
    /// The cubic roots tests class.
    /// </summary>
    [DisplayName("Cubic Roots")]
    [Description("Find the real roots of a Cubic polynomial.")]
    [SourceCodeLocationProvider]
    public static class CubicRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(CubicRootsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 3d, 4d, 2, Epsilon }, new TestCaseResults(description: "r is 0", trials: trials, expectedReturnValue: new List<double>{-1d }, epsilon: double.Epsilon) },
                { new object[] { 3d, 9d, 12d, 6, Epsilon }, new TestCaseResults(description: "r is 0", trials: trials, expectedReturnValue: new List<double>{-1d }, epsilon: double.Epsilon) },
                { new object[] { 12d, 6d, 4d, 2d, Epsilon }, new TestCaseResults(description: "Root is half", trials: trials, expectedReturnValue: new List<double>{-0.5d }, epsilon: double.Epsilon) },
                { new object[] { 1d, -2d, 3d, -4d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new List<double>{1.6506291914393882d }, epsilon: double.Epsilon) },
                { new object[] { 1d, 2d, 3d, 4d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new List<double>{-1.6506291914393882d }, epsilon: double.Epsilon) },
                { new object[] { 4d, 3d, 2d, 1d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new List<double>{-0.605829586188268d }, epsilon: double.Epsilon) },
                { new object[] { 1d, 3d, -6d, 18d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new List<double>{-4.9478859233751713d }, epsilon: double.Epsilon) },
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
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static IList<double> CubicRoots(double a, double b, double c, double d, double epsilon = Epsilon)
            => CubicRootsKevinLinDev(a, b, c, d, epsilon);

        /// <summary>
        /// Cubic Roots
        /// </summary>
        /// <param name="a">t^3</param>
        /// <param name="b">t^2</param>
        /// <param name="c">t</param>
        /// <param name="d">1</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// based on https://web.archive.org/web/20170322034124/http://abecedarical.com/javascript/script_exact_cubic.html
        /// </acknowledgment>
        [DisplayName("Cubic Roots")]
        [Description("Find real Cubic Roots  Stephen R. Schmitt.")]
        [Acknowledgment("https://web.archive.org/web/20170322034124/http://abecedarical.com/javascript/script_exact_cubic.html")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> CubicRootsStephenRSchmitt(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is quadratic.
            if (a is 0d)
            {
                return QuadraticRootsTests.QuadraticRoots(b, c, d, epsilon);
            }

            var ba = b / a;
            var ca = c / a;
            var da = d / a;

            var q = ((3d * ca) - (ba * ba)) / 9d;
            var r = (-(2d * ba * ba * ba) + (9d * ba * ca) - (27d * da)) / 54d;

            var offset = ba * OneThird;

            // Polynomial discriminant
            var discriminant = (r * r) + (q * q * q);

            // ToDo: May need to switch from a hash set to a list for scan-beams.
            var results = new HashSet<double>();

            if (Abs(discriminant) <= epsilon)
            {
                discriminant = 0d;
            }

            if (discriminant == 0d)
            {
                var t = Sign(r) * Cbrt(Abs(r));

                // Real root.
                results.Add(-offset + (t + t));

                // Real part of complex root.
                results.Add(-offset - ((t + t) * OneHalf));
            }
            if (discriminant > 0)
            {
                var e = Sqrt(discriminant);
                var s = Sign(r + e) * Cbrt(Abs(r + e));
                var t = Sign(r - e) * Cbrt(Abs(r - e));

                // Real root.
                results.Add(-offset + (s + t));

                // Complex part of root pair.
                var Im = Abs(Sqrt3 * (s - t) * OneHalf);
                if (Im == 0d)
                {
                    // Real part of complex root.
                    results.Add(-offset - ((s + t) * OneHalf));
                }
            }
            else if (discriminant < 0)
            {
                // Distinct real roots.
                var th = Acos(r / Sqrt(-q * q * q));

                var sq = Sqrt(-q);
                results.Add((2d * sq * Cos(th * OneThird)) - offset);
                results.Add((2d * sq * Cos((th + Tau) * OneThird)) - offset);
                results.Add((2d * sq * Cos((th + (4d * PI)) * OneThird)) - offset);
            }

            return results.ToList();
        }

        /// <summary>
        /// The cubic roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/geometry/2D/intersections/
        /// </acknowledgment>
        [DisplayName("Cubic Roots Kevin Lin")]
        [Description("Find real Cubic Roots.")]
        [Acknowledgment("http://www.kevlindev.com/geometry/2D/intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> CubicRootsKevinLinDev(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is quadratic.
            if (a is 0d)
            {
                return QuadraticRootsTests.QuadraticRoots(b, c, d, epsilon);
            }

            var ba = b / a;
            var ca = c / a;
            var da = d / a;

            var q = ((3d * ca) - (ba * ba)) * OneThird;
            var r = ((2d * ba * ba * ba) - (9d * ca * ba) + (27d * da)) * OneTwentySeventh;

            var offset = ba * OneThird;
            var discriminant = (r * r * OneQuarter) + (q * q * q * OneTwentySeventh);

            var halfR = OneHalf * r;
            //var ZEROepsilon = ZeroErrorEstimate();

            if (Abs(discriminant) <= epsilon)//ZEROepsilon)
            {
                discriminant = 0d;
            }

            var results = new HashSet<double>();
            if (discriminant > 0d)
            {
                var e = Sqrt(discriminant);
                var tmp = -halfR + e;
                var root = tmp >= 0 ? Cbrt(tmp) : -Cbrt(-tmp);
                tmp = -halfR - e;
                if (tmp >= 0)
                {
                    root += Cbrt(tmp);
                }
                else
                {
                    root -= Cbrt(-tmp);
                }

                results.Add(root - offset);
            }
            else if (discriminant < 0d)
            {
                var distance = Sqrt(-q * OneThird);
                var angle = Atan2(Sqrt(-discriminant), -halfR) * OneThird;

                //var (c, s) = ();

                var cos = Cos(angle);
                var sin = Sin(angle);
                results.Add((2d * distance * cos) - offset);
                results.Add((-distance * (cos + (Sqrt3 * sin))) - offset);
                results.Add((-distance * (cos - (Sqrt3 * sin))) - offset);
            }
            else
            {
                var tmp = halfR >= 0d ? -Cbrt(halfR) : Cbrt(-halfR);
                results.Add((2d * tmp) - offset);
                // really should return next root twice, but we return only one
                results.Add(-tmp - offset);
            }
            return results.ToList();
        }

        /// <summary>
        /// Cubics the roots switch.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns></returns>
        [DisplayName("Cubic Roots")]
        [Description("Find real Cubic Roots.")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> CubicRootsSwitch(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            if (a is 0d)
            {
                return QuadraticRootsTests.QuadraticRoots(b, c, d, epsilon);
            }

            var ba = b / a;
            var ca = c / a;
            var da = d / a;

            var q = ((3d * ca) - (ba * ba)) * OneThird; // / 9d;
            var r = ((2d * ba * ba * ba) - (9d * ba * ca) + (27d * da)) * OneTwentySeventh;// / 54d;

            var offset = ba * OneThird;
            var discriminant = (r * r * OneQuarter) + (q * q * q * OneTwentySeventh);
            var halfB = OneHalf * r;

            if (Abs(discriminant) <= epsilon)
            {
                discriminant = 0d;
            }

            switch (discriminant)
            {
                case 0:
                    {
                        var f = halfB >= 0d ? -Cbrt(halfB) : Cbrt(-halfB);
                        return new double[] {
                            (2d * f) - offset,
                            -f - offset
                        }.ToList();
                    }
                case double v when v > 0d:
                    {
                        var e = Sqrt(v);
                        var tmp = -halfB + e;
                        var root = tmp >= 0 ? Cbrt(tmp) : -Cbrt(-tmp);
                        tmp = -halfB - e;
                        if (tmp >= 0)
                        {
                            root += Cbrt(tmp);
                        }
                        else
                        {
                            root -= Cbrt(-tmp);
                        }

                        return new double[] { root - offset }.ToList();

                        //var s = Sign(r + e) * Cbrt(Abs(r + e));
                        //var t = Sign(r - e) * Cbrt(Abs(r - e));
                        //var im = Abs(Sqrt(3d) * (s - t) * OneHalf);
                        //return im == 0d ?
                        //    new double[] {
                        //    -offset + (s + t)
                        //    }.ToList() :
                        //    new double[] {
                        //        -offset + (s + t),
                        //        -offset - ((s + t) * OneHalf)
                        //    }.ToList();
                    }
                default:
                    {
                        var distance = Sqrt(-q * OneThird);
                        var angle = Atan2(Sqrt(-discriminant), -halfB) * OneThird;
                        var cos = Cos(angle);
                        var sin = Sin(angle);
                        return new double[] {
                            (2d * distance * cos) - offset,
                            (-distance * (cos + (Sqrt3 * sin))) - offset,
                            (-distance * (cos - (Sqrt3 * sin))) - offset
                        }.ToList();
                    }
            }
        }
    }
}
