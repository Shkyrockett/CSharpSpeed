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
    /// 
    /// </summary>
    [DisplayName("Get the Unit Normal of two Points")]
    [Description("Get the Unit Normal of two Points.")]
    [SourceCodeLocationProvider]
    public static class GetUnitNormal2DTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(GetUnitNormal2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 1d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (-0.70710678118654746d, -0.70710678118654746d), epsilon: double.Epsilon) },
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
        /// <param name="pt1X"></param>
        /// <param name="pt1Y"></param>
        /// <param name="pt2X"></param>
        /// <param name="pt2Y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double, double) GetUnitNormal(double pt1X, double pt1Y, double pt2X, double pt2Y)
            => GetUnitNormal0(pt1X, pt1Y, pt2X, pt2Y);

        /// <summary>
        /// Get the unit normal.
        /// </summary>
        /// <param name="pt1X">The pt1X.</param>
        /// <param name="pt1Y">The pt1Y.</param>
        /// <param name="pt2X">The pt2X.</param>
        /// <param name="pt2Y">The pt2Y.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://www.angusj.com
        /// </acknowledgment>
        [DisplayName("Get the Unit Normal of two Points")]
        [Description("Get the Unit Normal of two Points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double, double) GetUnitNormal0(double pt1X, double pt1Y, double pt2X, double pt2Y)
        {
            var dx = pt2X - pt1X;
            var dy = pt2Y - pt1Y;
            if ((dx == 0d) && (dy == 0d))
            {
                return (0d, 0d);
            }

            var f = 1d / Sqrt(dx * dx + dy * dy);
            dx *= f;
            dy *= f;

            return (dy, -dx);
        }
    }
}
