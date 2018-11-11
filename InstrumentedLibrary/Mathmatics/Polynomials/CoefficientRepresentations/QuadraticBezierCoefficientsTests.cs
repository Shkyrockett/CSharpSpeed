using CSharpSpeed;
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
    [Signature("public static IList<double> CubicRoots(double aCube, double bSquare, double cLinear, double dConstant, double epsilon = Epsilon)")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierCoefficientsTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the Polynomial Bezier Coefficients.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:null, epsilon:double.Epsilon) },
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
        /// Coefficients for a Quadratic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <acknowledgment>
        /// http://fontforge.github.io/bezier.html
        /// </acknowledgment>
        [DisplayName("Quadratic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quadratic Bezier Curve.")]
        [Acknowledgment("http://fontforge.github.io/bezier.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C) QuadraticBezierCoefficients(double a, double b, double c)
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
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Quadratic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quadratic Bezier Curve.")]
        [Acknowledgment("http://fontforge.github.io/bezier.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial QuadraticBezierCoefficientsGeneral(double a, double b, double c)
        {
            return GeneralBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c);
        }

        /// <summary>
        /// Coefficients for a Quadratic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
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
        public static Polynomial QuadraticBezierCoefficientsRecursive(double a, double b, double c)
        {
            return (Polynomial.OneMinusT * LinearBezierCoefficientsTests.LinearBezierCoefficients(a, b)) + (Polynomial.T * LinearBezierCoefficientsTests.LinearBezierCoefficients(b, c));
        }
    }
}
