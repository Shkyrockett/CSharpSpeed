using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The bounds of polygon tests class.
    /// </summary>
    [DisplayName("Polygon Bounds Tests")]
    [Description("Calculate bounding rectangle of a polygon.")]
    [Signature("public static Rectangle2D PolygonBounds(List<List<(double X, double Y)>> paths)")]
    [SourceCodeLocationProvider]
    public static class BoundsOfPolygonTests
    {
        /// <summary>
        /// Set of tests to run testing methods that Find the bounds of polygons.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(BoundsOfPolygonTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new List<List<(double X, double Y)>> { new List<(double X, double Y)> { (0, 0), (1, 0), (0, 1) }, new List<(double X, double Y)> { (10d, 10d), (25d, 5d), (5d, 30d) } } }, new TestCaseResults(description:"Circle test case.", trials:trials, expectedReturnValue:Tau, epsilon:double.Epsilon) },
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
        /// <param name="paths"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Rectangle2D PolygonBounds(List<List<(double X, double Y)>> paths)
            => GetBounds0(paths);        

        /// <summary>
        /// Get the bounds.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DisplayName("Polygon Bounds")]
        [Description("Find bounds of a polygon.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D GetBounds0(List<List<(double X, double Y)>> paths)
        {
            var i = 0;
            var cnt = paths.Count;
            while (i < cnt && paths[i].Count == 0)
            {
                i++;
            }

            if (i == cnt)
            {
                return new Rectangle2D(0, 0, 0, 0);
            }

            var result = new Rectangle2D
            {
                Left = paths[i][0].X
            };
            result.Right = result.Left;
            result.Top = paths[i][0].Y;
            result.Bottom = result.Top;
            for (; i < cnt; i++)
            {
                for (var j = 0; j < paths[i].Count; j++)
                {
                    if (paths[i][j].X < result.Left)
                    {
                        result.Left = paths[i][j].X;
                    }
                    else if (paths[i][j].X > result.Right)
                    {
                        result.Right = paths[i][j].X;
                    }

                    if (paths[i][j].Y < result.Top)
                    {
                        result.Top = paths[i][j].Y;
                    }
                    else if (paths[i][j].Y > result.Bottom)
                    {
                        result.Bottom = paths[i][j].Y;
                    }
                }
            }

            return result;
        }
    }
}
