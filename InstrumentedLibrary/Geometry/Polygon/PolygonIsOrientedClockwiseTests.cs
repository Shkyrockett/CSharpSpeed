using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon is oriented clockwise tests class.
    /// </summary>
    [DisplayName("Polygon Clockwise")]
    [Description("Determine the winding order of a polygon.")]
    [SourceCodeLocationProvider]
    public static class PolygonIsOrientedClockwiseTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(PolygonIsOrientedClockwiseTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var polygon = new (double X, double Y)[] { (0d, 0d), (1d, 0d), (1d, 1d) };
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { polygon }, new TestCaseResults(description: "polygon.", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="polygon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PolygonIsOrientedClockwise((double X, double Y)[] polygon)
            => PolygonIsOrientedClockwise0(polygon);

        /// <summary>
        /// The polygon is oriented clockwise.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>The <see cref="bool"/>. Return true if the polygon is oriented clockwise.</returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/triangulate-a-polygon-in-c/
        /// </acknowledgment>
        [DisplayName("Polygon Clockwise 6")]
        [Description("Determine if the polygon is built in a clockwise direction.")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PolygonIsOrientedClockwise0((double X, double Y)[] polygon)
        {
            return PolygonSignedAreaTests.SignedPolygonArea(polygon) < 0d;
        }
    }
}
