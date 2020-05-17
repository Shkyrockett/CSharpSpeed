using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Bisect Ray")]
    [Description("Bisect Ray.")]
    [SourceCodeLocationProvider]
    public static class BisectRayTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(BisectRayTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 5d, 5d, 1d, 0d, 1d }, new TestCaseResults(description: "polygon.", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (IShapeSegment A, IShapeSegment B) BisectRay(double x, double y, double i, double j, double t)
            => BisectRay1(x, y, i, j, t);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="Array"/>.</returns>
        [DisplayName("Bisect Ray")]
        [Description("Bisect Ray.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (IShapeSegment A, IShapeSegment B) BisectRay1(double x, double y, double i, double j, double t)
        {
            var (X, Y) = InterpolateLinear2DTests.LinearInterpolate2D(t, x, y, x + i, y + j);

            return (
                new LineSegment2D(x, y, X, Y),
                new Ray2D(X, Y, i, j)
                );
        }
    }
}
