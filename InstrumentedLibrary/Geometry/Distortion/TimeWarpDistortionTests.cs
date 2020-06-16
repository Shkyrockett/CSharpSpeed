using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Time Warp Distort Point Tests")]
    [Description("Time Warp distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class TimeWarpDistortionTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(TimeWarpDistortionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(10d, 10d), new Point2D(5d, 5d), 10d }, new TestCaseResults(description: "Swirl a point", trials: trials, expectedReturnValue: new Point2D(20d,  20d), epsilon: double.Epsilon) },
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
        /// <param name="point"></param>
        /// <param name="fulcrum"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D TimeWarp(Point2D point, Point2D fulcrum, double factor = 10d)
            => TimeWarp0(point, fulcrum, factor);

        /// <summary>
        /// The time warp distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Time Warp Distort Point Tests")]
        [Description("Time Warp distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D TimeWarp0(Point2D point, Point2D fulcrum, double factor = 10d)
        {
            var dX = point.X - fulcrum.X;
            var dY = point.Y - fulcrum.Y;
            var theta = Atan2(dY, dX); // Might this be simplified by finding the unit of the vector?
            var radius = Sqrt((dX * dX) + (dY * dY));
            var newRadius = Sqrt(radius) * factor;
            var newX = fulcrum.X + (newRadius * Cos(theta));
            var newY = fulcrum.Y + (newRadius * Sin(theta));
            return new Point2D(newX, newY);
        }
    }
}
