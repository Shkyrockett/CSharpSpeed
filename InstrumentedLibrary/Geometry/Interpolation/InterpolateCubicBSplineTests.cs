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
    /// The interpolate cubic b spline tests class.
    /// </summary>
    [DisplayName("Cubic B-Spline Interpolate 2D Tests")]
    [Description("Find a point on a 2D Cubic B-Spline curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateCubicBSplineTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateCubicBSplineTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (IList<(double X, double Y)>)new List<(double X, double Y)> { (0d, 0d), (1d, 1d), (2d, 0d), (3d, 1d) }, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(3d, 4d), epsilon: double.Epsilon) },
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
        /// <param name="points"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) InterpolateBSpline(IList<(double X, double Y)> points, double index)
            => InterpolateBSpline_(points, index);

        /// <summary>
        /// Function to Interpolate a Cubic Bezier Spline
        /// </summary>
        /// <param name="points"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DisplayName("Cubic B-Spline Interpolate 2D Tests")]
        [Description("Find a point on a 2D Cubic B-Spline curve.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateBSpline_(IList<(double X, double Y)> points, double index)
        {
            if (points.Count >= 4)
            {
                var VPoints = new List<(double X, double Y)>(4);

                const int A = 0;
                const int B = 1;
                const int C = 2;
                const int D = 3;

                VPoints.Add((
                    points[D].X - points[C].X - (points[A].X - points[B].X),
                    points[D].Y - points[C].Y - (points[A].Y - points[B].Y)
                    ));

                VPoints.Add((
                    points[A].X - points[B].X - VPoints[A].X,
                    points[A].Y - points[B].Y - VPoints[A].Y
                    ));

                VPoints.Add((
                    points[C].X - points[A].X,
                    points[C].Y - points[A].Y
                    ));

                VPoints.Add(points[1]);

                return (
                    VPoints[0].X * index * index * index + VPoints[1].X * index * index * index + VPoints[2].X * index + VPoints[3].X,
                    VPoints[0].Y * index * index * index + VPoints[1].Y * index * index * index + VPoints[2].Y * index + VPoints[3].Y
                );
            }

            return (0, 0);
        }

        /// <summary>
        /// General Bézier curve Number of control points is n+1 0 less than or equal to mu less than 1
        /// IMPORTANT, the last point is not computed.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DisplayName("Cubic B-Spline Interpolate 2D Tests")]
        [Description("Find a point on a 2D Cubic B-Spline curve.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate(IList<(double X, double Y)> points, double index)
        {
            var n = points.Count - 1;
            int kn;
            int nn;
            int nkn;

            double blend;
            double muk = 1;
            var munk = Pow(1 - index, n);

            var b = (X: 0d, Y: 0d);

            for (var k = 0; k <= n; k++)
            {
                nn = n;
                kn = k;
                nkn = n - k;
                blend = muk * munk;
                muk *= index;
                munk /= 1 - index;
                while (nn >= 1)
                {
                    blend *= nn;
                    nn--;
                    if (kn > 1)
                    {
                        blend /= kn;
                        kn--;
                    }
                    if (nkn > 1)
                    {
                        blend /= nkn;
                        nkn--;
                    }
                }

                b = (
                b.X + points[k].X * blend,
                b.Y + points[k].Y * blend
                    );
            }

            return b;
        }

        /// <summary>
        /// Function to Interpolate a Cubic Bezier Spline
        /// </summary>
        /// <param name="Points"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        [DisplayName("Cubic B-Spline Interpolate 2D Tests")]
        [Description("Find a point on a 2D Cubic B-Spline curve.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateCubicBSplinePoint(IList<(double X, double Y)> Points, double Index)
        {
            var VPoints = new (double X, double Y)[4];

            VPoints[0] = (
                Points[3].X - Points[2].X - (Points[0].X - Points[1].X),
                Points[3].Y - Points[2].Y - (Points[0].Y - Points[1].Y)
                );

            VPoints[1] = (
                Points[0].X - Points[1].X - VPoints[0].X,
                Points[0].Y - Points[1].Y - VPoints[0].Y
                );

            VPoints[2] = (
                Points[2].X - Points[0].X,
                Points[2].Y - Points[0].Y
                );

            VPoints[3] = Points[1];

            return (
                VPoints[0].X * Index * Index * Index + VPoints[1].X * Index * Index * Index + VPoints[2].X * Index + VPoints[3].X,
                VPoints[0].Y * Index * Index * Index + VPoints[1].Y * Index * Index * Index + VPoints[2].Y * Index + VPoints[3].Y
            );
        }
    }
}
