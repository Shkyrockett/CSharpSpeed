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
    [DisplayName("Swirl Distort Point Tests")]
    [Description("Swirl distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class SwirlDistortionTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SwirlDistortionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(10d, 10d), new Point2D(5d, 5d), 0.5d }, new TestCaseResults(description: "Swirl a point", trials: trials, expectedReturnValue: new Point2D(20d,  20d), epsilon: double.Epsilon) },
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
        /// <param name="degree"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D Swirl(Point2D point, Point2D fulcrum, double degree = OneHalf)
            => Swirl0(point, fulcrum, degree);

        /// <summary>
        /// The swirl distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="degree">The degree.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Swirl Distort Point Tests")]
        [Description("Swirl distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Swirl0(Point2D point, Point2D fulcrum, double degree = OneHalf)
        {
            if (fulcrum == point)
            {
                return point;
            }

            var dX = point.X - fulcrum.X;
            var dY = point.Y - fulcrum.Y;
            var theta = Atan2(dY, dX);
            var radius = Sqrt(dX * dX + dY * dY);
            var newX = fulcrum.X + (radius * Cos(theta + degree * radius));
            var newY = fulcrum.Y + (radius * Sin(theta + degree * radius));
            return new Point2D(newX, newY);
        }
    }
}
