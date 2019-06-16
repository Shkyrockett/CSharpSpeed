using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The change angle of vector tests class.
    /// </summary>
    [DisplayName("Change Angle of Vector Tests")]
    [Description("Change the angle of a vector.")]
    [SourceCodeLocationProvider]
    public static class ChangeAngleOfVectorTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the change of an angle of a vector.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ChangeAngleOfVectorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.8414709848078965d, -0.54030230586813977d), epsilon: double.Epsilon) },
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
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double I, double J) ChangeAngleOfVector(double i, double j, double angle)
            => SetAngle(i, j, angle);

        /// <summary>
        /// Set the angle.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Change Angle of Vector")]
        [Description("Change the angle of a vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J) SetAngle(double i, double j, double angle)
        {
            //double rads = angle; // * (PI / 180); // Original code used degrees rather than radians.
            var dist = Sqrt((i * i) + (j * j));
            return (
                Sin(angle) * dist,
                -(Cos(angle) * dist));
        }
    }
}
