﻿using CSharpSpeed;
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
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="num_points"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y)[] StarPoints(double x, double y, double width, double height, int num_points)
            => StarPoints0(x, y, width, height, num_points);

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
        public static (double X, double Y)[] StarPoints0(double x, double y, double width, double height, int num_points)
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
        /// https://www.xarg.org/2019/01/drawing-an-upright-star-polygon/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="innerRadius"></param>
        /// <param name="outerRadius"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] UprightStarPolygonRobertEisele(double x, double y, double innerRadius, double outerRadius, int n)
        {
            var points = new List<(double X, double Y)>();
            for (var i = 0; i <= 2 * n; i++)
            {
                var alpha = (2 * i + 2 - n % 4) / (2 * n) * PI;
                var radius = 1 == i % 2 ? innerRadius : outerRadius;

                (double X, double Y) point = (Cos(alpha) * radius, Sin(alpha) * radius);
                points.Add(point);
            }
            return points.ToArray();
        }

        /// <summary>
        /// Draw the stars.
        /// The pic canvas paint.
        /// </summary>
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
                if (draw_all || GreatestCommonDivisorTests.GreatestCommonDivisor(skip, NumPoints) == 1)
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

        // Draw the gear.
        /// <summary>
        /// The pic gears paint.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        public static void PicGears_Paint(/*PaintEventArgs e,*/ Rectangle2D bounds)
        {
            //// Draw smoothly.
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            const double radius = 50;
            const double tooth_length = 10;
            var x = bounds.Width / 2 - radius - tooth_length - 1;
            var y = bounds.Height / 3;
            //DrawGear(e.Graphics, Brushes.Black, Brushes.LightBlue, Pens.Blue, new Point2D(x, y),
            //    radius, tooth_length, 10, 5, true);

            //x += 2 * radius + tooth_length + 2;
            //DrawGear(e.Graphics, Brushes.Black, Brushes.LightGreen, Pens.Green, new Point2D(x, y),
            //    radius, tooth_length, 10, 5, false);

            //y += 2 * radius + tooth_length + 2;
            //DrawGear(e.Graphics, Brushes.Black, Brushes.Pink, Pens.Red, new Point2D(x, y),
            //    radius, tooth_length, 10, 5, true);
        }

        /// <summary>
        /// Draw a gear.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="tooth_length">The tooth_length.</param>
        /// <param name="num_teeth">The num_teeth.</param>
        /// <param name="axle_radius">The axle_radius.</param>
        /// <param name="start_with_tooth">The start_with_tooth.</param>
        public static void DrawGear(/*Graphics gr,*/ /*Brush axle_brush,*/ /*Brush gear_brush,*/ /*Pen gear_pen,*/ Point2D center, double radius, double tooth_length, int num_teeth, double axle_radius, bool start_with_tooth)
        {
            var dtheta = PI / num_teeth;
            var dtheta_degrees = dtheta * 180 / PI; // dtheta in degrees.

            const double chamfer = 2;
            var tooth_width = radius * dtheta - chamfer;
            var alpha = tooth_width / (radius + tooth_length);
            var alpha_degrees = alpha * 180 / PI;
            var phi = (dtheta - alpha) / 2;

            // Set theta for the beginning of the first tooth.
            double theta;
            theta = start_with_tooth ? dtheta / 2 : -dtheta / 2;

            // Make rectangles to represent the gear's inner and outer arcs.
            var inner_rect = new Rectangle2D(
                center.X - radius, center.Y - radius,
                2 * radius, 2 * radius);
            var outer_rect = new Rectangle2D(
                center.X - radius - tooth_length, center.Y - radius - tooth_length,
                2 * (radius + tooth_length), 2 * (radius + tooth_length));

            // Make a path representing the gear.
            //var path = new GraphicsPath();
            for (var i = 0; i < num_teeth; i++)
            {
                // Move across the gap between teeth.
                var degrees = theta * 180 / PI;
                //path.AddArc(inner_rect.ToRectangleF(), (float)degrees, (float)dtheta_degrees);
                theta += dtheta;

                // Move across the tooth's outer edge.
                degrees = (theta + phi) * 180 / PI;
                //path.AddArc(outer_rect.ToRectangleF(), (float)degrees, (float)alpha_degrees);
                theta += dtheta;
            }

            //path.CloseFigure();

            //// Draw the gear.
            //gr.FillPath(gear_brush, path);
            //gr.DrawPath(gear_pen, path);
            //gr.FillEllipse(axle_brush,
            //     (float)(center.X - axle_radius), (float)(center.Y - axle_radius),
            //    (float)(2 * axle_radius), (float)(2 * axle_radius));
        }
    }
}
