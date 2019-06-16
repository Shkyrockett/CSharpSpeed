using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The matrix determinant2x2tests class.
    /// </summary>
    [DisplayName("Determinant of a 2x2 matrix")]
    [Description("Find the determinant of a 2x2 matrix.")]
    [SourceCodeLocationProvider]
    public static class MatrixDeterminant2x2Tests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(MatrixDeterminant2x2Tests))]
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
        /// <param name="r1c1"></param>
        /// <param name="r1c2"></param>
        /// <param name="r2c1"></param>
        /// <param name="r2c2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Determinant(double r1c1, double r1c2, double r2c1, double r2c2)
            => Determinant0(r1c1, r1c2, r2c1, r2c2);

        /// <summary>
        /// Find the determinant of a 2 by 2 matrix.
        /// </summary>
        /// <param name="m1x1"></param>
        /// <param name="m1x2"></param>
        /// <param name="m2x1"></param>
        /// <param name="m2x2"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
        /// </acknowledgment>
        [DisplayName("Determinant of a 2x2 matrix")]
        [Description("Jerry J. Chen's method for finding the determinant of a 2x2 matrix.")]
        [Acknowledgment("https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant0(
            double m1x1, double m1x2,
            double m2x1, double m2x2)
        {
            return (m1x1 * m2x2) - (m1x2 * m2x1);
        }
    }
}
