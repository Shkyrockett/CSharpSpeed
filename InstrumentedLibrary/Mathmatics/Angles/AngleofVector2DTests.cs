using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The angleof vector tests class.
    /// </summary>
    [DisplayName("Angle of a 2D Vector Tests")]
    [Description("Find the angle of a 2D vector.")]
    [SourceCodeLocationProvider]
    public static class AngleofVector2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(AngleofVector2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d }, new TestCaseResults(description: " 0, 1.", trials: trials, expectedReturnValue:7.8539816339744828d, epsilon: double.Epsilon) },
                { new object[] { 0.25d, 0.75d }, new TestCaseResults(description: "0, 1", trials: trials, expectedReturnValue:7.5322310795778407d, epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double AngleOfVector2D(double i, double j)
            => AngleOf(i, j);

        /// <summary>
        /// Angle with tangent opp/hyp
        /// </summary>
        /// <param name="i">opposite component.</param>
        /// <param name="j">adjacent component.</param>
        /// <returns>Return the angle with tangent opp/hyp. The returned value is between PI and -PI.</returns>
        [DisplayName("Vector Angle 1")]
        [Description("Angle with tangent opp/hyp.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetAngle0(double i, double j)
        {
            return Atan2(i, -j);// * 180 / PI; // Original source method converted radians to degrees.
        }

        /// <summary>
        /// Returns the Angle of two deltas.
        /// </summary>
        /// <param name="i">Delta Angle 1</param>
        /// <param name="j">Delta Angle 2</param>
        /// <returns>Returns the Angle of a line.</returns>
        [DisplayName("Vector Angle 1")]
        [Description("Returns the Angle of two deltas.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetAngleAtan2v2(double i, double j)
        {
            if ((Abs(i) < DoubleEpsilon) && (Abs(j) < DoubleEpsilon))
            {
                return 0d;
            }

            var value = Asin(i / Sqrt((i * i) + (j * j)));
            if (j < 0d)
            {
                value = PI - value;
            }

            if (value < 0d)
            {
                value += (2d * PI);
            }

            return value;
        }

        /// <summary>
        /// Get the angle.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Vector Angle 1")]
        [Description("Get the angle using Trig.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetAngle(double i, double j)
        {
            return Tau + ((j > 0.0d ? 1.0d : -1.0d) * Acos(i / Sqrt((i * i) + (j * j))) % Tau);
        }

        /// <summary>
        /// Determine the radian angle of the specified vector (as it relates to the origin).
        /// Warning: Do not pass zero in both parameters, as this will cause a division-by-zero.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DisplayName("Angle of Vector")]
        [Description("Get the angle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AngleOf(double x, double y)
        {
            var dist = Sqrt((x * x) + (y * y));
            if (y >= 0d)
            {
                return Acos(x / dist);
            }
            else
            {
                return Acos(-x / dist) + PI;
            }
        }
    }
}
