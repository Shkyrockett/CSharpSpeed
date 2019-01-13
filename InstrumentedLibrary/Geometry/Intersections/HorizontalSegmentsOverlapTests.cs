using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The horizontal segments overlap tests class.
    /// </summary>
    [DisplayName("Horizontal Segments overlap")]
    [Description("Determines whether horizontal segments overlap.")]
    [Signature("public static bool HorizontalSegmentsOverlap(double segAX, double segAY, double segBX, double segBY)")]
    [SourceCodeLocationProvider]
    public static class HorizontalSegmentsOverlapTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(HorizontalSegmentsOverlapTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 0d, 3d, 0d }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:true, epsilon:double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segAX"></param>
        /// <param name="segAY"></param>
        /// <param name="segBX"></param>
        /// <param name="segBY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool HorizontalSegmentsOverlap(double segAX, double segAY, double segBX, double segBY)
            => HorzSegmentsOverlap(segAX, segAY, segBX, segBY);

        /// <summary>
        /// The horizontal segments overlap.
        /// </summary>
        /// <param name="segAX">The segAX.</param>
        /// <param name="segAY">The segAY.</param>
        /// <param name="segBX">The segBX.</param>
        /// <param name="segBY">The segBY.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://www.angusj.com/delphi/clipper.php
        /// </acknowledgment>
        [DisplayName("Horizontal Segments overlap")]
        [Description("Determines whether horizontal segments overlap.")]
        [Acknowledgment("http://www.angusj.com/delphi/clipper.php")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HorzSegmentsOverlap(double segAX, double segAY, double segBX, double segBY)
        {
            if (segAX > segAY)
            {
                SwapTests.Swap(ref segAX, ref segAY);
            }

            if (segBX > segBY)
            {
                SwapTests.Swap(ref segBX, ref segBY);
            }

            return (segAX < segBY) && (segBX < segAY);
        }
    }
}
