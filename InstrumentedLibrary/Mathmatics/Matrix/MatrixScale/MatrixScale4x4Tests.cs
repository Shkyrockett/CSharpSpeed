using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using CSharpSpeed;
using System.Reflection;
#if HAS_INTRINSICS
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Matrix Scale 4x4 Tests")]
    [Description("Matrix Scale 4x4 Tests.")]
    [SourceCodeLocationProvider]
    public static class MatrixScale4x4Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixDeterminant4x4Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix4x4ElevensTuple;
            var b = MatrixTestCases.Matrix4x4IncrementalTuple;
            var c = MatrixTestCases.Matrix4x4IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m4x1, a.m4x2, a.m4x3, a.m4x4, 2D }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue: (22d, 24d, 26d, 28d, 42d, 44d, 46d, 48d, 62d, 64d, 66d, 68d, 82d, 84d, 86d, 88d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m4x1, b.m4x2, b.m4x3, b.m4x4, 2D }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue: (2d, 4d, 6d, 8d, 10d, 12d, 14d, 16d, 18d, 20d, 22d, 24d, 26d, 28d, 30d, 32d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m4x1, c.m4x2, c.m4x3, c.m4x4, 2D }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue: (2d, 0d, 0d, 0d, 0d, 2d, 0d, 0d, 0d, 0d, 2d, 0d, 0d, 0d, 0d, 2d), epsilon: double.Epsilon) },
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
        /// Scale4x4s the double.
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
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4) Scale4x4Double(double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4, double value2)
            => Scale4x4(
                 m1x1, m1x2, m1x3, m1x4,
                 m2x1, m2x2, m2x3, m2x4,
                 m3x1, m3x2, m3x3, m3x4,
                 m4x1, m4x2, m4x3, m4x4, value2);

        /// <summary>
        /// Used to multiply (concatenate) two <see cref="Matrix4x4D" />s.
        /// </summary>
        /// <param name="leftM0x0">The left M0X0.</param>
        /// <param name="leftM0x1">The left M0X1.</param>
        /// <param name="leftM0x2">The left M0X2.</param>
        /// <param name="leftM0x3">The left M0X3.</param>
        /// <param name="leftM1x0">The left M1X0.</param>
        /// <param name="leftM1x1">The left M1X1.</param>
        /// <param name="leftM1x2">The left M1X2.</param>
        /// <param name="leftM1x3">The left M1X3.</param>
        /// <param name="leftM2x0">The left M2X0.</param>
        /// <param name="leftM2x1">The left M2X1.</param>
        /// <param name="leftM2x2">The left M2X2.</param>
        /// <param name="leftM2x3">The left M2X3.</param>
        /// <param name="leftM3x0">The left M3X0.</param>
        /// <param name="leftM3x1">The left M3X1.</param>
        /// <param name="leftM3x2">The left M3X2.</param>
        /// <param name="leftM3x3">The left M3X3.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns></returns>
        [DisplayName("Matrix Scale 4x4 Tests")]
        [Description("Matrix Scale 4x4 Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3
            ) Scale4x4(
            double leftM0x0, double leftM0x1, double leftM0x2, double leftM0x3,
            double leftM1x0, double leftM1x1, double leftM1x2, double leftM1x3,
            double leftM2x0, double leftM2x1, double leftM2x2, double leftM2x3,
            double leftM3x0, double leftM3x1, double leftM3x2, double leftM3x3,
            double scalar)
        {
            return (leftM0x0 * scalar, leftM0x1 * scalar, leftM0x2 * scalar, leftM0x3 * scalar,
                           leftM1x0 * scalar, leftM1x1 * scalar, leftM1x2 * scalar, leftM1x3 * scalar,
                           leftM2x0 * scalar, leftM2x1 * scalar, leftM2x2 * scalar, leftM2x3 * scalar,
                           leftM3x0 * scalar, leftM3x1 * scalar, leftM3x2 * scalar, leftM3x3 * scalar);
        }

        /// <summary>
        /// Used to multiply (concatenate) two <see cref="Matrix4x4D" />s.
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
        /// <param name="scalar">The scalar.</param>
        /// <returns></returns>
        [DisplayName("Matrix Scale 4x4 Tests")]
        [Description("Matrix Scale 4x4 Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3
            ) Scale4x4Predefine(
            double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44,
            double scalar)
        {
            (double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44) m;
            m.M11 = M11 * scalar;
            m.M12 = M12 * scalar;
            m.M13 = M13 * scalar;
            m.M14 = M14 * scalar;
            m.M21 = M21 * scalar;
            m.M22 = M22 * scalar;
            m.M23 = M23 * scalar;
            m.M24 = M24 * scalar;
            m.M31 = M31 * scalar;
            m.M32 = M32 * scalar;
            m.M33 = M33 * scalar;
            m.M34 = M34 * scalar;
            m.M41 = M41 * scalar;
            m.M42 = M42 * scalar;
            m.M43 = M43 * scalar;
            m.M44 = M44 * scalar;
            return m;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value.
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
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
        [DisplayName("Matrix Scale 4x4 Tests")]
        [Description("Matrix Scale 4x4 Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe (
            double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44)
            Scale4x4SIMDDouble(
            double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44, double value2)
            => Scale4x4SIMDDouble(
            (M11, M12, M13, M14,
             M21, M22, M23, M24,
             M31, M32, M33, M34,
             M41, M42, M43, M44), value2);

        /// <summary>
        /// Multiplies a matrix by a scalar value.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns></returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe (
            double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44)
            Scale4x4SIMDDouble(
            (double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44) matrix, double scalar)
        {
#if HAS_INTRINSICS
            if (Sse2.IsSupported)
            {
                var value2Vec = Vector128.Create(scalar);
                Sse2.Store(&matrix.M11, Sse2.Multiply(Sse2.LoadVector128(&matrix.M11), value2Vec));
                Sse2.Store(&matrix.M13, Sse2.Multiply(Sse2.LoadVector128(&matrix.M13), value2Vec));
                Sse2.Store(&matrix.M21, Sse2.Multiply(Sse2.LoadVector128(&matrix.M21), value2Vec));
                Sse2.Store(&matrix.M23, Sse2.Multiply(Sse2.LoadVector128(&matrix.M23), value2Vec));
                Sse2.Store(&matrix.M31, Sse2.Multiply(Sse2.LoadVector128(&matrix.M31), value2Vec));
                Sse2.Store(&matrix.M33, Sse2.Multiply(Sse2.LoadVector128(&matrix.M33), value2Vec));
                Sse2.Store(&matrix.M41, Sse2.Multiply(Sse2.LoadVector128(&matrix.M41), value2Vec));
                Sse2.Store(&matrix.M43, Sse2.Multiply(Sse2.LoadVector128(&matrix.M43), value2Vec));
                return matrix;
            }
#endif
            (double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44) m;
            m.M11 = matrix.M11 * scalar;
            m.M12 = matrix.M12 * scalar;
            m.M13 = matrix.M13 * scalar;
            m.M14 = matrix.M14 * scalar;
            m.M21 = matrix.M21 * scalar;
            m.M22 = matrix.M22 * scalar;
            m.M23 = matrix.M23 * scalar;
            m.M24 = matrix.M24 * scalar;
            m.M31 = matrix.M31 * scalar;
            m.M32 = matrix.M32 * scalar;
            m.M33 = matrix.M33 * scalar;
            m.M34 = matrix.M34 * scalar;
            m.M41 = matrix.M41 * scalar;
            m.M42 = matrix.M42 * scalar;
            m.M43 = matrix.M43 * scalar;
            m.M44 = matrix.M44 * scalar;
            return m;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value.
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
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
        [DisplayName("Matrix Scale 4x4 Tests")]
        [Description("Matrix Scale 4x4 Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe (
            double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44)
            Scale4x4SIMDDouble2(
            double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44, double value2)
        {
            return Scale4x4SIMDDouble2(
                       (M11, M12, M13, M14,
                        M21, M22, M23, M24,
                        M31, M32, M33, M34,
                        M41, M42, M43, M44), value2);
            static (
                double M11, double M12, double M13, double M14,
                double M21, double M22, double M23, double M24,
                double M31, double M32, double M33, double M34,
                double M41, double M42, double M43, double M44)
                Scale4x4SIMDDouble2(
                (double M11, double M12, double M13, double M14,
                double M21, double M22, double M23, double M24,
                double M31, double M32, double M33, double M34,
                double M41, double M42, double M43, double M44) matrix, double scalar)
            {
#if HAS_INTRINSICS
                if (Sse2.IsSupported)
                {
                    var value2Vec = Vector128.Create(scalar);
                    Sse2.Store(&matrix.M11, Sse2.Multiply(Sse2.LoadVector128(&matrix.M11), value2Vec));
                    Sse2.Store(&matrix.M13, Sse2.Multiply(Sse2.LoadVector128(&matrix.M13), value2Vec));
                    Sse2.Store(&matrix.M21, Sse2.Multiply(Sse2.LoadVector128(&matrix.M21), value2Vec));
                    Sse2.Store(&matrix.M23, Sse2.Multiply(Sse2.LoadVector128(&matrix.M23), value2Vec));
                    Sse2.Store(&matrix.M31, Sse2.Multiply(Sse2.LoadVector128(&matrix.M31), value2Vec));
                    Sse2.Store(&matrix.M33, Sse2.Multiply(Sse2.LoadVector128(&matrix.M33), value2Vec));
                    Sse2.Store(&matrix.M41, Sse2.Multiply(Sse2.LoadVector128(&matrix.M41), value2Vec));
                    Sse2.Store(&matrix.M43, Sse2.Multiply(Sse2.LoadVector128(&matrix.M43), value2Vec));
                    return matrix;
                }
#endif
                (double M11, double M12, double M13, double M14,
                double M21, double M22, double M23, double M24,
                double M31, double M32, double M33, double M34,
                double M41, double M42, double M43, double M44) m;
                m.M11 = matrix.M11 * scalar;
                m.M12 = matrix.M12 * scalar;
                m.M13 = matrix.M13 * scalar;
                m.M14 = matrix.M14 * scalar;
                m.M21 = matrix.M21 * scalar;
                m.M22 = matrix.M22 * scalar;
                m.M23 = matrix.M23 * scalar;
                m.M24 = matrix.M24 * scalar;
                m.M31 = matrix.M31 * scalar;
                m.M32 = matrix.M32 * scalar;
                m.M33 = matrix.M33 * scalar;
                m.M34 = matrix.M34 * scalar;
                m.M41 = matrix.M41 * scalar;
                m.M42 = matrix.M42 * scalar;
                m.M43 = matrix.M43 * scalar;
                m.M44 = matrix.M44 * scalar;
                return m;
            };
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value.
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
        /// <param name="value2">The scaling factor.</param>
        /// <returns>
        /// The scaled matrix.
        /// </returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe (
            float M11, float M12, float M13, float M14,
            float M21, float M22, float M23, float M24,
            float M31, float M32, float M33, float M34,
            float M41, float M42, float M43, float M44)
            Scale4x4SIMDFloat(
            float M11, float M12, float M13, float M14,
            float M21, float M22, float M23, float M24,
            float M31, float M32, float M33, float M34,
            float M41, float M42, float M43, float M44, float value2)
        {
#if HAS_INTRINSICS
            if (Sse.IsSupported)
            {
                var value2Vec = Vector128.Create(value2);
                Sse.Store(&M11, Sse.Multiply(Sse.LoadVector128(&M11), value2Vec));
                Sse.Store(&M21, Sse.Multiply(Sse.LoadVector128(&M21), value2Vec));
                Sse.Store(&M31, Sse.Multiply(Sse.LoadVector128(&M31), value2Vec));
                Sse.Store(&M41, Sse.Multiply(Sse.LoadVector128(&M41), value2Vec));
                return (M11, M12, M13, M14,
                         M21, M22, M23, M24,
                         M31, M32, M33, M34,
                         M41, M42, M43, M44);
            }
#endif
            (float M11, float M12, float M13, float M14,
            float M21, float M22, float M23, float M24,
            float M31, float M32, float M33, float M34,
            float M41, float M42, float M43, float M44) m;
            m.M11 = M11 * value2;
            m.M12 = M12 * value2;
            m.M13 = M13 * value2;
            m.M14 = M14 * value2;
            m.M21 = M21 * value2;
            m.M22 = M22 * value2;
            m.M23 = M23 * value2;
            m.M24 = M24 * value2;
            m.M31 = M31 * value2;
            m.M32 = M32 * value2;
            m.M33 = M33 * value2;
            m.M34 = M34 * value2;
            m.M41 = M41 * value2;
            m.M42 = M42 * value2;
            m.M43 = M43 * value2;
            m.M44 = M44 * value2;
            return m;
        }
    }
}
