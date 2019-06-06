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
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(MatrixDeterminant3x3Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d }, new TestCaseResults(description: "polygon, point.", trials: trials, expectedReturnValue:-2d, epsilon: double.Epsilon) },
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
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <param name="h"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Determinant(double a, double b, double c, double d, double e, double f, double g, double h, double i)
            => Determinant0(a, b, c, d, e, f, g, h, i);

        /// <summary>
        /// Find the determinant of a 3 by 3 matrix.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <param name="h"></param>
        /// <param name="i"></param>
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
            double a, double b, double c,
            double d, double e, double f,
            double g, double h, double i)
        {
            return (a * MatrixDeterminant2x2Tests.Determinant(e, f, h, i))
                - (b * MatrixDeterminant2x2Tests.Determinant(d, f, g, i))
                + (c * MatrixDeterminant2x2Tests.Determinant(d, e, g, h));
        }
    }
}
