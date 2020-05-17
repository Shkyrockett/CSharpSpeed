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
    public static class MatrixSubtract2x2x2x2Tests
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
            var a = MatrixTestCases.Matrix2x2ElevensTuple;
            var b = MatrixTestCases.Matrix2x2IncrementalTuple;
            var c = MatrixTestCases.Matrix2x2IdentityTuple;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { a.m1x1, a.m1x2, a.m2x1, a.m2x2 }, new TestCaseResults(description: "Matrix2x2 Elevens Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { b.m1x1, b.m1x2, b.m2x1, b.m2x2 }, new TestCaseResults(description: "Matrix2x2 Incremental Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
                { new object[] { c.m1x1, c.m1x2, c.m2x1, c.m2x2 }, new TestCaseResults(description: "Matrix2x2 Identity Tuple", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// Used to subtract two matrices.
        /// </summary>
        /// <param name="minuendM0x0">The minuend M0X0.</param>
        /// <param name="minuendM0x1">The minuend M0X1.</param>
        /// <param name="minuendM1x0">The minuend M1X0.</param>
        /// <param name="minuendM1x1">The minuend M1X1.</param>
        /// <param name="subtrahendM0x0">The subtrahend M0X0.</param>
        /// <param name="subtrahendM0x1">The subtrahend M0X1.</param>
        /// <param name="subtrahendM1x0">The subtrahend M1X0.</param>
        /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1,
            double m1x0, double m1x1
            ) Subtract2x2x2x2(
            double minuendM0x0, double minuendM0x1,
            double minuendM1x0, double minuendM1x1,
            double subtrahendM0x0, double subtrahendM0x1,
            double subtrahendM1x0, double subtrahendM1x1)
        {
            return (minuendM0x0 - subtrahendM0x0, minuendM0x1 - subtrahendM0x1,
                    minuendM1x0 - subtrahendM1x0, minuendM1x1 - subtrahendM1x1);
        }
    }
}
