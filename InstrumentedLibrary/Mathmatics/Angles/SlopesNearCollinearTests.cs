using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The slopes near collinear tests class.
    /// </summary>
    [DisplayName("Slopes Near Collinear Tests")]
    [Description("Determines whether slopes are collinear.")]
    [Signature("public static bool SlopesNearCollinear(Point2D a, Point2D b, Point2D c, double distSqrd)")]
    [SourceCodeLocationProvider]
    public static class SlopesNearCollinearTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SlopesNearCollinearTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(1d, 2d), new Point2D(2d, 1d), new Point2D(1d, 2d), 1d }, new TestCaseResults(description: "1, 2, 3, 4, 5", trials: trials, expectedReturnValue: true, epsilon:DoubleEpsilon) },
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
        /// The slopes near collinear.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="distSqrd">The distSqrd.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Slopes Near Collinear")]
        [Description("Determines whether slopes are collinear.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SlopesNearCollinear(Point2D a, Point2D b, Point2D c, double distSqrd)
        {
            // This function is more accurate when the point that is GEOMETRICALLY
            // between the other 2 points is the one that is tested for distance.
            // nb: with 'spikes', either pt1 or pt3 is geometrically between the other pts.
            if (Abs(a.X - b.X) > Abs(a.Y - b.Y))
            {
                if ((a.X > b.X) == (a.X < c.X))
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(a.X, a.Y, b.X, b.Y, c.X, c.Y) < distSqrd;
                }
                else if ((b.X > a.X) == (b.X < c.X))
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(b.X, b.Y, a.X, a.Y, c.X, c.Y) < distSqrd;
                }
                else
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(c.X, c.Y, a.X, a.Y, b.X, b.Y) < distSqrd;
                }
            }
            else
            {
                if ((a.Y > b.Y) == (a.Y < c.Y))
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(a.X, a.Y, b.X, b.Y, c.X, c.Y) < distSqrd;
                }
                else if ((b.Y > a.Y) == (b.Y < c.Y))
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(b.X, b.Y, a.X, a.Y, c.X, c.Y) < distSqrd;
                }
                else
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(c.X, c.Y, a.X, a.Y, b.X, b.Y) < distSqrd;
                }
            }
        }
    }
}
