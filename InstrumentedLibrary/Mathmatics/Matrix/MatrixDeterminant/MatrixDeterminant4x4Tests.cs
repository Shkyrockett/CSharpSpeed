using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The matrix determinant4x4tests class.
    /// </summary>
    [DisplayName("Determinant of a 4x4 matrix")]
    [Description("Find the determinant of a 4x4 matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixDeterminant4x4Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m4x1, a.m4x2, a.m4x3, a.m4x4 }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m4x1, b.m4x2, b.m4x3, b.m4x4 }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m4x1, c.m4x2, c.m4x3, c.m4x4 }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
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
        /// Determinants the specified a.
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
        public static double Determinant(double m1x1, double m1x2, double m1x3, double m1x4, double m2x1, double m2x2, double m2x3, double m2x4, double m3x1, double m3x2, double m3x3, double m3x4, double m4x1, double m4x2, double m4x3, double m4x4)
            => GetDeterminant2(
                 m1x1, m1x2, m1x3, m1x4,
                 m2x1, m2x2, m2x3, m2x4,
                 m3x1, m3x2, m3x3, m3x4,
                 m4x1, m4x2, m4x3, m4x4);

        /// <summary>
        /// Find the determinant of a 4 by 4 matrix.
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
        /// <acknowledgment>
        /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
        /// </acknowledgment>
        [DisplayName("Determinant of a 4x4 matrix")]
        [Description("Jerry J. Chen's method for finding the determinant of a 4x4 matrix.")]
        [Acknowledgment("https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant0(
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
        {
            return (m1x1 * MatrixDeterminant3x3Tests.Determinant(m2x2, m2x3, m2x4, m3x2, m3x3, m3x4, m4x2, m4x3, m4x4))
                 - (m1x2 * MatrixDeterminant3x3Tests.Determinant(m2x1, m2x3, m2x4, m3x1, m3x3, m3x4, m4x1, m4x3, m4x4))
                 + (m1x3 * MatrixDeterminant3x3Tests.Determinant(m2x1, m2x2, m2x4, m3x1, m3x2, m3x4, m4x1, m4x2, m4x4))
                 - (m1x4 * MatrixDeterminant3x3Tests.Determinant(m2x1, m2x2, m2x3, m3x1, m3x2, m3x3, m4x1, m4x2, m4x3));
        }

        /// <summary>
        /// Calculates the determinant of the matrix.
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
        /// The determinant of the matrix.
        /// </returns>
        /// <remarks>
        /// https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs
        /// </remarks>
        [DisplayName("Determinant of a 4x4 matrix from .NET Core")]
        [Description("Determinant of a 4x4 matrix from .NET Core.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/System.Numerics.Vectors/src/System/Numerics/Matrix4x4.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetDeterminant(
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
        {
            // | a b c d |     | f g h |     | e g h |     | e f h |     | e f g |
            // | e f g h | = a | j k l | - b | i k l | + c | i j l | - d | i j k |
            // | i j k l |     | n o p |     | m o p |     | m n p |     | m n o |
            // | m n o p |
            //
            //   | f g h |
            // a | j k l | = a ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
            //   | n o p |
            //
            //   | e g h |     
            // b | i k l | = b ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
            //   | m o p |     
            //
            //   | e f h |
            // c | i j l | = c ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
            //   | m n p |
            //
            //   | e f g |
            // d | i j k | = d ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
            //   | m n o |
            //
            // Cost of operation
            // 17 adds and 28 muls.
            //
            // add: 6 + 8 + 3 = 17
            // mul: 12 + 16 = 28

            double a = m1x1, b = m1x2, c = m1x3, d = m1x4;
            double e = m2x1, f = m2x2, g = m2x3, h = m2x4;
            double i = m3x1, j = m3x2, k = m3x3, l = m3x4;
            double m = m4x1, n = m4x2, o = m4x3, p = m4x4;

            var kp_lo = k * p - l * o;
            var jp_ln = j * p - l * n;
            var jo_kn = j * o - k * n;
            var ip_lm = i * p - l * m;
            var io_km = i * o - k * m;
            var in_jm = i * n - j * m;

            return a * (f * kp_lo - g * jp_ln + h * jo_kn) -
                   b * (e * kp_lo - g * ip_lm + h * io_km) +
                   c * (e * jp_ln - f * ip_lm + h * in_jm) -
                   d * (e * jo_kn - f * io_km + g * in_jm);
        }

        /// <summary>
        /// Gets the determinant2.
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
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// This is an expanded version of the Ogre determinant() method, to give better performance in C#. Generated using a script.
        /// </acknowledgment>
        [DisplayName("Determinant of a 4x4 matrix")]
        [Description("Jonathan Mark Porter's method for finding the determinant of a 4x4 matrix.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetDeterminant2(
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
        {
            var m33m44m43m34 = (m3x3 * m4x4) - (m4x3 * m3x4);
            var m32m44m42m34 = (m3x2 * m4x4) - (m4x2 * m3x4);
            var m32m43m42m33 = (m3x2 * m4x3) - (m4x2 * m3x3);

            var m31m44m41m34 = (m3x1 * m4x4) - (m4x1 * m3x4);
            var m31m43m41m33 = (m3x1 * m4x3) - (m4x1 * m3x3);
            var m31m42m41m32 = (m3x1 * m4x2) - (m4x1 * m3x2);

            return (m1x1 * ((m2x2 * m33m44m43m34) - (m2x3 * m32m44m42m34) + (m2x4 * m32m43m42m33)))
                 - (m1x2 * ((m2x1 * m33m44m43m34) - (m2x3 * m31m44m41m34) + (m2x4 * m31m43m41m33)))
                 + (m1x3 * ((m2x1 * m32m44m42m34) - (m2x2 * m31m44m41m34) + (m2x4 * m31m42m41m32)))
                 - (m1x4 * ((m2x1 * m32m43m42m33) - (m2x2 * m31m43m41m33) + (m2x3 * m31m42m41m32)));
        }

        /// <summary>
        /// Gets the determinant2.
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
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// This is an expanded version of the Ogre determinant() method, to give better performance in C#.
        /// </acknowledgment>
        [DisplayName("Determinant of a 4x4 matrix")]
        [Description("Jonathan Mark Porter's method for finding the determinant of a 4x4 matrix. Inlined even more.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetDeterminant3(
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
        {
            return (m1x1 * ((m2x2 * ((m3x3 * m4x4) - (m4x3 * m3x4))) - (m2x3 * ((m3x2 * m4x4) - (m4x2 * m3x4))) + (m2x4 * ((m3x2 * m4x3) - (m4x2 * m3x3)))))
                 - (m1x2 * ((m2x1 * ((m3x3 * m4x4) - (m4x3 * m3x4))) - (m2x3 * ((m3x1 * m4x4) - (m4x1 * m3x4))) + (m2x4 * ((m3x1 * m4x3) - (m4x1 * m3x3)))))
                 + (m1x3 * ((m2x1 * ((m3x2 * m4x4) - (m4x2 * m3x4))) - (m2x2 * ((m3x1 * m4x4) - (m4x1 * m3x4))) + (m2x4 * ((m3x1 * m4x2) - (m4x1 * m3x2)))))
                 - (m1x4 * ((m2x1 * ((m3x2 * m4x3) - (m4x2 * m3x3))) - (m2x2 * ((m3x1 * m4x3) - (m4x1 * m3x3))) + (m2x3 * ((m3x1 * m4x2) - (m4x1 * m3x2)))));
        }
    }
}
