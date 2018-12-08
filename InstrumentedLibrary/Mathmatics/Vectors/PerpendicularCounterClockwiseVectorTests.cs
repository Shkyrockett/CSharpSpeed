using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The perpendicular counter clockwise vector tests class.
    /// </summary>
    [DisplayName("Counter Clockwise Perpendicular Vector")]
    [Description("Find the counter clockwise perpendicular of a Vector.")]
    [Signature("public static (double I, double J) PerpendicularCounterClockwiseVector(double i, double j)")]
    [SourceCodeLocationProvider]
    public static class PerpendicularCounterClockwiseVectorTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PerpendicularCounterClockwiseVectorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0.5d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:Tau, epsilon:double.Epsilon) },
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
        /// Find the Counter Clockwise Perpendicular of a Vector.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        /// <remarks>
        /// To get the perpendicular vector in two dimensions use I = -J, J = I
        /// </remarks>
        [DisplayName("Counter Clockwise Perpendicular Vector")]
        [Description("Find the counter clockwise perpendicular of a Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J) PerpendicularCounterClockwiseVector(double i, double j)
        {
            return (j, -i);
        }
    }
}
