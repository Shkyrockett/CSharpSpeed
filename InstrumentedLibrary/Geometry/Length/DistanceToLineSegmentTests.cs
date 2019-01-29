using CSharpSpeed;
using System;
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
    /// The distance to line segment tests class.
    /// </summary>
    [DisplayName("Distance to line segment from point")]
    [Description("Calculates the distance from a point to the nearest point on a line segment.")]
    [SourceCodeLocationProvider]
    public static class DistanceToLineSegmentTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(DistanceToLineSegmentTests))]
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
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double DistanceToSegment(double px, double py, double x1, double y1, double x2, double y2)
            => DistToSegment2(px, py, x1, y1, x2, y2);

        /// <summary>
        /// Calculate the distance between the point and the segment.
        /// </summary>
        /// <param name="px">The px.</param>
        /// <param name="py">The py.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <returns></returns>
        [DisplayName("Distance to line segment from point")]
        [Description("Calculates the distance from a point to the nearest point on a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double distance, (double, double)) DistanceToSegment1(double px, double py, double x1, double y1, double x2, double y2)
        {
            var RetNear = (X: 0d, Y: 0d);
            var Delta = (X: x2 - x1, Y: y2 - y1);
            if ((Abs(Delta.X) < DoubleEpsilon) && (Abs(Delta.Y) < DoubleEpsilon))
            {
                //  It's a point not a line segment.
                Delta.X = px - x1;
                Delta.Y = py - y1;
                RetNear.X = x1;
                RetNear.Y = y1;
                return (Sqrt((Delta.X * Delta.X) + (Delta.Y * Delta.Y)), RetNear);
            }
            //  Calculate the t that minimizes the distance.
            var t = (((px - x1) * Delta.X) + ((py - y1) * Delta.Y)) / ((Delta.X * Delta.X) + (Delta.Y * Delta.Y));
            if (t < 0)
            {
                Delta.X = px - x1;
                Delta.Y = py - y1;
                RetNear.X = x1;
                RetNear.Y = y1;
            }
            else if (t > 1)
            {
                Delta.X = px - x2;
                Delta.Y = py - y2;
                RetNear.X = x2;
                RetNear.Y = y2;
            }
            else
            {
                RetNear.X = x1 + (t * Delta.X);
                RetNear.Y = y1 + (t * Delta.Y);
                Delta.X = px - RetNear.X;
                Delta.Y = py - RetNear.Y;
            }
            return (Sqrt((Delta.X * Delta.X) + (Delta.Y * Delta.Y)), RetNear);
        }

        /// <summary>
        /// The dist to segment2.
        /// </summary>
        /// <param name="px">The px.</param>
        /// <param name="py">The py.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Distance to line segment from point")]
        [Description("Calculates the distance from a point to the nearest point on a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistToSegment2(double px, double py, double x1, double y1, double x2, double y2)
        {
            double dx;
            double dy;
            double t;
            dx = x2 - x1;
            dy = y2 - y1;
            if ((Abs(dx) < DoubleEpsilon) && (Abs(dy) < DoubleEpsilon))
            {
                //  It's a point not a line segment.
                dx = px - x1;
                dy = py - y1;
                return Sqrt((dx * dx) + (dy * dy));
            }
            t = (px + (py - (x1 - y1))) / (dx + dy);
            if (t < 0)
            {
                dx = px - x1;
                dy = py - y1;
            }
            else if (t > 1)
            {
                dx = px - x2;
                dy = py - y2;
            }
            else
            {
                var x3 = x1 + (t * dx);
                var y3 = y1 + (t * dy);
                dx = px - x3;
                dy = py - y3;
            }
            return Sqrt((dx * dx) + (dy * dy));
        }

        /// <summary>
        /// Calculate the distance between the point and the segment.
        /// </summary>
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        [DisplayName("Distance to line segment from point")]
        [Description("Calculates the distance from a point to the nearest point on a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistToSegment(double px, double py, double x1, double y1, double x2, double y2)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;
            if ((Abs(dx) < DoubleEpsilon) && (Abs(dy) < DoubleEpsilon))
            {
                //  It's a point not a line segment.
                dx = px - x1;
                dy = py - y1;
                return Sqrt((dx * dx) + (dy * dy));
            }
            var t = (px + (py - (x1 - y1))) / (dx + dy);
            if (t < 0)
            {
                dx = px - x1;
                dy = py - y1;
            }
            else if (t > 1)
            {
                dx = px - x2;
                dy = py - y2;
            }
            else
            {
                var x3 = x1 + (t * dx);
                var y3 = y1 + (t * dy);
                dx = px - x3;
                dy = py - y3;
            }
            return Sqrt((dx * dx) + (dy * dy));
        }

        /// <summary>
        /// The dist from seg.
        /// </summary>
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <exception cref="Exception">Expected line segment, not point.</exception>
        /// <acknowledgment>
        /// From: http://stackoverflow.com/questions/2255842/detecting-coincident-subset-of-two-coincident-line-segments/2255848
        /// </acknowledgment>
        [DisplayName("Distance to line segment from point")]
        [Description("Calculates the distance from a point to the nearest point on a line segment.")]
        [Acknowledgment("http://stackoverflow.com/questions/2255842/detecting-coincident-subset-of-two-coincident-line-segments/2255848")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistFromSeg(double px, double py, double x1, double y1, double x2, double y2)
        {
            (double X, double Y) p = (px, py);
            (double X, double Y) q0 = (x1, y1);
            (double X, double Y) q1 = (x2, y2);
            // formula here:
            // http://mathworld.wolfram.com/Point-LineDistance2-Dimensional.html
            // where x0,y0 = p
            //       x1,y1 = q0
            //       x2,y2 = q1
            var dx21 = q1.X - q0.X;
            var dy21 = q1.Y - q0.Y;
            var dx10 = q0.X - p.X;
            var dy10 = q0.Y - p.Y;
            var segLength = Sqrt(dx21 * dx21 + dy21 * dy21);
            if (segLength < Epsilon)
            {
                throw new Exception("Expected line segment, not point.");
            }

            var num = Abs(dx21 * dy10 - dx10 * dy21);
            var d = num / segLength;
            return d;
        }
    }
}
