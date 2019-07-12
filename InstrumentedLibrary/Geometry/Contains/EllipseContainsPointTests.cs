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
    /// The point in ellipse tests class.
    /// </summary>
    [DisplayName("Point In Ellipse Tests")]
    [Description("Determines whether a point is in an Ellipse.")]
    [SourceCodeLocationProvider]
    public static class EllipseContainsPointTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(EllipseContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 0d, 0.5d, 0.5d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: Inclusions.Inside, epsilon: double.Epsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="angle"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Inclusions EllipseContainsPoint(double x, double y, double rX, double rY, double angle, double pX, double pY, double epsilon = Epsilon)
            => PointInEllipse0(x, y, rX, rY, angle, pX, pY, epsilon);

        /// <summary>
        /// Checks whether a point is found within the boundaries of an ellipse.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="angle"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm
        /// </acknowledgment>
        [DisplayName("Point In Ellipse Tests")]
        [Description("Determines whether a point is in an Ellipse.")]
        [Acknowledgment("http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusions PointInEllipse0(double x, double y, double rX, double rY, double angle, double pX, double pY, double epsilon = Epsilon)
        {
            if (rX <= 0d || rY <= 0d)
            {
                return Inclusions.Outside;
            }

            var cosT = Cos(-angle);
            var sinT = Sin(-angle);

            var u = pX - x;
            var v = pY - y;

            var a = (cosT * u + sinT * v) * (cosT * u + sinT * v);
            var b = (sinT * u - cosT * v) * (sinT * u - cosT * v);

            var d1Squared = 4d * rX * rX;
            var d2Squared = 4d * rY * rY;

            var normalizedRadius = (a / d1Squared) + (b / d2Squared);

            return (normalizedRadius <= 1d) ? ((Abs(normalizedRadius - 1d) < epsilon) ? Inclusions.Boundary : Inclusions.Inside) : Inclusions.Outside;
        }
    }
}
