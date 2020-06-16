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
    /// 
    /// </summary>
    [DisplayName("Pinch Distort Point Tests")]
    [Description("Pinch distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class PinchDistortionTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(PinchDistortionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(10d, 10d), new Point2D(5d, 5d), 0.5d }, new TestCaseResults(description: "Pinch a point", trials: trials, expectedReturnValue: new Point2D(0d,  0d), epsilon: double.Epsilon) },
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
        /// <param name="point"></param>
        /// <param name="fulcrum"></param>
        /// <param name="strength"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D Pinch(Point2D point, Point2D fulcrum, double strength = OneHalf)
            => Pinch0(point, fulcrum, strength);

        /// <summary>
        /// The pinch distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="strength">The strength.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Pinch Distort Point Tests")]
        [Description("Pinch distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Pinch0(Point2D point, Point2D fulcrum, double strength = OneHalf)
        {
            if (fulcrum == point)
            {
                return point;
            }

            var dx = point.X - fulcrum.X;
            var dy = point.Y - fulcrum.Y;
            var distanceSquared = (dx * dx) + (dy * dy);
            var sx = point.X;
            var sy = point.Y;
            var distance = Sqrt(distanceSquared);
            if (strength < 0d)
            {
                var r = distance;
                var a = Atan2(dy, dx); // Might this be simplified by finding the unit of the vector?
                var rn = Pow(r, strength) * distance;
                var newX = (rn * Cos(a)) + fulcrum.X;
                var newY = (rn * Sin(a)) + fulcrum.Y;
                sx += newX - point.X;
                sy += newY - point.Y;
            }
            else
            {
                var dirX = dx / distance;
                var dirY = dy / distance;
                var alpha = distance;
                var distortionFactor = distance * Pow(1d - alpha, 1d / strength);
                sx -= distortionFactor * dirX;
                sy -= distortionFactor * dirY;
            }

            return new Point2D(sx, sy);
        }
    }
}
