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
    [DisplayName("Flip Distort Point Tests")]
    [Description("Flip distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class FlipDistortionTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(FlipDistortionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(10d, 10d), new Point2D(5d, 5d), true, true }, new TestCaseResults(description: "Flip a point", trials: trials, expectedReturnValue: new Point2D(0d,  0d), epsilon: double.Epsilon) },
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
        /// <param name="flipHorizontal"></param>
        /// <param name="flipVertical"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D Flip(Point2D point, Point2D fulcrum, bool flipHorizontal, bool flipVertical)
            => Flip0(point, fulcrum, flipHorizontal, flipVertical);

        /// <summary>
        /// The flip distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="flipHorz">The bHorz.</param>
        /// <param name="flipVert">The bVert.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Flip Distort Point Tests")]
        [Description("Flip distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Flip0(Point2D point, Point2D fulcrum, bool flipHorz, bool flipVert)
        {
            var x = flipHorz ? fulcrum.X - (point.X - fulcrum.X + 1d) : point.X;
            var y = flipVert ? fulcrum.Y - (point.Y - fulcrum.Y + 1d) : point.Y;
            return new Point2D(x, y);
        }

        /// <summary>
        /// The flip distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="flipHorz">The bHorz.</param>
        /// <param name="flipVert">The bVert.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Flip Distort Point Tests")]
        [Description("Flip distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Flip1(Point2D point, Point2D fulcrum, bool flipHorz, bool flipVert)
        {
            return new Point2D(flipHorz ? fulcrum.X - (point.X - fulcrum.X + 1d) : point.X, flipVert ? fulcrum.Y - (point.Y - fulcrum.Y + 1d) : point.Y);
        }
    }
}
