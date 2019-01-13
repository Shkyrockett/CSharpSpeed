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
    /// The rotated rectangle bounds tests class.
    /// </summary>
    [DisplayName("Rotated Rectangle Bounds Tests")]
    [Description("Finds the bounding rectangle of a rotated rectangle.")]
    [Signature("public static Rectangle2D RotatedRectangleBounds(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)")]
    [SourceCodeLocationProvider]
    public static class RotatedRectangleBoundsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RotatedRectangleBoundsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 1d, 1d, Maths.ToRadians(45d) }, new TestCaseResults(description:"Circle from three points test case.", trials:trials, expectedReturnValue:new Rectangle2D(-0.20710678118654757d, -0.20710678118654757d, 1.4142135623730949d, 1.4142135623730949d), epsilon:double.Epsilon) },
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
        public static Rectangle2D RotatedRectangleBounds(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
            => RotatedRectangleBounds0(x, y, width, height, fulcrumX, fulcrumY, angle);

        /// <summary>
        /// The rotated rectangle bounds.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="fulcrumX"></param>
        /// <param name="fulcrumY"></param>
        /// <param name="angle">The angle.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DisplayName("Rotated Rectangle Bounds")]
        [Description("Finds the bounding rectangle of a rotated rectangle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D RotatedRectangleBounds0(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
        {
            var cosAngle = Abs(Cos(angle));
            var sinAngle = Abs(Sin(angle));

            var size = new Size2D(
                (cosAngle * width) + (sinAngle * height),
                (cosAngle * height) + (sinAngle * width)
                );

            var loc = new Point2D(
                fulcrumX + (-width / 2d * cosAngle + -height / 2d * sinAngle),
                fulcrumY + (-width / 2d * sinAngle + -height / 2d * cosAngle)
                );

            return new Rectangle2D(loc, size);
        }
    }
}
