using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The slopes equal tests class.
    /// </summary>
    [DisplayName("Slopes Equal Tests")]
    [Description("Determines whether slopes are Equal.")]
    [Signature("public static bool SlopesEqual(Point2D a, Point2D b, Point2D c, Point2D d, bool UseFullRange = false)")]
    [SourceCodeLocationProvider]
    public static class SlopesEqual4Tests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SlopesEqual4Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(1d, 2d), new Point2D(2d, 1d), new Point2D(1d, 2d), new Point2D(2d, 1d), true }, new TestCaseResults(description: "1, 2, 3, 4, 5", trials: trials, expectedReturnValue: true, epsilon:DoubleEpsilon) },
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="UseFullRange"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool SlopesEqual(Point2D a, Point2D b, Point2D c, Point2D d, bool UseFullRange = false)
            => SlopesEqual0(a, b, c, d, UseFullRange);

        /// <summary>
        /// The slopes equal.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
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
        public static bool SlopesEqual0(Point2D a, Point2D b, Point2D c, Point2D d, bool UseFullRange = false)
        {
            return UseFullRange ? BigInteger.Multiply((BigInteger)(a.Y - b.Y), (BigInteger)(b.X - c.X)) == BigInteger.Multiply((BigInteger)(a.X - b.X), (BigInteger)(b.Y - c.Y))
                : (int)(a.Y - b.Y) * (c.X - d.X) - (int)(a.X - b.X) * (c.Y - d.Y) == 0;
        }
    }
}
