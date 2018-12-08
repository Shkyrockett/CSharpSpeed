using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The point on line segment tests class.
    /// </summary>
    [DisplayName("Point On Line Segment Tests")]
    [Description("Determines whether a point is on a line segment.")]
    [Signature("public static double PointOnLineSegment(double value1, double value2, double value3, double amount1, double amount2)")]
    [SourceCodeLocationProvider]
    public static class PointOnLineSegmentTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PointOnLineSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 2d, 2d, 1.5d, 1.5d }, new TestCaseResults(description:"1, 2, 3, 4, 5", trials:trials, expectedReturnValue:15d, epsilon:DoubleEpsilon) },
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
        /// The point on line segment.
        /// </summary>
        /// <param name="segmentAX">The segmentAX.</param>
        /// <param name="segmentAY">The segmentAY.</param>
        /// <param name="segmentBX">The segmentBX.</param>
        /// <param name="segmentBY">The segmentBY.</param>
        /// <param name="pointX">The pointX.</param>
        /// <param name="pointY">The pointY.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool PointOnLineSegment(
            double segmentAX,
            double segmentAY,
            double segmentBX,
            double segmentBY,
            double pointX,
            double pointY)
        {
            return ((Abs(pointX - segmentAX) < DoubleEpsilon)
                && (Abs(pointY - segmentAY) < DoubleEpsilon))
                || ((Abs(pointX - segmentBX) < DoubleEpsilon)
                && (Abs(pointY - segmentBY) < DoubleEpsilon))
                || (((pointX > segmentAX) == (pointX < segmentBX))
                && ((pointY > segmentAY) == (pointY < segmentBY))
                && (Abs((pointX - segmentAX) * (segmentBY - segmentAY) - (segmentBX - segmentAX) * (pointY - segmentAY)) < DoubleEpsilon));
        }

        /// <summary>
        /// The point line segment.
        /// </summary>
        /// <param name="segmentAX">The segmentAX.</param>
        /// <param name="segmentAY">The segmentAY.</param>
        /// <param name="segmentBX">The segmentBX.</param>
        /// <param name="segmentBY">The segmentBY.</param>
        /// <param name="pointX">The pointX.</param>
        /// <param name="pointY">The pointY.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://www.angusj.com/delphi/clipper.php
        /// </acknowledgment>
        [DisplayName("Point On Line Segment Tests")]
        [Description("Determines whether a point is on a line segment.")]
        [Acknowledgment("http://www.angusj.com/delphi/clipper.php")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointLineSegment(
            double segmentAX,
            double segmentAY,
            double segmentBX,
            double segmentBY,
            double pointX,
            double pointY)
        {
            return ((pointX == segmentAX) && (pointY == segmentAY)) ||
                ((pointX == segmentBX) && (pointY == segmentBY)) ||
                (((pointX > segmentAX) == (pointX < segmentBX)) &&
                ((pointY > segmentAY) == (pointY < segmentBY)) &&
                ((pointX - segmentAX) * (segmentBY - segmentAY) ==
                (segmentBX - segmentAX) * (pointY - segmentAY)));
        }

        /// <summary>
        /// The point line segment.
        /// </summary>
        /// <param name="segmentAX">The segmentAX.</param>
        /// <param name="segmentAY">The segmentAY.</param>
        /// <param name="segmentBX">The segmentBX.</param>
        /// <param name="segmentBY">The segmentBY.</param>
        /// <param name="pointX">The pointX.</param>
        /// <param name="pointY">The pointY.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// From: http://stackoverflow.com/questions/2255842/detecting-coincident-subset-of-two-coincident-line-segments/2255848
        /// </acknowledgment>
        [DisplayName("Point On Line Segment Tests")]
        [Description("Determines whether a point is on a line segment.")]
        [Acknowledgment("http://stackoverflow.com/questions/2255842/detecting-coincident-subset-of-two-coincident-line-segments/2255848")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointLineSegment2(
            double segmentAX,
            double segmentAY,
            double segmentBX,
            double segmentBY,
            double pointX,
            double pointY)
        {
            return DistanceToLineSegmentTests.DistFromSeg(pointX, pointY, segmentAX, segmentAY, segmentBX, segmentBY) < Epsilon;
        }

        /// <summary>
        /// The point on line.
        /// </summary>
        /// <param name="segmentAX">The segmentAX.</param>
        /// <param name="segmentAY">The segmentAY.</param>
        /// <param name="segmentBX">The segmentBX.</param>
        /// <param name="segmentBY">The segmentBY.</param>
        /// <param name="pointX">The pointX.</param>
        /// <param name="pointY">The pointY.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Point On Line Segment Tests")]
        [Description("Determines whether a point is on a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointOnLine(
            double segmentAX,
            double segmentAY,
            double segmentBX,
            double segmentBY,
            double pointX,
            double pointY)
        {
            var Length1 = Distance2DTests.Distance2D_1(pointX, pointY, segmentBX, segmentBY);
            // Sqrt((Point.X - Line.B.X) ^ 2 + (Point.Y - Line.B.Y))
            var Length2 = Distance2DTests.Distance2D_1(pointX, pointY, segmentAX, segmentAY);
            // Sqrt((Point.X - Line.A.X) ^ 2 + (Point.Y - Line.A.Y))
            return Abs(Distance2DTests.Distance2D_1(segmentAX, segmentAY, segmentBX, segmentBY) - Length1 + Length2) < DoubleEpsilon;
        }
    }
}
