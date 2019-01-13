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
    /// The star points tests class.
    /// </summary>
    [DisplayName("Star Points Tests")]
    [Description("Star Points.")]
    [Signature("public static Point2D[] StarPoints(double x, double y, double width, double height, int num_points)")]
    [SourceCodeLocationProvider]
    public static class StarPointsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(Distance2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 4d, 4d, 5 }, new TestCaseResults("", trials, true, double.Epsilon) },
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
        /// The star points.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="num_points">The num_points.</param>
        /// <returns>The <see cref="T:PointF[]"/>. Return PointFs to define a star.</returns>
        [DisplayName("Star Points Tests")]
        [Description("Star Points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] StarPoints(double x, double y, double width, double height, int num_points)
        {
            // Make room for the points.
            var pts = new (double X, double Y)[num_points];

            var rx = width / 2d;
            var ry = height / 2d;
            var cx = x + rx;
            var cy = y + ry;

            // Start at the top.
            var theta = -PI / 2d;
            var dtheta = 4d * PI / num_points;
            for (var i = 0; i < num_points; i++)
            {
                pts[i] = (
                    cx + rx * Cos(theta),
                    cy + ry * Sin(theta));
                theta += dtheta;
            }

            return pts;
        }

        /// <summary>
        /// Draw the stars.
        /// The pic canvas paint.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        /// <param name="NumPoints">The NumPoints.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="chkHalfOnly">The chkHalfOnly.</param>
        /// <param name="chkRelPrimeOnly">The chkRelPrimeOnly.</param>
        public static void PicCanvas_Paint(/*PaintEventArgs e,*/ int NumPoints, Rectangle2D bounds, bool chkHalfOnly, bool chkRelPrimeOnly)
        {
            if (NumPoints < 3)
            {
                return;
            }

            // Get the radii.
            var r3 = Min(bounds.Width, bounds.Height) / 2d;
            var r1 = r3 / 2d;
            var r2 = r3 / 4d;
            r3 = r1 + r2;

            // Position variables.
            var cx = bounds.Width / 2d;
            var cy = bounds.Height / 2d;

            // Position the original points.
            var pts1 = new (double X, double Y)[NumPoints];
            var pts2 = new (double X, double Y)[NumPoints];
            var theta = -PI / 2d;
            var dtheta = 2 * PI / NumPoints;
            for (var i = 0; i < NumPoints; i++)
            {
                pts1[i].X = r1 * Cos(theta);
                pts1[i].Y = r1 * Sin(theta);
                pts2[i].X = r2 * Cos(theta);
                pts2[i].Y = r2 * Sin(theta);
                theta += dtheta;
            }

            // Draw stars.
            var max = NumPoints - 1;
            if (chkHalfOnly)
            {
                max = NumPoints / 2;
            }

            for (var skip = 1; skip <= max; skip++)
            {
                // See if they are relatively prime.
                var draw_all = !chkRelPrimeOnly;
                if (draw_all || GreatestCommonDivisorTests.GCD(skip, NumPoints) == 1)
                {
                    // Draw the big version of the star.
                    //DrawStar(e.Graphics, cx, cy, pts1, skip, NumPoints);

                    // Draw the smaller version.
                    theta = -PI / 2d + skip * 2d * PI / NumPoints;
                    var x = (int)(cx + r3 * Cos(theta));
                    var y = (int)(cy + r3 * Sin(theta));

                    //DrawStar(e.Graphics, x, y, pts2, skip, NumPoints);
                }
            }
        }

        /// <summary>
        /// Draw a star centered at (x, y) using this skip value.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="orig_pts">The orig_pts.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="NumPoints">The NumPoints.</param>
        public static void DrawStar(/*Graphics gr,*/ int x, int y, (double X, double Y)[] orig_pts, int skip, int NumPoints)
        {
            // Make a PointF array with the points in the proper order.
            var pts = new (double X, double Y)[NumPoints];
            for (var i = 0; i < NumPoints; i++)
            {
                pts[i] = orig_pts[i * skip % NumPoints];
            }

            // Draw the star.
            //gr.TranslateTransform(x, y);
            //gr.DrawPolygon(Pens.Blue, pts);
            //gr.ResetTransform();
        }
    }
}
