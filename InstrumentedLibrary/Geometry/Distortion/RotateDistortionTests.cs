using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Rotate Distort Point Tests")]
    [Description("Rotate distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class RotateDistortionTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(RotateDistortionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(10d, 10d), new Point2D(5d, 5d), new Vector2D(0d, 1d), new Vector2D(1d, 0d) }, new TestCaseResults(description: "Flip a point", trials: trials, expectedReturnValue: new Point2D(0d,  0d), epsilon: double.Epsilon) },
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
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D Rotate(Point2D point, Point2D fulcrum, Vector2D xAxis, Vector2D yAxis)
            => Rotate0(point, fulcrum, xAxis, yAxis);

        /// <summary>
        /// Rotate a point about a center point.
        /// </summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="fulcrum">The center axis point.</param>
        /// <param name="xAxis">The Sine and Cosine of the angle on the x-axis.</param>
        /// <param name="yAxis">The Sine and Cosine of the angle on the y-axis.</param>
        /// <returns></returns>
        [DisplayName("Rotate Distort Point Tests")]
        [Description("Rotate distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Rotate0(Point2D point, Point2D fulcrum, Vector2D xAxis, Vector2D yAxis)
        {
            return new Point2D(
                           fulcrum.X + (((point.X - fulcrum.X) * xAxis.I) + ((point.Y - fulcrum.Y) * xAxis.J)),
                           fulcrum.Y + (((point.X - fulcrum.X) * yAxis.I) + ((point.Y - fulcrum.Y) * yAxis.J)));
        }
    }
}
