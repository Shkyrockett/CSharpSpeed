﻿using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Is lower matrix jagged.")]
    [Description("Determines whether a jagged matrix is a lower matrix.")]
    [SourceCodeLocationProvider]
    public static class JaggedIsLowerMatrixTests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(JaggedIsLowerMatrixTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { MatrixTestCases.Matrix2x2ElevensJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix2x2IdentityJagged2DArray }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3ElevensJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix3x3IdentityJagged2DArray }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4ElevensJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix4x4IdentityJagged2DArray }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5ElevensJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix5x5IdentityJagged2DArray }, new TestCaseResults(description: "Matrix5x5 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6ElevensJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6IncrementalJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { MatrixTestCases.Matrix6x6IdentityJagged2DArray }, new TestCaseResults(description: "Matrix6x6 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// Determines whether [is lower matrix] [the specified matrix].
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is lower matrix] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsLowerMatrix(double[][] matrix)
            => IsLowerMatrix1(matrix);

        /// <summary>
        /// Check whether a matrix is a lower matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is lower matrix] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L181
        /// </acknowledgment>
        [DisplayName("Is lower matrix.")]
        [Description("Determines whether a matrix is a lower matrix.")]
        [Acknowledgment("https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L181")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLowerMatrix1(double[][] matrix)
        {
            var rows = matrix?.Length;
            var cols = matrix[0]?.Length;

            for (var i = 0; i < rows; i++)
            {
                for (var j = i + 1; j < cols; j++)
                {
                    if (matrix[i][j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
