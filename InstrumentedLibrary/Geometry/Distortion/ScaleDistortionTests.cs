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
    [DisplayName("Scale Distort Point Tests")]
    [Description("Scale distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class ScaleDistortionTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(ScaleDistortionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(10d, 10d), new Size2D(2d, 2d) }, new TestCaseResults(description: "Scale a point", trials: trials, expectedReturnValue: new Point2D(20d,  20d), epsilon: double.Epsilon) },
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
        /// <param name="factors"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D Scale(Point2D point, Size2D factors)
            => Scale0(point, factors);

        /// <summary>
        /// The scale distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="factors">The factors.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Scale Distort Point Tests")]
        [Description("Scale distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Scale0(Point2D point, Size2D factors)
        {
            return new Point2D(point.X * factors.Width, point.Y * factors.Height);
        }
    }
}
