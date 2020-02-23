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
    /// The ellipse perimeter length tests class.
    /// </summary>
    [DisplayName("Ellipse Perimeter Length Tests")]
    [Description("Estimations on the length of the Perimeter of an ellipse.")]
    [SourceCodeLocationProvider]
    public static class EllipsePerimeterLengthTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(EllipsePerimeterLengthTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d }, new TestCaseResults(description: "Circle test case.", trials: trials, expectedReturnValue:Tau, epsilon: double.Epsilon) },
                { new object[] { 1d, 2d }, new TestCaseResults(description: "One to two test case.", trials: trials, expectedReturnValue:9.6884482205476754d, epsilon: double.Epsilon) },
                { new object[] { 1d, 3d }, new TestCaseResults(description: "One to three test case.", trials: trials, expectedReturnValue:13.364893220555258d, epsilon: double.Epsilon) },
                { new object[] { 2d, 4d }, new TestCaseResults(description: "Two to four test case.", trials: trials, expectedReturnValue:19.376896441095351d, epsilon: double.Epsilon) },
                { new object[] { 0d, 4d }, new TestCaseResults(description: "Zero height, or double sided line segment test case.", trials: trials, expectedReturnValue:16d, epsilon: double.Epsilon) },
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double EllipsePerimeterLength(double a, double b)
            => EllipsePerimeter1(a, b);

        /// <summary>
        /// AGM algorithm contributed by Charles Karney and based upon Carlson, B. C. (1995). 
        /// "Computation of real or complex elliptic integrals". Numerical Algorithms 10. 
        /// This algorithm converses quadratically, that is, the number of correct digits 
        /// doubles on each iteration so the fastest converging series.
        /// The series was first proposed by James Ivory, A new series for the rectification 
        /// of the ellipsis, Trans. Roy. Soc. Edinburgh 4, 177-190 (1798). 
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.paulbourke.net/geometry/ellipsecirc/
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 1")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.paulbourke.net/geometry/ellipsecirc/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ExactEllipsePerimeter1(double a, double b)
        {
            // If a or b are 0 then the ellipse is a set of two line segments.
            if (a == 0 || b == 0)
            {
                return a > b ? a * 4d : b * 4d;
            }

            var tol = DoubleEpsilon;// Pow(0.5d, 27d);
            var s = 0d;
            var m = 1d;
            var x = a > b ? a : b;
            var y = a < b ? a : b;
            while (x - y > tol * y)
            {
                var t = (x + y) / 2d;
                y = Sqrt(x * y);
                x = t;
                m *= 2d;
                s += m * (x - y) * (x - y);
            }

            return PI * (((a + b) * (a + b)) - s) / (x + y);
        }

        /// <summary>
        /// This approximation is within about 5% of the true value, so long as a is not more than 3 times longer than b (in other words, the ellipse is not too "squashed"):
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 1")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeter1(double a, double b)
        {
            return 2d * PI * Sqrt(0.5d * ((b * b) + (a * a)));
        }

        /// <summary>
        /// The ellipse perimeter2.
        /// </summary>
        /// <param name="a">todo: describe a parameter on EllipsePerimeter2</param>
        /// <param name="b">todo: describe b parameter on EllipsePerimeter2</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://ellipse-circumference.blogspot.com/
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 2")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://ellipse-circumference.blogspot.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeter2(double a, double b)
        {
            var h = (b - a) * (b - a) / ((b + a) * (b + a));
            var H2 = 4d - (3d * h);
            var d = (11d * PI / (44d - (14d * PI))) + 24100d - (24100d * h);
            return PI * (b + a) * (1d + (3d * h / (10d + Sqrt(H2))) + (((1.5d * Pow(h, 6)) - (0.5d * Pow(h, 12d))) / d));
        }

        /// <summary>
        /// The ellipse perimeter2 3Jacobsen waadeland.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 17")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeter23JacobsenWaadeland(double a, double b)
        {
            const double d1 = (PI / 4d * (61d / 48d)) - 1d;
            const double d2 = (PI / 4d * (187d / 147d)) - 1d;
            const double p = d1 / (d1 - d2);
            const double h = 1d;
            return PI * (a + b) * ((p * ((3072d - (1280d * h) - (252d * h * h) + (33d * h * h * h)) / (3072d - (2048d * h) + (212d * h * h)))) + ((1d - p) * ((256d - (48d * h) - (21d * h * h)) / (256d - (112d * h) + (3d * h * h)))));
        }

        /// <summary>
        /// The ellipse perimeter3 3 3 2.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 18")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeter3332(double a, double b)
        {
            const double d1 = (PI / 4d * (61d / 48d)) - 1d;
            const double d2 = (PI / 4d * (187d / 147d)) - 1d;
            const double p = d1 / (d1 - d2);
            const double h = 1d;
            return PI * (a + b) * ((p * ((135168d - (85760d * h) - (5568d * h * h) + (3867d * h * h * h)) / (135168d - (119552d * h) + (22208d * h * h) - (345d * h * h * h)))) + ((1d - p) * ((3072d - (1280d * h) - (252d * h * h) + (33d * h * h * h)) / (3072d - (2048d * h) + (212d * h * h)))));
        }

        /// <summary>
        /// The ellipse perimeter ahmadi2006.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox06.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 47")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterAhmadi2006(double a, double b)
        {
            const double c1 = PI - 3d;
            const double c2 = PI;
            const double c3 = 0.5d;
            const double c4 = (PI + 1d) / 2d;
            const double c5 = 4d;
            var k = 1d - (c1 * a * b / ((a * a) + (b * b) + (c2 * Sqrt((c3 * a * b * a * b) + (a * b * Sqrt(a * b * ((c4 * ((a * a) + (b * b))) + (c5 * a * b))))))));
            return 4d * (((PI * a * b) + (k * (a - b) * (a - b))) / (a + b));
        }

        /// <summary>
        /// The ellipse perimeter almkvist.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 8")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterAlmkvist(double a, double b)
        {
            return 2d * PI
                * (((2d * Pow(a + b, 2d)) - Pow(Sqrt(a) - Sqrt(b), 4d))
                / (Pow(Sqrt(a) - Sqrt(b), 2d) + (2d * Sqrt(2d * (a + b)) * Pow(a * b, 1d / 4d))));
        }

        /// <summary>
        /// The ellipse perimeter bartolomeu.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 37")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterBartolomeu(double a, double b)
        {
            var t = PI / 4d * ((a - b) / b);
            return PI * Sqrt(2d * ((a * a) + (b * b))) * (Sin(t) / t);
        }

        /// <summary>
        /// The ellipse perimeter bartolomeu michon.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 33")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterBartolomeuMichon(double a, double b)
        {
            return Abs(a - b) < DoubleEpsilon ? 2d * PI * a : PI * ((a - b) / Atan((a - b) / (a + b)));
        }

        /// <summary>
        /// The ellipse perimeter bessel.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Ellipse Perimeter Length Bessel")]
        [Description("Find the length of the Perimeter of an ellipse using the Bessel formula.")]
        [Acknowledgment("http://www.paulbourke.net/geometry/ellipsecirc/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterBessel(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            var n = 10;

            var len = 1d;
            double sum;
            for (var i = 1; i < n; i++)
            {
                sum = 1d;
                for (var j = i; j > 0; j--)
                {
                    if (j > 1)
                    {
                        sum *= (2d * (j - 1)) - 1;
                    }
                    sum /= 2d * j;
                }
                len += Pow(h, i) * sum * sum;
            }
            len *= PI * (a + b);

            return len;
        }

        /// <summary>
        /// The ellipse perimeter cantrell.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 40")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCantrell(double a, double b)
        {
            var s = Log(2d) / Log(2d / (4d - PI));
            return (4d * (a + b)) - (2d * (4d - PI) * a * b / Pow(Pow(a, s) + Pow(b, s), 1d / s));
        }

        /// <summary>
        /// The ellipse perimeter cantrell2.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 34")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCantrell2(double a, double b)
        {
            const double p = 0.410117d;
            const double w = 74d;
            return (4d * (a + b)) - ((8d - (2d * PI)) * a * b / ((p * (a + b)) + ((1d - (2d * p)) * (Sqrt((a + (w * b)) * ((w * a) + b)) / (1d + w)))));
        }

        /// <summary>
        /// The ellipse perimeter cantrell2006.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox06.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 46")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCantrell2006(double a, double b)
        {
            const double p = 3.982901d;
            const double q = 66.71674d;
            const double s = 18.31287d;
            const double t = 23.39728d;
            const double r = 4d * (((4d - PI) * ((4d * s) + t + 16d)) - ((4d * p) + q));
            return (4d * (a + b))
                - (a * b / (a + b)
                * (((p * (a + b) * (a + b)) + (q * a * b) + (r * (a * b / (a + b)) * (a * b / (a + b))))
                / (((a + b) * (a + b)) + (s * a * b) + (t * (a * b / (a + b)) * (a * b / (a + b))))));
        }

        /// <summary>
        /// The ellipse perimeter cantrell ramanujan.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 42")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCantrellRamanujan(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * (1d + (3d * h / (10d + Sqrt(4d - (3d * h)))) + (((4d / PI) - (14d / 11d)) * Pow(h, 12d)));
        }

        /// <summary>
        /// The ellipse perimeter combined padé.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html
        /// http://www.numericana.com/answer/ellipse.htm#elliptic
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 14")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html", "http://www.numericana.com/answer/ellipse.htm#elliptic")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCombinedPadé(double a, double b)
        {
            const double d1 = (PI / 4d * (19d / 15d)) - 1d;
            const double d2 = (PI / 4d * (80d / 63d)) - 1d;
            const double p = d1 / (d1 - d2);
            const double h = 1d;
            return PI * (a + b) * ((p * ((64d + (16d * h)) / (64d - (h * h)))) + ((1d - p) * ((16d + (3d * h)) / (16d - h))));
        }

        /// <summary>
        /// Not correct.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 25")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCombinedPadéHudsonLipkaMichon(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((64d + (3d * h * h)) / (64d - (16d * h)));
        }

        /// <summary>
        /// The ellipse perimeter euler.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 7")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterEuler(double a, double b)
        {
            return 2d * PI * Sqrt(((a * a) + (b * b)) / 2d);
        }

        /// <summary>
        /// The ellipse perimeter jacobsen waadeland hudson lipka.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 16")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterJacobsenWaadelandHudsonLipka(double a, double b)
        {
            const double d1 = (PI / 4d * (61d / 48d)) - 1d;
            const double d2 = (PI / 4d * (187d / 147d)) - 1d;
            const double p = d1 / (d1 - d2);
            const double h = 1d;
            return PI * (a + b) * ((p * ((256d - (48d * h) - (21d * h * h)) / (256d - (112d * h) + (3d * h * h)))) + ((1d - p) * ((64d - (3d * h * h)) / (64d - (16d * h)))));
        }

        /// <summary>
        /// The ellipse perimeter k13.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 43")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterK13(double a, double b)
        {
            return PI * (((a + b) / 2d) + Sqrt(((a * a) + (b * b)) / 2d));
        }

        /// <summary>
        /// The ellipse perimeter kepler.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 3")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterKepler(double a, double b)
        {
            return 2d * PI * Sqrt(a * b);
        }

        /// <summary>
        /// The ellipse perimeter lindner.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 11")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterLindner(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * Sqrt(1d + (h / 8d));
        }

        /// <summary>
        /// The ellipse perimeter lockwood.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 36")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterLockwood(double a, double b)
        {
            return 4d * ((b * b / a * Atan(a / b)) + (a * a / b * Atan(b / a)));
        }

        /// <summary>
        /// The ellipse perimeter muir.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 10")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterMuir(double a, double b)
        {
            return 2d * PI * Pow((Pow(a, 3d / 2d) + Pow(b, 3d / 2d)) / 2d, 2d / 3d);
        }

        /// <summary>
        /// The ellipse perimeter naive.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 5")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterNaive(double a, double b)
        {
            return PI * (a + b);
        }

        /// <summary>
        /// The ellipse perimeter optimized peano.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 29")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterOptimizedPeano(double a, double b)
        {
            const double p = 1.32d;
            return 2d * PI * ((p * ((a + b) / 2d)) + ((1d - p) * Sqrt(a * b)));
        }

        /// <summary>
        /// The ellipse perimeter optimized quadratic1.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 30")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterOptimizedQuadratic1(double a, double b)
        {
            const double w = 0.7966106d;
            return 2d * PI * Sqrt((w * (((a * a) + (b * b)) / 2d)) + ((1d - w) * a * b));
        }

        /// <summary>
        /// The ellipse perimeter optimized quadratic2.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 31")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterOptimizedQuadratic2(double a, double b)
        {
            return PI * Sqrt((2d * ((a * a) + (b * b))) + ((a - b) * (a - b) / 2.458338d));
        }

        /// <summary>
        /// The ellipse perimeter optimized ramanujan1.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 32")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterOptimizedRamanujan1(double a, double b)
        {
            const double p = 3.0273d;
            const double w = 3d;
            return 2d * PI * ((p * ((a + b) / 2d)) + ((1d - p) * Sqrt((a + (w * b)) * ((w * a) + b)) / (1d + w)));
        }

        /// <summary>
        /// The ellipse perimeter padé3 2.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 27")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadé32(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((3072d - (1280d * h) - (252d * h * h) + (33d * h * h * h)) / (3072d - (2048d * h) + (212d * h * h)));
        }

        /// <summary>
        /// The ellipse perimeter padé3 3.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 28")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadé33(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b)
                * ((135168d - (85760d * h) - (5568d * h * h) + (3867d * h * h * h))
                / (135168d - (119552d * h) + (22208d * h * h) - (345d * h * h * h)));
        }

        /// <summary>
        /// The ellipse perimeter padéhudson lipka bronshtein.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 24")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadéHudsonLipkaBronshtein(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((64d + (3d * h * h)) / (64d - (16d * h)));
        }

        /// <summary>
        /// The ellipse perimeter padéjacobsen waadeland.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 26")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadéJacobsenWaadeland(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((256d - (48d * h) - (21d * h * h)) / (256d - (112d * h) + (3d * h * h)));
        }

        /// <summary>
        /// The ellipse perimeter padémichon.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 23")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadéMichon(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((64d + (16d * h)) / (64d - (h * h)));
        }

        /// <summary>
        /// The ellipse perimeter padéselmer.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 22")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadéSelmer(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((16d + (3d * h)) / (16d - h));
        }

        /// <summary>
        /// The ellipse perimeter peano.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 6")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPeano(double a, double b)
        {
            return PI * ((3d * (a + b) / 2d) - Sqrt(a * b));
        }

        /// <summary>
        /// The ellipse perimeter quadratic.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 9")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterQuadratic(double a, double b)
        {
            return PI / 2d * Sqrt((6d * ((a * a) + (b * b))) + (4d * a * b));
        }

        /// <summary>
        /// The ellipse perimeter ramanujan.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 19")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterRamanujan(double a, double b)
        {
            return PI * ((3d * (a + b)) - Sqrt(((3d * a) + b) * (a + (3d * b))));
        }

        /// <summary>
        /// The ellipse perimeter ramanujan2.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 21")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterRamanujan2(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * (1d + (3d * h / (10d + Sqrt(4 - (3d * h)))));
        }

        /// <summary>
        /// The ellipse perimeter rivera1.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 38")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterRivera1(double a, double b)
        {
            return (4d * a) + (2d * (PI - 2d) * a * Pow(b / a, 1.456d));
        }

        /// <summary>
        /// The ellipse perimeter rivera2.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 39")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterRivera2(double a, double b)
        {
            return (4d * (((PI * a * b) + ((a - b) * (a - b))) / (a + b))) - (89d / 146d * Pow(((b * Sqrt(a)) - (a * Sqrt(b))) / (a + b), 2d));
        }

        /// <summary>
        /// The ellipse perimeter selmer.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 20")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterSelmer(double a, double b)
        {
            return PI / 4d * (((6 + (0.5d * (Pow(a - b, 2d) * Pow(a - b, 2d) / Pow(a + b, 2d) * Pow(a + b, 2d)))) * (a + b)) - Sqrt(2d * ((a * a) + (3d * a * b) + (b * b))));
        }

        /// <summary>
        /// The ellipse perimeter sipos.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 4")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterSipos(double a, double b)
        {
            return 2d * PI * ((a + b) * (a + b) / ((Sqrt(a) + Sqrt(a)) * (Sqrt(b) + Sqrt(b))));
        }

        /// <summary>
        /// The ellipse perimeter sykora.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 41")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterSykora(double a, double b)
        {
            return (4d * (((PI * a * b) + ((a - b) * (a - b))) / (a + b))) - (0.5d * (a * b / (a + b)) * ((a - b) * (a - b) / ((PI * a * b) + ((a + b) * (a + b)))));
        }

        /// <summary>
        /// The ellipse perimeter sykora rivera cantrells particularly fruitful.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math05a/EllipseCircumference05.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 12")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterSykoraRiveraCantrellsParticularlyFruitful(double a, double b)
        {
            return 4d * ((PI * a * b) + ((a - b) * (a - b))) / (a + b);
        }

        /// <summary>
        /// The ellipse perimeter takakazu seki.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.mathsisfun.com/geometry/ellipse-perimeter.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 35")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterTakakazuSeki(double a, double b)
        {
            return 2d * Sqrt((PI * PI * a * b) + (4d * (a - b) * (a - b)));
        }

        /// <summary>
        /// This one is not as good with a circle.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://ellipse-circumference2.blogspot.com/2011/12/accurate-online-ellipse-circumference.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 44")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterThomasBlankenhorn1(double a, double b)
        {
            var X1 = a;
            var X2 = b;
            var HMX = Max(X1, X2);
            var HMN = Min(X1, X2);
            var H1 = HMN / HMX;
            return 2d * PI * HMX * ((2d / PI) + (0.0000122d * Pow(H1, 0.6125d)) - (0.0021973d * Pow(H1, 1.225d)) + (0.919315d * Pow(H1, 1.8375d)) - (1.0359227d * Pow(H1, 2.45d)) + (0.861913d * Pow(H1, 3.0625d)) - (0.7274398d * Pow(H1, 3.675d)) + (0.6352295d * Pow(H1, 4.2875d)) - (0.436051d * Pow(H1, 4.9d)) + (0.1818904d * Pow(H1, 5.5125d)) - (0.0333691d * Pow(H1, 6.125d)));
        }

        /// <summary>
        /// The ellipse perimeter thomas blankenhorn8.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://ellipse-circumference3.blogspot.com/
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 45")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.mathsisfun.com/geometry/ellipse-perimeter.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterThomasBlankenhorn8(double a, double b)
        {
            var X1 = a;
            var X2 = b;
            var HMX = Max(X1, X2);
            var HMN = Min(X1, X2);
            var H1 = HMN / HMX;
            return HMX * (4d + (((3929d * Pow(H1, 1.5d)) + (1639157d * Pow(H1, 2d)) + (19407215d * Pow(H1, 2.5d)) + (24302653d * Pow(H1, 3d)) + (12892432d * Pow(H1, 3.5d))) / (86251d + (1924742d * Pow(H1, 0.5d)) + (6612384 * Pow(H1, 1d)) + (7291509d * Pow(H1, 1.5d)) + (6436977 * Pow(H1, 2d)) + (3158719d * Pow(H1, 2.5d)))));
        }

        /// <summary>
        /// The ellipse perimeter YNOT.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html
        /// </acknowledgment>
        [DisplayName("Ellipse Perimeter Length 13")]
        [Description("Find the length of the Perimeter of an ellipse.")]
        [Acknowledgment("http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterYNOT(double a, double b)
        {
            var s = Log(2d, E) / Log(PI / 2d, E);
            return 4d * Pow(Pow(a, s) + Pow(b, s), 1d / s);
        }
    }
}
