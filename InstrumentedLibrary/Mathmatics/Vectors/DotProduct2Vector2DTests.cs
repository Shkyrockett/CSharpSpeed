using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
#if HAS_INTRINSICS
using System.Runtime.Intrinsics.X86;
#endif

namespace InstrumentedLibrary
{
    /// <summary>
    /// The dot product2points2d tests class.
    /// </summary>
    [DisplayName("Dot Product Tests")]
    [Description("Returns the Angle of a line that runs between two points.")]
    [SourceCodeLocationProvider]
    public static class DotProduct2Vector2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the dot product of two 2D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(DotProduct2Vector2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d }, new TestCaseResults(description: "0, 0, 1, 1.", trials: trials, expectedReturnValue: 0d, epsilon: double.Epsilon) },
                { new object[] { 4d, 3d, 2d, 1d }, new TestCaseResults(description: "4, 3, 2, 1.", trials: trials, expectedReturnValue: 11d, epsilon: double.Epsilon) },
                { new object[] { 1d, 2d, 3d, 4d }, new TestCaseResults(description: "1, 2, 3, 4.", trials: trials, expectedReturnValue: 11d, epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double DotProduct2D(double x1, double y1, double x2, double y2)
            => DotProduct2D0(x1, y1, x2, y2);

        /// <summary>
        /// Calculates the dot Aka. scalar or inner product of a vector.
        /// </summary>
        /// <param name="x1">First Point X component.</param>
        /// <param name="y1">First Point Y component.</param>
        /// <param name="x2">Second Point X component.</param>
        /// <param name="y2">Second Point Y component.</param>
        /// <returns>The Dot Product.</returns>
        /// <remarks>The dot product "·" is calculated with DotProduct = X ^ 2 + Y ^ 2</remarks>
        [DisplayName("Dot Product of two 2D Vectors 1")]
        [Description("Dot Product of two 2D Vectors")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProduct2D0(
            double x1, double y1,
            double x2, double y2)
        {
            return (x1 * x2) + (y1 * y2);
        }

        /// <summary>
        /// Calculates the dot Aka. scalar or inner product of a vector.
        /// </summary>
        /// <param name="x1">First Point X component.</param>
        /// <param name="y1">First Point Y component.</param>
        /// <param name="x2">Second Point X component.</param>
        /// <param name="y2">Second Point Y component.</param>
        /// <returns>The Dot Product.</returns>
        /// <remarks>The dot product "·" is calculated with DotProduct = X ^ 2 + Y ^ 2</remarks>
        [DisplayName("Dot Product of two 2D Vectors SSE")]
        [Description("Dot Product of two 2D Vectors")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe double DotProduct2DSSE(
            double x1, double y1,
            double x2, double y2)
        {
#if HAS_INTRINSICS
            if (Sse41.IsSupported)
            {
                var vf1 = Sse2.LoadVector128(&x1);
                var vf2 = Sse2.LoadVector128(&x2);
                Unsafe.Write(&x1, Sse41.DotProduct(vf1, vf2, 51));
                return x1;
            }
#endif
            return (x1 * x2) + (y1 * y2);
        }
    }
}
