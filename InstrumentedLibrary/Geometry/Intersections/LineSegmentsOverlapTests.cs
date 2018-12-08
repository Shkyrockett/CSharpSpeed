using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The line segments overlap tests class.
    /// </summary>
    [DisplayName("Gets the Segment overlap")]
    [Description("Determines whether segments overlap and retrieves the locations.")]
    [Signature("public static bool HorzSegmentsOverlap(double segAX, double segAY, double segBX, double segBY)")]
    [SourceCodeLocationProvider]
    public static class LineSegmentsOverlapTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(LineSegmentsOverlapTests))]
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
        /// Get the overlap.
        /// </summary>
        /// <param name="a1">The a1.</param>
        /// <param name="a2">The a2.</param>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://www.angusj.com/delphi/clipper.php
        /// </acknowledgment>
        [DisplayName("Gets the Segment overlap")]
        [Description("Determines whether segments overlap and retrieves the locations.")]
        [Acknowledgment("http://www.angusj.com/delphi/clipper.php")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool Overlap, double Left, double Right) GetOverlap(double a1, double a2, double b1, double b2)
        {
            (var Overlap, var Left, var Right) = (false, 0d, 0d);
            if (a1 < a2)
            {
                if (b1 < b2)
                {
                    Left = Max(a1, b1);
                    Right = Min(a2, b2);
                }
                else
                {
                    Left = Max(a1, b2);
                    Right = Min(a2, b1);
                }
            }
            else
            {
                if (b1 < b2)
                {
                    Left = Max(a2, b1);
                    Right = Min(a1, b2);
                }
                else
                {
                    Left = Max(a2, b2);
                    Right = Min(a1, b1);
                }
            }

            return (Left < Right, Left, Right);
        }
    }
}
