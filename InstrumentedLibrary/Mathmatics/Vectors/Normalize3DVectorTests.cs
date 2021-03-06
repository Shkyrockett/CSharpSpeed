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
    /// The normalize3d vector tests class.
    /// </summary>
    [DisplayName("Normalize 3D Vector Tests")]
    [Description("Normalizes a 3D Vector.")]
    [SourceCodeLocationProvider]
    public static class Normalize3DVectorTests
    {
        /// <summary>
        /// The normalize3d test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(Normalize3DVectorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 0.70710678118654746d, 0d), epsilon: double.Epsilon) },
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
        /// <param name="k"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double i, double j, double k) Normalize(double i, double j, double k)
            => Normalize0(i, j, k);

        /// <summary>
        /// The normalize.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        [DisplayName("Normalize 3D Vector")]
        [Description("Normalize a 3D Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double i, double j, double k) Normalize0(double i, double j, double k)
        {
            return (
                i / Sqrt((i * i) + (j * j) + (k * k)),
                j / Sqrt((i * i) + (j * j) + (k * k)),
                k / Sqrt((i * i) + (j * j) + (k * k))
                );
        }
    }
}
