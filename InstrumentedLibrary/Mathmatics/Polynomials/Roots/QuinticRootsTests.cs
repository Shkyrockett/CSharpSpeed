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
    /// The quintic roots tests class.
    /// </summary>
    [DisplayName("Quintic Roots")]
    [Description("Find the real roots of a Quintic polynomial.")]
    [SourceCodeLocationProvider]
    public static class QuinticRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(QuinticRootsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<double> {-0.6723782435877943d, -3.234022892850585d, -0.046799431780810474d, -0.046799431780810474d, 0d, 0d}, epsilon: double.Epsilon) },
                { new object[] { 6, 5d, 4d, 3d, 2d, 1d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<double> {-1.6665418277880788d, -1.6665418277880788d, 0.16654182778807858d, 0.16654182778807858d, 0d, 0d}, epsilon: double.Epsilon) },
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
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static IList<double> QuinticRoots(double a, double b, double c, double d, double e, double f, double epsilon = Epsilon)
            => QuinticRoots0(a, b, c, d, e, f, epsilon);

        // ToDo: Translate code found at: http://abecedarical.com/javascript/script_quintic.html
        // and http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/

        /// <summary>
        /// The quintic roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name = "epsilon"> The minimal value to represent a change.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        /// <acknowledgment>
        /// This is a Copy and paste port of the method found at:
        /// https://web.archive.org/web/20150504111126/http://abecedarical.com/javascript/script_quintic.html
        /// There has been little attempt to fix it up and get it working correctly.
        /// </acknowledgment>
        [DisplayName("Quintic Roots")]
        [Description("Find real Quintic Roots.")]
        [Acknowledgment("https://web.archive.org/web/20150504111126/http://abecedarical.com/javascript/script_quintic.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuinticRoots0(double a, double b, double c, double d, double e, double f, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is quartic.
            if (a is 0d)
            {
                return QuarticRootsTests.QuarticRoots(b, c, d, e, f, epsilon);
            }

            var A = b / a;
            var B = c / a;
            var C = d / a;
            var D = e / a;
            var E = f / a;

            var coeff = new List<double> { a, b, c, d, e, f };

            var beta2 = 0d;
            var delta1 = 0d;
            var delta2 = 0d;
            var delta3 = 0d;

            // order
            var n = 4;// 5;
            var n1 = 5;// 6;
            var n2 = 6;// 7;

            var a_ = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var b_ = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var c_ = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var d_ = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var real = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var imag = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };

            // is the coefficient of the highest term zero?
            if (Abs(coeff[0]) < epsilon)
            {
                return new List<double>();
            }

            //  copy into working array
            for (var i = 0; i <= n; i++)
            {
                a_[a_.Count - 1 - i] = coeff[i];
            }

            // initialize root counter
            var count = 0;

            // start the main Lin-Bairstow iteration loop
            do
            {
                // initialize the counter and guesses for the coefficients of quadratic factor: p(x) = x^2 + alfa1*x + beta1
                var alfa1 = Maths.Random(OneHalf, 1d);
                var alfa2 = 0d;
                var beta1 = Maths.Random(OneHalf, 1d);
                var limit = 1000;

                do
                {
                    b_[0] = 0d;
                    d_[0] = 0d;
                    b_[1] = 1d;
                    d_[1] = 1d;

                    for (int i = 2, j = 1, k = 0; i < a_.Count; i++)
                    {
                        b_[i] = a_[i] - (alfa1 * b_[j]) - (beta1 * b_[k]);
                        d_[i] = b_[i] - (alfa1 * d_[j]) - (beta1 * d_[k]);
                        j += 1;
                        k += 1;
                    }

                    {
                        var j = n - 1;
                        var k = n - 2;
                        delta1 = (d_[j] * d_[j]) - ((d_[n] - b_[n]) * d_[k]);
                        alfa2 = ((b_[n] * d_[j]) - (b_[n1] * d_[k])) / delta1;
                        beta2 = ((b_[n1] * d_[j]) - ((d_[n] - b_[n]) * b_[n])) / delta1;
                        alfa1 += alfa2;
                        beta1 += beta2;
                    }

                    if (--limit < 0)
                    {
                        // cannot solve
                        return new List<double>();
                    }

                    if (Abs(alfa2) < epsilon && Abs(beta2) < epsilon)
                    {
                        break;
                    }
                }
                while (true);

                delta1 = (alfa1 * alfa1) - (4d * beta1);

                // imaginary roots
                if (delta1 < 0)
                {
                    delta2 = Sqrt(Abs(delta1)) * OneHalf;
                    delta3 = -alfa1 * OneHalf;

                    real[count] = delta3;
                    imag[count] = delta2;

                    real[count + 1] = delta3;
                    // sign is inverted on display
                    imag[count + 1] = delta2;
                }
                else
                {
                    // roots are real
                    delta2 = Sqrt(delta1);

                    real[count] = (delta2 - alfa1) * OneHalf;
                    imag[count] = 0;

                    real[count + 1] = (delta2 + alfa1) * -OneHalf;
                    imag[count + 1] = 0;
                }

                // update root counter
                count += 2;

                // reduce polynomial order
                n -= 2;
                n1 -= 2;
                n2 -= 2;

                // for n >= 2 calculate coefficients of
                //  the new polynomial
                if (n >= 2)
                {
                    for (var i = 1; i <= n1; i++)
                    {
                        a_[i] = b_[i];
                    }
                }

                if (n < 2)
                {
                    break;
                }
            }
            while (true);

            if (n == 1)
            {
                // obtain last single real root
                real[count] = -b_[2];
                imag[count] = 0;
            }

            return real;
        }
    }
}
