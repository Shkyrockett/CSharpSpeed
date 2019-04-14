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
                { new object[] { 1d, 1d, 2d, 2d, 1.5d, 1.5d }, new TestCaseResults(description: "1, 2, 3, 4, 5", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        /// <param name="segmentAX"></param>
        /// <param name="segmentAY"></param>
        /// <param name="segmentBX"></param>
        /// <param name="segmentBY"></param>
        /// <param name="pointX"></param>
        /// <param name="pointY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PointOnLineSegment(double segmentAX, double segmentAY, double segmentBX, double segmentBY, double pointX, double pointY)
            => PointOnLineSegment1(segmentAX, segmentAY, segmentBX, segmentBY, pointX, pointY);

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
        public static bool PointOnLineSegment1(
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
            return DistanceToLineSegmentTests.DistanceToSegment(pointX, pointY, segmentAX, segmentAY, segmentBX, segmentBY) < Epsilon;
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
            var Length1 = Distance2DTests.Distance2D(pointX, pointY, segmentBX, segmentBY);
            // Sqrt((Point.X - Line.B.X) ^ 2 + (Point.Y - Line.B.Y))
            var Length2 = Distance2DTests.Distance2D(pointX, pointY, segmentAX, segmentAY);
            // Sqrt((Point.X - Line.A.X) ^ 2 + (Point.Y - Line.A.Y))
            return Abs(Distance2DTests.Distance2D(segmentAX, segmentAY, segmentBX, segmentBY) - Length1 + Length2) < DoubleEpsilon;
        }

        /// <summary>
        /// Return true iff the point (x, y) is in the line
        /// segment (x1, y1) to (x2, y2).
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/profile/BobLyon/programs
        /// </acknowledgment>
        [DisplayName("Point On Line Segment Tests")]
        [Description("Determines whether a point is on a line segment.")]
        [Acknowledgment("https://www.khanacademy.org/profile/BobLyon/programs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LineContainsPoint(double x1, double y1, double x2, double y2, double x, double y)
        {
            return (y2 - y1) / (x2 - x1) == (y - y1) / (x - x1) && ValueBetweenTests.Between(x, x1, x2);
        }
    }
}
