﻿using CSharpSpeed;
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
    [DisplayName("Matrix Scale 6x6 Tests")]
    [Description("Matrix Scale 6x6 Tests.")]
    [SourceCodeLocationProvider]
    public static class MatrixScale6x6Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixInverseDeterminant6x6Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix6x6ElevensTuple;
            var b = MatrixTestCases.Matrix6x6IncrementalTuple;
            var c = MatrixTestCases.Matrix6x6IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m1x5, a.m1x6, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m2x5, a.m2x6, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m3x5, a.m3x6, a.m4x1, a.m4x2, a.m4x3, a.m4x4, a.m4x5, a.m4x6, a.m5x1, a.m5x2, a.m5x3, a.m5x4, a.m5x5, a.m5x6, a.m6x1, a.m6x2, a.m6x3, a.m6x4, a.m6x5, a.m6x6, 2D }, new TestCaseResults(description: "Matrix6x6 Elevens Tuple", trials: trials, expectedReturnValue: (22d, 24d, 26d, 28d, 30d, 32d, 42d, 44d, 46d, 48d, 50d, 52d, 62d, 64d, 66d, 68d, 70d, 72d, 82d, 84d, 86d, 88d, 90d, 92d, 102d, 104d, 106d, 108d, 110d, 112d, 122d, 124d, 126d, 128d, 130d, 132d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m1x5, b.m1x6, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m2x5, b.m2x6, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m3x5, b.m3x6, b.m4x1, b.m4x2, b.m4x3, b.m4x4, b.m4x5, b.m4x6, b.m5x1, b.m5x2, b.m5x3, b.m5x4, b.m5x5, b.m5x6, b.m6x1, b.m6x2, b.m6x3, b.m6x4, b.m6x5, b.m6x6, 2D }, new TestCaseResults(description: "Matrix6x6 Incremental Tuple", trials: trials, expectedReturnValue: (2d, 4d, 6d, 8d, 10d, 12d, 14d, 16d, 18d, 20d, 22d, 24d, 26d, 28d, 30d, 32d, 34d, 36d, 38d, 40d, 42d, 44d, 46d, 48d, 50d, 52d, 54d, 56d, 58d, 60d, 62d, 64d, 66d, 68d, 70d, 72d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m1x5, c.m1x6, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m2x5, c.m2x6, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m3x5, c.m3x6, c.m4x1, c.m4x2, c.m4x3, c.m4x4, c.m4x5, c.m4x6, c.m5x1, c.m5x2, c.m5x3, c.m5x4, c.m5x5, c.m5x6, c.m6x1, c.m6x2, c.m6x3, c.m6x4, c.m6x5, c.m6x6, 2D }, new TestCaseResults(description: "Matrix6x6 Identity Tuple", trials: trials, expectedReturnValue: (2d, 0d, 0d, 0d, 0d, 0d, 0d, 2d, 0d, 0d, 0d, 0d, 0d, 0d, 2d, 0d, 0d, 0d, 0d, 0d, 0d, 2d, 0d, 0d, 0d, 0d, 0d, 0d, 2d, 0d, 0d, 0d, 0d, 0d, 0d, 2d), epsilon: double.Epsilon) },
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
        /// Scale6x6s the double.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m1x4">The M1X4.</param>
        /// <param name="m1x5">The M1X5.</param>
        /// <param name="m1x6">The M1X6.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m2x4">The M2X4.</param>
        /// <param name="m2x5">The M2X5.</param>
        /// <param name="m2x6">The M2X6.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <param name="m3x4">The M3X4.</param>
        /// <param name="m3x5">The M3X5.</param>
        /// <param name="m3x6">The M3X6.</param>
        /// <param name="m4x1">The M4X1.</param>
        /// <param name="m4x2">The M4X2.</param>
        /// <param name="m4x3">The M4X3.</param>
        /// <param name="m4x4">The M4X4.</param>
        /// <param name="m4x5">The M4X5.</param>
        /// <param name="m4x6">The M4X6.</param>
        /// <param name="m5x1">The M5X1.</param>
        /// <param name="m5x2">The M5X2.</param>
        /// <param name="m5x3">The M5X3.</param>
        /// <param name="m5x4">The M5X4.</param>
        /// <param name="m5x5">The M5X5.</param>
        /// <param name="m5x6">The M5X6.</param>
        /// <param name="m6x1">The M6X1.</param>
        /// <param name="m6x2">The M6X2.</param>
        /// <param name="m6x3">The M6X3.</param>
        /// <param name="m6x4">The M6X4.</param>
        /// <param name="m6x5">The M6X5.</param>
        /// <param name="m6x6">The M6X6.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6) Scale6x6Double(double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6, double value2)
            => Scale6x6(
                 m1x1, m1x2, m1x3, m1x4, m1x5, m1x6,
                 m2x1, m2x2, m2x3, m2x4, m2x5, m2x6,
                 m3x1, m3x2, m3x3, m3x4, m3x5, m3x6,
                 m4x1, m4x2, m4x3, m4x4, m4x5, m4x6,
                 m5x1, m5x2, m5x3, m5x4, m5x5, m5x6,
                 m6x1, m6x2, m6x3, m6x4, m6x5, m6x6, value2);

        /// <summary>
        /// Used to multiply (concatenate) two Matrix5x5Ds.
        /// </summary>
        /// <param name="leftM0x0">The left M0X0.</param>
        /// <param name="leftM0x1">The left M0X1.</param>
        /// <param name="leftM0x2">The left M0X2.</param>
        /// <param name="leftM0x3">The left M0X3.</param>
        /// <param name="leftM0x4">The left M0X4.</param>
        /// <param name="leftM0x5">The left M0X5.</param>
        /// <param name="leftM1x0">The left M1X0.</param>
        /// <param name="leftM1x1">The left M1X1.</param>
        /// <param name="leftM1x2">The left M1X2.</param>
        /// <param name="leftM1x3">The left M1X3.</param>
        /// <param name="leftM1x4">The left M1X4.</param>
        /// <param name="leftM1x5">The left M1X5.</param>
        /// <param name="leftM2x0">The left M2X0.</param>
        /// <param name="leftM2x1">The left M2X1.</param>
        /// <param name="leftM2x2">The left M2X2.</param>
        /// <param name="leftM2x3">The left M2X3.</param>
        /// <param name="leftM2x4">The left M2X4.</param>
        /// <param name="leftM2x5">The left M2X5.</param>
        /// <param name="leftM3x0">The left M3X0.</param>
        /// <param name="leftM3x1">The left M3X1.</param>
        /// <param name="leftM3x2">The left M3X2.</param>
        /// <param name="leftM3x3">The left M3X3.</param>
        /// <param name="leftM3x4">The left M3X4.</param>
        /// <param name="leftM3x5">The left M3X5.</param>
        /// <param name="leftM4x0">The left M4X0.</param>
        /// <param name="leftM4x1">The left M4X1.</param>
        /// <param name="leftM4x2">The left M4X2.</param>
        /// <param name="leftM4x3">The left M4X3.</param>
        /// <param name="leftM4x4">The left M4X4.</param>
        /// <param name="leftM4x5">The left M4X5.</param>
        /// <param name="leftM5x0">The left M5X0.</param>
        /// <param name="leftM5x1">The left M5X1.</param>
        /// <param name="leftM5x2">The left M5X2.</param>
        /// <param name="leftM5x3">The left M5X3.</param>
        /// <param name="leftM5x4">The left M5X4.</param>
        /// <param name="leftM5x5">The left M5X5.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns></returns>
        [DisplayName("Matrix Scale 6x6 Tests")]
        [Description("Matrix Scale 6x6 Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
                double m0x0, double m0x1, double m0x2, double m0x3, double m0x4, double m0x5,
                double m1x0, double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
                double m2x0, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
                double m3x0, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
                double m4x0, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
                double m5x0, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5
                ) Scale6x6(
                double leftM0x0, double leftM0x1, double leftM0x2, double leftM0x3, double leftM0x4, double leftM0x5,
                double leftM1x0, double leftM1x1, double leftM1x2, double leftM1x3, double leftM1x4, double leftM1x5,
                double leftM2x0, double leftM2x1, double leftM2x2, double leftM2x3, double leftM2x4, double leftM2x5,
                double leftM3x0, double leftM3x1, double leftM3x2, double leftM3x3, double leftM3x4, double leftM3x5,
                double leftM4x0, double leftM4x1, double leftM4x2, double leftM4x3, double leftM4x4, double leftM4x5,
                double leftM5x0, double leftM5x1, double leftM5x2, double leftM5x3, double leftM5x4, double leftM5x5,
                double scalar)
        {
            return (leftM0x0 * scalar, leftM0x1 * scalar, leftM0x2 * scalar, leftM0x3 * scalar, leftM0x4 * scalar, leftM0x5 * scalar,
                    leftM1x0 * scalar, leftM1x1 * scalar, leftM1x2 * scalar, leftM1x3 * scalar, leftM1x4 * scalar, leftM1x5 * scalar,
                    leftM2x0 * scalar, leftM2x1 * scalar, leftM2x2 * scalar, leftM2x3 * scalar, leftM2x4 * scalar, leftM2x5 * scalar,
                    leftM3x0 * scalar, leftM3x1 * scalar, leftM3x2 * scalar, leftM3x3 * scalar, leftM3x4 * scalar, leftM3x5 * scalar,
                    leftM4x0 * scalar, leftM4x1 * scalar, leftM4x2 * scalar, leftM4x3 * scalar, leftM4x4 * scalar, leftM4x5 * scalar,
                    leftM5x0 * scalar, leftM5x1 * scalar, leftM5x2 * scalar, leftM5x3 * scalar, leftM5x4 * scalar, leftM5x5 * scalar);
        }
    }
}
