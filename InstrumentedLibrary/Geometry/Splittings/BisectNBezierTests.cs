using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using CSharpSpeed;
using System.ComponentModel;
using System.Reflection;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Bisect Any Number Bezier")]
    [Description("Bisect Any Number Bezier.")]
    [SourceCodeLocationProvider]
    public static class BisectNBezierTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(BisectNBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D[] { (0d, 0d), (0d, 5d), (5d, 5d), (5d, 0d) }, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="points"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (Point2D[] A, Point2D[] B) BisectNBezier(Point2D[] points, double t)
            => BisectNBezier1(points, t);

        /// <summary>
        /// Cut a Bezier into multiple fragments at the given t indices, using "De Casteljau" algorithm.
        /// The value at which to split the curve. Should be strictly inside ]0,1[ interval.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="Array"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <acknowledgment>
        /// http://pomax.github.io/bezierinfo/#decasteljau
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Bisect Any Number Bezier")]
        [Description("Bisect Any Number Bezier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (Point2D[] A, Point2D[] B) BisectNBezier1(Point2D[] points, double t)
        {
            if (t < 0d || t > 1d)
            {
                throw new ArgumentOutOfRangeException(nameof(t));
            }

            var bezier2 = new List<Point2D>();
            var bezier1 = new List<Point2D>();
            var lp = points.ToList();

            while (lp.Count > 0)
            {
                bezier2.Insert(0, lp.Last());
                bezier1.Add(lp.First());
                var next = new List<Point2D>(lp.Count - 1);
                for (var i = 0; i < lp.Count - 1; i++)
                {
                    var p0 = lp[i];
                    var p1 = lp[i + 1];
                    next.Add(new Point2D(((p0.X * (1d - t)) + (t * p1.X), (p0.Y * (1d - t)) + (t * p1.Y))));
                }

                lp = next;
            }

            return (
                 bezier1.ToArray(),
                 bezier2.ToArray()
            );
        }
    }
}
