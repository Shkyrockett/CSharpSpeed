using CSharpSpeed;
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
    [DisplayName("Matrix Adjoint")]
    [Description("Adjoint Matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixAdjoint4x4Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixDeterminant2x2Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix4x4ElevensTuple;
            var b = MatrixTestCases.Matrix4x4IncrementalTuple;
            var c = MatrixTestCases.Matrix4x4IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m4x1, a.m4x2, a.m4x3, a.m4x4 }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue: (0d, -0d, 0d, -0d, -0d, 0d, -0d, 0d, 0d, -0d, 0d, -0d, -0d, 0d, -0d, 0d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m4x1, b.m4x2, b.m4x3, b.m4x4 }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue: (0d, -0d, 0d, -0d, -0d, 0d, -0d, 0d, 0d, -0d, 0d, -0d, -0d, 0d, -0d, 0d), epsilon: double.Epsilon) },
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
        /// Adjoints the specified M1X1.
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
        public static (double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4) Adjoint(double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4)
            => Adjoint1(m1x1, m1x2, m1x3, m1x4, m2x1, m2x2, m2x3, m2x4, m3x1, m3x2, m3x3, m3x4, m4x1, m4x2, m4x3, m4x4);

        /// <summary>
        /// Used to generate the adjoint of this matrix.
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
        /// The adjoint matrix of the current instance.
        /// </returns>
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// This is an expanded version of the Ogre adjoint() method.
        /// </acknowledgment>
        [DisplayName("Matrix Adjoint")]
        [Description("Adjoint Matrix.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3
            ) Adjoint1(
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3)
        {
            var m22m33m32m23 = (m2x2 * m3x3) - (m3x2 * m2x3);
            var m21m33m31m23 = (m2x1 * m3x3) - (m3x1 * m2x3);
            var m21m32m31m22 = (m2x1 * m3x2) - (m3x1 * m2x2);

            var m12m33m32m13 = (m1x2 * m3x3) - (m3x2 * m1x3);
            var m11m33m31m13 = (m1x1 * m3x3) - (m3x1 * m1x3);
            var m11m32m31m12 = (m1x1 * m3x2) - (m3x1 * m1x2);

            var m12m23m22m13 = (m1x2 * m2x3) - (m2x2 * m1x3);
            var m11m23m21m13 = (m1x1 * m2x3) - (m2x1 * m1x3);
            var m11m22m21m12 = (m1x1 * m2x2) - (m2x1 * m1x2);

            var m20m33m30m23 = (m2x0 * m3x3) - (m3x0 * m2x3);
            var m20m32m30m22 = (m2x0 * m3x2) - (m3x0 * m2x2);
            var m10m33m30m13 = (m1x0 * m3x3) - (m3x0 * m1x3);

            var m10m32m30m12 = (m1x0 * m3x2) - (m3x0 * m1x2);
            var m10m23m20m13 = (m1x0 * m2x3) - (m2x0 * m1x3);
            var m10m22m20m12 = (m1x0 * m2x2) - (m2x0 * m1x2);

            var m20m31m30m21 = (m2x0 * m3x1) - (m3x0 * m2x1);
            var m10m31m30m11 = (m1x0 * m3x1) - (m3x0 * m1x1);
            var m10m21m20m11 = (m1x0 * m2x1) - (m2x0 * m1x1);

            return (
                  (m1x1 * m22m33m32m23) - (m1x2 * m21m33m31m23) + (m1x3 * m21m32m31m22), -((m0x1 * m22m33m32m23) - (m0x2 * m21m33m31m23) + (m0x3 * m21m32m31m22)),  (m0x1 * m12m33m32m13) - (m0x2 * m11m33m31m13) + (m0x3 * m11m32m31m12), -((m0x1 * m12m23m22m13) - (m0x2 * m11m23m21m13) + (m0x3 * m11m22m21m12)),
                -((m1x0 * m22m33m32m23) - (m1x2 * m20m33m30m23) + (m1x3 * m20m32m30m22)),  (m0x0 * m22m33m32m23) - (m0x2 * m20m33m30m23) + (m0x3 * m20m32m30m22), -((m0x0 * m12m33m32m13) - (m0x2 * m10m33m30m13) + (m0x3 * m10m32m30m12)),  (m0x0 * m12m23m22m13) - (m0x2 * m10m23m20m13) + (m0x3 * m10m22m20m12),
                  (m1x0 * m21m33m31m23) - (m1x1 * m20m33m30m23) + (m1x3 * m20m31m30m21), -((m0x0 * m21m33m31m23) - (m0x1 * m20m33m30m23) + (m0x3 * m20m31m30m21)),  (m0x0 * m11m33m31m13) - (m0x1 * m10m33m30m13) + (m0x3 * m10m31m30m11), -((m0x0 * m11m23m21m13) - (m0x1 * m10m23m20m13) + (m0x3 * m10m21m20m11)),
                -((m1x0 * m21m32m31m22) - (m1x1 * m20m32m30m22) + (m1x2 * m20m31m30m21)),  (m0x0 * m21m32m31m22) - (m0x1 * m20m32m30m22) + (m0x2 * m20m31m30m21), -((m0x0 * m11m32m31m12) - (m0x1 * m10m32m30m12) + (m0x2 * m10m31m30m11)),  (m0x0 * m11m22m21m12) - (m0x1 * m10m22m20m12) + (m0x2 * m10m21m20m11));
        }
    }
}
