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
    /// 
    /// </summary>
    [DisplayName("Find Parabola h from two points and a vertex")]
    [Description("Find Parabola h from two points and a vertex.")]
    [SourceCodeLocationProvider]
    public static class FindParabolaHFromTwoPointsAndKTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(FindParabolaHFromTwoPointsAndKTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 4.34d, 8d, 6d, 0d, 10d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (4.852968210662413d, 2.9970317893375875d), epsilon: double.Epsilon) },
                { new object[] { 2d, 10d, 8d, 10d, 8d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (5d, 5d), epsilon: double.Epsilon) },
                { new object[] { 2d, 10d, 8d, 12d, 8d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (4.4852813742385695d, -12.48528137423857d), epsilon: double.Epsilon) },
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
        public static (double a, double b) FindParabolaHFromTwoPointsAndK(double x1, double y1, double x2, double y2, double k)
            => FindParabolaHFromTwoPointsAndK3(x1, y1, x2, y2, k);

        /// <summary>
        /// Find the h of a parabola given two points on the parabola and the k vertex height.
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
        [DisplayName("Find Parabola h from two points and a vertex")]
        [Description("Find Parabola h from two points and a vertex.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b) FindParabolaHFromTwoPointsAndK1(double x1, double y1, double x2, double y2, double k)
        {
            var a = 1d - (y2 - k) / (y1 - k);
            var b = -2d * x2 + (2d * x1 * ((y2 - k) / (y1 - k)));
            var c = x2 * x2​ - (x1 * x1 * ((y2 - k) / (y1 - k)));
            var r = QuadraticRootsTests.QuadraticRoots(a, b, c);
            return (r[0], r.Count > 1 ? r[1] : r[0]);
        }

        /// <summary>
        /// Find the h of a parabola given two points on the parabola and the k vertex height.
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
        [DisplayName("Find Parabola h from two points and a vertex")]
        [Description("Find Parabola h from two points and a vertex.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b) FindParabolaHFromTwoPointsAndK2(double x1, double y1, double x2, double y2, double k)
        {
            var a = 1d - (y2 - k) / (y1 - k);
            var b = -2d * x2 + (2d * x1 * ((y2 - k) / (y1 - k)));
            var c = x2 * x2​ - (x1 * x1 * ((y2 - k) / (y1 - k)));
            if (a is 0d || (Abs(a) <= double.Epsilon))
            {
                if (b is 0d || (Abs(b) <= double.Epsilon))
                {
                    return (c, c);
                }
                else
                {
                    return (-c / b, -c / b);
                }
            }
            else
            {
                var b_ = b / a;
                var c_ = c / a;
                var discriminant = (b_ * b_) - (4d * c_);
                if (Abs(discriminant) <= double.Epsilon)
                {
                    discriminant = 0d;
                }

                if (discriminant > 0d)
                {
                    var e = Sqrt(discriminant);
                    return (OneHalf * (-b_ + e), OneHalf * (-b_ - e));
                }
                else if (discriminant == 0)
                {
                    return (OneHalf * -b_, OneHalf * -b_);
                }
                else
                {
                    // Imaginary number.
                    return (double.NaN, double.NaN);
                }
            }
        }

        /// <summary>
        /// Find the h of a parabola given two points on the parabola and the k vertex height.
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
        [DisplayName("Find Parabola h from two points and a vertex")]
        [Description("Find Parabola h from two points and a vertex.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b) FindParabolaHFromTwoPointsAndK3(double x1, double y1, double x2, double y2, double k)
        {
            var a = 1d - (y2 - k) / (y1 - k);
            var b = -2d * x2 + (2d * x1 * ((y2 - k) / (y1 - k)));
            var c = x2 * x2​ - (x1 * x1 * ((y2 - k) / (y1 - k)));

            // Find the roots.
            if (a is 0d)
            {
                // If a is zero, reduce to linear, if b is also zero reduce to constant.
                return b is 0d ? (c, c) : (-c / b, -c / b);
            }
            else
            {
                var b_ = b / a;
                var c_ = c / a;
                var discriminant = (b_ * b_) - (4d * c_);

                if (discriminant == 0)
                {
                    return (OneHalf * -b_, OneHalf * -b_);
                }
                else if (discriminant > 0d)
                {
                    var e = Sqrt(discriminant);
                    return (OneHalf * (-b_ + e), OneHalf * (-b_ - e));
                }
                else
                {
                    // ToDo: Not sure exactly what to do here.
                    // Imaginary number.
                    var e = Sqrt(Abs(discriminant));
                    return (OneHalf * (-b_ + e), OneHalf * (-b_ - e));
                    //return (double.NaN, double.NaN);
                }
            }
        }
    }
}
