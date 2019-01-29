using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The Catmull-Rom to cubic Bézier tests class.
    /// </summary>
    [DisplayName("Catmull-Rom to Cubic Bézier Tests")]
    [Description("Convert a Catmull-Rom curve to a Cubic Bézier segment.")]
    [SourceCodeLocationProvider]
    public static class CatmullRomToCubicBezierTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CatmullRomToCubicBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 1d, 0d, 1d, 1.33333333333333d, 2.33333333333333d, 2d, 3d) , epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) CatmullRomToBezier(double aX, double aY, double bX, double bY, double cX, double cY)
            => CatmullRomToBezier0(aX, aY, bX, bY, cX, cY);

        /// <summary>
        /// Converts a list of points on a Catmull Rom Curve to a list of Cubic Bézier curves.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns>Returns a list of Cubic Bézier curves from a list of points on a Catmull Rom curve.</returns>
        /// <acknowledgment>
        /// https://github.com/ariutta/catmullrom2bezier/blob/master/catmullrom2bezier.js
        /// </acknowledgment>
        [DisplayName("Catmull-Rom to Cubic Bézier")]
        [Description("Convert a Catmull-Rom curve to a list of Cubic Bézier segments.")]
        [Acknowledgment("https://github.com/ariutta/catmullrom2bezier/blob/master/catmullrom2bezier.js")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) CatmullRomToBezier0(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY
            )
        {
            var p = new List<(double x, double y)>
            {
                (bX, bY),
                (aX, aY),
                (bX, bY),
                (cX, cY)
            };

            // Catmull-Rom to Cubic Bézier conversion matrix 
            //    0       1       0       0
            //  -1/6      1      1/6      0
            //    0      1/6      1     -1/6
            //    0       0       1       0
            return (p[1].x, p[1].y, (-p[0].x + 6d * p[1].x + p[2].x) / 6d,
                (-p[0].y + 6d * p[1].y + p[2].y) / 6d, (p[1].x + 6d * p[2].x - p[3].x) / 6d,
                (p[1].y + 6d * p[2].y - p[3].y) / 6d,
                p[2].x, p[2].y);
        }
    }
}
