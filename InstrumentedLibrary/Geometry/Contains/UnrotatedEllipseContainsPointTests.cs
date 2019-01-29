using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The unrotated ellipse contains point tests class.
    /// </summary>
    [DisplayName("Point In Orthogonal Ellipse Tests")]
    [Description("Determines whether a point is in an Orthogonal Ellipse.")]
    [SourceCodeLocationProvider]
    public static class UnrotatedEllipseContainsPointTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(UnrotatedEllipseContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 0.5d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool UnrotatedEllipseContainsPoint(double x, double y, double rX, double rY, double pX, double pY)
            => UnrotatedEllipseContainsPoint1(x, y, rX, rY, pX, pY);

        /// <summary>
        /// The unrotated ellipse contains point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Point In Ellipse Tests")]
        [Description("Determines whether a point is in an Ellipse.")]
        [Acknowledgment("http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool UnrotatedEllipseContainsPoint1(double x, double y, double rX, double rY, double pX, double pY)
        {
            if (rX <= 0d || rY <= 0d)
            {
                return false;
            }

            var u = pX - x;
            var v = pY - y;

            var a = u * u;
            var b = u * u;

            var d1Squared = rX * rX;
            var d2Squared = rY * rY;

            return (a / d1Squared) + (b / d2Squared) <= 1d;
        }
    }
}
