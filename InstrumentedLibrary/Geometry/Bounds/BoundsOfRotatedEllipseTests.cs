using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpSpeed;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The bounds of rotated ellipse tests class.
    /// </summary>
    [DisplayName("Bounds Rotated Ellipse Tests")]
    [Description("Finds the Bounds of a rotated ellipse.")]
    [Signature("public static Rectangle2D EllipseBoundingBox(double x, double y, int ra, int rb, double angle)")]
    [SourceCodeLocationProvider]
    public static class BoundsOfRotatedEllipseTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle of three 2D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(BoundsOfRotatedEllipseTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 5d, 5d, 5d, 4d, 45d.ToRadians() }, new TestCaseResults(description:" Test for bounding box of ellipse.", trials:trials, expectedReturnValue: new Rectangle2D(0.47230743093129135d, 0.47230743093129135d, 9.0553851381374173d, 9.0553851381374173d), epsilon:DoubleEpsilon) },
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
        /// The ellipse bounding box.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r1">The r1.</param>
        /// <param name="r2">The r2.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
        /// </acknowledgment>
        [DisplayName("Bounds Rotated Ellipse 1")]
        [Description("Finds the Bounds of a rotated ellipse.")]
        [Acknowledgment("http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipseBoundingBox(double x, double y, double r1, double r2, double angle)
        {
            var a = r1 * Cos(angle);
            var b = r2 * Sin(angle);
            var c = r1 * Sin(angle);
            var d = r2 * Cos(angle);
            var width = Sqrt((a * a) + (b * b)) * 2d;
            var height = Sqrt((c * c) + (d * d)) * 2d;
            var x2 = x - (width * 0.5d);
            var y2 = y - (height * 0.5d);
            return new Rectangle2D(x2, y2, width, height);
        }

        /// <summary>
        /// The ellipse bounds.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r1">The r1.</param>
        /// <param name="r2">The r2.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DisplayName("Bounds Rotated Ellipse 2")]
        [Description("Finds the Bounds of a rotated ellipse.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipseBounds(double x, double y, double r1, double r2, double angle)
        {
            var phi = angle;
            var aspect = r2 / r1;
            var ux = r1 * Cos(phi);
            var uy = r1 * Sin(phi);
            var vx = r1 * aspect * Cos(phi + (PI / 2d));
            var vy = r1 * aspect * Sin(phi + (PI / 2d));

            var bbox_halfwidth = Sqrt((ux * ux) + (vx * vx));
            var bbox_halfheight = Sqrt((uy * uy) + (vy * vy));

            return Rectangle2D.FromLTRB(
                x - bbox_halfwidth,
                y - bbox_halfheight,
                x + bbox_halfwidth,
                y + bbox_halfheight
                );
        }

        /// <summary>
        /// The ellipse bounds.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r1">The r1.</param>
        /// <param name="r2">The r2.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DisplayName("Bounds Rotated Ellipse 3")]
        [Description("Finds the Bounds of a rotated ellipse.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipseBounds2(double x, double y, double r1, double r2, double angle)
        {
            var phi = angle;
            var aspect = r2 / r1;
            var ux = r1 * Cos(phi);
            var uy = r1 * Sin(phi);
            var vx = r1 * aspect * Cos(phi + (PI * 0.5d));
            var vy = r1 * aspect * Sin(phi + (PI * 0.5d));

            var bbox_halfwidth = Sqrt((ux * ux) + (vx * vx));
            var bbox_halfheight = Sqrt((uy * uy) + (vy * vy));

            return Rectangle2D.FromLTRB(
                x - bbox_halfwidth,
                y - bbox_halfheight,
                x + bbox_halfwidth,
                y + bbox_halfheight
                );
        }
    }
}
