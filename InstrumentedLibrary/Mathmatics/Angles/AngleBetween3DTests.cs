﻿using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The angle between3d tests class.
    /// </summary>
    [DisplayName("Angle Between 3D Vectors Tests")]
    [Description("Find the angle between two 3D vectors.")]
    [Signature("public static double AngleBetween3D(double uI, double uJ, double uK, double vI, double vJ, double vK)")]
    [SourceCodeLocationProvider]
    public static class AngleBetween3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(AngleBetween3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d }, new TestCaseResults(" 0, 0, 0, 1, 1, 1.", trials, double.NaN, double.Epsilon * 2d) }
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
        /// Finds the angle between two vectors.
        /// </summary>
        /// <param name="uX">The uX.</param>
        /// <param name="uY">The uY.</param>
        /// <param name="uZ">The uZ.</param>
        /// <param name="vX">The vX.</param>
        /// <param name="vY">The vY.</param>
        /// <param name="vZ">The vZ.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://james-ramsden.com/angle-between-two-vectors/
        /// </acknowledgment>
        [DisplayName("AngleBetween")]
        [Description("James Ramsden's method of finding the angle between two 3D vectors.")]
        [Acknowledgment("http://james-ramsden.com/angle-between-two-vectors/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AngleBetween(
            double uX, double uY, double uZ,
            double vX, double vY, double vZ)
        {
            return Acos(((uX * vX) + (uY * vY) + (uZ * vZ)) / Sqrt(((uX * uX) + (uY * uY) + (uZ * uZ)) * ((vX * vX) + (vY * vY) + (vZ * vZ))));
        }
    }
}
