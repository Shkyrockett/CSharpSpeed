using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The sin cos tests class.
    /// </summary>
    [DisplayName("Sin and Cos")]
    [Description("Calculate the tuple of Sin and Cos.")]
    [SourceCodeLocationProvider]
    public static class SinCosTests
    {
        /// <summary>
        /// The sin cos table.
        /// </summary>
        public static Dictionary<double, (double, double)?> sinCosTable = new Dictionary<double, (double Cos, double Sin)?>();

        /// <summary>
        /// Clear the sin cos table.
        /// </summary>
        /// <returns>The <see cref="double"/>.</returns>
        public static double ClearSinCosTable()
        {
            sinCosTable.Clear();
            return 0;
        }

        /// <summary>
        /// Set of tests to lookup the Sin and Cos of a radian angle.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SinCosTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:(1d, 0d), epsilon:double.Epsilon) },
                { new object[] { ToRadiansTests.ToRadians(30d) }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:(0.86602540378443871d, 0.49999999999999994d), epsilon:double.Epsilon) },
                { new object[] { ToRadiansTests.ToRadians(45d) }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:(0.70710678118654757d, 0.70710678118654757d), epsilon:double.Epsilon) },
                { new object[] { ToRadiansTests.ToRadians(60d) }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:(0.50000000000000011d, 0.8660254037844386d), epsilon:double.Epsilon) },
                { new object[] { HalfPi }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:(0d, 1d), epsilon:double.Epsilon) },
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
        /// <param name="angle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double Cos, double Sin) SinCos(double angle)
            => SinCos_0(angle);

        /// <summary>
        /// The sin cos.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>The <see cref="T:(double Cos, double Sin)"/>.</returns>
        [DisplayName("Sin and Cos Reference")]
        [Description("Calculate the tuple of Sin and Cos.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos_0(double angle)
        {
            return (Cos(angle), Sin(angle));
        }

        /// <summary>
        /// The sin cos low precision.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>The <see cref="T:(double Cos, double Sin)"/>.</returns>
        /// <acknowledgment>
        /// http://web.archive.org/web/20110925033606/http://lab.polygonal.de/2007/07/18/fast-and-accurate-sinecosine-approximation/
        /// </acknowledgment>
        [DisplayName("Sin and Cos")]
        [Description("Calculate the tuple of Sin and Cos.")]
        [Acknowledgment("http://web.archive.org/web/20110925033606/http://lab.polygonal.de/2007/07/18/fast-and-accurate-sinecosine-approximation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCosLowPrecision(double x)
        {
            // Always wrap input angle to -PI..PI.
            if (x < -PI)
            {
                x += Tau;
            }
            else
            {
                if (x > PI)
                {
                    x -= Tau;
                }
            }

            // Compute sine.
            var sin = x < 0 ? 1.27323954 * x + 0.405284735 * x * x : 1.27323954 * x - 0.405284735 * x * x;

            // Compute cosine: sin(x + PI/2) = cos(x).
            x += HalfPi;
            if (x > PI)
            {
                x -= Tau;
            }

            var cos = x < 0 ? 1.27323954 * x + 0.405284735 * x * x : 1.27323954 * x - 0.405284735 * x * x;

            return (cos, sin);
        }

        /// <summary>
        /// The sin cos high precision.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>The <see cref="T:(double Cos, double Sin)"/>.</returns>
        /// <acknowledgment>
        /// http://web.archive.org/web/20110925033606/http://lab.polygonal.de/2007/07/18/fast-and-accurate-sinecosine-approximation/
        /// </acknowledgment>
        [DisplayName("Sin and Cos")]
        [Description("Calculate the tuple of Sin and Cos.")]
        [Acknowledgment("http://web.archive.org/web/20110925033606/http://lab.polygonal.de/2007/07/18/fast-and-accurate-sinecosine-approximation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCosHighPrecision(double x)
        {
            // Always wrap input angle to -PI..PI
            if (x < -PI)
            {
                x += Tau;
            }
            else
            {
                if (x > PI)
                {
                    x -= Tau;
                }
            }

            // Compute sine
            var sin = 0d;
            if (x < 0)
            {
                sin = 1.27323954 * x + 0.405284735 * x * x;

                sin = sin < 0 ? 0.225d * (sin * -sin - sin) + sin : 0.225d * (sin * sin - sin) + sin;
            }
            else
            {
                sin = 1.27323954d * x - 0.405284735d * x * x;

                sin = sin < 0 ? 0.225d * (sin * -sin - sin) + sin : 0.225d * (sin * sin - sin) + sin;
            }

            // Compute cosine: sin(x + PI/2) = cos(x)
            x += HalfPi;
            if (x > PI)
            {
                x -= Tau;
            }

            var cos = 0d;
            if (x < 0)
            {
                cos = 1.27323954d * x + 0.405284735d * x * x;

                cos = cos < 0 ? 0.225d * (cos * -cos - cos) + cos : 0.225d * (cos * cos - cos) + cos;
            }
            else
            {
                cos = 1.27323954d * x - 0.405284735d * x * x;

                cos = cos < 0d ? 0.225d * (cos * -cos - cos) + cos : 0.225d * (cos * cos - cos) + cos;
            }

            return (cos, sin);
        }

        /// <summary>
        /// The sin cos0.
        /// </summary>
        /// <param name="radian">The radian.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Sin and Cos Lookup")]
        [Description("Calculate the tuple of Sin and Cos.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos0(double radian)
        {
            return sinCosTable.GetValueOrDefault(radian) ?? (sinCosTable[radian] = (Cos(radian), Sin(radian))).Value;
        }

        /// <summary>
        /// The sin cos1.
        /// </summary>
        /// <param name="radian">The radian.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Sin and Cos Lookup")]
        [Description("Calculate the tuple of Sin and Cos.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos1(double radian)
        {
            return (sinCosTable[radian] = sinCosTable.GetValueOrDefault(radian) ?? (Cos(radian), Sin(radian))).Value;
        }

        /// <summary>
        /// The sin cos2.
        /// </summary>
        /// <param name="radian">The radian.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Sin and Cos Lookup")]
        [Description("Calculate the tuple of Sin and Cos.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos2(double radian)
        {
            if (!sinCosTable.ContainsKey(radian))
            {
                sinCosTable.Add(radian, (Cos(radian), Sin(radian)));
            }

            return sinCosTable[radian].Value;
        }

        /// <summary>
        /// The sin cos3.
        /// </summary>
        /// <param name="radian">The radian.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Sin and Cos Lookup")]
        [Description("Calculate the tuple of Sin and Cos.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos3(double radian)
        {
            if (!sinCosTable.ContainsKey(radian))
            {
                var value = (Cos(radian), Sin(radian));
                sinCosTable.Add(radian, value);
                return value;
            }

            return sinCosTable[radian].Value;
        }

        /// <summary>
        /// The sin cos4.
        /// </summary>
        /// <param name="radian">The radian.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Sin and Cos Lookup")]
        [Description("Calculate the tuple of Sin and Cos.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos4(double radian)
        {
            if (!sinCosTable.ContainsKey(radian))
            {
                return (sinCosTable[radian] = (Cos(radian), Sin(radian))).Value;
            }

            return sinCosTable[radian].Value;
        }
    }
}
