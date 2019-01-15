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
    /// The trim zeros tests class.
    /// </summary>
    [DisplayName("Real Order of Polynomial")]
    [Description("Find the real order of a polynomial.")]
    [SourceCodeLocationProvider]
    public static class PolynomialRealOrderTests
    {
        /// <summary>
        /// The normalize2d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolynomialRealOrderTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new double[] { 3d, 4d, 5d }, Epsilon }, new TestCaseResults(description:"3d, 4d, 5d.", trials:trials, expectedReturnValue:PolynomialDegree.Quadratic, epsilon:double.Epsilon) },
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
        /// <param name="coefficients"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static PolynomialDegree RealOrder(double[] coefficients, double epsilon = Epsilon)
            => RealOrderSuperLloyd(coefficients, epsilon);

        /// <summary>
        /// The real order super lloyd.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="int"/>.</returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Real Order of Polynomial Super Lloyd")]
        [Description("Find the real order of a polynomial.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PolynomialDegree RealOrderSuperLloyd(double[] coefficients, double epsilon = Epsilon)
        {
            if (coefficients is null)
            {
                return PolynomialDegree.Empty;
            }

            var order = 0;
            for (var i = 0; i < coefficients.Length; i++)
            {
                if (Abs(coefficients[i]) > epsilon)
                {
                    order = i;
                }
            }

            return (PolynomialDegree)order;
        }

        /// <summary>
        /// Calculates the real order or degree of the polynomial.
        /// Or rather, locates where to trim off any leading zero coefficients.
        /// </summary>
        /// <returns></returns>
        /// <acknowledgment>
        /// A hodge-podge method based on Simplify from of: http://www.kevlindev.com/
        /// and Trim and RealOrder from: https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Real Order of Polynomial")]
        [Description("Find the real order of a polynomial.")]
        [Acknowledgment("http://www.kevlindev.com/", "https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PolynomialDegree RealOrder0(double[] coefficients, double epsilon = Epsilon)
        {
            var pos = 1;
            var count = coefficients.Length;

            // Monomial can be a zero constant, skip them and check the rest.
            if (count > 1)
            {
                // Count the number of leading zeros. Because the coefficients array is reversed, start at the end.
                for (var i = count - 1; i >= 1 /* Monomials can be 0. */; i--)
                {
                    // Check if coefficient is a leading zero.
                    if (Abs(coefficients[i]) <= epsilon)
                    {
                        pos++;
                    }
                    else
                    {
                        // Break early if a non zero value was found. This indicates the end of any leading zeros.
                        break;
                    }
                }
            }

            return (PolynomialDegree)(coefficients?.Length - pos ?? 0);
        }
    }
}
