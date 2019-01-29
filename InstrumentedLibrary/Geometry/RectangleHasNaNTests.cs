using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The rectangle has NaN tests class.
    /// </summary>
    [DisplayName("Rectangle has NaN Tests")]
    [Description("Rectangle has NaN.")]
    [SourceCodeLocationProvider]
    public static class RectangleHasNaNTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RectangleHasNaNTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Rectangle2D(double.NaN, double.NaN, double.NaN, double.NaN) }, new TestCaseResults(description: "Circle from three points test case.", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="rect"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool RectHasNaN(Rectangle2D rect)
            => RectHasNaN0(rect);

        /// <summary>
        /// rectHasNaN - this returns true if this rectangle has X, Y , Height or Width as NaN.
        /// </summary>
        /// <param name='rect'>The rectangle to test</param>
        /// <returns>returns whether the Rectangle has NaN</returns>
        [DisplayName("Rectangle has NaN Tests")]
        [Description("Rectangle has NaN.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RectHasNaN0(Rectangle2D rect)
        {
            return double.IsNaN(rect.X)
                || double.IsNaN(rect.Y)
                || double.IsNaN(rect.Height)
                || double.IsNaN(rect.Width);
        }
    }
}
