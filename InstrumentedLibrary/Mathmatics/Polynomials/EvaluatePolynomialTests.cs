using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System;
using System.Linq;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The evaluate polynomial tests class.
    /// </summary>
    [DisplayName("Evaluate Polynomial Tests")]
    [Description("Evaluate a Polynomial.")]
    [SourceCodeLocationProvider]
    public static class EvaluatePolynomialTests
    {
        /// <summary>
        /// Set of tests to run testing methods that evaluates a polynomial.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(EvaluatePolynomialTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new double[] { 100d, 200d, -200d }, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:PolynomialDegree.Quadratic, epsilon: double.Epsilon) },
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
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Evaluate(double[] coefficients, double x)
            => Evaluate0(coefficients, x);

        /// <summary>
        /// An implementation of Horner's Evaluate method.
        /// </summary>
        /// <param name="coefficients"></param>
        /// <param name="x">The value to evaluate.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Horner%27s_method
        /// https://github.com/thelonious/kld-polynomial
        /// </acknowledgment>
        [DisplayName("Evaluate Polynomial Tests")]
        [Description("Evaluate a Polynomial.")]
        [Acknowledgment("https://en.wikipedia.org/wiki/Horner%27s_method", "https://github.com/thelonious/kld-polynomial")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Evaluate0(double[] coefficients, double x)
        {
            if (double.IsNaN(x))
            {
                throw new ArithmeticException($"{nameof(Evaluate)}: parameter {nameof(x)} must be a number");
            }

            var degree = coefficients.Length - 1;
            var result = 0d;

            for (var i = degree; i >= 0; i--)
            {
                result = result * x + coefficients[i];
            }

            return result;
        }

        /// <summary>
        /// The horner.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        /// <param name="x">The x.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <exception cref="ArithmeticException"></exception>
        /// <acknowledgment>
        /// http://rosettacode.org/wiki/Horner%27s_rule_for_polynomial_evaluation
        /// </acknowledgment>
        [DisplayName("Evaluate Polynomial Tests")]
        [Description("Evaluate a Polynomial.")]
        [Acknowledgment("http://rosettacode.org/wiki/Horner%27s_rule_for_polynomial_evaluation")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Horner(double[] coefficients, double x)
        {
            if (double.IsNaN(x))
            {
                throw new ArithmeticException($"{nameof(Horner)}: parameter {nameof(x)} must be a number");
            }

            return coefficients.Reverse().Aggregate(
                    (accumulator, coefficient) => accumulator * x + coefficient);
        }

        /// <summary>
        /// The compute.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        /// <param name="x">The x.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <exception cref="ArithmeticException"></exception>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Evaluate Polynomial Tests")]
        [Description("Evaluate a Polynomial.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Compute(double[] coefficients, double x)
        {
            if (double.IsNaN(x))
            {
                throw new ArithmeticException($"{nameof(Compute)}: parameter {nameof(x)} must be a number");
            }

            var degree = coefficients.Length - 1;
            var result = 0d;
            var ncoef = 1d;
            for (var i = 0; i <= degree; i++)
            {
                result += coefficients[i] * ncoef;
                ncoef *= x;
            }

            return result;
        }

        ///// <summary>
        ///// The compute c.
        ///// </summary>
        ///// <param name="coefficients">The coefficients.</param>
        ///// <param name="x">The x.</param>
        ///// <returns>The <see cref="Complex"/>.</returns>
        ///// <acknowledgment>
        ///// https://github.com/superlloyd/Poly
        ///// </acknowledgment>
        //[DisplayName("Evaluate Polynomial Tests")]
        //[Description("Evaluate a Polynomial.")]
        //[Acknowledgment("https://github.com/superlloyd/Poly")]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Complex ComputeC(double[] coefficients, Complex x)
        //{
        //    var degree = coefficients.Length - 1;
        //    var result = Complex.Zero;
        //    var ncoef = Complex.One;

        //    for (var i = 0; i <= degree; i++)
        //    {
        //        result += coefficients[i] * ncoef;
        //        ncoef *= x;
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// The compute c2.
        ///// </summary>
        ///// <param name="coefficients">The coefficients.</param>
        ///// <param name="x">The x.</param>
        ///// <returns>The <see cref="Complex"/>.</returns>
        ///// <acknowledgment>
        ///// https://en.wikipedia.org/wiki/Horner%27s_method
        ///// https://github.com/superlloyd/Poly
        ///// https://github.com/thelonious/kld-polynomial
        ///// </acknowledgment>
        //[DisplayName("Evaluate Polynomial Tests")]
        //[Description("Evaluate a Polynomial.")]
        //[Acknowledgment("https://en.wikipedia.org/wiki/Horner%27s_method", "https://github.com/superlloyd/Poly", "https://github.com/thelonious/kld-polynomial")]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Complex ComputeC2(double[] coefficients, Complex x)
        //{
        //    var degree = coefficients.Length - 1;
        //    var result = Complex.Zero;

        //    for (var i = degree; i >= 0; i--)
        //    {
        //        result = result * x + coefficients[i];
        //    }

        //    return result;
        //}
    }
}
