using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The nearest point on line segment tests class.
    /// </summary>
    [DisplayName("Nearest Point on Line Segment")]
    [Description("Find the nearest point on a line segment to a point.")]
    [Signature("public static (double X, double Y) ClosestPointOnLineSegment(double aX, double aY, double bX, double bY, double pX, double pY)")]
    [SourceCodeLocationProvider]
    public static class NearestPointOnLineSegmentTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the cross product of three 2D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(NearestPointOnLineSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 0d, 1d, 1d }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:(1d, 0d), epsilon:double.Epsilon) },
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
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) ClosestPointOnLineSegment(double aX, double aY, double bX, double bY, double pX, double pY)
            => ClosestPointOnLineSegmentDarienPardinas(aX, aY, bX, bY, pX, pY);

        /// <summary>
        /// The closest point on line segment mv g.
        /// </summary>
        /// <param name="aX">The aX.</param>
        /// <param name="aY">The aY.</param>
        /// <param name="bX">The bX.</param>
        /// <param name="bY">The bY.</param>
        /// <param name="pX">The pX.</param>
        /// <param name="pY">The pY.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line
        /// </acknowledgment>
        [DisplayName("Nearest Point on Line Segment")]
        [Description("Find the nearest point on a line segment to a point.")]
        [Acknowledgment("http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) ClosestPointOnLineSegmentMvG(
            double aX, double aY,
            double bX, double bY,
            double pX, double pY)
        {
            // Vector A->B
            var diffAB = (X: aX - bX, Y: aY - bY);
            var det = aY * bX - aX * bY;
            var dot = diffAB.X * pX + diffAB.Y * pY;
            var val = (X: dot * diffAB.X + det * diffAB.Y, Y: dot * diffAB.Y - det * diffAB.X);
            var magnitude = diffAB.X * diffAB.X + diffAB.Y * diffAB.Y;
            var inverseDist = 1 / magnitude;
            return (val.X * inverseDist, val.Y * inverseDist);
        }

        /// <summary>
        /// The closest point on line segment darien pardinas.
        /// </summary>
        /// <param name="aX">The aX.</param>
        /// <param name="aY">The aY.</param>
        /// <param name="bX">The bX.</param>
        /// <param name="bY">The bY.</param>
        /// <param name="pX">The pX.</param>
        /// <param name="pY">The pY.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line
        /// </acknowledgment>
        [DisplayName("Nearest Point on Line Segment")]
        [Description("Find the nearest point on a line segment to a point.")]
        [Acknowledgment("http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) ClosestPointOnLineSegmentDarienPardinas(
            double aX, double aY,
            double bX, double bY,
            double pX, double pY)
        {
            // Vector A->P
            var diffAP = (X: pX - aX, Y: pY - aY);
            // Vector A->B
            var diffAB = (X: bX - aX, Y: bY - aY);
            var dotAB = diffAB.X * diffAB.X + diffAB.Y * diffAB.Y;
            // The dot product of diffAP and diffAB
            var dotABAP = diffAP.X * diffAB.X + diffAP.Y * diffAB.Y;
            //  # The normalized "distance" from a to the closest point
            var dist = dotABAP / dotAB;
            if (dist < 0)
            {
                return (aX, aY);
            }
            else if (dist > dotABAP)
            {
                return (bX, bY);
            }
            else
            {
                return (aX + diffAB.X * dist, aY + diffAB.Y * dist);
            }
        }

        /// <summary>
        /// The closest point on line darien pardinas.
        /// </summary>
        /// <param name="aX">The aX.</param>
        /// <param name="aY">The aY.</param>
        /// <param name="bX">The bX.</param>
        /// <param name="bY">The bY.</param>
        /// <param name="pX">The pX.</param>
        /// <param name="pY">The pY.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line
        /// </acknowledgment>
        [DisplayName("Nearest Point on Line Segment")]
        [Description("Find the nearest point on a line segment to a point.")]
        [Acknowledgment("http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) ClosestPointOnLineDarienPardinas(
            double aX, double aY,
            double bX, double bY,
            double pX, double pY)
        {
            // Vector A->P
            var diffAP = (X: pX - aX, Y: pY - aY);
            // Vector A->B
            var diffAB = (X: bX - aX, Y: bY - aY);
            var dotAB = diffAB.X * diffAB.X + diffAB.Y * diffAB.Y;
            // The dot product of diffAP and diffAB
            var dotABAP = diffAP.X * diffAB.X + diffAP.Y * diffAB.Y;
            // The normalized "distance" from a to the closest point
            var dist = dotABAP / dotAB;
            return (aX + diffAB.X * dist, aY + diffAB.Y * dist);
        }
    }
}
