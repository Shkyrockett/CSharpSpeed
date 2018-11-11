using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The normalize point2d tests class.
    /// </summary>
    [DisplayName("Normalize Point to Bounding Box")]
    [Description("Normalize the position of a point to a surounding bounding box as a percentage of that box.")]
    [Signature("public static Point2D NormalizePoint(Rectangle2D bounds, Point2D point)")]
    [SourceCodeLocationProvider]
    public static class NormalizeBoundedPoint2DTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(NormalizeBoundedPoint2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Rectangle2D(0d, 0d, 10d, 10d), new Point2D(5d, 5d) }, new TestCaseResults(description:"Point Inside", trials:trials, expectedReturnValue:new Point2D(0.5d, 0.5d), DoubleEpsilon) }
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
        /// Normalizes a point, so that it is expressed as percentage coordinates relative to the bounding box.
        /// </summary>
        /// <param name="bounds">The bounding box of the shape.</param>
        /// <param name="point">The point to warp.</param>
        /// <returns>The returned point in normalized percentage form.</returns>
        [DisplayName("Normalize 2D Point to Bounding Rectangle")]
        [Description("Normalizes a point, so that it is expressed as percentage coordinates relative to the bounding box.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D NormalizePoint(Rectangle2D bounds, Point2D point)
        {
            return new Point2D(
                (point.X - bounds.X) / bounds.Width,
                (point.Y - bounds.Top) / bounds.Height
                );
        }
    }
}
