using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The atan2tests class.
    /// </summary>
    [DisplayName("Atan2 Tests")]
    [Description("Returns the Atan2 of a vector.")]
    [SourceCodeLocationProvider]
    public static class Atan2Tests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(Atan2Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 100000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 0d }, new TestCaseResults(description: " 0, 1.", trials: trials, expectedReturnValue:1.5707963267948966d, epsilon: double.Epsilon) },
                { new object[] { 0.25d, 0.75d }, new TestCaseResults(description: "0, 1", trials: trials, expectedReturnValue:0.32175055439664219d, epsilon: double.Epsilon) },
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
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Atan2(double y, double x)
            => Math.Atan2(y, x);

        /// <summary>
        /// The atan2 0.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("System.Math.Atan2")]
        [Description("")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atan2_0(double y, double x)
        {
            return Atan2(y, x);
        }

        /// <summary>
        /// The ATAN2 BITS (const). Value: 7.
        /// </summary>
        private const int ATAN2_BITS = 7;

        /// <summary>
        /// The ATAN2 BITS2 (const). Value: ATAN2_BITS &lt;&lt; 1.
        /// </summary>
        private const int ATAN2_BITS2 = ATAN2_BITS << 1;

        /// <summary>
        /// The ATAN2 MASK (const). Value: ~(-1 &lt;&lt; ATAN2_BITS2).
        /// </summary>
        private const int ATAN2_MASK = ~(-1 << ATAN2_BITS2);

        /// <summary>
        /// The ATAN2 COUNT (const). Value: ATAN2_MASK + 1.
        /// </summary>
        private const int ATAN2_COUNT = ATAN2_MASK + 1;

        /// <summary>
        /// The ATAN2 DIM (readonly). Value: (int)Sqrt(ATAN2_COUNT).
        /// </summary>
        private static readonly int ATAN2_DIM = (int)Sqrt(ATAN2_COUNT);

        /// <summary>
        /// The INV ATAN2 DIM MINUS 1 (readonly). Value: 1.0f / (ATAN2_DIM - 1).
        /// </summary>
        private static readonly double INV_ATAN2_DIM_MINUS_1 = 1.0f / (ATAN2_DIM - 1);

        /// <summary>
        /// The atan2 (readonly). Value: Atan2_1Setup().
        /// </summary>
        private static readonly double[] atan2 = Atan2_1Setup();

        /// <summary>
        /// The atan2 0Setup.
        /// </summary>
        /// <returns>The <see cref="T:double[]"/>.</returns>
        private static double[] Atan2_1Setup()
        {
            var atan2 = new double[ATAN2_COUNT];
            for (var i = 0; i < ATAN2_DIM; i++)
            {
                for (var j = 0; j < ATAN2_DIM; j++)
                {
                    var x0 = (double)i / ATAN2_DIM;
                    var y0 = (double)j / ATAN2_DIM;

                    atan2[(j * ATAN2_DIM) + i] = Atan2(y0, x0);
                }
            }
            return atan2;
        }

        /// <summary>
        /// The atan2 0.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Atan2")]
        [Description("")]
        [Acknowledgment("http://www.java-gaming.org/index.php?topic=14647.0")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atan2_1(double y, double x)
        {
            double add, mul;

            if (x < 0d)
            {
                if (y < 0d)
                {
                    x = -x;
                    y = -y;

                    mul = 1d;
                }
                else
                {
                    x = -x;
                    mul = -1d;
                }

                add = -PI;
            }
            else
            {
                if (y < 0d)
                {
                    y = -y;
                    mul = -1d;
                }
                else
                {
                    mul = 1d;
                }

                add = 0d;
            }

            var invDiv = 1d / (((x < y) ? y : x) * INV_ATAN2_DIM_MINUS_1);

            var xi = (int)(x * invDiv);
            var yi = (int)(y * invDiv);

            return (atan2[(yi * ATAN2_DIM) + xi] + add) * mul;
        }
    }
}
