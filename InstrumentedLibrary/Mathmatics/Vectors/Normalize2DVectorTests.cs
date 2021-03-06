﻿using CSharpSpeed;
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
    /// The normalize2d tests class.
    /// </summary>
    [DisplayName("Normalize 2D Vector Tests")]
    [Description("Normalizes a 2D Vector.")]
    [SourceCodeLocationProvider]
    public static class Normalize2DVectorTests
    {
        /// <summary>
        /// The normalize2d test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(Normalize2DVectorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 0.70710678118654746d), epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double i, double j) Normalize(double i, double j)
            => Normalize0(i, j);

        /// <summary>
        /// The normalize.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Normalize 2D Vector")]
        [Description("Normalize a 2D Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double i, double j) Normalize0(double i, double j)
        {
            return (
                i / Sqrt((i * i) + (j * j)),
                j / Sqrt((i * i) + (j * j))
                );
        }
    }
}
