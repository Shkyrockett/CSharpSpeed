using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The general bezier coefficients tests class.
    /// </summary>
    [DisplayName("General Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a General Bezier Curve.")]
    [SourceCodeLocationProvider]
    public static class RecursiveBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RecursiveBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new double[]{ 1d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(1d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(2d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d, 4d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(3d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d, 4d, 5d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(4d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d, 4d, 5d, 6d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(5d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d, 4d, 5d, 6d, 7d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(6d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(7d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(8d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(9d, 1d), epsilon: double.Epsilon) },
                { new object[] { new double[]{ 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new Polynomial(10d, 1d), epsilon: double.Epsilon) },
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
        /// <param name="values"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Polynomial RecursiveBezierCoefficients(params double[] values)
            => BezierCoefficientsRecursive(values);

        /// <summary>
        /// Recursive method for calculating the Bezier Polynomial.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("General Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a General Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial BezierCoefficientsRecursive(params double[] values)
        {
            if (values is null || values.Length < 1)
            {
                throw new ArgumentNullException(nameof(values), "At least 2 different points must be given");
            }

            return BezierCoefficientsRecursive(0, values.Length - 1, values);
        }

        /// <summary>
        /// Internal Recursive method for calculating the Bezier Polynomial.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Polynomial BezierCoefficientsRecursive(int from, int to, double[] values)
        {
            return (from == to)
                       ? new Polynomial(values[from])
                       : (Polynomial.OneMinusT * BezierCoefficientsRecursive(from, to - 1, values)) + (Polynomial.T * BezierCoefficientsRecursive(from + 1, to, values));
        }
    }
}
