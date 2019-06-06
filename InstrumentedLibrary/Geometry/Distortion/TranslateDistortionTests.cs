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
    [DisplayName("Translate Distort Point Tests")]
    [Description("Translate distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class TranslateDistortionTests
    {
        /// <summary>
        /// The point2d in circle2d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(TranslateDistortionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(10d, 10d), new Vector2D(2d, 2d) }, new TestCaseResults(description: "Translate a point", trials: trials, expectedReturnValue: new Point2D(12d,  12d), epsilon: double.Epsilon) },
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
        /// <param name="offset"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D Translate(Point2D point, Vector2D offset)
            => Translate0(point, offset);

        /// <summary>
        /// The Translate distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Translate Distort Point Tests")]
        [Description("Translate distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Translate0(Point2D point, Vector2D offset)
        {
            return point + offset;
        }
    }
}
