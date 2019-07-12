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
    /// 
    /// </summary>
    [DisplayName("Find a general vertex Parabola from two points and k")]
    [Description("Find a general vertex Parabola from two points and k.")]
    [SourceCodeLocationProvider]
    public static class FindVertexParabolaFromTwoPointsAndKTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(FindVertexParabolaFromTwoPointsAndKTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 4.34d, 8d, 6d, 0d, 10d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (-7.600621247640862d, 4.852968210662413d, 10d), epsilon: double.Epsilon) },
                { new object[] { 2d, 10d, 8d, 10d, 8d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.2222222222222222d, 5d, 8d), epsilon: double.Epsilon) },
                { new object[] { 2d, 10d, 8d, 12d, 8d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.3238015069303441d, 4.4852813742385695d, 8d), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double a, double h, double k) FindVertexParabolaFromTwoPointsAndK(double x1, double y1, double x2, double y2, double k)
            => FindVertexParabolaFromTwoPointsAndK1(x1, y1, x2, y2, k);

        /// <summary>
        /// Find the parabola that passes through two points and has a k vertex height.
        /// </summary>
        /// <param name="x1">The x component of the first point on the parabola.</param>
        /// <param name="y1">The y component of the first point on the parabola.</param>
        /// <param name="x2">The x component of the second point on the parabola.</param>
        /// <param name="y2">The y component of the second point on the parabola.</param>
        /// <param name="k">The k or vertex height of the parabola.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK
        /// </acknowledgment>
        [DisplayName("Find a general vertex Parabola from two points and k")]
        [Description("Find a general vertex Parabola from two points and k.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double h, double k) FindVertexParabolaFromTwoPointsAndK1(double x1, double y1, double x2, double y2, double k)
        {
            var h = FindParabolaHFromTwoPointsAndKTests.FindParabolaHFromTwoPointsAndK(x1, y1, x2, y2, k);
            var hv = (h.a > x1 && h.a < x2) ? h.a : h.b;
            var a = FindParabolaAFromAPointAndVertexTests.FindParabolaAFromAPointAndVertex(x1, y1, hv, k);
            return (a, hv, k);
        }

        /// <summary>
        /// Find the parabola that passes through two points and has a k vertex height.
        /// </summary>
        /// <param name="x1">The x component of the first point on the parabola.</param>
        /// <param name="y1">The y component of the first point on the parabola.</param>
        /// <param name="x2">The x component of the second point on the parabola.</param>
        /// <param name="y2">The y component of the second point on the parabola.</param>
        /// <param name="k">The k or vertex height of the parabola.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK
        /// </acknowledgment>
        [DisplayName("Find a general vertex Parabola from two points and k")]
        [Description("Find a general vertex Parabola from two points and k.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double h, double k) FindVertexParabolaFromTwoPointsAndK2(double x1, double y1, double x2, double y2, double k)
        {
            var h = FindParabolaHFromTwoPointsAndKTests.FindParabolaHFromTwoPointsAndK(x1, y1, x2, y2, k);
            var hv = (h.a > x1 && h.a < x2) ? h.a : h.b;
            var a = x1 - hv is 0d ? 0d : (y1 - k) / ((x1 - hv) * (x1 - hv));
            return (a, hv, k);
        }

        /// <summary>
        /// Find the parabola that passes through two points and has a k vertex height.
        /// </summary>
        /// <param name="x1">The x component of the first point on the parabola.</param>
        /// <param name="y1">The y component of the first point on the parabola.</param>
        /// <param name="x2">The x component of the second point on the parabola.</param>
        /// <param name="y2">The y component of the second point on the parabola.</param>
        /// <param name="k">The k or vertex height of the parabola.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK
        /// </acknowledgment>
        [DisplayName("Find a general vertex Parabola from two points and k")]
        [Description("Find a general vertex Parabola from two points and k.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double h, double k) FindVertexParabolaFromTwoPointsAndK3(double x1, double y1, double x2, double y2, double k)
        {
            var a = 1d - (y2 - k) / (y1 - k);
            var b = -2d * x2 + (2d * x1 * ((y2 - k) / (y1 - k)));
            var c = x2 * x2​ - (x1 * x1 * ((y2 - k) / (y1 - k)));
            double h;

            // Find the roots.
            if (a is 0d)
            {
                // If a is zero, reduce to linear, if b is also zero reduce to constant.
                h = b is 0d ? c : -c / b;
            }
            else
            {
                var b_ = b / a;
                var c_ = c / a;
                var discriminant = (b_ * b_) - (4d * c_);

                if (discriminant is 0d)
                {
                    h = OneHalf * -b_;
                }
                else if (discriminant > 0d)
                {
                    var e = Sqrt(discriminant);
                    var hv = (a: OneHalf * (-b_ + e), b: OneHalf * (-b_ - e));
                    h = (hv.a > x1 && hv.a < x2) ? hv.a : hv.b;
                }
                else
                {
                    // ToDo: Not sure exactly what to do here.
                    // Imaginary number.
                    var e = Sqrt(Abs(discriminant));
                    var hv = (a: OneHalf * (-b_ + e), b: OneHalf * (-b_ - e));
                    h = (hv.a > x1 && hv.a < x2) ? hv.a : hv.b;
                    //h = double.NaN;
                }
            }

            a = x1 - h is 0d ? 0d : (y1 - k) / ((x1 - h) * (x1 - h));
            return (a, h, k);
        }

        /// <summary>
        /// Find the parabola that passes through two points and has a k vertex height.
        /// </summary>
        /// <param name="x1">The x component of the first point on the parabola.</param>
        /// <param name="y1">The y component of the first point on the parabola.</param>
        /// <param name="x2">The x component of the second point on the parabola.</param>
        /// <param name="y2">The y component of the second point on the parabola.</param>
        /// <param name="k">The k or vertex height of the parabola.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK
        /// </acknowledgment>
        [DisplayName("Find a general vertex Parabola from two points and k")]
        [Description("Find a general vertex Parabola from two points and k.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double h, double k) FindVertexParabolaFromTwoPointsAndK4(double x1, double y1, double x2, double y2, double k)
        {
            var a = 1d - (y2 - k) / (y1 - k);
            var b = -2d * x2 + (2d * x1 * ((y2 - k) / (y1 - k)));
            var c = x2 * x2​ - (x1 * x1 * ((y2 - k) / (y1 - k)));
            double h;

            // Find the roots.
            switch (a)
            {
                case 0d:
                    // If a is zero, reduce to linear, if b is also zero reduce to constant.
                    h = b is 0d ? c : -c / b;
                    break;
                default:
                    {
                        var b_ = b / a;
                        var c_ = c / a;

                        switch ((b_ * b_) - (4d * c_))
                        {
                            case 0d:
                                h = OneHalf * -b_;
                                break;
                            case double d when d > 0d:
                                {
                                    var e = Sqrt(d);
                                    var hv = (a: OneHalf * (-b_ + e), b: OneHalf * (-b_ - e));
                                    h = (hv.a > x1 && hv.a < x2) ? hv.a : hv.b;
                                }
                                break;
                            case double d when d < 0d:
                                {
                                    // ToDo: Not sure exactly what to do here.
                                    // Imaginary number.
                                    var e = Sqrt(Abs(d));
                                    var hv = (a: OneHalf * (-b_ + e), b: OneHalf * (-b_ - e));
                                    h = (hv.a > x1 && hv.a < x2) ? hv.a : hv.b;
                                }
                                break;
                            default:
                                h = 0d;
                                break;
                        }
                        break;
                    }
            }

            a = x1 - h is 0d ? 0d : (y1 - k) / ((x1 - h) * (x1 - h));
            return (a, h, k);
        }

        /// <summary>
        /// Find the parabola that passes through two points and has a k vertex height.
        /// </summary>
        /// <param name="x1">The x component of the first point on the parabola.</param>
        /// <param name="y1">The y component of the first point on the parabola.</param>
        /// <param name="x2">The x component of the second point on the parabola.</param>
        /// <param name="y2">The y component of the second point on the parabola.</param>
        /// <param name="k">The k or vertex height of the parabola.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK
        /// </acknowledgment>
        [DisplayName("Find a general vertex Parabola from two points and k")]
        [Description("Find a general vertex Parabola from two points and k.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double h, double k) FindVertexParabolaFromTwoPointsAndK5(double x1, double y1, double x2, double y2, double k)
        {
            var h = FindParabolaHFromTwoPointsAndKTests.FindParabolaHFromTwoPointsAndK(x1, y1, x2, y2, k);
            var hv = (h.a > x1 && h.a < x2) ? h.a : h.b;
            return FindVertexParabolaFromThreePointsTests.FindVertexParabolaFromThreePoints(x1, y1, hv, k, x2, y2);
        }
    }
}
