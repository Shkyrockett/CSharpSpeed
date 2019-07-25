using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
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
        /// 
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(MatrixDeterminant4x4Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d, 12d, 13d, 14d, 15d, 16d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.5d, 1d, 1.5d, 2d, 2.5d, 3d, 3.5d, 4d, 4.5d, 5d, 5.5d, 6d, 6.5d, 7d, 7.5d, 8d), epsilon: double.Epsilon) },
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
        /// <param name="M11"></param>
        /// <param name="M12"></param>
        /// <param name="M13"></param>
        /// <param name="M14"></param>
        /// <param name="M21"></param>
        /// <param name="M22"></param>
        /// <param name="M23"></param>
        /// <param name="M24"></param>
        /// <param name="M31"></param>
        /// <param name="M32"></param>
        /// <param name="M33"></param>
        /// <param name="M34"></param>
        /// <param name="M41"></param>
        /// <param name="M42"></param>
        /// <param name="M43"></param>
        /// <param name="M44"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static unsafe (double M11, double M12, double M13, double M14, double M21, double M22, double M23, double M24, double M31, double M32, double M33, double M34, double M41, double M42, double M43, double M44) Scale4x4Double(double M11, double M12, double M13, double M14, double M21, double M22, double M23, double M24, double M31, double M32, double M33, double M34, double M41, double M42, double M43, double M44, double value2)
            => Scale4x4(
                 M11, M12, M13, M14,
                 M21, M22, M23, M24,
                 M31, M32, M33, M34,
                 M41, M42, M43, M44, value2);

        /// <summary>
        /// Used to multiply (concatenate) two <see cref="Matrix4x4D"/>s.
        /// </summary>
        /// <param name="leftM0x0"></param>
        /// <param name="leftM0x1"></param>
        /// <param name="leftM0x2"></param>
        /// <param name="leftM0x3"></param>
        /// <param name="leftM1x0"></param>
        /// <param name="leftM1x1"></param>
        /// <param name="leftM1x2"></param>
        /// <param name="leftM1x3"></param>
        /// <param name="leftM2x0"></param>
        /// <param name="leftM2x1"></param>
        /// <param name="leftM2x2"></param>
        /// <param name="leftM2x3"></param>
        /// <param name="leftM3x0"></param>
        /// <param name="leftM3x1"></param>
        /// <param name="leftM3x2"></param>
        /// <param name="leftM3x3"></param>
        /// <param name="scalar"></param>
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
        /// 
        /// </summary>
        /// <param name="M11"></param>
        /// <param name="M12"></param>
        /// <param name="M13"></param>
        /// <param name="M14"></param>
        /// <param name="M21"></param>
        /// <param name="M22"></param>
        /// <param name="M23"></param>
        /// <param name="M24"></param>
        /// <param name="M31"></param>
        /// <param name="M32"></param>
        /// <param name="M33"></param>
        /// <param name="M34"></param>
        /// <param name="M41"></param>
        /// <param name="M42"></param>
        /// <param name="M43"></param>
        /// <param name="M44"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [DisplayName("Matrix Scale 4x4 Tests")]
        [Description("Matrix Scale 4x4 Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static unsafe (
        //    double M11, double M12, double M13, double M14,
        //    double M21, double M22, double M23, double M24,
        //    double M31, double M32, double M33, double M34,
        //    double M41, double M42, double M43, double M44)
        //    Scale4x4SIMDDouble(
        //    double M11, double M12, double M13, double M14,
        //    double M21, double M22, double M23, double M24,
        //    double M31, double M32, double M33, double M34,
        //    double M41, double M42, double M43, double M44, double value2)
        //    => Scale4x4SIMDDouble(
        //        (M11, M12, M13, M14,
        //         M21, M22, M23, M24,
        //         M31, M32, M33, M34,
        //         M41, M42, M43, M44), value2);

        /// <summary>
        /// Multiplies a matrix by a scalar value.
        /// </summary>
        /// <param name="value1">The source matrix.</param>
        /// <param name="value2">The scaling factor.</param>
        /// <returns>The scaled matrix.</returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        {
#if HAS_INTRINSICS
            if (Sse2.IsSupported)
            {
                var value2Vec = Vector128.Create(value2);
                Sse2.Store(&M11, Sse2.Multiply(Sse2.LoadVector128(&M11), value2Vec));
                Sse2.Store(&M21, Sse2.Multiply(Sse2.LoadVector128(&M21), value2Vec));
                Sse2.Store(&M31, Sse2.Multiply(Sse2.LoadVector128(&M31), value2Vec));
                Sse2.Store(&M41, Sse2.Multiply(Sse2.LoadVector128(&M41), value2Vec));
                return (M11, M12, M13, M14,
                         M21, M22, M23, M24,
                         M31, M32, M33, M34,
                         M41, M42, M43, M44);
            }
#endif
            (double M11, double M12, double M13, double M14,
            double M21, double M22, double M23, double M24,
            double M31, double M32, double M33, double M34,
            double M41, double M42, double M43, double M44) m;
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

        /// <summary>
        /// Multiplies a matrix by a scalar value.
        /// </summary>
        /// <param name="value1">The source matrix.</param>
        /// <param name="value2">The scaling factor.</param>
        /// <returns>The scaled matrix.</returns>
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
            (float M11, float M12, float M13, float M14,
            float M21, float M22, float M23, float M24,
            float M31, float M32, float M33, float M34,
            float M41, float M42, float M43, float M44) value1, float value2)
        {
#if HAS_INTRINSICS
            if (Sse.IsSupported)
            {
                var value2Vec = Vector128.Create(value2);
                Sse.Store(&value1.M11, Sse.Multiply(Sse.LoadVector128(&value1.M11), value2Vec));
                Sse.Store(&value1.M21, Sse.Multiply(Sse.LoadVector128(&value1.M21), value2Vec));
                Sse.Store(&value1.M31, Sse.Multiply(Sse.LoadVector128(&value1.M31), value2Vec));
                Sse.Store(&value1.M41, Sse.Multiply(Sse.LoadVector128(&value1.M41), value2Vec));
                return value1;
            }
#endif
            (float M11, float M12, float M13, float M14,
            float M21, float M22, float M23, float M24,
            float M31, float M32, float M33, float M34,
            float M41, float M42, float M43, float M44) m;
            m.M11 = value1.M11 * value2;
            m.M12 = value1.M12 * value2;
            m.M13 = value1.M13 * value2;
            m.M14 = value1.M14 * value2;
            m.M21 = value1.M21 * value2;
            m.M22 = value1.M22 * value2;
            m.M23 = value1.M23 * value2;
            m.M24 = value1.M24 * value2;
            m.M31 = value1.M31 * value2;
            m.M32 = value1.M32 * value2;
            m.M33 = value1.M33 * value2;
            m.M34 = value1.M34 * value2;
            m.M41 = value1.M41 * value2;
            m.M42 = value1.M42 * value2;
            m.M43 = value1.M43 * value2;
            m.M44 = value1.M44 * value2;
            return m;
        }
    }
}
