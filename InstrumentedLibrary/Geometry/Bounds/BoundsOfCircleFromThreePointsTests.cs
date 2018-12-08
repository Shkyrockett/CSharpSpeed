using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The circle bounds from three points tests class.
    /// </summary>
    [DisplayName("Ellipse Perimeter Length Tests")]
    [Description("Estimations on the length of the Perimeter of an ellipse.")]
    [Signature("public static double TripointCircleBounds(double aX, double aY, double bX, double bY, double cX, double cY)")]
    [SourceCodeLocationProvider]
    public static class BoundsOfCircleFromThreePointsTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(BoundsOfCircleFromThreePointsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d }, new TestCaseResults(description:"Circle from three points test case.", trials:trials, expectedReturnValue:new Rectangle2D(-0.20710678118654757d, -0.20710678118654757d, 1.4142135623730949d, 1.4142135623730949d), epsilon:double.Epsilon) },
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
        [DisplayName("Circle Bounds from Three Points 1")]
        [Description("Find the bounds of a circle from three points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        public static Rectangle2D TripointCircleBounds(
            double PointAX, double PointAY,
            double PointBX, double PointBY,
            double PointCX, double PointCY)
        {
            (var X, var Y) = CircleCenterFromThreePointsTests.TripointCircleCenter(PointAX, PointAY, PointBX, PointBY, PointCX, PointCY);
            var Radius = Distance2DTests.Distance2D_1(X, Y, PointAX, PointAY);
            return Rectangle2D.FromLTRB(X - Radius, Y - Radius, X + Radius, Y + Radius);
        }

        /// <summary>
        /// The circle bounds from points.
        /// </summary>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points
        /// </acknowledgment>
        [DisplayName("Circle Bounds from Three Points 2")]
        [Description("Find the bounds of a circle from three points.")]
        [Acknowledgment("http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        public static Rectangle2D? CircleBoundsFromPoints(
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

            return Rectangle2D.FromLTRB(centerx - radius, centery - radius, centerx + radius, centery + radius);
        }
    }
}
