using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate elliptical arc tests class.
    /// </summary>
    [DisplayName("Interpolate Unrotated Elliptical Arc Tests")]
    [Description("Find a point on an unrotated elliptical arc.")]
    [SourceCodeLocationProvider]
    public static class InterpolateUnrotatedEllipticalArcTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(InterpolateUnrotatedEllipticalArcTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 3d, 4d, 0d.ToRadians(), 30d.ToRadians(), 0.5d }, new TestCaseResults(description: "Find the point in the middle of an elliptical arc of 3:4 centered about the origin.", trials: trials, expectedReturnValue:(2.9411967076827623d, 0.788091282604673d), epsilon: double.Epsilon) },
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
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) EllipticalArc(double cX, double cY, double r1, double r2, double startAngle, double sweepAngle, double t)
            => EllipticalArc_(cX, cY, r1, r2, startAngle, sweepAngle, t);

        /// <summary>
        /// Interpolates the unrotated elliptical Arc.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="startAngle">The angle to start the arc.</param>
        /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
        /// <param name="t">Theta of interpolation.</param>
        /// <returns>Interpolated point at theta.</returns>
        [DisplayName("Interpolate Unrotated Elliptical Arc 1")]
        [Description("Interpolates the unrotated elliptical Arc.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) EllipticalArc_(
            double cX, double cY,
            double r1, double r2,
            double startAngle, double sweepAngle,
            double t)
        {
            var phi = startAngle + (sweepAngle * t);
            var theta = phi % PI;

            var tanAngle = Abs(Tan(theta));
            var x = Sqrt(r1 * r1 * (r2 * r2) / ((r2 * r2) + (r1 * r1 * (tanAngle * tanAngle))));
            var y = x * tanAngle;

            return (theta >= 0d) && (theta < 90d.ToRadians())
                ? (cX + x, cY + y)
                : (theta >= 90d.ToRadians()) && (theta < 180d.ToRadians())
                ? (cX - x, cY + y)
                : (theta >= 180d.ToRadians()) && (theta < 270d.ToRadians()) ? (cX - x, cY - y) : (cX + x, cY - y);
        }
    }
}
