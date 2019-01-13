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
    /// The point near line segment tests class.
    /// </summary>
    [DisplayName("Point Near Line Segment Tests")]
    [Description("Determines whether a point is near to a line segment.")]
    [Signature("public static bool PointNearSegment(double px, double py, double x1, double y1, double x2, double y2, double close_distance)")]
    [SourceCodeLocationProvider]
    public static class PointNearLineSegmentTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PointNearLineSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 2d, 2d, 1.5d, 1.5d, Epsilon }, new TestCaseResults(description:"1, 2, 3, 4, 5", trials:trials, expectedReturnValue:15d, epsilon:DoubleEpsilon) },
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
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="close_distance"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PointNearSegment(double px, double py, double x1, double y1, double x2, double y2, double close_distance)
            => PointNearSegment1(px, py, x1, y1, x2, y2, close_distance);

        /// <summary>
        /// The point near segment.
        /// </summary>
        /// <param name="px">The px.</param>
        /// <param name="py">The py.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="close_distance">The close_distance. Return True if (px, py) is within close_distance if the segment from (x1, y1) to (X2, y2).</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Point Near Line Segment Tests")]
        [Description("Determines whether a point is near to a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointNearSegment1(double px, double py, double x1, double y1, double x2, double y2, double close_distance)
        {
            return DistanceToLineSegmentTests.DistanceToSegment(px, py, x1, y1, x2, y2) <= close_distance;
        }
    }
}
