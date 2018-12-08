using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The sign of number tests class.
    /// </summary>
    [DisplayName("Sign of a Number")]
    [Description("Find the Sign of a number.")]
    [Signature("public static int Sign(double value)")]
    [SourceCodeLocationProvider]
    public static class SignOfNumberTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SignOfNumberTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.000000001d }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:Signs.Positive, epsilon:double.Epsilon) },
                { new object[] { -1d }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:Signs.Negative, epsilon:double.Epsilon) },
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
        /// Find the Sign of a number.
        /// </summary>
        /// <param name="value">The Value to use.</param>
        /// <returns>
        /// Returns <see cref="Signs.Negative"/>, <see cref="Signs.Zero"/>, or <see cref="Signs.Positive"/> if the sign of the number is negative, 0, or positive.
        /// Throws for floating point NaN's.
        /// </returns>
        /// <exception cref="ArithmeticException">NAN is not a valid value for Sign.</exception>
        /// <acknowledgment>
        /// https://referencesource.microsoft.com/#mscorlib/system/math.cs,8cbccaf4a250fb70
        /// </acknowledgment>
        [DisplayName("Sign of Number Using System.Math.Sign")]
        [Description("Find the Sign of a number using System.Math.Sign.")]
        [Acknowledgment("https://referencesource.microsoft.com/#mscorlib/system/math.cs,8cbccaf4a250fb70")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Signs SignSystem(double value)
        {
            return (Signs)Sign(value);
        }

        /// <summary>
        /// Find the Sign of a number.
        /// </summary>
        /// <param name="value">The Value to use.</param>
        /// <returns>
        /// Returns <see cref="Signs.Negative"/>, <see cref="Signs.Zero"/>, or <see cref="Signs.Positive"/> if the sign of the number is negative, 0, or positive.
        /// </returns>
        [DisplayName("Sign of Number Using Ternary")]
        [Description("Find the Sign of a number using a Ternary tree.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Signs SignTernary(double value)
        {
            return (value < 0d) ? Signs.Negative : (value > 0) ? Signs.Positive : (value == 0) ? Signs.Zero : throw new ArithmeticException("NAN is not a valid value for Sign.");
        }

        /// <summary>
        /// Find the Sign of a number.
        /// </summary>
        /// <param name="value">The Value to use.</param>
        /// <returns>
        /// Returns <see cref="Signs.Negative"/>, <see cref="Signs.Zero"/>, or <see cref="Signs.Positive"/> if the sign of the number is negative, 0, or positive.
        /// </returns>
        /// <exception cref="ArithmeticException">NAN is not a valid value for Sign.</exception>
        /// <acknowledgment>
        /// https://referencesource.microsoft.com/#mscorlib/system/math.cs,8cbccaf4a250fb70
        /// </acknowledgment>
        [DisplayName("Sign of Number Using Switch")]
        [Description("Find the Sign of a number using a Switch statement.")]
        [Acknowledgment("https://referencesource.microsoft.com/#mscorlib/system/math.cs,8cbccaf4a250fb70")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Signs SignSwitch(double value)
        {
            switch (value)
            {
                case double s when s < 0:
                    return Signs.Negative;
                case double s when s > 0:
                    return Signs.Positive;
                case double s when s == 0:
                    return Signs.Zero;
                default:
                    throw new ArithmeticException("NAN is not a valid value for Sign.");
            }
        }

        /// <summary>
        /// Find the Sign of a number.
        /// </summary>
        /// <param name="value">The Value to use.</param>
        /// <returns>
        /// Returns <see cref="Signs.Negative"/>, <see cref="Signs.Zero"/>, or <see cref="Signs.Positive"/> if the sign of the number is negative, 0, or positive.
        /// </returns>
        [DisplayName("Sign of Number Using If")]
        [Description("Find the Sign of a number using a If statement.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Signs SignIf(double value)
        {
            if (value < 0)
            {
                return Signs.Negative;
            }
            else if (value > 0)
            {
                return Signs.Positive;
            }
            else if (value == 0)
            {
                return Signs.Zero;
            }

            throw new ArithmeticException("NAN is not a valid value for Sign.");
        }
    }
}
