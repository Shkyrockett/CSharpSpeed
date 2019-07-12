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
    /// The vector between vectors tests class.
    /// </summary>
    [DisplayName("Vector between Vectors Tests")]
    [Description("Determine whether a vector is between two other vectors.")]
    [SourceCodeLocationProvider]
    public static class VectorBetweenVectorsTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate whether a vector is between two others.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(VectorBetweenVectorsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var a = 45d.ToRadians();
            var b = 90d.ToRadians();
            var c = 0d.ToRadians();
            var i = Sin(a);
            var j = Cos(a);
            var i2 = Sin(b);
            var j2 = Cos(b);
            var i3 = Sin(c);
            var j3 = Cos(c);

            var trials = 10000;
            var polygon = new Polygon2D(new List<PolygonContour2D> { new PolygonContour2D(new List<Point2D> { new Point2D(0, 0), new Point2D(2, 0), new Point2D(0, 2) }) });
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { i, j, i2, j2, i3, j3 }, new TestCaseResults(description: "polygon, point.", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="i2"></param>
        /// <param name="j2"></param>
        /// <param name="i3"></param>
        /// <param name="j3"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool VectorBetween(double i, double j, double i2, double j2, double i3, double j3)
            => VectorBetween1(i, j, i2, j2, i3, j3);

        /// <summary>
        /// The vector between0.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="i2">The i2.</param>
        /// <param name="j2">The j2.</param>
        /// <param name="i3">The i3.</param>
        /// <param name="j3">The j3.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors
        /// http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors
        /// http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d
        /// http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin
        /// </acknowledgment>
        [DisplayName("Vector between Vectors")]
        [Description("Determine whether a vector is between two other vectors.")]
        [Acknowledgment("http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors", "http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors", "http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d", "http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool VectorBetween0(double i, double j, double i2, double j2, double i3, double j3)
        {
            return CrossProduct2Vector2DTests.CrossProduct2Vector2D(i2, j2, i, j) * CrossProduct2Vector2DTests.CrossProduct2Vector2D(i2, j2, i3, j3) >= 0
                && CrossProduct2Vector2DTests.CrossProduct2Vector2D(i3, j3, i, j) * CrossProduct2Vector2DTests.CrossProduct2Vector2D(i3, j3, i2, j2) >= 0;
        }

        /// <summary>
        /// The vector between1.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="i2">The i2.</param>
        /// <param name="j2">The j2.</param>
        /// <param name="i3">The i3.</param>
        /// <param name="j3">The j3.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors
        /// http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors
        /// http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d
        /// http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin
        /// </acknowledgment>
        [DisplayName("Vector between Vectors")]
        [Description("Determine whether a vector is between two other vectors.")]
        [Acknowledgment("http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors", "http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors", "http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d", "http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool VectorBetween1(double i, double j, double i2, double j2, double i3, double j3)
        {
            return ((i2 * j) - (j2 * i)) * ((i2 * j3) - (j2 * i3)) >= 0
                && ((i3 * j) - (j3 * i)) * ((i3 * j2) - (j3 * i2)) >= 0;
        }
    }
}
