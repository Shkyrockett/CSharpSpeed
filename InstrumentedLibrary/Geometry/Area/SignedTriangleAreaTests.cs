using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The signed triangle area tests class.
    /// </summary>
    [DisplayName("Signed Area of Triangle")]
    [Description("Find the signed area of a triangle.")]
    [SourceCodeLocationProvider]
    public static class SignedTriangleAreaTests
    {
        /// <summary>
        /// Set of Finds the signed area of a triangle.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SignedTriangleAreaTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: -1d, epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double SignedTriangleArea(double aX, double aY, double bX, double bY, double cX, double cY)
            => SignedTriangleAreaVelcroPhysics(aX, aY, bX, bY, cX, cY);

        /// <summary>
        /// Returns a positive number if c is to the left of the line going from a to b.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns>
        /// Positive number if point is left, negative if point is right,
        /// and 0 if points are collinear.
        /// </returns>
        /// <acknowledgment>
        /// From Farseer Physics Engine. https://github.com/VelcroPhysics/VelcroPhysics
        /// </acknowledgment>
        [DisplayName("Signed Area of Triangle")]
        [Description("Find the signed area of a triangle.")]
        [Acknowledgment("https://github.com/VelcroPhysics/VelcroPhysics")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedTriangleAreaVelcroPhysics(double aX, double aY, double bX, double bY, double cX, double cY)
        {
            return aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY);
        }

        /// <summary>
        /// Returns a positive number if c is to the left of the line going from a to b.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns>
        /// Positive number if point is left, negative if point is right,
        /// and 0 if points are collinear.
        /// </returns>
        /// <acknowledgment>
        /// w8r
        /// </acknowledgment>
        [DisplayName("Signed Area of Triangle")]
        [Description("Find the signed area of a triangle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedTriangleAreaW8R(double aX, double aY, double bX, double bY, double cX, double cY)
        {
            return (aX - cX) * (bY - cY) - (bX - cX) * (aY - cY);
        }
    }
}
