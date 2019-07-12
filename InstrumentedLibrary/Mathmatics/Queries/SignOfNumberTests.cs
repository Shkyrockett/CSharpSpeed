using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The sign of number tests class.
    /// </summary>
    [DisplayName("Sign of a Number")]
    [Description("Find the Sign of a number.")]
    [SourceCodeLocationProvider]
    public static class SignOfNumberTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SignOfNumberTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.000000001d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:InstrumentedLibrary.Sign.Positive, epsilon: double.Epsilon) },
                { new object[] { -1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:InstrumentedLibrary.Sign.Negative, epsilon: double.Epsilon) },
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
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Sign Sign(double value)
            => SignSystem(value);

        /// <summary>
        /// Find the Sign of a number.
        /// </summary>
        /// <param name="value">The Value to use.</param>
        /// <returns>
        /// Returns <see cref="Sign.Negative"/>, <see cref="Sign.Zero"/>, or <see cref="Sign.Positive"/> if the sign of the number is negative, 0, or positive.
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
        public static Sign SignSystem(double value)
        {
            return (Sign)Math.Sign(value);
        }

        /// <summary>
        /// Find the Sign of a number.
        /// </summary>
        /// <param name="value">The Value to use.</param>
        /// <returns>
        /// Returns <see cref="Sign.Negative"/>, <see cref="Sign.Zero"/>, or <see cref="Sign.Positive"/> if the sign of the number is negative, 0, or positive.
        /// </returns>
        [DisplayName("Sign of Number Using Ternary")]
        [Description("Find the Sign of a number using a Ternary tree.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Sign SignTernary(double value)
        {
            return (value < 0d) ? InstrumentedLibrary.Sign.Negative : (value > 0) ? InstrumentedLibrary.Sign.Positive : (value == 0) ? InstrumentedLibrary.Sign.Zero : throw new ArithmeticException("NAN is not a valid value for Sign.");
        }

        /// <summary>
        /// Find the Sign of a number.
        /// </summary>
        /// <param name="value">The Value to use.</param>
        /// <returns>
        /// Returns <see cref="Sign.Negative"/>, <see cref="Sign.Zero"/>, or <see cref="Sign.Positive"/> if the sign of the number is negative, 0, or positive.
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
        public static Sign SignSwitch(double value)
        {
            switch (value)
            {
                case double s when s < 0:
                    return InstrumentedLibrary.Sign.Negative;
                case double s when s > 0:
                    return InstrumentedLibrary.Sign.Positive;
                case double s when s == 0:
                    return InstrumentedLibrary.Sign.Zero;
                default:
                    throw new ArithmeticException("NAN is not a valid value for Sign.");
            }
        }

        /// <summary>
        /// Find the Sign of a number.
        /// </summary>
        /// <param name="value">The Value to use.</param>
        /// <returns>
        /// Returns <see cref="Sign.Negative"/>, <see cref="Sign.Zero"/>, or <see cref="Sign.Positive"/> if the sign of the number is negative, 0, or positive.
        /// </returns>
        [DisplayName("Sign of Number Using If")]
        [Description("Find the Sign of a number using a If statement.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Sign SignIf(double value)
        {
            if (value < 0)
            {
                return InstrumentedLibrary.Sign.Negative;
            }
            else if (value > 0)
            {
                return InstrumentedLibrary.Sign.Positive;
            }
            else if (value == 0)
            {
                return InstrumentedLibrary.Sign.Zero;
            }

            throw new ArithmeticException("NAN is not a valid value for Sign.");
        }
    }
}
