using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The matrix inverse determinant 2x2 tests class.
    /// </summary>
    [DisplayName("Inverse Determinant of a 2x2 matrix")]
    [Description("Find the inverse determinant of a 2x2 matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixInverseDeterminant2x2Tests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(MatrixInverseDeterminant2x2Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d }, new TestCaseResults(description: "polygon, point.", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double InverseDeterminant(double a, double b, double c, double d)
            => InverseDeterminant0(a, b, c, d);

        /// <summary>
        /// Find the inverse of the determinant of a 2 by 2 matrix.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [DisplayName("Inverse Determinant of a 2x2 matrix")]
        [Description("Jerry J. Chen's method for finding the inverse determinant of a 2x2 matrix.")]
        [Acknowledgment("https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InverseDeterminant0(
            double a, double b,
            double c, double d)
        {
            return 1 / ((a * d)
                    - (b * c));
        }
    }
}
