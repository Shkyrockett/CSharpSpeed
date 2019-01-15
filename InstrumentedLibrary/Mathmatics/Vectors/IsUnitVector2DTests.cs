using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Is Vector a Unit Vector Test")]
    [Description("Is Vector a Unit Vector Test.")]
    [SourceCodeLocationProvider]
    public static class IsUnitVector2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d , 1d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        public static bool IsUnitVector(double i, double j) => IsUnitVector0(i, j);

        /// <summary>
        /// The is unit vector.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        [DisplayName("Is Vector a Unit Vector Test")]
        [Description("Is Vector a Unit Vector Test.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUnitVector0(double i, double j)
        {
            return Math.Abs(VectorMagnitude2D.Magnitude(i, j) - 1) < Maths.Epsilon;
        }
    }
}
