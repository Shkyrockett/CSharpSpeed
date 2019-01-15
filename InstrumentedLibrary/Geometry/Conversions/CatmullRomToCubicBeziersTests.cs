using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using static InstrumentedLibrary.Maths;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The Catmull-Rom to cubic Bézier tests class.
    /// </summary>
    [DisplayName("Catmull-Rom to Cubic Bézier List Tests")]
    [Description("Convert a Catmull-Rom curve to a list of Cubic Bézier segments.")]
    [SourceCodeLocationProvider]
    public static class CatmullRomToCubicBeziersTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CatmullRomToCubicBeziersTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new (double X, double Y)[] { (0d, 1d), (2d, 3d), (4d, 5d), (6d, 7d), (8d, 9d) } }, new TestCaseResults(description:"", trials:trials, expectedReturnValue: (0d, 1d, 1.33333333333333d, 2.33333333333333d, 4.66666666666667d, 5.66666666666667d, 6d, 7d), epsilon:DoubleEpsilon) },
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
        /// <param name="points"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static List<(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY)> CatmullRomToBezier((double X, double Y)[] points)
            => CatmullRomToBezier0(points);

        /// <summary>
        /// Converts a list of points on a Catmull Rom Curve to a list of Cubic Bézier curves.
        /// </summary>
        /// <param name="points">The list of points.</param>
        /// <returns>Returns a list of Cubic Bézier curves from a list of points on a Catmull Rom curve.</returns>
        /// <acknowledgment>
        /// https://github.com/ariutta/catmullrom2bezier/blob/master/catmullrom2bezier.js
        /// </acknowledgment>
        [DisplayName("Catmull-Rom to Cubic Bézier List")]
        [Description("Convert a Catmull-Rom curve to a list of Cubic Bézier segments.")]
        [Acknowledgment("https://github.com/ariutta/catmullrom2bezier/blob/master/catmullrom2bezier.js")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY)> CatmullRomToBezier0(
            (double X, double Y)[] points)
        {
            var d = new List<(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY)>();
            for (int i = 0, iLen = points.Length; iLen - 4 > i; i++)
            {
                var p = new List<(double x, double y)>();
                if (0 == i)
                {
                    p.Add((points[i].X, points[i].Y));
                    p.Add((points[i].X, points[i].Y));
                    p.Add((points[i + 1].X, points[i + 1].Y));
                    p.Add((points[i + 2].X, points[i + 2].Y));
                }
                else if (iLen - 4 == i)
                {
                    p.Add((points[i - 1].X, points[i - 1].Y));
                    p.Add((points[i].X, points[i].Y));
                    p.Add((points[i + 1].X, points[i + 1].Y));
                    p.Add((points[i + 2].X, points[i + 2].Y));
                }
                else
                {
                    p.Add((points[i - 1].X, points[i - 1].Y));
                    p.Add((points[i].X, points[i].Y));
                    p.Add((points[i + 1].X, points[i + 1].Y));
                    p.Add((points[i + 2].X, points[i + 2].Y));
                }

                // Catmull-Rom to Cubic Bézier conversion matrix 
                //    0       1       0       0
                //  -1/6      1      1/6      0
                //    0      1/6      1     -1/6
                //    0       0       1       0
                d.Add((
                    p[1].x, p[1].y, (-p[0].x + 6d * p[1].x + p[2].x) / 6d,
                    (-p[0].y + 6d * p[1].y + p[2].y) / 6d, (p[1].x + 6d * p[2].x - p[3].x) / 6d,
                    (p[1].y + 6d * p[2].y - p[3].y) / 6d,
                    p[2].x, p[2].y
                    ));
            }

            return d;
        }
    }
}
