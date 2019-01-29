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
    /// 
    /// </summary>
    [DisplayName("Vector Magnitude Test")]
    [Description("Vector Magnitude.")]
    [SourceCodeLocationProvider]
    public static class VectorMagnitude2D
    {
        /// <summary>
        /// Set of tests to run testing methods.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
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
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Magnitude(double i, double j)
            => Magnitude_(i, j);

        /// <summary>
        /// The Magnitude of a two dimensional Vector.
        /// </summary>
        /// <param name="i">The i component of the vector.</param>
        /// <param name="j">The j component of the vector.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Vector Magnitude Test")]
        [Description("Vector Magnitude.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Magnitude_(double i, double j)
        {
            return Math.Sqrt((i * i) + (j * j));
        }
    }
}
