using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The sort special tests class.
    /// </summary>
    [DisplayName("SortSpecial")]
    [Description("SortSpecial.")]
    [SourceCodeLocationProvider]
    public static class SortSpecialTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SortSpecialTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new double[] { 1d, 2d, -3d, 4d, 5d } }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue:PolynomialDegree.Quadratic, epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[] SortSpecial(double[] a)
            => SortSpecial0(a);

        /// <summary>
        /// Special sorting routine designed to place negative values at the back.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// based on http://abecedarical.com/javascript/script_exact_cubic.html
        /// </acknowledgment>
        [DisplayName("Special Sorting method")]
        [Description("Special Sorting method.")]
        [Acknowledgment("http://abecedarical.com/javascript/script_exact_cubic.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] SortSpecial0(double[] a)
        {
            bool flip;
            double temp;

            do
            {
                flip = false;
                for (var i = 0; i < a.Length - 1; i++)
                {
                    if ((a[i + 1] >= 0d && a[i] > a[i + 1]) ||
                        (a[i] < 0d && a[i + 1] >= 0d))
                    {
                        flip = true;
                        temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                    }
                }
            } while (flip);
            return a;
        }
    }
}
