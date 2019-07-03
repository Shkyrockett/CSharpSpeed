using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The bounds of rotated elliptical arc tests class.
    /// </summary>
    [DisplayName("Angle of a 2D Vector Tests")]
    [Description("Find the angle of a 2D vector.")]
    [SourceCodeLocationProvider]
    public static class BoundsOfRotatedEllipticalArcTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle of three 2D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(BoundsOfRotatedEllipticalArcTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0, 0, 3, 4, 30d.ToRadians(), -30d.ToRadians(), 90d.ToRadians() }, new TestCaseResults(description: "Test for bounding box of rotated elliptical arc.", trials: trials, expectedReturnValue: new Rectangle2D(2.2204460492503131E-16,-2.2204460492503131E-16,3.1788776569561055,3.6599656879825124), epsilon: double.Epsilon) },
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
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="angle"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Rectangle2D EllipticalArc(double cX, double cY, double r1, double r2, double angle, double startAngle, double sweepAngle)
            => EllipticalArc0(cX, cY, r1, r2, angle, startAngle, sweepAngle);

        /// <summary>
        /// Find the close fitting rectangular bounding box of a rotated ellipse elliptical arc.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle">The angle to start the arc.</param>
        /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
        /// <returns>The close bounding box of a rotated elliptical arc.</returns>
        /// <acknowledgment>
        /// Helpful hints on how this might be implemented came from:
        /// http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html,
        /// http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp
        /// and http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
        /// </acknowledgment>
        [DisplayName("Interpolate Unrotated Ellipse 1")]
        [Description("Interpolates the unrotated ellipse.")]
        [Acknowledgment("http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html", "http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp", "http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipticalArc0(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle, double sweepAngle)
        {
            // Get the ellipse rotation transform.
            var cosT = Cos(angle);
            var sinT = Sin(angle);

            var i = (r1 - r2) * (r1 + r2) * sinT * cosT;

            // Find the angles of the Cartesian extremes.
            var angles = new double[4] {
                Atan2(i, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)),
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), i),
                Atan2(i, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)) + PI,
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), i) + PI };

            // Sort the angles so that like sides are consistently at the same index.
            Array.Sort(angles);

            // Get the start and end angles adjusted to polar coordinates.
            var t0 = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle, r1, r2);
            var t1 = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle + sweepAngle, r1, r2);

            // Interpolate the ratios of height and width of the chord.
            var sinT0 = Sin(t0);
            var cosT0 = Cos(t0);
            var sinT1 = Sin(t1);
            var cosT1 = Cos(t1);

            // Get the end points of the chord.
            var bounds = new Rectangle2D(
                // Apply the rotation transformation and translate to new center.
                new Point2D(
                    cX + ((r1 * cosT0 * cosT) - (r2 * sinT0 * sinT)),
                    cY + ((r1 * cosT0 * sinT) + (r2 * sinT0 * cosT))),
                // Apply the rotation transformation and translate to new center.
                new Point2D(
                    cX + ((r1 * cosT1 * cosT) - (r2 * sinT1 * sinT)),
                    cY + ((r1 * cosT1 * sinT) + (r2 * sinT1 * cosT))));

            // Find the parent ellipse's horizontal and vertical radii extremes.
            var halfWidth = Sqrt((r1 * r1 * cosT * cosT) + (r2 * r2 * sinT * sinT));
            var halfHeight = Sqrt((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT));

            // Expand the elliptical boundaries if any of the extreme angles fall within the sweep angle.
            if (AngleWithinAngleTests.Within(angles[0], angle + startAngle, sweepAngle))
            {
                bounds.Right = cX + halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[1], angle + startAngle, sweepAngle))
            {
                bounds.Bottom = cY + halfHeight;
            }

            if (AngleWithinAngleTests.Within(angles[2], angle + startAngle, sweepAngle))
            {
                bounds.Left = cX - halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[3], angle + startAngle, sweepAngle))
            {
                bounds.Top = cY - halfHeight;
            }

            // Return the points of the Cartesian extremes of the rotated elliptical arc.
            return bounds;
        }

        /// <summary>
        /// Find the close fitting rectangular bounding box of a rotated ellipse elliptical arc.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle">The angle to start the arc.</param>
        /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
        /// <returns>The close bounding box of a rotated elliptical arc.</returns>
        /// <acknowledgment>
        /// Helpful hints on how this might be implemented came from:
        /// http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html,
        /// http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp
        /// and http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
        /// </acknowledgment>
        [DisplayName("Interpolate Unrotated Ellipse 1")]
        [Description("Interpolates the unrotated ellipse.")]
        [Acknowledgment("http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html", "http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp", "http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipticalArc1(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle, double sweepAngle)
        {
            // Get the ellipse rotation transform.
            var cosT = Cos(angle);
            var sinT = Sin(angle);

            // Find the angles of the Cartesian extremes.
            var angles = new double[4] {
                Atan2((r1 - r2) * (r1 + r2) * sinT * cosT, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)),
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), (r1 - r2) * (r1 + r2) * sinT * cosT),
                Atan2((r1 - r2) * (r1 + r2) * sinT * cosT, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)) + PI,
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), (r1 - r2) * (r1 + r2) * sinT * cosT) + PI };

            // Sort the angles so that like sides are consistently at the same index.
            Array.Sort(angles);

            // Get the start and end angles adjusted to polar coordinates.
            var t0 = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle, r1, r2);
            var t1 = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle + sweepAngle, r1, r2);

            // Interpolate the ratios of height and width of the chord.
            var sinT0 = Sin(t0);
            var cosT0 = Cos(t0);
            var sinT1 = Sin(t1);
            var cosT1 = Cos(t1);

            // Get the end points of the chord.
            var bounds = new Rectangle2D(
                // Apply the rotation transformation and translate to new center.
                new Point2D(
                    cX + ((r1 * cosT0 * cosT) - (r2 * sinT0 * sinT)),
                    cY + ((r1 * cosT0 * sinT) + (r2 * sinT0 * cosT))),
                // Apply the rotation transformation and translate to new center.
                new Point2D(
                    cX + ((r1 * cosT1 * cosT) - (r2 * sinT1 * sinT)),
                    cY + ((r1 * cosT1 * sinT) + (r2 * sinT1 * cosT))));

            // Find the parent ellipse's horizontal and vertical radii extremes.
            var halfWidth = Sqrt((r1 * r1 * cosT * cosT) + (r2 * r2 * sinT * sinT));
            var halfHeight = Sqrt((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT));

            // Expand the elliptical boundaries if any of the extreme angles fall within the sweep angle.
            if (AngleWithinAngleTests.Within(angles[0], angle + startAngle, sweepAngle))
            {
                bounds.Right = cX + halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[1], angle + startAngle, sweepAngle))
            {
                bounds.Bottom = cY + halfHeight;
            }

            if (AngleWithinAngleTests.Within(angles[2], angle + startAngle, sweepAngle))
            {
                bounds.Left = cX - halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[3], angle + startAngle, sweepAngle))
            {
                bounds.Top = cY - halfHeight;
            }

            // Return the points of the Cartesian extremes of the rotated elliptical arc.
            return bounds;
        }

        /// <summary>
        /// Find the close fitting rectangular bounding box of a rotated ellipse elliptical arc.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle">The angle to start the arc.</param>
        /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
        /// <returns>The close bounding box of a rotated elliptical arc.</returns>
        /// <acknowledgment>
        /// Helpful hints on how this might be implemented came from:
        /// http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html,
        /// http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp
        /// and http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
        /// </acknowledgment>
        [DisplayName("Interpolate Unrotated Ellipse 1")]
        [Description("Interpolates the unrotated ellipse.")]
        [Acknowledgment("http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html", "http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp", "http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipticalArc2(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle, double sweepAngle)
        {
            // Get the ellipse rotation transform.
            var cosT = Cos(angle);
            var sinT = Sin(angle);

            // Find the angles of the Cartesian extremes.
            var angles = new List<double>(4) {
                Atan2((r1 - r2) * (r1 + r2) * sinT * cosT, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)),
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), (r1 - r2) * (r1 + r2) * sinT * cosT),
                Atan2((r1 - r2) * (r1 + r2) * sinT * cosT, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)) + PI,
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), (r1 - r2) * (r1 + r2) * sinT * cosT) + PI };

            // Sort the angles so that like sides are consistently at the same index.
            angles.Sort();

            // Calculate the radii of the angle of rotation.
            var a = r1 * cosT;
            var b = r2 * sinT;
            var c = r1 * sinT;
            var d = r2 * cosT;

            // Find the parent ellipse's horizontal and vertical radii extremes.
            var halfWidth = Sqrt((a * a) + (b * b));
            var halfHeight = Sqrt((c * c) + (d * d));

            // Get the end points of the chord.
            var bounds = new Rectangle2D(
                InterpolateRotatedEllipticalArcTests.EllipticalArc(0, cX, cY, r1, r2, angle, startAngle, sweepAngle),
                InterpolateRotatedEllipticalArcTests.EllipticalArc(1, cX, cY, r1, r2, angle, startAngle, sweepAngle));

            // Expand the elliptical boundaries if any of the extreme angles fall within the sweep angle.
            if (AngleWithinAngleTests.Within(angles[0], angle + startAngle, sweepAngle))
            {
                bounds.Right = cX + halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[1], angle + startAngle, sweepAngle))
            {
                bounds.Bottom = cY + halfHeight;
            }

            if (AngleWithinAngleTests.Within(angles[2], angle + startAngle, sweepAngle))
            {
                bounds.Left = cX - halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[3], angle + startAngle, sweepAngle))
            {
                bounds.Top = cY - halfHeight;
            }

            // Return the points of the Cartesian extremes of the rotated elliptical arc.
            return bounds;
        }

        /// <summary>
        /// Find the close fitting rectangular bounding box of a rotated ellipse elliptical arc.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle">The angle to start the arc.</param>
        /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
        /// <returns>The close bounding box of a rotated elliptical arc.</returns>
        /// <acknowledgment>
        /// Helpful hints on how this might be implemented came from:
        /// http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html,
        /// http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp
        /// and http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
        /// </acknowledgment>
        [DisplayName("Interpolate Unrotated Ellipse 1")]
        [Description("Interpolates the unrotated ellipse.")]
        [Acknowledgment("http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html", "http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp", "http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipticalArc3(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle, double sweepAngle)
        {
            // Get the ellipse rotation transform.
            var cosT = Cos(angle);
            var sinT = Sin(angle);

            // Calculate the radii of the angle of rotation.
            var a = r1 * cosT;
            var b = r2 * sinT;
            var c = r1 * sinT;
            var d = r2 * cosT;

            // Calculate the vectors of the Cartesian extremes.
            var u1 = r1 * Cos(Atan2(d, c));
            var v1 = -(r2 * Sin(Atan2(d, c)));
            var u2 = r1 * Cos(Atan2(-b, a));
            var v2 = -(r2 * Sin(Atan2(-b, a)));

            // Find the angles of the Cartesian extremes.
            var angles = new List<double>(4) {
                Atan2((u1 * sinT) - (v1 * cosT), (u1 * cosT) + (v1 * sinT)),
                Atan2((u2 * sinT) - (v2 * cosT), (u2 * cosT) + (v2 * sinT)),
                Atan2((u1 * sinT) - (v1 * cosT), (u1 * cosT) + (v1 * sinT)) + PI,
                Atan2((u2 * sinT) - (v2 * cosT), (u2 * cosT) + (v2 * sinT)) + PI };

            // Sort the angles so that like sides are consistently at the same index.
            angles.Sort();

            // Find the parent ellipse's horizontal and vertical radii extremes.
            var halfWidth = Sqrt((a * a) + (b * b));
            var halfHeight = Sqrt((c * c) + (d * d));

            // Get the end points of the chord.
            var bounds = new Rectangle2D(
                InterpolateRotatedEllipticalArcTests.EllipticalArc(0, cX, cY, r1, r2, angle, startAngle, sweepAngle),
                InterpolateRotatedEllipticalArcTests.EllipticalArc(1, cX, cY, r1, r2, angle, startAngle, sweepAngle));

            // Expand the elliptical boundaries if any of the extreme angles fall within the sweep angle.
            if (AngleWithinAngleTests.Within(angles[0], angle + startAngle, sweepAngle))
            {
                bounds.Right = cX + halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[1], angle + startAngle, sweepAngle))
            {
                bounds.Bottom = cY + halfHeight;
            }

            if (AngleWithinAngleTests.Within(angles[2], angle + startAngle, sweepAngle))
            {
                bounds.Left = cX - halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[3], angle + startAngle, sweepAngle))
            {
                bounds.Top = cY - halfHeight;
            }

            // Return the points of the Cartesian extremes of the rotated elliptical arc.
            return bounds;
        }

        ///// <summary>
        ///// The ellptic arc.
        ///// </summary>
        ///// <param name="x1">The x1.</param>
        ///// <param name="y1">The y1.</param>
        ///// <param name="r1">The r1.</param>
        ///// <param name="r2">The r2.</param>
        ///// <param name="angle">The angle.</param>
        ///// <param name="largeArc">The largeArc.</param>
        ///// <param name="sweep">The sweep.</param>
        ///// <param name="x2">The x2.</param>
        ///// <param name="y2">The y2.</param>
        ///// <returns>The <see cref="Rectangle2D"/>.</returns>
        ///// <acknowledgment>
        ///// http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html
        ///// </acknowledgment>
        //[DisplayName("Interpolate Unrotated Ellipse 1")]
        //[Description("Interpolates the unrotated ellipse.")]
        //[Acknowledgment("http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html")]
        //[SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Rectangle2D EllpticArc(
        //    double x1, double y1,
        //    double r1, double r2,
        //    double angle,
        //    bool largeArc, bool sweep,
        //    double x2, double y2)
        //{
        //    double xmin;
        //    double ymin;
        //    double xmax;
        //    double ymax;

        //    if (r1 < 0d)
        //        r1 *= -1d;
        //    if (r2 < 0d)
        //        r2 *= -1d;

        //    if (r1 == 0d || r2 == 0d)
        //    {
        //        xmin = x1 < x2 ? x1 : x2;
        //        xmax = x1 > x2 ? x1 : x2;
        //        ymin = y1 < y2 ? y1 : y2;
        //        ymax = y1 > y2 ? y1 : y2;
        //        return Rectangle2D.FromLTRB(xmin, ymin, xmax, ymax);
        //    }

        //    var x1prime = Cos(angle) * (x1 - x2) / 2 + Sin(angle) * (y1 - y2) / 2;
        //    var y1prime = -Sin(angle) * (x1 - x2) / 2 + Cos(angle) * (y1 - y2) / 2;

        //    var radicant = r1 * r1 * r2 * r2 - r1 * r1 * y1prime * y1prime - r2 * r2 * x1prime * x1prime;
        //    radicant /= r1 * r1 * y1prime * y1prime + r2 * r2 * x1prime * x1prime;
        //    var cxprime = 0d;
        //    var cyprime = 0d;
        //    if (radicant < 0d)
        //    {
        //        var ratio = r1 / r2;
        //        radicant = y1prime * y1prime + x1prime * x1prime / (ratio * ratio);
        //        if (radicant < 0d)
        //        {
        //            xmin = x1 < x2 ? x1 : x2;
        //            xmax = x1 > x2 ? x1 : x2;
        //            ymin = y1 < y2 ? y1 : y2;
        //            ymax = y1 > y2 ? y1 : y2;
        //            return Rectangle2D.FromLTRB(xmin, ymin, xmax, ymax);
        //        }
        //        r2 = Sqrt(radicant);
        //        r1 = ratio * r2;
        //    }
        //    else
        //    {
        //        var factor = (largeArc == sweep ? -1.0 : 1.0) * Sqrt(radicant);

        //        cxprime = factor * r1 * y1prime / r2;
        //        cyprime = -factor * r2 * x1prime / r1;
        //    }

        //    var cx = cxprime * Cos(angle) - cyprime * Sin(angle) + (x1 + x2) / 2;
        //    var cy = cxprime * Sin(angle) + cyprime * Cos(angle) + (y1 + y2) / 2;

        //    double txmin, txmax, tymin, tymax;

        //    if (angle == 0 || angle == PI)
        //    {
        //        xmin = cx - r1;
        //        txmin = AngleofVectorTests.GetAngle(-r1, 0);
        //        xmax = cx + r1;
        //        txmax = AngleofVectorTests.GetAngle(r1, 0);
        //        ymin = cy - r2;
        //        tymin = AngleofVectorTests.GetAngle(0, -r2);
        //        ymax = cy + r2;
        //        tymax = AngleofVectorTests.GetAngle(0, r2);
        //    }
        //    else if (angle == PI / 2.0 || angle == 3.0 * PI / 2.0)
        //    {
        //        xmin = cx - r2;
        //        txmin = AngleofVectorTests.GetAngle(-r2, 0);
        //        xmax = cx + r2;
        //        txmax = AngleofVectorTests.GetAngle(r2, 0);
        //        ymin = cy - r1;
        //        tymin = AngleofVectorTests.GetAngle(0, -r1);
        //        ymax = cy + r1;
        //        tymax = AngleofVectorTests.GetAngle(0, r1);
        //    }
        //    else
        //    {
        //        txmin = -Atan(r2 * Tan(angle) / r1);
        //        txmax = PI - Atan(r2 * Tan(angle) / r1);
        //        xmin = cx + r1 * Cos(txmin) * Cos(angle) - r2 * Sin(txmin) * Sin(angle);
        //        xmax = cx + r1 * Cos(txmax) * Cos(angle) - r2 * Sin(txmax) * Sin(angle);
        //        if (xmin > xmax)
        //        {
        //            SwapTests.Swap(ref xmin, ref xmax);
        //            SwapTests.Swap(ref txmin, ref txmax);
        //        }
        //        var tmpY = cy + r1 * Cos(txmin) * Sin(angle) + r2 * Sin(txmin) * Cos(angle);
        //        txmin = AngleofVectorTests.GetAngle(xmin - cx, tmpY - cy);
        //        tmpY = cy + r1 * Cos(txmax) * Sin(angle) + r2 * Sin(txmax) * Cos(angle);
        //        txmax = AngleofVectorTests.GetAngle(xmax - cx, tmpY - cy);

        //        tymin = Atan(r2 / (Tan(angle) * r1));
        //        tymax = Atan(r2 / (Tan(angle) * r1)) + PI;
        //        ymin = cy + r1 * Cos(tymin) * Sin(angle) + r2 * Sin(tymin) * Cos(angle);
        //        ymax = cy + r1 * Cos(tymax) * Sin(angle) + r2 * Sin(tymax) * Cos(angle);
        //        if (ymin > ymax)
        //        {
        //            SwapTests.Swap(ref ymin, ref ymax);
        //            SwapTests.Swap(ref tymin, ref tymax);
        //        }
        //        var tmpX = cx + r1 * Cos(tymin) * Cos(angle) - r2 * Sin(tymin) * Sin(angle);
        //        tymin = AngleofVectorTests.GetAngle(tmpX - cx, ymin - cy);
        //        tmpX = cx + r1 * Cos(tymax) * Cos(angle) - r2 * Sin(tymax) * Sin(angle);
        //        tymax = AngleofVectorTests.GetAngle(tmpX - cx, ymax - cy);
        //    }

        //    var angle1 = AngleofVectorTests.GetAngle(x1 - cx, y1 - cy);
        //    var angle2 = AngleofVectorTests.GetAngle(x2 - cx, y2 - cy);

        //    if (!sweep)
        //        SwapTests.Swap(ref angle1, ref angle2);

        //    var otherArc = false;
        //    if (angle1 > angle2)
        //    {
        //        SwapTests.Swap(ref angle1, ref angle2);
        //        otherArc = true;
        //    }

        //    if ((!otherArc && (angle1 > txmin || angle2 < txmin)) || (otherArc && !(angle1 > txmin || angle2 < txmin)))
        //        xmin = x1 < x2 ? x1 : x2;
        //    if ((!otherArc && (angle1 > txmax || angle2 < txmax)) || (otherArc && !(angle1 > txmax || angle2 < txmax)))
        //        xmax = x1 > x2 ? x1 : x2;
        //    if ((!otherArc && (angle1 > tymin || angle2 < tymin)) || (otherArc && !(angle1 > tymin || angle2 < tymin)))
        //        ymin = y1 < y2 ? y1 : y2;
        //    if ((!otherArc && (angle1 > tymax || angle2 < tymax)) || (otherArc && !(angle1 > tymax || angle2 < tymax)))
        //        ymax = y1 > y2 ? y1 : y2;

        //    return Rectangle2D.FromLTRB(xmin, ymin, xmax, ymax);
        //}
    }
}
