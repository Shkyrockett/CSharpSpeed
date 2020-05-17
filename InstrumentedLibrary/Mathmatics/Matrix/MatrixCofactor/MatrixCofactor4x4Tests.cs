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
    [DisplayName("Cofactor of a 4x4 matrix")]
    [Description("Find the cofactor of a 4x4 matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixCofactor4x4Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m4x1, a.m4x2, a.m4x3, a.m4x4 }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue: (-0d, 0d, -0d, 0d, 0d, -0d, 0d, -0d, -0d, 0d, 0d, 0d, 0d, -0d, 0d, -0d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m4x1, b.m4x2, b.m4x3, b.m4x4 }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue: (-0d, 0d, -0d, 0d, 0d, -0d, 0d, -0d, -0d, 0d, -0d, 0d, 0d, -0d, 0d, -0d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m4x1, c.m4x2, c.m4x3, c.m4x4 }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue: (-1d, 0d, -0d, 0d, 0d, -1d, 0d, -0d, -0d, 0d, -1d, 0d, 0d, -0d, 0d, -1d), epsilon: double.Epsilon) },
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
        /// Cofactors the specified M1X1.
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
        public static (double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4) Cofactor(double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4)
            => CofactorMatrix(
                 m1x1, m1x2, m1x3, m1x4,
                 m2x1, m2x2, m2x3, m2x4,
                 m3x1, m3x2, m3x3, m3x4,
                 m4x1, m4x2, m4x3, m4x4);

        /// <summary>
        /// The cofactor.
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
        /// The <see cref="Matrix4x4D" />.
        /// </returns>
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// This is an expanded version of the Ogre determinant() method, to give better performance in C#.
        /// </acknowledgment>
        [DisplayName("Cofactor of a 4x4 matrix")]
        [Description("Jonathan Mark Porter's method for finding the cofactor of a 4x4 matrix.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4
            ) CofactorMatrix(
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
        {
            var m33m44m43m34 = (m3x3 * m4x4) - (m4x3 * m3x4);
            var m32m44m42m34 = (m3x2 * m4x4) - (m4x2 * m3x4);
            var m32m43m42m33 = (m3x2 * m4x3) - (m4x2 * m3x3);
            var m23m44m43m24 = (m2x3 * m4x4) - (m4x3 * m2x4);

            var m22m44m42m24 = (m2x2 * m4x4) - (m4x2 * m2x4);
            var m22m43m42m23 = (m2x2 * m4x3) - (m4x2 * m2x3);
            var m23m34m33m24 = (m2x3 * m3x4) - (m3x3 * m2x4);
            var m22m34m32m24 = (m2x2 * m3x4) - (m3x2 * m2x4);

            var m22m33m32m23 = (m2x2 * m3x3) - (m3x2 * m2x3);
            var m31m44m41m34 = (m3x1 * m4x4) - (m4x1 * m3x4);
            var m31m43m41m33 = (m3x1 * m4x3) - (m4x1 * m3x3);
            var m21m44m41m24 = (m2x1 * m4x4) - (m4x1 * m2x4);

            var m21m43m41m23 = (m2x1 * m4x3) - (m4x1 * m2x3);
            var m21m34m31m24 = (m2x1 * m3x4) - (m3x1 * m2x4);
            var m21m33m31m23 = (m2x1 * m3x3) - (m3x1 * m2x3);
            var m31m42m41m32 = (m3x1 * m4x2) - (m4x1 * m3x2);

            var m21m42m41m22 = (m2x1 * m4x2) - (m4x1 * m2x2);
            var m21m32m31m22 = (m2x1 * m3x2) - (m3x1 * m2x2);

            return (
                -((m2x2 * m33m44m43m34) - (m2x3 * m32m44m42m34) + (m2x4 * m32m43m42m33)), (m1x2 * m33m44m43m34) - (m1x3 * m32m44m42m34) + (m1x4 * m32m43m42m33), -((m1x2 * m23m44m43m24) - (m1x3 * m22m44m42m24) + (m1x4 * m22m43m42m23)), (m1x2 * m23m34m33m24) - (m1x3 * m22m34m32m24) + (m1x4 * m22m33m32m23),
                (m2x1 * m33m44m43m34) - (m2x3 * m31m44m41m34) + (m2x4 * m31m43m41m33), -((m1x1 * m33m44m43m34) - (m1x3 * m31m44m41m34) + (m1x4 * m31m43m41m33)), (m1x1 * m23m44m43m24) - (m1x3 * m21m44m41m24) + (m1x4 * m21m43m41m23), -((m1x1 * m23m34m33m24) - (m1x3 * m21m34m31m24) + (m1x4 * m21m33m31m23)),
                -((m2x1 * m32m44m42m34) - (m2x2 * m31m44m41m34) + (m2x4 * m31m42m41m32)), (m1x1 * m32m44m42m34) - (m1x2 * m31m44m41m34) + (m1x4 * m31m42m41m32), -((m1x1 * m22m44m42m24) - (m1x2 * m21m44m41m24) + (m1x4 * m21m42m41m22)), (m1x1 * m22m34m32m24) - (m1x2 * m21m34m31m24) + (m1x4 * m21m32m31m22),
                (m2x1 * m32m43m42m33) - (m2x2 * m31m43m41m33) + (m2x3 * m31m42m41m32), -((m1x1 * m32m43m42m33) - (m1x2 * m31m43m41m33) + (m1x3 * m31m42m41m32)), (m1x1 * m22m43m42m23) - (m1x2 * m21m43m41m23) + (m1x3 * m21m42m41m22), -((m1x1 * m22m33m32m23) - (m1x2 * m21m33m31m23) + (m1x3 * m21m32m31m22)));
        }

        /// <summary>
        /// The cofactor.
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
        /// The <see cref="Matrix4x4D" />.
        /// </returns>
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// This is an expanded version of the Ogre determinant() method, to give better performance in C#.
        /// </acknowledgment>
        [DisplayName("Cofactor of a 4x4 matrix")]
        [Description("Jonathan Mark Porter's method for finding the cofactor of a 4x4 matrix. Inlined even more.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4
            ) CofactorMatrix2(
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
        {
            return (
                -((m2x2 * ((m3x3 * m4x4) - (m4x3 * m3x4))) - (m2x3 * ((m3x2 * m4x4) - (m4x2 * m3x4))) + (m2x4 * ((m3x2 * m4x3) - (m4x2 * m3x3)))), (m1x2 * ((m3x3 * m4x4) - (m4x3 * m3x4))) - (m1x3 * ((m3x2 * m4x4) - (m4x2 * m3x4))) + (m1x4 * ((m3x2 * m4x3) - (m4x2 * m3x3))), -((m1x2 * ((m2x3 * m4x4) - (m4x3 * m2x4))) - (m1x3 * ((m2x2 * m4x4) - (m4x2 * m2x4))) + (m1x4 * ((m2x2 * m4x3) - (m4x2 * m2x3)))), (m1x2 * ((m2x3 * m3x4) - (m3x3 * m2x4))) - (m1x3 * ((m2x2 * m3x4) - (m3x2 * m2x4))) + (m1x4 * ((m2x2 * m3x3) - (m3x2 * m2x3))),
                (m2x1 * ((m3x3 * m4x4) - (m4x3 * m3x4))) - (m2x3 * ((m3x1 * m4x4) - (m4x1 * m3x4))) + (m2x4 * ((m3x1 * m4x3) - (m4x1 * m3x3))), -((m1x1 * ((m3x3 * m4x4) - (m4x3 * m3x4))) - (m1x3 * ((m3x1 * m4x4) - (m4x1 * m3x4))) + (m1x4 * ((m3x1 * m4x3) - (m4x1 * m3x3)))), (m1x1 * ((m2x3 * m4x4) - (m4x3 * m2x4))) - (m1x3 * ((m2x1 * m4x4) - (m4x1 * m2x4))) + (m1x4 * ((m2x1 * m4x3) - (m4x1 * m2x3))), -((m1x1 * ((m2x3 * m3x4) - (m3x3 * m2x4))) - (m1x3 * ((m2x1 * m3x4) - (m3x1 * m2x4))) + (m1x4 * ((m2x1 * m3x3) - (m3x1 * m2x3)))),
                -((m2x1 * ((m3x2 * m4x4) - (m4x2 * m3x4))) - (m2x2 * ((m3x1 * m4x4) - (m4x1 * m3x4))) + (m2x4 * ((m3x1 * m4x2) - (m4x1 * m3x2)))), (m1x1 * ((m3x2 * m4x4) - (m4x2 * m3x4))) - (m1x2 * ((m3x1 * m4x4) - (m4x1 * m3x4))) + (m1x4 * ((m3x1 * m4x2) - (m4x1 * m3x2))), -((m1x1 * ((m2x2 * m4x4) - (m4x2 * m2x4))) - (m1x2 * ((m2x1 * m4x4) - (m4x1 * m2x4))) + (m1x4 * ((m2x1 * m4x2) - (m4x1 * m2x2)))), (m1x1 * ((m2x2 * m3x4) - (m3x2 * m2x4))) - (m1x2 * ((m2x1 * m3x4) - (m3x1 * m2x4))) + (m1x4 * ((m2x1 * m3x2) - (m3x1 * m2x2))),
                (m2x1 * ((m3x2 * m4x3) - (m4x2 * m3x3))) - (m2x2 * ((m3x1 * m4x3) - (m4x1 * m3x3))) + (m2x3 * ((m3x1 * m4x2) - (m4x1 * m3x2))), -((m1x1 * ((m3x2 * m4x3) - (m4x2 * m3x3))) - (m1x2 * ((m3x1 * m4x3) - (m4x1 * m3x3))) + (m1x3 * ((m3x1 * m4x2) - (m4x1 * m3x2)))), (m1x1 * ((m2x2 * m4x3) - (m4x2 * m2x3))) - (m1x2 * ((m2x1 * m4x3) - (m4x1 * m2x3))) + (m1x3 * ((m2x1 * m4x2) - (m4x1 * m2x2))), -((m1x1 * ((m2x2 * m3x3) - (m3x2 * m2x3))) - (m1x2 * ((m2x1 * m3x3) - (m3x1 * m2x3))) + (m1x3 * ((m2x1 * m3x2) - (m3x1 * m2x2)))));
        }
    }
}
