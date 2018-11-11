using CSharpSpeed;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The swap tests class.
    /// </summary>
    //[DisplayName("Swap")]
    //[Description("Swap")]
    //[Signature("public static bool Swap(ref T a, ref T b)")]
    //[SourceCodeLocationProvider]
    public static class SwapTests
    {
        ///// <summary>
        ///// Set of tests to run testing methods that swap values.
        ///// </summary>
        ///// <returns></returns>
        //[DisplayName(nameof(SwapTests))]
        //public static List<SpeedTester> TestHarness()
        //{
        //    var trials = 10000;
        //    double a = 0;
        //    double b = 100;
        //    var tests = new Dictionary<object[], TestCaseResults> {
        //        { new object[] { a, b }, new TestCaseResults(description:"Angle lies inside of sweep angle.", trials:trials, expectedReturnValue:true) }
        //    };

        //    var results = new List<SpeedTester>();
        //    foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
        //    {
        //        var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
        //        results.Add(new SpeedTester(method, methodDescription, tests));
        //    }
        //    return results;
        //}

        /// <summary>
        /// The swap.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <typeparam name="T"></typeparam>
        [DisplayName("Swap")]
        [Description("Swap")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Swap<T>(ref T a, ref T b)
        {
            var swap = a;
            a = b;
            b = swap;
            return true;
        }
    }
}
