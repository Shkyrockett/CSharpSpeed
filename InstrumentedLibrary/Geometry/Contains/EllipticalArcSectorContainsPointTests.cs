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
    /// The elliptical arc sector contains point tests class.
    /// </summary>
    [DisplayName("Point In Elliptical Arc Sector Tests")]
    [Description("Determines whether a point is in an Elliptical Arc Sector.")]
    [SourceCodeLocationProvider]
    public static class EllipticalArcSectorContainsPointTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(EllipticalArcSectorContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, ToRadiansTests.ToRadians(0d), ToRadiansTests.ToRadians(0d), ToRadiansTests.ToRadians(45d), 0.5d, 0.5d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: Inclusion.Inside, epsilon: double.Epsilon) },
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
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Inclusion EllipticalArcSectorContainsPoint(double cX, double cY, double r1, double r2, double angle, double startAngle, double sweepAngle, double pX, double pY, double epsilon = Epsilon)
            => EllipticalArcSectorContainsPointSC(cX, cY, r1, r2, angle, startAngle, sweepAngle, pX, pY, epsilon);

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="EllipticalArc2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="pX">The x-coordinate of the test point.</param>
        /// <param name="pY">The y-coordinate of the test point.</param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of: http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// </acknowledgment>
        [DisplayName("Point In Ellipse Tests")]
        [Description("Determines whether a point is in an Ellipse.")]
        [Acknowledgment("http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcSectorContainsPointSC(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle,
            double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            return EllipticalArcSectorContainsPointSC(cX, cY, r1, r2, Cos(angle), Sin(angle), Cos(startAngle), Sin(startAngle), Cos(sweepAngle), Sin(sweepAngle), pX, pY, epsilon);
        }

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="EllipticalArc2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="cosT">The cosine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="sinT">The sine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="startCosT"></param>
        /// <param name="startSinT"></param>
        /// <param name="sweepCosT"></param>
        /// <param name="sweepSinT"></param>
        /// <param name="pX">The x-coordinate of the test point.</param>
        /// <param name="pY">The y-coordinate of the test point.</param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of: http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcSectorContainsPointSC(
            double cX, double cY,
            double r1, double r2,
            double cosT, double sinT,
            double startCosT, double startSinT,
            double sweepCosT, double sweepSinT,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            // If the ellipse is empty it can't contain anything.
            if (r1 <= 0d || r2 <= 0d)
            {
                return Inclusion.Outside;
            }

            var endSinT = sweepSinT * startCosT + sweepCosT * startSinT;
            var endCosT = sweepCosT * startCosT - sweepSinT * startSinT;

            // Find the start and end angles.
            var sa = EllipticalPolarVectorTests.EllipticalPolarVector(startCosT, startSinT, r1, r2);
            var ea = EllipticalPolarVectorTests.EllipticalPolarVector(endCosT, endSinT, r1, r2);

            // Ellipse equation for an ellipse at origin for the chord end points.
            var u1 = r1 * sa.cosT;
            var v1 = -(r2 * sa.sinT);
            var u2 = r1 * ea.cosT;
            var v2 = -(r2 * ea.sinT);

            // Find the points of the chord.
            var sX = cX + (u1 * cosT + v1 * sinT);
            var sY = cY + (u1 * sinT - v1 * cosT);
            var eX = cX + (u2 * cosT + v2 * sinT);
            var eY = cY + (u2 * sinT - v2 * cosT);

            // Find the determinant of the chord.
            var determinant = (sX - pX) * (eY - pY) - (eX - pX) * (sY - pY);

            // Check if the point is on the chord.
            if (Abs(determinant) <= epsilon)
            {
                return (sX < eX) ?
                (sX <= pX && pX <= eX) ? Inclusion.Boundary : Inclusion.Outside :
                (eX <= pX && pX <= sX) ? Inclusion.Boundary : Inclusion.Outside;
            }

            // Check whether the point is on the side of the chord as the center.
            if (Sign(-determinant) == Sign(sweepSinT * sweepCosT))
            {
                return Inclusion.Outside;
            }

            // Translate points to origin.
            var u0 = pX - cX;
            var v0 = pY - cY;

            // Apply the rotation transformation.
            var a = u0 * cosT + v0 * sinT;
            var b = u0 * sinT - v0 * cosT;

            // Normalize the radius.
            var normalizedRadius
                = (a * a / (r1 * r1))
                + (b * b / (r2 * r2));

            return (normalizedRadius <= 1d)
                ? ((Abs(normalizedRadius - 1d) < epsilon)
                ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="EllipticalArc2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="pX">The x-coordinate of the test point.</param>
        /// <param name="pY">The y-coordinate of the test point.</param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of: http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// </acknowledgment>
        [DisplayName("Point In Ellipse Tests")]
        [Description("Determines whether a point is in an Ellipse.")]
        [Acknowledgment("http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcSectorContainsPoint0(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle,
            double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            return EllipticalArcSectorContainsPoint0(cX, cY, r1, r2, Cos(angle), Sin(angle), startAngle, sweepAngle, pX, pY, epsilon);
        }

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="EllipticalArc2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="cosT">The cosine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="sinT">The sine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="pX">The x-coordinate of the test point.</param>
        /// <param name="pY">The y-coordinate of the test point.</param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of: http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcSectorContainsPoint0(
            double cX, double cY,
            double r1, double r2,
            double cosT, double sinT,
            double startAngle, double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            // If the ellipse is empty it can't contain anything.
            if (r1 <= 0d || r2 <= 0d)
            {
                return Inclusion.Outside;
            }

            var endAngle = startAngle + sweepAngle;

            // Find the start and end angles.
            var sa = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle, r1, r2);
            var ea = EllipticalPolarAngleTests.EllipticalPolarAngle(endAngle, r1, r2);

            // Ellipse equation for an ellipse at origin for the chord end points.
            var u1 = r1 * Cos(sa);
            var v1 = -(r2 * Sin(sa));
            var u2 = r1 * Cos(ea);
            var v2 = -(r2 * Sin(ea));

            // Find the points of the chord.
            var sX = cX + (u1 * cosT + v1 * sinT);
            var sY = cY + (u1 * sinT - v1 * cosT);
            var eX = cX + (u2 * cosT + v2 * sinT);
            var eY = cY + (u2 * sinT - v2 * cosT);

            // Find the determinant of the chord.
            var determinant = (sX - pX) * (eY - pY) - (eX - pX) * (sY - pY);

            // Check if the point is on the chord.
            if (Abs(determinant) <= epsilon)
            {
                return (sX < eX) ?
                (sX <= pX && pX <= eX) ? Inclusion.Boundary : Inclusion.Outside :
                (eX <= pX && pX <= sX) ? Inclusion.Boundary : Inclusion.Outside;
            }

            // Check whether the point is on the side of the chord as the center.
            if (Sign(determinant) == Sign(sweepAngle))
            {
                return Inclusion.Outside;
            }

            // Translate points to origin.
            var u0 = pX - cX;
            var v0 = pY - cY;

            // Apply the rotation transformation.
            var a = u0 * cosT + v0 * sinT;
            var b = u0 * sinT - v0 * cosT;

            // Normalize the radius.
            var normalizedRadius
                = (a * a / (r1 * r1))
                + (b * b / (r2 * r2));

            return (normalizedRadius <= 1d)
                ? ((Abs(normalizedRadius - 1d) < epsilon)
                ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="EllipticalArc2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="pX">The x-coordinate of the test point.</param>
        /// <param name="pY">The y-coordinate of the test point.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of: http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// </acknowledgment>
        [DisplayName("Point In Ellipse Tests")]
        [Description("Determines whether a point is in an Ellipse.")]
        [Acknowledgment("http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcContainsPoint1(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle,
            double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            return EllipticalArcContainsPoint1(cX, cY, r1, r2, Cos(angle), Sin(angle), Cos(startAngle), Sin(startAngle), Cos(sweepAngle), Sin(sweepAngle), pX, pY, epsilon);
        }

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="EllipticalArc2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="sinT">The sine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="cosT">The cosine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="startCosT"></param>
        /// <param name="startSinT"></param>
        /// <param name="sweepCosT"></param>
        /// <param name="sweepSinT"></param>
        /// <param name="pX">The x-coordinate of the test point.</param>
        /// <param name="pY">The y-coordinate of the test point.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of: http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// https://math.stackexchange.com/a/1760296
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcContainsPoint1(
            double cX, double cY,
            double r1, double r2,
            double cosT, double sinT,
            double startCosT, double startSinT,
            double sweepCosT, double sweepSinT,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            // If the ellipse is empty it can't contain anything.
            if (r1 <= 0d || r2 <= 0d)
            {
                return Inclusion.Outside;
            }

            // If the Sweep angle is Tau, the EllipticalArc must be an Ellipse.
            if (Abs(sweepCosT - 1d) < epsilon && Abs(sweepSinT) < epsilon)
            {
                return EllipseWithVectorAngleContainsPointTests.EllipseContainsPoint(cX, cY, r1, r2, sinT, cosT, pX, pY);
            }

            var endSinT = sweepSinT * startCosT + sweepCosT * startSinT;
            var endCosT = sweepCosT * startCosT - sweepSinT * startSinT;

            // Find the start and end angles.
            var sa = EllipticalPolarVectorTests.EllipticalPolarVector(startCosT, startSinT, r1, r2);
            var ea = EllipticalPolarVectorTests.EllipticalPolarVector(endCosT, endSinT, r1, r2);

            // Ellipse equation for an ellipse at origin for the chord end points.
            var u1 = r1 * sa.cosT;
            var v1 = -(r2 * sa.sinT);
            var u2 = r1 * ea.cosT;
            var v2 = -(r2 * ea.sinT);

            // Find the points of the chord.
            var sX = cX + (u1 * cosT + v1 * sinT);
            var sY = cY + (u1 * sinT - v1 * cosT);
            var eX = cX + (u2 * cosT + v2 * sinT);
            var eY = cY + (u2 * sinT - v2 * cosT);

            // Find the determinant of the chord.
            var determinant = (sX - pX) * (eY - pY) - (eX - pX) * (sY - pY);

            // Check whether the point is on the same side of the chord as the center.
            if (Sign(-determinant) == Sign(sweepSinT * sweepCosT))
            {
                return Inclusion.Outside;
            }

            // Translate point to origin.
            var u0 = pX - cX;
            var v0 = pY - cY;

            // Apply the rotation transformation to the point at the origin.
            var a = u0 * cosT + v0 * sinT;
            var b = u0 * sinT - v0 * cosT;

            // Normalize the radius.
            var normalizedRadius
                = (a * a / (r1 * r1))
                + (b * b / (r2 * r2));

            return (normalizedRadius <= 1d)
                ? ((Abs(normalizedRadius - 1d) < epsilon)
                ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="EllipticalArc2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="pX">The x-coordinate of the test point.</param>
        /// <param name="pY">The y-coordinate of the test point.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of: http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// </acknowledgment>
        [DisplayName("Point In Ellipse Tests")]
        [Description("Determines whether a point is in an Ellipse.")]
        [Acknowledgment("http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcContainsPoint2(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle,
            double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            return EllipticalArcContainsPoint2(cX, cY, r1, r2, Cos(angle), Sin(angle), Cos(startAngle), Sin(startAngle), Cos(sweepAngle), Sin(sweepAngle), pX, pY, epsilon);
        }

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="EllipticalArc2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="sinT">The sine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="cosT">The cosine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="startCosT"></param>
        /// <param name="startSinT"></param>
        /// <param name="sweepCosT"></param>
        /// <param name="sweepSinT"></param>
        /// <param name="pX">The x-coordinate of the test point.</param>
        /// <param name="pY">The y-coordinate of the test point.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of: http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// https://math.stackexchange.com/a/1760296
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcContainsPoint2(
            double cX, double cY,
            double r1, double r2,
            double cosT, double sinT,
            double startCosT, double startSinT,
            double sweepCosT, double sweepSinT,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            // If the ellipse is empty it can't contain anything.
            if (r1 <= 0d || r2 <= 0d)
            {
                return Inclusion.Outside;
            }

            // If the Sweep angle is Tau, the EllipticalArc must be an Ellipse.
            if (Abs(sweepCosT - 1d) < epsilon && Abs(sweepSinT) < epsilon)
            {
                return EllipseWithVectorAngleContainsPointTests.EllipseContainsPoint(cX, cY, r1, r2, sinT, cosT, pX, pY);
            }

            var endSinT = sweepSinT * startCosT + sweepCosT * startSinT;
            var endCosT = sweepCosT * startCosT - sweepSinT * startSinT;

            // ToDo: Simplify out Atan2
            var startAngle = Atan2(startSinT, startCosT);
            var endAngle = Atan2(endSinT, endCosT);

            // Find the start and end angles.
            var sa = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle, r1, r2);
            var ea = EllipticalPolarAngleTests.EllipticalPolarAngle(endAngle, r1, r2);

            // Ellipse equation for an ellipse at origin for the chord end points.
            var u1 = r1 * Cos(sa);
            var v1 = -(r2 * Sin(sa));
            var u2 = r1 * Cos(ea);
            var v2 = -(r2 * Sin(ea));

            // Find the points of the chord.
            var sX = cX + (u1 * cosT + v1 * sinT);
            var sY = cY + (u1 * sinT - v1 * cosT);
            var eX = cX + (u2 * cosT + v2 * sinT);
            var eY = cY + (u2 * sinT - v2 * cosT);

            // Find the determinant of the chord.
            var determinant = (sX - pX) * (eY - pY) - (eX - pX) * (sY - pY);

            // Check whether the point is on the same side of the chord as the center.
            if (Sign(-determinant) == Sign(sweepSinT * sweepCosT))
            {
                return Inclusion.Outside;
            }

            // Translate point to origin.
            var u0 = pX - cX;
            var v0 = pY - cY;

            // Apply the rotation transformation to the point at the origin.
            var a = u0 * cosT + v0 * sinT;
            var b = u0 * sinT - v0 * cosT;

            // Normalize the radius.
            var normalizedRadius
                = (a * a / (r1 * r1))
                + (b * b / (r2 * r2));

            return (normalizedRadius <= 1d)
                ? ((Abs(normalizedRadius - 1d) < epsilon)
                ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
    }
}
