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
    /// 
    /// </summary>
    [DisplayName("Water Distort Point Tests")]
    [Description("Water distort the location of a point.")]
    [SourceCodeLocationProvider]
    public static class WaterDistortionTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(WaterDistortionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D(10d, 10d), new Point2D(5d, 5d), 1d }, new TestCaseResults(description: "Swirl a point", trials: trials, expectedReturnValue: new Point2D(20d,  20d), epsilon: double.Epsilon) },
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
        /// <param name="point"></param>
        /// <param name="fulcrum"></param>
        /// <param name="nWave"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D Water(Point2D point, Point2D fulcrum, double nWave = 1)
            => Water0(point, fulcrum, nWave);

        /// <summary>
        /// The water distortion.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="fulcrum">The fulcrum.</param>
        /// <param name="nWave">The nWave.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        [DisplayName("Water Distort Point Tests")]
        [Description("Water distort the location of a point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Water0(Point2D point, Point2D fulcrum, double nWave = 1)
        {
            var xo = nWave * Sin(2d * PI * point.Y / 128d);
            var yo = nWave * Cos(2d * PI * point.X / 128d);
            var newX = point.X + xo;
            var newY = point.Y + yo;
            return new Point2D(newX, newY);
        }
    }
}
