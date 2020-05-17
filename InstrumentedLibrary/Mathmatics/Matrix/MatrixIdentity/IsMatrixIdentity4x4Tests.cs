using CSharpSpeed;
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
    [DisplayName("Is Matrix Identity")]
    [Description("Check whether the Matrix is an Identity Matrix.")]
    [SourceCodeLocationProvider]
    public static class IsMatrixIdentity4x4Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(IsMatrixIdentity4x4Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix4x4ElevensTuple;
            var b = MatrixTestCases.Matrix4x4IncrementalTuple;
            var c = MatrixTestCases.Matrix4x4IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m4x1, a.m4x2, a.m4x3, a.m4x4 }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m4x1, b.m4x2, b.m4x3, b.m4x4 }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m4x1, c.m4x2, c.m4x3, c.m4x4 }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// Determines whether the specified M1X1 is identity.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m1x4">The M1X4.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m2x4">The M2X4.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <param name="m3x4">The M3X4.</param>
        /// <param name="m4x1">The M4X1.</param>
        /// <param name="m4x2">The M4X2.</param>
        /// <param name="m4x3">The M4X3.</param>
        /// <param name="m4x4">The M4X4.</param>
        /// <returns>
        ///   <c>true</c> if the specified M1X1 is identity; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsIdentity(double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4)
            => IsIdentity1(m1x1, m1x2, m1x3, m1x4, m2x1, m2x2, m2x3, m2x4, m3x1, m3x2, m3x3, m3x4, m4x1, m4x2, m4x3, m4x4);

        /// <summary>
        /// Tests whether or not a given transform is an identity transform matrix.
        /// </summary>
        /// <param name="m0x0">The M0X0.</param>
        /// <param name="m0x1">The M0X1.</param>
        /// <param name="m0x2">The M0X2.</param>
        /// <param name="m0x3">The M0X3.</param>
        /// <param name="m1x0">The M1X0.</param>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m2x0">The M2X0.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m3x0">The M3X0.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <returns>
        ///   <c>true</c> if the specified M0X0 is identity; otherwise, <c>false</c>.
        /// </returns>
        [DisplayName("Is Matrix Identity")]
        [Description("Check whether the Matrix is an Identity Matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity1(
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3)
        {
            return Math.Abs(m0x0 - 1d) < double.Epsilon && Math.Abs(m0x1) < double.Epsilon && Math.Abs(m0x2) < double.Epsilon && Math.Abs(m0x3) < double.Epsilon
                && Math.Abs(m1x0) < double.Epsilon && Math.Abs(m1x1 - 1d) < double.Epsilon && Math.Abs(m1x2) < double.Epsilon && Math.Abs(m1x3) < double.Epsilon
                && Math.Abs(m2x0) < double.Epsilon && Math.Abs(m2x1) < double.Epsilon && Math.Abs(m2x2 - 1d) < double.Epsilon && Math.Abs(m2x3) < double.Epsilon
                && Math.Abs(m3x0) < double.Epsilon && Math.Abs(m3x1) < double.Epsilon && Math.Abs(m3x2) < double.Epsilon && Math.Abs(m3x3 - 1d) < double.Epsilon;
        }

        /// <summary>
        /// Returns whether the matrix is the identity matrix.
        /// </summary>
        /// <param name="M11">The M11.</param>
        /// <param name="M12">The M12.</param>
        /// <param name="M13">The M13.</param>
        /// <param name="M14">The M14.</param>
        /// <param name="M21">The M21.</param>
        /// <param name="M22">The M22.</param>
        /// <param name="M23">The M23.</param>
        /// <param name="M24">The M24.</param>
        /// <param name="M31">The M31.</param>
        /// <param name="M32">The M32.</param>
        /// <param name="M33">The M33.</param>
        /// <param name="M34">The M34.</param>
        /// <param name="M41">The M41.</param>
        /// <param name="M42">The M42.</param>
        /// <param name="M43">The M43.</param>
        /// <param name="M44">The M44.</param>
        /// <returns>
        ///   <c>true</c> if [is identity cs] [the specified M11]; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
        [DisplayName("Is Matrix Identity")]
        [Description("Check whether the Matrix is an Identity Matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentityCS(double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44)
        {
            return M11 == 1d && M22 == 1d && M33 == 1d && M44 == 1d && // Check diagonal element first for early out.
                   M12 == 0d && M13 == 0d && M14 == 0d &&
                   M21 == 0d && M23 == 0d && M24 == 0d &&
                   M31 == 0d && M32 == 0d && M34 == 0d &&
                   M41 == 0d && M42 == 0d && M43 == 0d;
        }
    }
}
