using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class IsMatrixIdentity4x4Tests
    {
        /// <summary>
        /// Tests whether or not a given transform is an identity transform matrix.
        /// </summary>
        /// <param name="m0x0"></param>
        /// <param name="m0x1"></param>
        /// <param name="m0x2"></param>
        /// <param name="m0x3"></param>
        /// <param name="m1x0"></param>
        /// <param name="m1x1"></param>
        /// <param name="m1x2"></param>
        /// <param name="m1x3"></param>
        /// <param name="m2x0"></param>
        /// <param name="m2x1"></param>
        /// <param name="m2x2"></param>
        /// <param name="m2x3"></param>
        /// <param name="m3x0"></param>
        /// <param name="m3x1"></param>
        /// <param name="m3x2"></param>
        /// <param name="m3x3"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity(
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
        /// <returns></returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
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
