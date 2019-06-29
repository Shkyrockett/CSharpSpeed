using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Split Quadratic Bezier")]
    [Description("Split Quadratic Bezier.")]
    [SourceCodeLocationProvider]
    public static class SplitQuadraticBezierTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SplitQuadraticBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 5d, 5d, 5d, 0d, new double[] { 0.5d } }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static QuadraticBezier2D[] SplitQuadraticBezier(double aX, double aY, double bX, double bY, double cX, double cY, params double[] ts)
            => Split(aX, aY, bX, bY, cX, cY, ts);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:BezierSegment[]"/>.</returns>
        [DisplayName("Split Quadratic Bezier")]
        [Description("Split Quadratic Bezier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static QuadraticBezier2D[] Split(double aX, double aY, double bX, double bY, double cX, double cY, params double[] ts)
        {
            if (ts is null)
            {
                return new[] { new QuadraticBezier2D(aX, aY, bX, bY, cX, cY) };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToList();
            var start = new QuadraticBezier2D(aX, aY, bX, bY, cX, cY);
            if (filtered.Count == 0)
            {
                return new[] { start };
            }

            var tLast = 0d;
            var list = new List<QuadraticBezier2D>(filtered.Count + 1);
            foreach (var t in filtered)
            {
                var relT = (1d - t) / (1d - tLast);
                tLast = t;
                var (A, B) = BisectQuadraticBezierTests.BisectQuadraticBezier(start.A.X, start.A.Y, start.B.X, start.B.Y, start.C.X, start.C.Y, relT);
                list.Add(A);
                start = B;
            }

            list.Add(start);
            return list.ToArray();
        }
    }
}
