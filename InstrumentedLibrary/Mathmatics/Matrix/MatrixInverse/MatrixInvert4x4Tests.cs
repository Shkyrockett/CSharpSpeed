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
    [DisplayName("Matrix Invert 4x4 Tests")]
    [Description("Matrix Invert 4x4 Tests.")]
    [SourceCodeLocationProvider]
    public static class MatrixInvert4x4Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixInverseDeterminant4x4Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix4x4ElevensTuple;
            var b = MatrixTestCases.Matrix4x4IncrementalTuple;
            var c = MatrixTestCases.Matrix4x4IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m4x1, a.m4x2, a.m4x3, a.m4x4 }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue: (double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m4x1, b.m4x2, b.m4x3, b.m4x4 }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue: (double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m4x1, c.m4x2, c.m4x3, c.m4x4 }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue: (1d, -0d, 0d, -0d, -0d, 1d, -0d, 0d, 0d, -0d, 1d, -0d, -0d, 0d, -0d, 1d), epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4) Invert(double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4)
            => Invert1(
                 m1x1, m1x2, m1x3, m1x4,
                 m2x1, m2x2, m2x3, m2x4,
                 m3x1, m3x2, m3x3, m3x4,
                 m4x1, m4x2, m4x3, m4x4);

        /// <summary>
        /// Invert1s the specified M1X1.
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
        /// <returns></returns>
        [DisplayName("Inversion of a 4x4 matrix")]
        [Description("Jonathan Mark Porter's method for finding the inversion of a 4x4 matrix.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4
            ) Invert1(
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
        {
            var m22m33m32m23 = (m3x3 * m4x4) - (m4x3 * m3x4);
            var m21m33m31m23 = (m3x2 * m4x4) - (m4x2 * m3x4);
            var m21m32m31m22 = (m3x2 * m4x3) - (m4x2 * m3x3);

            var m12m33m32m13 = (m2x3 * m4x4) - (m4x3 * m2x4);
            var m11m33m31m13 = (m2x2 * m4x4) - (m4x2 * m2x4);
            var m11m32m31m12 = (m2x2 * m4x3) - (m4x2 * m2x3);

            var m12m23m22m13 = (m2x3 * m3x4) - (m3x3 * m2x4);
            var m11m23m21m13 = (m2x2 * m3x4) - (m3x2 * m2x4);
            var m11m22m21m12 = (m2x2 * m3x3) - (m3x2 * m2x3);

            var m20m33m30m23 = (m3x1 * m4x4) - (m4x1 * m3x4);
            var m20m32m30m22 = (m3x1 * m4x3) - (m4x1 * m3x3);
            var m10m33m30m13 = (m2x1 * m4x4) - (m4x1 * m2x4);

            var m10m32m30m12 = (m2x1 * m4x3) - (m4x1 * m2x3);
            var m10m23m20m13 = (m2x1 * m3x4) - (m3x1 * m2x4);
            var m10m22m20m12 = (m2x1 * m3x3) - (m3x1 * m2x3);

            var m20m31m30m21 = (m3x1 * m4x2) - (m4x1 * m3x2);
            var m10m31m30m11 = (m2x1 * m4x2) - (m4x1 * m2x2);
            var m10m21m20m11 = (m2x1 * m3x2) - (m3x1 * m2x2);

            var detInv = 1d /
            ((m1x1 * ((m2x2 * m22m33m32m23) - (m2x3 * m21m33m31m23) + (m2x4 * m21m32m31m22))) -
            (m1x2 * ((m2x1 * m22m33m32m23) - (m2x3 * m20m33m30m23) + (m2x4 * m20m32m30m22))) +
            (m1x3 * ((m2x1 * m21m33m31m23) - (m2x2 * m20m33m30m23) + (m2x4 * m20m31m30m21))) -
            (m1x4 * ((m2x1 * m21m32m31m22) - (m2x2 * m20m32m30m22) + (m2x3 * m20m31m30m21))));

            return (
                detInv * ((m2x2 * m22m33m32m23) - (m2x3 * m21m33m31m23) + (m2x4 * m21m32m31m22)), detInv * (-((m1x2 * m22m33m32m23) - (m1x3 * m21m33m31m23) + (m1x4 * m21m32m31m22))), detInv * ((m1x2 * m12m33m32m13) - (m1x3 * m11m33m31m13) + (m1x4 * m11m32m31m12)), detInv * (-((m1x2 * m12m23m22m13) - (m1x3 * m11m23m21m13) + (m1x4 * m11m22m21m12))),
                detInv * (-((m2x1 * m22m33m32m23) - (m2x3 * m20m33m30m23) + (m2x4 * m20m32m30m22))), detInv * ((m1x1 * m22m33m32m23) - (m1x3 * m20m33m30m23) + (m1x4 * m20m32m30m22)), detInv * (-((m1x1 * m12m33m32m13) - (m1x3 * m10m33m30m13) + (m1x4 * m10m32m30m12))), detInv * ((m1x1 * m12m23m22m13) - (m1x3 * m10m23m20m13) + (m1x4 * m10m22m20m12)),
                detInv * ((m2x1 * m21m33m31m23) - (m2x2 * m20m33m30m23) + (m2x4 * m20m31m30m21)), detInv * (-((m1x1 * m21m33m31m23) - (m1x2 * m20m33m30m23) + (m1x4 * m20m31m30m21))), detInv * ((m1x1 * m11m33m31m13) - (m1x2 * m10m33m30m13) + (m1x4 * m10m31m30m11)), detInv * (-((m1x1 * m11m23m21m13) - (m1x2 * m10m23m20m13) + (m1x4 * m10m21m20m11))),
                detInv * (-((m2x1 * m21m32m31m22) - (m2x2 * m20m32m30m22) + (m2x3 * m20m31m30m21))), detInv * ((m1x1 * m21m32m31m22) - (m1x2 * m20m32m30m22) + (m1x3 * m20m31m30m21)), detInv * (-((m1x1 * m11m32m31m12) - (m1x2 * m10m32m30m12) + (m1x3 * m10m31m30m11))), detInv * ((m1x1 * m11m22m21m12) - (m1x2 * m10m22m20m12) + (m1x3 * m10m21m20m11)));
        }

        /// <summary>
        /// Attempts to calculate the inverse of the given matrix. If successful, result will contain the inverted matrix.
        /// </summary>
        /// <param name="m1x1">The M11.</param>
        /// <param name="m1x2">The M12.</param>
        /// <param name="m1x3">The M13.</param>
        /// <param name="m1x4">The M14.</param>
        /// <param name="m2x1">The M21.</param>
        /// <param name="m2x2">The M22.</param>
        /// <param name="m2x3">The M23.</param>
        /// <param name="m2x4">The M24.</param>
        /// <param name="m3x1">The M31.</param>
        /// <param name="m3x2">The M32.</param>
        /// <param name="m3x3">The M33.</param>
        /// <param name="m3x4">The M34.</param>
        /// <param name="m4x1">The M41.</param>
        /// <param name="m4x2">The M42.</param>
        /// <param name="m4x3">The M43.</param>
        /// <param name="m4x4">The M44.</param>
        /// <returns>
        /// True if the source matrix could be inverted; False otherwise.
        /// </returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
        [DisplayName("Matrix Invert 4x4 Tests")]
        [Description("Matrix Invert 4x4 Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4
            ) InvertDotNet(
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
        {
            //                                       -1
            // If you have matrix M, inverse Matrix M   can compute
            //
            //     -1       1      
            //    M   = --------- A
            //            det(M)
            //
            // A is adjugate (adjoint) of M, where,
            //
            //      T
            // A = C
            //
            // C is Cofactor matrix of M, where,
            //           i + j
            // C   = (-1)      * det(M  )
            //  ij                    ij
            //
            //     [ a b c d ]
            // M = [ e f g h ]
            //     [ i j k l ]
            //     [ m n o p ]
            //
            // First Row
            //           2 | f g h |
            // C   = (-1)  | j k l | = + ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
            //  11         | n o p |
            //
            //           3 | e g h |
            // C   = (-1)  | i k l | = - ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
            //  12         | m o p |
            //
            //           4 | e f h |
            // C   = (-1)  | i j l | = + ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
            //  13         | m n p |
            //
            //           5 | e f g |
            // C   = (-1)  | i j k | = - ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
            //  14         | m n o |
            //
            // Second Row
            //           3 | b c d |
            // C   = (-1)  | j k l | = - ( b ( kp - lo ) - c ( jp - ln ) + d ( jo - kn ) )
            //  21         | n o p |
            //
            //           4 | a c d |
            // C   = (-1)  | i k l | = + ( a ( kp - lo ) - c ( ip - lm ) + d ( io - km ) )
            //  22         | m o p |
            //
            //           5 | a b d |
            // C   = (-1)  | i j l | = - ( a ( jp - ln ) - b ( ip - lm ) + d ( in - jm ) )
            //  23         | m n p |
            //
            //           6 | a b c |
            // C   = (-1)  | i j k | = + ( a ( jo - kn ) - b ( io - km ) + c ( in - jm ) )
            //  24         | m n o |
            //
            // Third Row
            //           4 | b c d |
            // C   = (-1)  | f g h | = + ( b ( gp - ho ) - c ( fp - hn ) + d ( fo - gn ) )
            //  31         | n o p |
            //
            //           5 | a c d |
            // C   = (-1)  | e g h | = - ( a ( gp - ho ) - c ( ep - hm ) + d ( eo - gm ) )
            //  32         | m o p |
            //
            //           6 | a b d |
            // C   = (-1)  | e f h | = + ( a ( fp - hn ) - b ( ep - hm ) + d ( en - fm ) )
            //  33         | m n p |
            //
            //           7 | a b c |
            // C   = (-1)  | e f g | = - ( a ( fo - gn ) - b ( eo - gm ) + c ( en - fm ) )
            //  34         | m n o |
            //
            // Fourth Row
            //           5 | b c d |
            // C   = (-1)  | f g h | = - ( b ( gl - hk ) - c ( fl - hj ) + d ( fk - gj ) )
            //  41         | j k l |
            //
            //           6 | a c d |
            // C   = (-1)  | e g h | = + ( a ( gl - hk ) - c ( el - hi ) + d ( ek - gi ) )
            //  42         | i k l |
            //
            //           7 | a b d |
            // C   = (-1)  | e f h | = - ( a ( fl - hj ) - b ( el - hi ) + d ( ej - fi ) )
            //  43         | i j l |
            //
            //           8 | a b c |
            // C   = (-1)  | e f g | = + ( a ( fk - gj ) - b ( ek - gi ) + c ( ej - fi ) )
            //  44         | i j k |
            //
            // Cost of operation
            // 53 adds, 104 muls, and 1 div.
            double a = m1x1, b = m1x2, c = m1x3, d = m1x4;
            double e = m2x1, f = m2x2, g = m2x3, h = m2x4;
            double i = m3x1, j = m3x2, k = m3x3, l = m3x4;
            double m = m4x1, n = m4x2, o = m4x3, p = m4x4;

            var kp_lo = (k * p) - (l * o);
            var jp_ln = (j * p) - (l * n);
            var jo_kn = (j * o) - (k * n);
            var ip_lm = (i * p) - (l * m);
            var io_km = (i * o) - (k * m);
            var in_jm = (i * n) - (j * m);

            var a11 = +((f * kp_lo) - (g * jp_ln) + (h * jo_kn));
            var a12 = -((e * kp_lo) - (g * ip_lm) + (h * io_km));
            var a13 = +((e * jp_ln) - (f * ip_lm) + (h * in_jm));
            var a14 = -((e * jo_kn) - (f * io_km) + (g * in_jm));

            var det = (a * a11) + (b * a12) + (c * a13) + (d * a14);

            if (Math.Abs(det) < double.Epsilon)
            {
                return (float.NaN, float.NaN, float.NaN, float.NaN,
                            float.NaN, float.NaN, float.NaN, float.NaN,
                            float.NaN, float.NaN, float.NaN, float.NaN,
                            float.NaN, float.NaN, float.NaN, float.NaN);
            }

            var invDet = 1.0d / det;

            (double m11, double m12, double m13, double m14,
            double m21, double m22, double m23, double m24,
            double m31, double m32, double m33, double m34,
            double m41, double m42, double m43, double m44) result;

            result.m11 = a11 * invDet;
            result.m21 = a12 * invDet;
            result.m31 = a13 * invDet;
            result.m41 = a14 * invDet;

            result.m12 = -((b * kp_lo) - (c * jp_ln) + (d * jo_kn)) * invDet;
            result.m22 = +((a * kp_lo) - (c * ip_lm) + (d * io_km)) * invDet;
            result.m32 = -((a * jp_ln) - (b * ip_lm) + (d * in_jm)) * invDet;
            result.m42 = +((a * jo_kn) - (b * io_km) + (c * in_jm)) * invDet;

            var gp_ho = (g * p) - (h * o);
            var fp_hn = (f * p) - (h * n);
            var fo_gn = (f * o) - (g * n);
            var ep_hm = (e * p) - (h * m);
            var eo_gm = (e * o) - (g * m);
            var en_fm = (e * n) - (f * m);

            result.m13 = +((b * gp_ho) - (c * fp_hn) + (d * fo_gn)) * invDet;
            result.m23 = -((a * gp_ho) - (c * ep_hm) + (d * eo_gm)) * invDet;
            result.m33 = +((a * fp_hn) - (b * ep_hm) + (d * en_fm)) * invDet;
            result.m43 = -((a * fo_gn) - (b * eo_gm) + (c * en_fm)) * invDet;

            var gl_hk = (g * l) - (h * k);
            var fl_hj = (f * l) - (h * j);
            var fk_gj = (f * k) - (g * j);
            var el_hi = (e * l) - (h * i);
            var ek_gi = (e * k) - (g * i);
            var ej_fi = (e * j) - (f * i);

            result.m14 = -((b * gl_hk) - (c * fl_hj) + (d * fk_gj)) * invDet;
            result.m24 = +((a * gl_hk) - (c * el_hi) + (d * ek_gi)) * invDet;
            result.m34 = -((a * fl_hj) - (b * el_hi) + (d * ej_fi)) * invDet;
            result.m44 = +((a * fk_gj) - (b * ek_gi) + (c * ej_fi)) * invDet;

            return result;
        }
    }
}
