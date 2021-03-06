﻿using CSharpSpeed;
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
    [DisplayName("Rounding Tests")]
    [Description("Rounding.")]
    [SourceCodeLocationProvider]
    public static class RoundToEvenTests
    {
        /// <summary>
        /// Set of tests to run testing methods that round a number.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(RoundToEvenTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:1d, epsilon: double.Epsilon) },
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
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Round(double value)
            => RoundToEven(value);

        /// <summary>
        /// To Even, or Bankers rounding.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DisplayName("Rounding Tests")]
        [Description("Rounding.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RoundToEven(double value)
        {
            return Math.Round(value, 0, MidpointRounding.ToEven);
        }
    }
}
