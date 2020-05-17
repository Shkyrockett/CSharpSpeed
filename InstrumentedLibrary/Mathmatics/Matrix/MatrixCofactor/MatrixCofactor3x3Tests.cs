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
    [DisplayName("Cofactor of a 3x3 matrix")]
    [Description("Find the cofactor of a 3x3 matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixCofactor3x3Tests
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
            var a = MatrixTestCases.Matrix3x3ElevensTuple;
            var b = MatrixTestCases.Matrix3x3IncrementalTuple;
            var c = MatrixTestCases.Matrix3x3IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m2x1, a.m2x2, a.m2x3, a.m3x1, a.m3x2, a.m3x3 }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue: (10d, -20d, 10d, -20d, 40d, -20d, 10d, -20d, 10d), epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m2x1, b.m2x2, b.m2x3, b.m3x1, b.m3x2, b.m3x3 }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue: (3d, -6d, 3d, -6d, 12d, -6d, 3d, -6d, 3d), epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m2x1, c.m2x2, c.m2x3, c.m3x1, c.m3x2, c.m3x3 }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue: (-1d, 0d, -0d, 0d, -1d, 0d, -0d, 0d, -1d), epsilon: double.Epsilon) },
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
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3) Cofactor(double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3)
            => CofactorMatrix(
                 m1x1, m1x2, m1x3,
                 m2x1, m2x2, m2x3,
                 m3x1, m3x2, m3x3);

        /// <summary>
        /// Gets the cofactor.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// This is an expanded version of the Ogre determinant() method, to give better performance in C#. Generated using a script.
        /// </acknowledgment>
        [DisplayName("Cofactor of a 3x3 matrix")]
        [Description("Jonathan Mark Porter's method for finding the cofactor of a 3x3 matrix.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3) GetCofactor(double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3)
        {
            var m22m33m23m32 = (m2x2 * m3x3) - (m2x3 * m3x2);
            var m21m33m23m31 = (m2x1 * m3x3) - (m2x3 * m3x1);
            var m21m32m22m31 = (m2x1 * m3x2) - (m2x2 * m3x1);

            return (-m22m33m23m32, (m1x2 * m3x3) - (m1x3 * m3x2), -((m1x2 * m2x3) - (m1x3 * m2x2)),
                    m21m33m23m31, -((m1x1 * m3x3) - (m1x3 * m3x1)), (m1x1 * m2x3) - (m1x3 * m2x1),
                    -m21m32m22m31, (m1x1 * m3x2) - (m1x2 * m3x1), -((m1x1 * m2x2) - (m1x2 * m2x1)));
        }

        /// <summary>
        /// The cofactor.
        /// </summary>
        /// <param name="m1x1">The M1X1.</param>
        /// <param name="m1x2">The M1X2.</param>
        /// <param name="m1x3">The M1X3.</param>
        /// <param name="m2x1">The M2X1.</param>
        /// <param name="m2x2">The M2X2.</param>
        /// <param name="m2x3">The M2X3.</param>
        /// <param name="m3x1">The M3X1.</param>
        /// <param name="m3x2">The M3X2.</param>
        /// <param name="m3x3">The M3X3.</param>
        /// <returns>
        /// The <see cref="Matrix3x3D" />.
        /// </returns>
        /// <acknowledgment>
        /// https://sites.google.com/site/physics2d/
        /// This is an expanded version of the Ogre determinant() method, to give better performance in C#. Generated using a script.
        /// </acknowledgment>
        [DisplayName("Cofactor of a 3x3 matrix")]
        [Description("Jonathan Mark Porter's method for finding the cofactor of a 3x3 matrix. Inlined even more.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3
            ) CofactorMatrix(
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
        {
            return (-((m2x2 * m3x3) - (m2x3 * m3x2)), (m1x2 * m3x3) - (m1x3 * m3x2), -((m1x2 * m2x3) - (m1x3 * m2x2)),
                      (m2x1 * m3x3) - (m2x3 * m3x1), -((m1x1 * m3x3) - (m1x3 * m3x1)), (m1x1 * m2x3) - (m1x3 * m2x1),
                    -((m2x1 * m3x2) - (m2x2 * m3x1)), (m1x1 * m3x2) - (m1x2 * m3x1), -((m1x1 * m2x2) - (m1x2 * m2x1)));
        }
    }
}
