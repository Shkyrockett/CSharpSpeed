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
    /// The circle center from three points tests class.
    /// </summary>
    [DisplayName("Circle center from Three Points Tests")]
    [Description("Find the center of a circle that intersects three points.")]
    [SourceCodeLocationProvider]
    public static class CircleCenterFromThreePointsTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CircleCenterFromThreePointsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.5d, 0.5d), epsilon: double.Epsilon) },
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
        public static (double X, double Y)? CircleCenterFromPoints(double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y)
            => CircleCenterFromPoints0(p1X, p1Y, p2X, p2Y, p3X, p3Y);

        /// <summary>
        /// Find the Center of A Circle from Three Points
        /// </summary>
        /// <param name="pointAX">First Point on the Ellipse</param>
        /// <param name="pointAY">First Point on the Ellipse</param>
        /// <param name="pointBX">Second Point on the Ellipse</param>
        /// <param name="pointBY">Second Point on the Ellipse</param>
        /// <param name="pointCX">Last Point on the Ellipse</param>
        /// <param name="pointCY">Last Point on the Ellipse</param>
        /// <returns>Returns the Center point of a Circle defined by three points</returns>
        /// <acknowledgment>
        /// </acknowledgment>
        [DisplayName("Circle center from three points")]
        [Description("Find the center of a circle that intersects with three points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) TripointCircleCenter(
            double pointAX, double pointAY,
            double pointBX, double pointBY,
            double pointCX, double pointCY)
        {
            //  Calculate the slopes of the lines.
            var slopeA = Slope2Points2DTests.Slope(pointAX, pointAY, pointBX, pointBY);
            var slopeB = Slope2Points2DTests.Slope(pointCX, pointCY, pointBX, pointBY);
            var fY = (((pointAX - pointBX) * (pointAX + pointBX)) + ((pointAY - pointBY) * (pointAY + pointBY))) / (2d * (pointAX - pointBX));
            var fX = (((pointCX - pointBX) * (pointCX + pointBX)) + ((pointCY - pointBY) * (pointCY + pointBY))) / (2d * (pointCX - pointBX));
            var newY = (fX - fY) / (slopeB - slopeA);
            var newX = fX - (slopeB * newY);
            return (newX, newY);
        }

        /// <summary>
        /// The circle center from points.
        /// </summary>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <returns>The <see cref="T:ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points
        /// </acknowledgment>
        [DisplayName("Circle center from three points")]
        [Description("Find the center of a circle that intersects with three points.")]
        [Acknowledgment("http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)? CircleCenterFromPoints0(
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

            return (
                ((bc * (p2Y - p3Y)) - (cd * (p1Y - p2Y))) / determinant,
                ((cd * (p1X - p2X)) - (bc * (p2X - p3X))) / determinant);
        }
    }
}
