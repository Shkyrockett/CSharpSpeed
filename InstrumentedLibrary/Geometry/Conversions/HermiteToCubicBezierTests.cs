using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static InstrumentedLibrary.Maths;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The hermite to cubic Bézier tests class.
    /// </summary>
    [DisplayName("Hermite to Cubic Bézier Tests")]
    [Description("Convert a Hermite curve to a Cubic Bézier.")]
    [Signature("public static double HermiteInterpolate2D(double v0, double v1, double v2, double v3, double t)")]
    [SourceCodeLocationProvider]
    public static class HermiteToCubicBezierTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(HermiteToCubicBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 1d, 0d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue: (0d, 1d, 1.33333333333333d, 2.33333333333333d, 4.66666666666667d, 5.66666666666667d, 6d, 7d), epsilon:DoubleEpsilon) },
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
        /// The to cubic Bézier.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="tension"></param>
        /// <param name="bias"></param>
        /// <returns>The .</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/29087503/how-to-create-jigsaw-puzzle-pieces-using-opengl-and-bezier-curve/29089681#29089681
        /// </acknowledgment>
        [DisplayName("Hermite to Cubic Bézier Tests")]
        [Description("Convert a Hermite curve to a Cubic Bézier.")]
        [Acknowledgment("http://stackoverflow.com/questions/29087503/how-to-create-jigsaw-puzzle-pieces-using-opengl-and-bezier-curve/29089681#29089681")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) ToCubicBezier(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double tension, double bias)
        {
            return (aX, aY, bX - (cX - aX) / 6d, bY - (cY - aY) / 6d, cX + (dX - bX) / 6d, cY + (dY - bY) / 6d, dX, dY);
        }
    }
}
