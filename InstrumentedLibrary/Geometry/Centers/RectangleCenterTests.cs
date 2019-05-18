using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The rectangle center tests class.
    /// </summary>
    [DisplayName("Center of Rectangle Tests")]
    [Description("Find the center of a rectangle.")]
    [SourceCodeLocationProvider]
    public static class RectangleCenterTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RectangleCenterTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Rectangle2D(0d, 0d, 2d, 2d) }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (1d, 1d), epsilon: double.Epsilon) },
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
        /// <param name="rectangle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) RectangleCenter(Rectangle2D rectangle)
            => Center0(rectangle);

        /// <summary>
        /// Extension method to find the center point of a rectangle.
        /// </summary>
        /// <param name="rectangle">The <see cref="Rectangle2D"/> of which you want the center.</param>
        /// <returns>A <see cref="Point2D"/> representing the center point of the <see cref="Rectangle2D"/>.</returns>
        /// <acknowledgment>Be sure to cache the results of this method if used repeatedly, as it is recalculated each time.
        /// </acknowledgment>
        [DisplayName("Center of Rectangle")]
        [Description("Find the center of a rectangle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Center0(Rectangle2D rectangle)
        {
            return (
                rectangle.Left + (rectangle.Right - rectangle.Left) * 0.5d,
                rectangle.Top + (rectangle.Bottom - rectangle.Top) * 0.5d
                );
        }

        /// <summary>
        /// Extension method to find the center point of a rectangle.
        /// </summary>
        /// <param name="rectangle">The <see cref="Rectangle2D"/> of which you want the center.</param>
        /// <returns>A <see cref="Point2D"/> representing the center point of the <see cref="Rectangle2D"/>.</returns>
        /// <acknowledgment>Be sure to cache the results of this method if used repeatedly, as it is recalculated each time.
        /// </acknowledgment>
        [DisplayName("Center of Rectangle")]
        [Description("Find the center of a rectangle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Center1(Rectangle2D rectangle)
        {
            return (
                (rectangle.Left + rectangle.Right) * 0.5d,
                (rectangle.Top + rectangle.Bottom) * 0.5d
                );
        }
    }
}
