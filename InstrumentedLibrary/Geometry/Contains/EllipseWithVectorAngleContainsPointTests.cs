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
    /// The ellipse with vector angle contains point tests class.
    /// </summary>
    [DisplayName("Point In Ellipse Tests")]
    [Description("Determines whether a point is in an Ellipse.")]
    [SourceCodeLocationProvider]
    public static class EllipseWithVectorAngleContainsPointTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(EllipseWithVectorAngleContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, Cos(0d), Sin(0d), 0.5d, 0.5d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: Inclusions.Inside, epsilon: double.Epsilon) },
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
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="cosT"></param>
        /// <param name="sinT"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Inclusions EllipseContainsPoint(double cX, double cY, double rx, double ry, double cosT, double sinT, double pX, double pY, double epsilon = Epsilon)
            => EllipseContainsPoint2(cX, cY, rx, ry, cosT, sinT, pX, pY, epsilon);

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="Ellipse2D"/>.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="rx">The first radius of the Ellipse.</param>
        /// <param name="ry">The second radius of the Ellipse.</param>
        /// <param name="cosT">The cosine of the angle of rotation of Ellipse about it's center.</param>
        /// <param name="sinT">The sine of the angle of rotation of Ellipse about it's center.</param>
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
        public static Inclusions EllipseContainsPoint1(
            double cX, double cY, double rx, double ry, double cosT, double sinT,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            if (rx <= 0d || ry <= 0d)
            {
                return Inclusions.Outside;
            }

            // Translate point to origin.
            var u = pX - cX;
            var v = pY - cY;

            // Apply the rotation transformation.
            var a = u * cosT + v * sinT;
            var b = u * sinT - v * cosT;

            var normalizedRadius = (a * a / (rx * rx)) + (b * b / (ry * ry));

            return (normalizedRadius <= 1d)
                ? ((Abs(normalizedRadius - 1d) < epsilon)
                ? Inclusions.Boundary : Inclusions.Inside) : Inclusions.Outside;
        }

        /// <summary>
        /// Is point (x, y) inside of the ellipse centered at (ex, ey) with diameters width and height, rotated by angle rot? 
        /// Return true if it is so.
        /// </summary>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="rx">The rx.</param>
        /// <param name="ry">The ry.</param>
        /// <param name="cosT">The cosT.</param>
        /// <param name="sinT">The sinT.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="Inclusions"/>.</returns>
        /// <acknowledgment>
        /// From: https://www.khanacademy.org/math/trigonometry/conics_precalc/ellipses-precalc/v/conic-sections--intro-to-ellipses
        /// See also: https://www.khanacademy.org/computer-programming/ellipse-collision-detector/5514890244521984
        /// </acknowledgment>
        [DisplayName("Point In Ellipse Tests")]
        [Description("Determines whether a point is in an Ellipse.")]
        [Acknowledgment("https://www.khanacademy.org/math/trigonometry/conics_precalc/ellipses-precalc/v/conic-sections--intro-to-ellipses", "https://www.khanacademy.org/computer-programming/ellipse-collision-detector/5514890244521984")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusions EllipseContainsPoint2(
            double cx, double cy, double rx, double ry, double cosT, double sinT,
            double x, double y,
            double epsilon = Epsilon)
        {
            if (rx <= 0d || ry <= 0d)
            {
                return Inclusions.Outside;
            }

            // Translate point to origin.
            var u = x - cx;
            var v = y - cy;

            // Apply the rotation transformation.
            var a = cosT * u + sinT * v;
            var b = sinT * u - cosT * v;

            // sqrt x/y terms
            var termX = 2 * a / rx;
            var termY = 2 * b / ry;

            var normalizedRadius = (termX * termX) + (termY * termY);
            return (normalizedRadius <= 1d)
                ? ((Abs(normalizedRadius - 1d) < epsilon)
                ? Inclusions.Boundary : Inclusions.Inside) : Inclusions.Outside;
        }
    }
}
