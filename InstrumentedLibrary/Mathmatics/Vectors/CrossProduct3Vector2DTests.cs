using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cross product3vector2d tests class.
    /// </summary>
    [DisplayName("Cross Product 3 Vector2D Tests")]
    [Description("Returns the cross product of three 2D vectors.")]
    [SourceCodeLocationProvider]
    public static class CrossProduct3Vector2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the cross product of three 2D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(CrossProduct3Vector2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 0d, 1d, 1d }, new TestCaseResults(description:"0, 0, 1, 0, 1, 1.", trials:trials, expectedReturnValue:-1d, epsilon:double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CrossProductVector2D(double aX, double aY, double bX, double bY, double cX, double cY)
            => CrossProductVector2D_0(aX, aY, bX, bY, cX, cY);

        /// <summary>
        /// The cross product is a vector perpendicular to AB
        /// and BC having length |AB| * |BC| * Sin(theta) and
        /// with direction given by the right-hand rule.
        /// For two vectors in the X-Y plane, the result is a
        /// vector with X and Y components 0 so the Z component
        /// gives the vector's length and direction.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns>
        /// Return the cross product AB x BC.
        /// </returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
        /// </acknowledgment>
        [DisplayName("Cross Product of three 2D Vectors 1")]
        [Description("Cross Product of three 2D Vectors")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductVector2D_0(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
        {
            return ((aX - bX) * (cY - bY)) - ((aY - bY) * (cX - bX));
        }

        /// <summary>
        /// The cross product vector0.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://www.angusj.com
        /// </acknowledgment>
        [DisplayName("Cross Product of three 2D Vectors 1")]
        [Description("Cross Product of three 2D Vectors")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductVector0(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            return (x2 - x1) * (y1 - y3) - (x1 - x3) * (y2 - y1);
        }

        /// <summary>
        /// The cross product is a vector perpendicular to AB
        /// and BC having length |AB| * |BC| * Sin(theta) and
        /// with direction given by the right-hand rule.
        /// For two vectors in the X-Y plane, the result is a
        /// vector with X and Y components 0 so the Z component
        /// gives the vector's length and direction.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns>
        /// Return the cross product AB x BC.
        /// </returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
        /// </acknowledgment>
        [DisplayName("Cross Product of three 2D Vectors 1")]
        [Description("Cross Product of three 2D Vectors")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductVector2D_1(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
        {
            // Get the vectors' coordinates.
            var BAx = aX - bX;
            var BAy = aY - bY;
            var BCx = cX - bX;
            var BCy = cY - bY;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy) - (BAy * BCx);
        }

        /// <summary>
        /// Return the cross product AB x BC.
        /// The cross product is a vector perpendicular to AB
        /// and BC having length |AB| * |BC| * Sin(theta) and
        /// with direction given by the right-hand rule.
        /// For two vectors in the X-Y plane, the result is a
        /// vector with X and Y components 0 so the Z component
        /// gives the vector's length and direction.
        /// </summary>
        /// <param name="Ax"></param>
        /// <param name="Ay"></param>
        /// <param name="Bx"></param>
        /// <param name="By"></param>
        /// <param name="Cx"></param>
        /// <param name="Cy"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/
        /// </acknowledgment>
        [DisplayName("Cross Product of three 2D Vectors 2")]
        [Description("Cross Product of three 2D Vectors")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductVector2D_2(
            double Ax, double Ay,
            double Bx, double By,
            double Cx, double Cy)
        {
            // Get the vectors' coordinates.
            var BAx = Ax - Bx;
            var BAy = Ay - By;
            var BCx = Cx - Bx;
            var BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy) - (BAy * BCx);
        }
    }
}
