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
    /// The circle from three points tests class.
    /// </summary>
    [DisplayName("Circle from Three Points Tests")]
    [Description("Find a circle that intersects three points.")]
    [SourceCodeLocationProvider]
    public static class CircleFromThreePointsTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CircleFromThreePointsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new Circle2D(0.5d, 0.5d, 0.70710678118654757d), epsilon: double.Epsilon) },
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
        /// <param name="p1X"></param>
        /// <param name="p1Y"></param>
        /// <param name="p2X"></param>
        /// <param name="p2Y"></param>
        /// <param name="p3X"></param>
        /// <param name="p3Y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Circle2D? CircleFromPoints(double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y)
            => CircleFromPoints0(p1X, p1Y, p2X, p2Y, p3X, p3Y);

        /// <summary>
        /// Find the Bounds of A Circle from Three Points
        /// </summary>
        /// <param name="PointAX">First Point on the Ellipse</param>
        /// <param name="PointAY">First Point on the Ellipse</param>
        /// <param name="PointBX">Second Point on the Ellipse</param>
        /// <param name="PointBY">Second Point on the Ellipse</param>
        /// <param name="PointCX">Last Point on the Ellipse</param>
        /// <param name="PointCY">Last Point on the Ellipse</param>
        /// <returns>A Rectangle Representing the bounds of A Circle Defined from three
        /// Points</returns>
        [DisplayName("Circle from three points")]
        [Description("Find a circle that intersects with three points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Circle2D? TripointCircle(
            double PointAX, double PointAY,
            double PointBX, double PointBY,
            double PointCX, double PointCY)
        {
            (var X, var Y) = CircleCenterThreePointsTests.CenterCircleThreePoints(PointAX, PointAY, PointBX, PointBY, PointCX, PointCY) ?? (0d, 0d);
            var radius = Distance2DTests.Distance2D(X, Y, PointAX, PointAY);
            return new Circle2D(X, Y, radius);
        }

        /// <summary>
        /// The circle from points.
        /// </summary>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <returns>The <see cref="Circle2D"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points
        /// </acknowledgment>
        [DisplayName("Circle from three points")]
        [Description("Find a circle that intersects with three points.")]
        [Acknowledgment("http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Circle2D? CircleFromPoints0(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y)
        {
            var offset = (p2X * p2X) + (p2Y * p2Y);
            var bc = ((p1X * p1X) + (p1Y * p1Y) - offset) * 0.5d;
            var cd = (offset - (p3X * p3X) - (p3Y * p3Y)) * 0.5d;
            var determinant = ((p1X - p2X) * (p2Y - p3Y)) - ((p2X - p3X) * (p1Y - p2Y));

            if (Abs(determinant) < DoubleEpsilon)
            {
                return null;
            }

            var centerx = ((bc * (p2Y - p3Y)) - (cd * (p1Y - p2Y))) / determinant;
            var centery = ((cd * (p1X - p2X)) - (bc * (p2X - p3X))) / determinant;

            var radius = Sqrt(((p2X - centerx) * (p2X - centerx)) + ((p2Y - centery) * (p2Y - centery)));

            return new Circle2D(centerx, centery, radius);
        }
    }
}
