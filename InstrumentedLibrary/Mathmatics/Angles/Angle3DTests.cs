using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The angle3d tests class.
    /// </summary>
    [DisplayName("3D Angle Tests")]
    [Description("Returns the Angle of a line that runs between two points.")]
    [SourceCodeLocationProvider]
    public static class Angle3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle of Two 3D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(Angle3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d }, new TestCaseResults(description:"0, 0, 0, 1, 1, 1.", trials:trials, expectedReturnValue:double.NaN, epsilon:double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Angle(double x1, double y1, double z1, double x2, double y2, double z2)
            => Angle0(x1, y1, z1, x2, y2, z2);

        /// <summary>
        /// The angle.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        [DisplayName("Angle from two 3D points")]
        [Description("This is the most common method of finding the angle of a line that runs between two points.")]
        [Acknowledgment("http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle0(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            return (Abs(x1 - x2) < DoubleEpsilon
                && Abs(y1 - y2) < DoubleEpsilon
                && Abs(z1 - z2) < DoubleEpsilon)
                ? 0d : Acos(Min(1.0d, DotProduct2Vector3DTests.DotProduct(Normalize3DVectorTests.Normalize(x1, y1, z1), Normalize3DVectorTests.Normalize(x2, y2, z2))));
        }
    }
}
