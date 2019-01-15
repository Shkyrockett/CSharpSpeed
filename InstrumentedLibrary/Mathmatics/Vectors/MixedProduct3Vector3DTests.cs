using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The mixed product3vector3d tests class.
    /// </summary>
    [DisplayName("Mixed Product 3 Vector2D Tests")]
    [Description("Returns the Mixed product of three 2D vectors.")]
    [SourceCodeLocationProvider]
    public static class MixedProduct3Vector3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the mixed product for three 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(MixedProduct3Vector3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d, 2d, 2d, 2d }, new TestCaseResults(description:"0, 0, 1, 0, 1, 1.", trials:trials, expectedReturnValue:-1d, epsilon:double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="z3"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double MixedProduct3D(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
            => MixedProduct3D_0(x1, y1, z1, x2, y2, z2, x3, y3, z3);

        /// <summary>
        /// The mixed product3d 0.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="z3">The z3.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Mixed Product of three 2D Vectors 1")]
        [Description("Mixed Product of two 2D Vectors")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MixedProduct3D_0(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3)
        {
            var (cx, cy, cz) = CrossProduct2Vector3DTests.CrossProduct2Points3D(x1, y1, z1, x2, y2, z2);
            return DotProduct2Vector3DTests.DotProduct(cx, cy, cz, x3, y3, z3);
        }
    }
}
