using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The slopes equal tests class.
    /// </summary>
    [DisplayName("Slopes Equal Tests")]
    [Description("Determines whether slopes are Equal.")]
    [SourceCodeLocationProvider]
    public static class SlopesEqual3Tests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SlopesEqual3Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(1d, 2d), new Point2D(2d, 1d), new Point2D(1d, 2d), true }, new TestCaseResults(description: "1, 2, 3, 4, 5", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="UseFullRange"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool SlopesEqual(Point2D a, Point2D b, Point2D c, bool UseFullRange = false)
            => SlopesEqual0(a, b, c, UseFullRange);

        /// <summary>
        /// The slopes equal.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="UseFullRange">The UseFullRange.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://www.angusj.com/delphi/clipper.php
        /// </acknowledgment>
        [DisplayName("Slopes Equal")]
        [Description("Determines whether slopes are Equal.")]
        [Acknowledgment("http://www.angusj.com/delphi/clipper.php")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SlopesEqual0(Point2D a, Point2D b, Point2D c, bool UseFullRange = false)
        {
            return UseFullRange ? BigInteger.Multiply((BigInteger)(a.Y - b.Y), (BigInteger)(b.X - c.X)) == BigInteger.Multiply((BigInteger)(a.X - b.X), (BigInteger)(b.Y - c.Y))
                : (a.Y - b.Y) * (b.X - c.X) - (a.X - b.X) * (b.Y - c.Y) == 0;
        }
    }
}
