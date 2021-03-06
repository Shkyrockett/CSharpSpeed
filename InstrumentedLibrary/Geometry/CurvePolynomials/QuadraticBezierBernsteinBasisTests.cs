﻿using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The quadratic bezier coefficients tests class.
    /// </summary>
    [DisplayName("Quadratic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Quadratic Bezier Curve.")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierBernsteinBasisTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the Polynomial Bezier Coefficients.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierBernsteinBasisTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: (0d, 2d, 1d), epsilon: double.Epsilon) },
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
        /// Quadratics the bezier bernstein basis.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double A, double B, double C) QuadraticBezierBernsteinBasis(double a, double b, double c)
            => QuadraticBezierCoefficients0(a, b, c);

        /// <summary>
        /// Coefficients for a Quadratic Bézier curve.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://fontforge.github.io/bezier.html
        /// </acknowledgment>
        [DisplayName("Quadratic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quadratic Bezier Curve.")]
        [Acknowledgment("http://fontforge.github.io/bezier.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C) QuadraticBezierCoefficients0(double a, double b, double c)
        {
            return (c - (2d * b) + a,
                    2d * (b - a),
                    a);
        }

        /// <summary>
        /// The quadratic bezier coefficients general.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <returns>
        /// The <see cref="Polynomial" />.
        /// </returns>
        [DisplayName("Quadratic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quadratic Bezier Curve.")]
        [Acknowledgment("http://fontforge.github.io/bezier.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C) QuadraticBezierCoefficientsGeneral(double a, double b, double c)
        {
            var polynomial = RecursiveBezierBernsteinBasisTests.BezierCoefficientsRecursive(a, b, c);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c]);
        }

        /// <summary>
        /// Coefficients for a Quadratic Bézier curve.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Quadratic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quadratic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C) QuadraticBezierCoefficientsRecursive(double a, double b, double c)
        {
            var polynomial = (Polynomial.OneMinusT * LinearBezierBernsteinBasisTests.LinearBezierBernsteinBasis(a, b)) + (Polynomial.T * LinearBezierBernsteinBasisTests.LinearBezierBernsteinBasis(b, c));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c]);
        }
    }
}
