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
    [DisplayName("Get the control nodes for the Quadratic Bezier for a section of the Parabola.")]
    [Description("Get the control nodes for the Quadratic Bezier for a section of the Parabola.")]
    [SourceCodeLocationProvider]
    public static class StandardParabolaToQuadraticBezierTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CircleFromThreePointsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.0125d, 150d, 100d, 25d, 200d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (25d, 3857.8125d, 112.5d, 17037.5d, 200d, 30600d), epsilon: double.Epsilon) },
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
        /// Find the Quadratic Bezier curve that represents the parabola.
        /// </summary>
        /// <param name="a">The a component of the Parabola.</param>
        /// <param name="b">The b component of the Parabola.</param>
        /// <param name="c">The c component of the Parabola.</param>
        /// <param name="x1">The first x position to crop the parabola.</param>
        /// <param name="x2">The second x position to crop the parabola.</param>
        /// <returns>Returns the control point locations of a Quadric Bezier curve.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double ax, double ay, double bx, double by, double cx, double cy) StandardParabolaToQuadraticBezier(double a, double b, double c, double x1, double x2)
            => StandardParabolaToQuadraticBezier1(a, b, c, x1, x2);

        /// <summary>
        /// Find the Quadratic Bezier curve that represents the parabola.
        /// </summary>
        /// <param name="a">The a component of the Parabola.</param>
        /// <param name="b">The b component of the Parabola.</param>
        /// <param name="c">The c component of the Parabola.</param>
        /// <param name="x1">The first x position to crop the parabola.</param>
        /// <param name="x2">The second x position to crop the parabola.</param>
        /// <returns>Returns the control point locations of a Quadric Bezier curve.</returns>
        /// <acknowledgment>
        /// https://math.stackexchange.com/a/1258196
        /// </acknowledgment>
        [DisplayName("Get the control nodes for the Quadratic Bezier for a section of the Parabola.")]
        [Description("Get the control nodes for the Quadratic Bezier for a section of the Parabola.")]
        [Acknowledgment("https://math.stackexchange.com/a/1258196")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double ax, double ay, double bx, double by, double cx, double cy) StandardParabolaToQuadraticBezier1(double a, double b, double c, double x1, double x2)
        {
            // Get the vertical components of the end points.
            var y1 = x1 * (a * x1 + b) + c;
            var y2 = x2 * (a * x2 + b) + c;
            // Find the intersection of the tangents at the end nodes to find the center node.
            var cx = (x2 - x1) / 2d + x1;
            var cy = (x2 - x1) / 2d * (2d * a * x1 + b) + y1;
            return (x1, y1, cx, cy, x2, y2);
        }

        /// <summary>
        /// Find the Quadratic Bezier curve that represents the parabola.
        /// </summary>
        /// <param name="a">The a component of the Parabola.</param>
        /// <param name="b">The b component of the Parabola.</param>
        /// <param name="c">The c component of the Parabola.</param>
        /// <param name="x1">The first x position to crop the parabola.</param>
        /// <param name="x2">The second x position to crop the parabola.</param>
        /// <returns>Returns the control point locations of a Quadric Bezier curve.</returns>
        /// <acknowledgment>
        /// https://math.stackexchange.com/a/1258196
        /// </acknowledgment>
        [DisplayName("Get the control nodes for the Quadratic Bezier for a section of the Parabola.")]
        [Description("Get the control nodes for the Quadratic Bezier for a section of the Parabola.")]
        [Acknowledgment("https://math.stackexchange.com/a/1258196")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double ax, double ay, double bx, double by, double cx, double cy) StandardParabolaToQuadraticBezier2(double a, double b, double c, double x1, double x2)
        {
            // Get the vertical components of the end points.
            var y1 = (a * x1 * x1) + (x1 * b) + c;
            var y2 = (a * x2 * x2) + (x2 * b) + c;
            // Find the intersection of the tangents at the end nodes to find the center node.
            var cx = (x2 + x1) * 0.5;
            var cy = (a * x1 * (x2 - x1)) + (b * (x2 - x1) * 0.5) + y1;
            return (x1, y1, cx, cy, x2, y2);
        }
    }
}
