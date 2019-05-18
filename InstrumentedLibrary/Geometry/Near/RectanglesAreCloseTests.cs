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
    /// The rectangles are close tests class.
    /// </summary>
    [DisplayName("Rectangle Near Rectangle Tests")]
    [Description("Determines whether a Rectangle is near another Rectangle.")]
    [SourceCodeLocationProvider]
    public static class RectanglesAreCloseTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RectanglesAreCloseTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Rectangle2D(0d, 0d, 1d, 1d), new Rectangle2D(1d, 1d, 2d, 2d), DoubleEpsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        /// <param name="rect1"></param>
        /// <param name="rect2"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool AreRectanglesClose(Rectangle2D rect1, Rectangle2D rect2, double epsilon = DoubleEpsilon)
            => AreClose(rect1, rect2, epsilon);

        /// <summary>
        /// Compares two rectangles for fuzzy equality.  This function
        /// helps compensate for the fact that double values can
        /// acquire error when operated upon
        /// </summary>
        /// <param name='rect1'>The first rectangle to compare</param>
        /// <param name='rect2'>The second rectangle to compare</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>Whether or not the two rectangles are equal</returns>
        [DisplayName("Rectangle Near Rectangle")]
        [Description("Determines whether a Rectangle is near another Rectangle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreClose(Rectangle2D rect1, Rectangle2D rect2, double epsilon = DoubleEpsilon)
        {
            // If they're both empty, don't bother with the double logic.
            if (RectangleIsEmptyTests.IsRectangleEmpty(rect1.Width, rect1.Height))
            {
                return RectangleIsEmptyTests.IsRectangleEmpty(rect2.Width, rect2.Height);
            }

            // At this point, rect1 isn't empty, so the first thing we can test is
            // rect2.IsEmpty, followed by property-wise compares.
            return (!RectangleIsEmptyTests.IsRectangleEmpty(rect2.Width, rect2.Height))
                && AreCloseTests.AreClose(rect1.X, rect2.X, epsilon)
                && AreCloseTests.AreClose(rect1.Y, rect2.Y, epsilon)
                && AreCloseTests.AreClose(rect1.Height, rect2.Height, epsilon)
                && AreCloseTests.AreClose(rect1.Width, rect2.Width, epsilon);
        }
    }
}
