using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The angle tests class.
    /// </summary>
    [DisplayName("2D Angle Tests")]
    [Description("Returns the Angle of a line that runs between two points.")]
    [SourceCodeLocationProvider]
    public static class Angle2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle of Two 2D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(Angle2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 100000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d }, new TestCaseResults(description:"0d, 0d, 1d, 1d.", trials:trials, expectedReturnValue:-2.3561944901923448d, epsilon:double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Angle2D(double x1, double y1, double x2, double y2)
            => Angle2D0(x1, y1, x2, y2);

        /// <summary>
        /// Returns the Angle of a line.
        /// </summary>
        /// <param name="x1">Horizontal Component of Point Starting Point</param>
        /// <param name="y1">Vertical Component of Point Starting Point</param>
        /// <param name="x2">Horizontal Component of Ending Point</param>
        /// <param name="y2">Vertical Component of Ending Point</param>
        /// <returns>Returns <see cref="double"/> representing the Angle of a line.</returns>
        [DisplayName("Angle from two points using Atan2")]
        [Description("This is the most common method of finding the angle of a line that runs between two points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle2D0(
            double x1, double y1,
            double x2, double y2)
        {
            return /*PI +*/ Atan2(y1 - y2, x1 - x2);
        }

        /// <summary>
        /// Return the angle between two vectors on a plane
        /// The angle is from vector 1 to vector 2, positive anticlockwise
        /// The result is between -pi -> pi
        /// </summary>
        /// <param name="x1">Horizontal Component of Point Starting Point</param>
        /// <param name="y1">Vertical Component of Point Starting Point</param>
        /// <param name="x2">Horizontal Component of Ending Point</param>
        /// <param name="y2">Vertical Component of Ending Point</param>
        /// <returns>Returns <see cref="double"/> representing the Angle of a line.</returns>
        [DisplayName("Angle from two points")]
        [Description("Philippe Reverdy Angle from two points method.")]
        [Acknowledgment("http://paulbourke.net/geometry/polygonmesh/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle2DPhilippeReverdy(
            double x1, double y1,
            double x2, double y2)
        {
            var theta1 = Atan2(y1, x1);
            var theta2 = Atan2(y2, x2);
            var dtheta = /*-PI +*/ theta2 - theta1;

            while (dtheta > PI)
            {
                dtheta -= PI * 2d;
            }

            while (dtheta < -PI)
            {
                dtheta += PI * 2d;
            }

            return dtheta;
        }

        /// <summary>
        /// Return the angle between two vectors on a plane
        /// The angle is from vector 1 to vector 2, positive anticlockwise
        /// The result is between -pi -> pi
        /// </summary>
        /// <param name="x1">Horizontal Component of Point Starting Point</param>
        /// <param name="y1">Vertical Component of Point Starting Point</param>
        /// <param name="x2">Horizontal Component of Ending Point</param>
        /// <param name="y2">Vertical Component of Ending Point</param>
        /// <returns>Returns <see cref="double"/> representing the Angle of a line.</returns>
        [DisplayName("Angle from two points")]
        [Description("Angle from two points mashup method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle2DMashup(
            double x1, double y1,
            double x2, double y2)
        {
            var dtheta = /*-PI +*/ Atan2(y2, x2) - Atan2(y1, x1);
            return (dtheta < -PI) ? dtheta + Tau : (dtheta > PI) ? dtheta - Tau : dtheta;
        }

        /// <summary>
        /// Returns the Angle of a line.
        /// </summary>
        /// <param name="x1">Horizontal Component of Point Starting Point</param>
        /// <param name="y1">Vertical Component of Point Starting Point</param>
        /// <param name="x2">Horizontal Component of Ending Point</param>
        /// <param name="y2">Vertical Component of Ending Point</param>
        /// <returns>Returns <see cref="double"/> representing the Angle of a line.</returns>
        [DisplayName("Angle from two points using Atan2")]
        [Description("This is the most common method of finding the angle of a line that runs between two points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle2DMashup2(
            double x1, double y1,
            double x2, double y2)
        {
            var value = /*PI +*/ Atan2(y1 - y2, x1 - x2);
            return (value < -PI) ? value + Tau : (value > PI) ? value - Tau : value;
        }
    }
}
