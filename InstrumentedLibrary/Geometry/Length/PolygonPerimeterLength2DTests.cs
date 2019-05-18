using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using System.Linq;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon perimeter length2d tests class.
    /// </summary>
    [DisplayName("Polygon Perimeter Length Tests")]
    [Description("Calculate the length of the Perimeter of a polygon.")]
    [SourceCodeLocationProvider]
    public static class PolygonPerimeterLength2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the cross product of three 2D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolygonPerimeterLength2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new List<(double X, double Y)> {(0d, 0d), (1d, 0d), (0d, 1d)} }, new TestCaseResults(description: "Circle test case.", trials: trials, expectedReturnValue:Tau, epsilon: double.Epsilon) },
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
        /// <param name="points"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double PolygonPerimeterLength2D(IEnumerable<(double X, double Y)> points)
            => Perimeter0(points);

        /// <summary>
        /// The perimeter0.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Perimeter of Polygon")]
        [Description("Find Perimeter length of a polygon.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Perimeter0(IEnumerable<(double X, double Y)> points)
        {
            var last = (points as List<(double X, double Y)>)[0];
            double dist = 0;
            foreach (var cur in points.Skip(1))
            {
                dist += Distance2DTests.Distance2D(last.X, last.Y, cur.X, cur.Y);
                last = cur;
            }
            return dist;
        }

        /// <summary>
        /// The perimeter1.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/2227828/find-the-distance-required-to-navigate-a-list-of-points-using-linq
        /// </acknowledgment>
        [DisplayName("Perimeter of Polygon")]
        [Description("Find Perimeter length of a polygon.")]
        [Acknowledgment("http://stackoverflow.com/questions/2227828/find-the-distance-required-to-navigate-a-list-of-points-using-linq")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Perimeter1(IEnumerable<(double X, double Y)> points)
        {
            return points.Zip(points.Skip(1), Distance2Point2DTests.Distance2D_1).Sum();
        }
    }
}
