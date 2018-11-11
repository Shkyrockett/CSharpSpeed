using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The linear bezier coefficients tests class.
    /// </summary>
    [DisplayName("Linear Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Linear Bezier Curve.")]
    [Signature("public static IList<double> LinearBezierCoefficients(double a, double b)")]
    [SourceCodeLocationProvider]
    public static class LinearBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:null, epsilon:double.Epsilon) },
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
        /// Coefficients for a Linear Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://fontforge.github.io/bezier.html
        /// </acknowledgment>
        [DisplayName("Linear Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Linear Bezier Curve.")]
        [Acknowledgment("http://fontforge.github.io/bezier.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B) LinearBezierCoefficients(double a, double b)
        {
            return (b - a, a);
        }

        /// <summary>
        /// The linear bezier coefficients general.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Linear Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Linear Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial LinearBezierCoefficientsGeneral(double a, double b)
        {
            return GeneralBezierCoefficientsTests.BezierCoefficientsRecursive(a, b);
        }

        /// <summary>
        /// Coefficients for a Linear Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Linear Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Linear Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial LinearBezierCoefficientsRecursive(double a, double b)
        {
            return (Polynomial.OneMinusT * a) + (Polynomial.T * b);
        }
    }
}
