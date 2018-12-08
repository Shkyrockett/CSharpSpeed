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
    [Signature("public static Inclusion PointInEllipse(double x, double y, double rX, double rY, double angle, double pX, double pY)")]
    [SourceCodeLocationProvider]
    public static class EllipseContainsPointTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(EllipseContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 0d, 0.5d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon:DoubleEpsilon) },
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
        /// Checks whether a point is found within the boundaries of an ellipse.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="angle"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
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
        public static Inclusion PointInEllipse(double x, double y, double rX, double rY, double angle, double pX, double pY)
        {
            if (rX <= 0d || rY <= 0d)
            {
                return Inclusion.Outside;
            }

            var cosT = Cos(-angle);
            var sinT = Sin(-angle);

            var u = pX - x;
            var v = pY - y;

            var a = (cosT * u + sinT * v) * (cosT * u + sinT * v);
            var b = (sinT * u - cosT * v) * (sinT * u - cosT * v);

            var d1Squared = 4 * rX * rX;
            var d2Squared = 4 * rY * rY;

            var normalizedRadius = (a / d1Squared) + (b / d2Squared);

            return (normalizedRadius <= 1d) ? ((Abs(normalizedRadius - 1d) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
    }
}
