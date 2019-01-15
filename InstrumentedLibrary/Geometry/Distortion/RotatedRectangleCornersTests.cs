using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The rotated rectangle corners tests class.
    /// </summary>
    [DisplayName("Rotated Rectangle Points")]
    [Description("Find the corner points of a rotated rectangle.")]
    [SourceCodeLocationProvider]
    public static class RotatedRectangleCornersTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RotatedRectangleCornersTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 10d, 10d, 5d, 5d, ToRadiansTests.ToRadians(45d) }, new TestCaseResults(description:"Point Inside", trials:trials, expectedReturnValue:new Point2D(0.5d, 0.5d), epsilon:DoubleEpsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fulcrumX"></param>
        /// <param name="fulcrumY"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y)[] RotatedRectangleCorners(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
            => RotatedRectangleCorners0(x, y, width, height, fulcrumX, fulcrumY, angle);

        /// <summary>
        /// The rotated rectangle corners.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="fulcrumX"></param>
        /// <param name="fulcrumY"></param>
        /// <param name="angle">The angle.</param>
        /// <returns>The <see cref="T:List{Point2D}"/>.</returns>
        [DisplayName("Rotated Rectangle Points")]
        [Description("Find the corner points of a rotated rectangle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] RotatedRectangleCorners0(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
        {
            var xaxis = (X: Cos(angle), Y: Sin(angle));
            var yaxis = (X: -Sin(angle), Y: Cos(angle));

            // Apply the rotation transformation and translate to new center.
            var points = new List<(double X, double Y)>
            {
                (
                fulcrumX + (-width / 2d * xaxis.X + -height / 2d * xaxis.Y),
                fulcrumY + (-width / 2d * yaxis.X + -height / 2d * yaxis.Y)
                ),
                (
                fulcrumX + (width / 2d * xaxis.X + -height / 2d * xaxis.Y),
                fulcrumY + (width / 2d * yaxis.X + -height / 2d * yaxis.Y)
                ),
                (
                fulcrumX + (width / 2d * xaxis.X + height / 2d * xaxis.Y),
                fulcrumY + (width / 2d * yaxis.X + height / 2d * yaxis.Y)
                ),
                (
                fulcrumX + (-width / 2d * xaxis.X + height / 2d * xaxis.Y),
                fulcrumY + (-width / 2d * yaxis.X + height / 2d * yaxis.Y)
                )
            };

            return points.ToArray();
        }
    }
}
