using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The matrix determinant3x3tests class.
    /// </summary>
    [DisplayName("Determinant of a 3x3 matrix")]
    [Description("Find the determinant of a 3x3 matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixDeterminant3x3Tests
    {
        /// <summary>
        /// Tests the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(MatrixDeterminant3x3Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var a = MatrixTestCases.Matrix3x3ElevensTuple;
            var b = MatrixTestCases.Matrix3x3IncrementalTuple;
            var c = MatrixTestCases.Matrix3x3IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m2x1, a.m2x2, a.m2x3, a.m3x1, a.m3x2, a.m3x3 }, new TestCaseResults(description: "Matrix3x3 Elevens Tuple", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m2x1, b.m2x2, b.m2x3, b.m3x1, b.m3x2, b.m3x3 }, new TestCaseResults(description: "Matrix3x3 Incremental Tuple", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m2x1, c.m2x2, c.m2x3, c.m3x1, c.m3x2, c.m3x3 }, new TestCaseResults(description: "Matrix3x3 Identity Tuple", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
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
        /// Determinants the specified matrix.
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
        public static double Determinant(double m1x1, double m1x2, double m1x3, double m2x1, double m2x2, double m2x3, double m3x1, double m3x2, double m3x3)
            => Determinant0(
                 m1x1, m1x2, m1x3,
                 m2x1, m2x2, m2x3,
                 m3x1, m3x2, m3x3);

        /// <summary>
        /// Find the determinant of a 3 by 3 matrix.
        /// </summary>
        /// <param name="m1x1">a.</param>
        /// <param name="m1x2">The b.</param>
        /// <param name="m1x3">The c.</param>
        /// <param name="m2x1">The d.</param>
        /// <param name="m2x2">The e.</param>
        /// <param name="m2x3">The f.</param>
        /// <param name="m3x1">The g.</param>
        /// <param name="m3x2">The h.</param>
        /// <param name="m3x3">The i.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
        /// </acknowledgment>
        [DisplayName("Determinant of a 3x3 matrix")]
        [Description("Jerry J. Chen's method for finding the determinant of a 3x3 matrix.")]
        [Acknowledgment("https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant0(
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
        {
            return (m1x1 * MatrixDeterminant2x2Tests.Determinant(m2x2, m2x3, m3x2, m3x3))
                 - (m1x2 * MatrixDeterminant2x2Tests.Determinant(m2x1, m2x3, m3x1, m3x3))
                 + (m1x3 * MatrixDeterminant2x2Tests.Determinant(m2x1, m2x2, m3x1, m3x2));
        }

        /// <summary>
        /// Gets the determinant.
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
        [DisplayName("Determinant of a 3x3 matrix")]
        [Description("Jonathan Mark Porter's method for finding the determinant of a 3x3 matrix.")]
        [Acknowledgment("https://sites.google.com/site/physics2d/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetDeterminant(
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
        {
            return (m1x1 * ((m2x2 * m3x3) - (m2x3 * m3x2)))
                 - (m1x2 * ((m2x1 * m3x3) - (m2x3 * m3x1)))
                 + (m1x3 * ((m2x1 * m3x2) - (m2x2 * m3x1)));
        }
    }
}
