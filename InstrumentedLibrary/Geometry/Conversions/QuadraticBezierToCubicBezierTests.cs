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
    /// The quadratic Bézier to cubic Bézier tests class.
    /// </summary>
    [DisplayName("Quadratic Bézier to Cubic Bézier Tests")]
    [Description("Convert a Quadratic Bézier to a Cubic Bézier.")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierToCubicBezierTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierToCubicBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 1d, 1.3333333333333333d, 2.333333333333333d, 2.666666666666667d, 3.666666666666667d, 4d, 5d), epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) QuadraticBezierToCubicBezier(double aX, double aY, double bX, double bY, double cX, double cY)
            => QuadraticBezierToCubicBezierTuple(aX, aY, bX, bY, cX, cY);

        /// <summary>
        /// Raise a Quadratic Bézier to a Cubic Bézier.
        /// </summary>
        /// <param name="aX">The x-component of the starting point.</param>
        /// <param name="aY">The y-component of the starting point.</param>
        /// <param name="bX">The x-component of the handle.</param>
        /// <param name="bY">The y-component of the handle.</param>
        /// <param name="cX">The x-component of the end point.</param>
        /// <param name="cY">The y-component of the end point.</param>
        /// <returns>Returns Quadratic Bézier curve from a cubic curve.</returns>
        [DisplayName("Quadratic Bézier to Cubic Bézier Tests")]
        [Description("Raise a Quadratic Bézier to a Cubic Bézier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) QuadraticBezierToCubicBezierTuple(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
        {
            return (aX, aY,
                    aX + TwoThirds * (bX - aX), aY + TwoThirds * (bY - aY),
                    cX + TwoThirds * (bX - cX), cY + TwoThirds * (bY - cY),
                    cX, cY);
        }

        /// <summary>
        /// Raise a Quadratic Bezier to a Cubic Bezier.
        /// </summary>
        /// <param name="aX">The x-component of the starting point.</param>
        /// <param name="aY">The y-component of the starting point.</param>
        /// <param name="bX">The x-component of the handle.</param>
        /// <param name="bY">The y-component of the handle.</param>
        /// <param name="cX">The x-component of the end point.</param>
        /// <param name="cY">The y-component of the end point.</param>
        /// <returns>Returns Quadratic Bézier curve from a cubic curve.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] QuadraticBezierToCubicBezierArray(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
            => new (double X, double Y)[]
            {
                (aX, aY),
                (aX + (TwoThirds * (bX - aX)), aY + (TwoThirds * (bY - aY))),
                (cX + (TwoThirds * (bX - cX)), cY + (TwoThirds * (bY - cY))),
                (cX, cY)
            };

        /// <summary>
        /// Converts a Quadratic Bezier to a Cubic Bezier.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <param name="c">The third point.</param>
        /// <returns>Returns a Cubic Bezier from a Quadratic Bezier.</returns>
        /// <acknowledgment>
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D[] QuadraticBezierToCubicBezierList(
            Point2D a,
            Point2D b,
            Point2D c)
            => new Point2D[]
            {
                a,
                new Point2D(a.X + (TwoThirds * (b.X - a.X)), a.Y + (TwoThirds * (b.Y - a.Y))),
                new Point2D(c.X + (TwoThirds * (b.X - c.X)), c.Y + (TwoThirds * (b.Y - c.Y))),
                c
            };

        /// <summary>
        /// Raises a <see cref="QuadraticBezier2D"/> to a <see cref="CubicBezier2D"/>.
        /// </summary>
        /// <param name="a">The starting point of the Quadratic Bézier curve.</param>
        /// <param name="b">The handle of the Quadratic Bézier curve.</param>
        /// <param name="c">The end point of the Quadratic Bézier curve.</param>
        /// <returns>Returns a Cubic Bézier curve from the Quadratic Bézier curve.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CubicBezier2D QuadraticBezierToCubicBezierPoint2D(
            Point2D a,
            Point2D b,
            Point2D c)
            => new CubicBezier2D(
                a.X, a.Y,
                a.X + (TwoThirds * (b.X - a.X)), a.Y + (TwoThirds * (b.Y - a.Y)),
                c.X + (TwoThirds * (b.X - c.X)), c.Y + (TwoThirds * (b.Y - c.Y)),
                c.X, c.Y
            );
    }
}
