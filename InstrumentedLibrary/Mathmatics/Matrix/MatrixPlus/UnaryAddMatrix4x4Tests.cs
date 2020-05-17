using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class UnaryAddMatrix4x4Tests
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
                { new object[] { a.m1x1, a.m1x2, a.m1x3, a.m1x4, a.m2x1, a.m2x2, a.m2x3, a.m2x4, a.m3x1, a.m3x2, a.m3x3, a.m3x4, a.m4x1, a.m4x2, a.m4x3, a.m4x4 }, new TestCaseResults(description: "Matrix4x4 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m1x3, b.m1x4, b.m2x1, b.m2x2, b.m2x3, b.m2x4, b.m3x1, b.m3x2, b.m3x3, b.m3x4, b.m4x1, b.m4x2, b.m4x3, b.m4x4 }, new TestCaseResults(description: "Matrix4x4 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m1x3, c.m1x4, c.m2x1, c.m2x2, c.m2x3, c.m2x4, c.m3x1, c.m3x2, c.m3x3, c.m3x4, c.m4x1, c.m4x2, c.m4x3, c.m4x4 }, new TestCaseResults(description: "Matrix4x4 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// Posates a <see cref="Matrix4x4D" />.
        /// </summary>
        /// <param name="sourceM0x0">The source M0X0.</param>
        /// <param name="sourceM0x1">The source M0X1.</param>
        /// <param name="sourceM0x2">The source M0X2.</param>
        /// <param name="sourceM0x3">The source M0X3.</param>
        /// <param name="sourceM1x0">The source M1X0.</param>
        /// <param name="sourceM1x1">The source M1X1.</param>
        /// <param name="sourceM1x2">The source M1X2.</param>
        /// <param name="sourceM1x3">The source M1X3.</param>
        /// <param name="sourceM2x0">The source M2X0.</param>
        /// <param name="sourceM2x1">The source M2X1.</param>
        /// <param name="sourceM2x2">The source M2X2.</param>
        /// <param name="sourceM2x3">The source M2X3.</param>
        /// <param name="sourceM3x0">The source M3X0.</param>
        /// <param name="sourceM3x1">The source M3X1.</param>
        /// <param name="sourceM3x2">The source M3X2.</param>
        /// <param name="sourceM3x3">The source M3X3.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3
            ) UnaryPosate(
            double sourceM0x0, double sourceM0x1, double sourceM0x2, double sourceM0x3,
            double sourceM1x0, double sourceM1x1, double sourceM1x2, double sourceM1x3,
            double sourceM2x0, double sourceM2x1, double sourceM2x2, double sourceM2x3,
            double sourceM3x0, double sourceM3x1, double sourceM3x2, double sourceM3x3)
        {
            return (+sourceM0x0, +sourceM0x1, +sourceM0x2, +sourceM0x3,
                    +sourceM1x0, +sourceM1x1, +sourceM1x2, +sourceM1x3,
                    +sourceM2x0, +sourceM2x1, +sourceM2x2, +sourceM2x3,
                    +sourceM3x0, +sourceM3x1, +sourceM3x2, +sourceM3x3);
        }
    }
}
