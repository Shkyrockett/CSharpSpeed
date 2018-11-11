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
    /// The absolute angle class.
    /// </summary>
    [DisplayName("2D Point in 2D Circle Tests")]
    [Description("Test whether a 2D point is contained within a 2D circle.")]
    [Signature("public static Inclusion PointInCircle(double centerX, double centerY, double radius, double x, double y)")]
    [SourceCodeLocationProvider]
    public static class Point2DInCircle2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate whether a point is within a circle.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(Point2DInCircle2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0, 0, 2, 1, 1 }, new TestCaseResults(description:"Point Inside", trials:trials, expectedReturnValue:Inclusion.Inside) },
                { new object[] { 0, 0, 2, 3, 3 }, new TestCaseResults(description:"Point Outside", trials:trials, expectedReturnValue:Inclusion.Outside) }
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
        /// Find out if a Point is in a Circle.
        /// </summary>
        /// <param name="centerX">The centerX.</param>
        /// <param name="centerY">The centerY.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        [DisplayName("Point in Circle Method 1")]
        [Description("Determine whether a point is contained within a circle by calling a distance method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircle(
                double centerX, double centerY,
                double radius,
                double x, double y)
        {
            var distance = Distance2DTests.Distance2D_1(centerX, centerY, x, y);
            return (radius >= distance) ? ((Abs(radius - distance) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }

        /// <summary>
        /// Find out if a Point is in a Circle.
        /// </summary>
        /// <param name="centerX">The centerX.</param>
        /// <param name="centerY">The centerY.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/481151
        /// </acknowledgment>
        [DisplayName("Point in Circle Method 2")]
        [Description("A modified version of Jason Punyon's method to determine whether a point is contained within a circle by comparing the distance between the point and the center of the circle to the radius.")]
        [Acknowledgment("https://stackoverflow.com/a/481151")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircleInline(
            double centerX, double centerY,
            double radius,
            double x, double y)
        {
            var distance = Sqrt(((x - centerX) * (x - centerX)) + ((y - centerY) * (y - centerY)));
            return (radius >= distance) ? ((Abs(radius - distance) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }

        /// <summary>
        /// The point in circle philcolbourn.
        /// </summary>
        /// <param name="centerX">The centerX.</param>
        /// <param name="centerY">The centerY.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/7227057
        /// </acknowledgment>
        [DisplayName("Point in Circle Method 3")]
        [Description("Phil Colbourn's method for determining whether a point is contained within a circle.")]
        [Acknowledgment("https://stackoverflow.com/a/7227057")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCirclePhilcolbourn(
            double centerX,
            double centerY,
            double radius,
            double x,
            double y)
        {
            var dx = Abs(x - centerX);
            if (dx > radius)
            {
                return Inclusion.Outside;
            }

            var dy = Abs(y - centerY);
            if (dy > radius)
            {
                return Inclusion.Outside;
            }
            //if (dx + dy <= radius) return InsideOutside.Inside;
            var distanceSquared = (dx * dx) + (dy * dy);
            var radiusSquared = radius * radius;
            return (radiusSquared >= distanceSquared) ? ((Abs(radiusSquared - distanceSquared) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }

        /// <summary>
        /// The point in circle n philcolbourn.
        /// </summary>
        /// <param name="centerX">The centerX.</param>
        /// <param name="centerY">The centerY.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/7227057
        /// </acknowledgment>
        [DisplayName("Point in Circle Method 4")]
        [Description("Phil Colbourn's n method for determining whether a point is contained within a circle.")]
        [Acknowledgment("https://stackoverflow.com/a/7227057")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircleNPhilcolbourn(
            double centerX,
            double centerY,
            double radius,
            double x,
            double y)
        {
            var dx = Abs(x - centerX);
            var dy = Abs(y - centerY);
            var distanceSquared = (dx * dx) + (dy * dy);
            var radiusSquared = radius * radius;
            return (radiusSquared >= distanceSquared) ? ((Abs(radiusSquared - distanceSquared) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }

        /// <summary>
        /// test if coordinate (x, y) is within a radius from coordinate (centerX, centerY)
        /// </summary>
        /// <summary>
        /// The point in circle william morrison.
        /// </summary>
        /// <param name="centerX">The centerX.</param>
        /// <param name="centerY">The centerY.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/6311501
        /// </acknowledgment>
        [DisplayName("Point in Circle Method 5")]
        [Description("William Morrison's method for determining whether a point is contained within a circle.")]
        [Acknowledgment("https://stackoverflow.com/a/6311501")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircleWilliamMorrison(
            double centerX,
            double centerY,
            double radius,
            double x,
            double y)
        {
            if (x >= centerX - radius && x <= centerX + radius
                && y >= centerY - radius && y <= centerY + radius)
            {
                var dx = centerX - x;
                var dy = centerY - y;
                dx *= dx;
                dy *= dy;
                var distanceSquared = dx + dy;
                var radiusSquared = radius * radius;
                return (radiusSquared >= distanceSquared) ? ((Abs(radiusSquared - distanceSquared) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
            }
            return Inclusion.Outside;
        }

        /// <summary>
        /// test if coordinate (x, y) is within a radius from coordinate (centerX, centerY)
        /// </summary>
        /// <param name="centerX">The centerX.</param>
        /// <param name="centerY">The centerY.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/6311501
        /// </acknowledgment>
        [DisplayName("Point in Circle Method 6")]
        [Description("A modified version of William Morrison's method for determining whether a point is contained within a circle.")]
        [Acknowledgment("https://stackoverflow.com/a/6311501")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircleX(
            double centerX,
            double centerY,
            double radius,
            double x,
            double y)
        {
            if (x >= centerX - radius && x <= centerX + radius
                && y >= centerY - radius && y <= centerY + radius)
            {
                var dx = (centerX > x) ? (x - centerX) : (centerX - x);
                var dy = (centerY > y) ? (y - centerY) : (centerY - y);
                if (dx > radius || dy > radius)
                {
                    return Inclusion.Outside;
                }

                dx *= dx;
                dy *= dy;
                var distanceSquared = dx + dy;
                var radiusSquared = radius * radius;
                return (radiusSquared >= distanceSquared) ? ((Abs(radiusSquared - distanceSquared) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
            }
            return Inclusion.Outside;
        }
    }
}
