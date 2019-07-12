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
    /// The interpolate elliptical arc tests class.
    /// </summary>
    [DisplayName("Interpolate Rotated Elliptical Arc Tests")]
    [Description("Find a point on an rotated elliptical arc.")]
    [SourceCodeLocationProvider]
    public static class InterpolateRotatedEllipseTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(InterpolateRotatedEllipseTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 0d, 3d, 4d, 0d.ToRadians() }, new TestCaseResults(description: "Find the point halfway around an ellipse 3:4 centered about the origin.", trials: trials, expectedReturnValue:(2.6327476856711183d, 1.917702154416812d), epsilon: double.Epsilon) },
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
        /// <param name="t"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) Ellipse(double t, double cX, double cY, double r1, double r2, double angle)
            => Ellipse1(t, cX, cY, r1, r2, angle);

        /// <summary>
        /// Interpolate a point on an Ellipse.
        /// </summary>
        /// <param name="t">Theta of interpolation.</param>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <returns>Interpolated point at theta.</returns>
        /// <acknowledgment>
        /// http://www.vbforums.com/showthread.php?686351-RESOLVED-Elliptical-orbit
        /// </acknowledgment>
        [DisplayName("Interpolate Unrotated Ellipse 1")]
        [Description("Interpolates the unrotated ellipse.")]
        [Acknowledgment("http://www.vbforums.com/showthread.php?686351-RESOLVED-Elliptical-orbit")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Ellipse1(double t, double cX, double cY, double r1, double r2, double angle)
            => Ellipse(Cos(t), Sin(t), cX, cY, r1, r2, Cos(angle), Sin(angle));

        /// <summary>
        /// Interpolate a point on an Ellipse.
        /// </summary>
        /// <param name="cosTheta">Theta cosine of interpolation.</param>
        /// <param name="sinTheta">Theta sine of interpolation.</param>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="cosAngle">Horizontal rotation transform of the Ellipse.</param>
        /// <param name="sinAngle">Vertical rotation transform of the Ellipse.</param>
        /// <returns>Interpolated point at theta.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Ellipse(
            double cosTheta, double sinTheta,
            double cX, double cY,
            double r1, double r2,
            double cosAngle, double sinAngle)
        {
            // Ellipse equation for an ellipse at origin.
            var u = r1 * cosTheta;
            var v = -(r2 * sinTheta);

            // Apply the rotation transformation and translate to new center.
            return (
                cX + ((u * cosAngle) + (v * sinAngle)),
                cY + ((u * sinAngle) - (v * cosAngle)));
        }
    }
}
