using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpSpeed;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The point2d in polygon contour tests class.
    /// </summary>
    [DisplayName("Point in Polygon")]
    [Description("Determine whether a point is contained within a Polygon.")]
    [SourceCodeLocationProvider]
    public static class PolygonContourContainsPointTests
    {
        /// <summary>
        /// Set of tests to run testing methods that test whether a point is contained in a polygon contour.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(PolygonContourContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var point = new Point2D(1, 1);
            var triangle = new List<Point2D> { new Point2D(0, 0), new Point2D(2, 0), new Point2D(0, 2) };
            //var PatrickMullenValues = PrecalcPointInPolygonContourPatrickMullenValues(polygon);
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { triangle, point }, new TestCaseResults(description: "Triangle, contains point.", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PolygonContourContainsPoint(List<Point2D> polygon, Point2D point)
            => PointInPolygonContourJerryKnauss2(polygon, point);

        /// <summary>
        /// The point in polygon contour jerry knauss.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/geometry/polygonmesh/
        /// http://paulbourke.net/geometry/polygonmesh/contains.txt
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Jerry Knauss Point in Polygon method.")]
        [Acknowledgment("http://paulbourke.net/geometry/polygonmesh/", "http://paulbourke.net/geometry/polygonmesh/contains.txt")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourJerryKnauss(
            List<Point2D> polygon, Point2D point)
        {
            var result = false;

            for (var i = 0; i < polygon.Count - 1; i++)
            {
                if ((((polygon[i + 1].Y < point.Y) && (point.Y < polygon[i].Y))
                    || ((polygon[i].Y < point.Y) && (point.Y < polygon[i + 1].Y)))
                    && (point.X < ((polygon[i].X - polygon[i + 1].X)
                    * (point.Y - polygon[i + 1].Y)
                    / (polygon[i].Y - polygon[i + 1].Y)) + polygon[i + 1].X))
                {
                    result = !result;
                }
            }
            return result;
        }

        /// <summary>
        /// The point in polygon contour jerry knauss2.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/geometry/polygonmesh/
        /// http://paulbourke.net/geometry/polygonmesh/contains.txt
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Jerry Knauss Point in Polygon method 2.")]
        [Acknowledgment("http://paulbourke.net/geometry/polygonmesh/", "http://paulbourke.net/geometry/polygonmesh/contains.txt")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourJerryKnauss2(
            List<Point2D> polygon, Point2D point)
        {
            var j = polygon.Count - 1;
            var result = false;

            for (var i = 0; i < polygon.Count; i++)
            {
                if (((
                    (polygon[j].Y < point.Y)
                    && (point.Y < polygon[i].Y))
                    || ((polygon[i].Y < point.Y)
                    && (point.Y < polygon[j].Y)))
                    && (point.X < ((polygon[i].X - polygon[j].X)
                    * (point.Y - polygon[j].Y)
                    / (polygon[i].Y - polygon[j].Y)) + polygon[j].X))
                {
                    result = !result;
                }

                j = i;
            }
            return result;
        }

        /// <summary>
        /// The function will return true if the point x,y is inside the polygon, or
        /// false if it is not.  If the point is exactly on the edge of the polygon,
        /// then the function may return true or false.
        /// </summary>
        /// <param name="point">point to be tested</param>
        /// <param name="polygon">coordinates of corners</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon/
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Darel Rex Finley Point in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/polygon/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourDarelRexFinley(
            List<Point2D> polygon, Point2D point)
        {
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (var i = 0; i < polygon.Count; i++)
            {
                if (
                    polygon[i].Y < point.Y
                    && polygon[j].Y >= point.Y
                    || polygon[j].Y < point.Y
                    && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }

        /// <summary>
        /// The function will return true if the point x,y is inside the polygon, or
        /// false if it is not.  If the point is exactly on the edge of the polygon,
        /// then the function may return true or false.
        /// </summary>
        /// <param name="point">point to be tested</param>
        /// <param name="polygon">coordinates of corners</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon/
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Nathan Mercer Point in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/polygon/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourNathanMercer(
            List<Point2D> polygon, Point2D point)
        {
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (var i = 0; i < polygon.Count; i++)
            {
                //  Note that division by zero is avoided because the division is protected
                //  by the "if" clause which surrounds it.
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y
                && (polygon[i].X <= point.X || polygon[j].X <= point.X))
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        oddNodes = !oddNodes;
                    }
                }

                j = i;
            }

            return oddNodes;
        }

        /// <summary>
        ///  The function will return YES if the point x,y is inside the polygon, or
        ///  NO if it is not.  If the point is exactly on the edge of the polygon,
        ///  then the function may return YES or NO.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon/
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("LaschaLagidse Point in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/polygon/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourLaschaLagidse(
            List<Point2D> polygon, Point2D point)
        {
            int i;
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (i = 0; i < polygon.Count; i++)
            {
                //  Note that division by zero is avoided because the division is protected
                //  by the "if" clause which surrounds it.
                if ((polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                && (polygon[i].X <= point.X || polygon[j].X <= point.X))
                {
                    oddNodes ^= polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X;
                }

                j = i;
            }

            return oddNodes;
        }

        /// <summary>
        ///  USAGE:
        ///  Call precalc_values() to initialize the constant[] and multiple[] arrays,
        ///  then call pointInPolygon(x, y) to determine if the point is in the polygon.
        ///
        ///  The function will return YES if the point x,y is inside the polygon, or
        ///  NO if it is not.  If the point is exactly on the edge of the polygon,
        ///  then the function may return YES or NO.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="polygon">coordinates of corners</param>
        /// <param name="constant">storage for pre-calculated constants (same size as polyX)</param>
        /// <param name="multiple">storage for pre-calculated multipliers (same size as polyX)</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourPatrickMullen(
            List<Point2D> polygon, Point2D point,
            List<double> constant, List<double> multiple)
        {
            int i, j = polygon.Count - 1;
            var oddNodes = false;

            for (i = 0; i < polygon.Count; i++)
            {
                //  Note that division by zero is avoided because the division is protected
                //  by the "if" clause which surrounds it.
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    oddNodes ^= (point.Y * multiple[i]) + constant[i] < point.X;
                }
                j = i;
            }

            return oddNodes;
        }

        /// <summary>
        /// The precalc point in polygon contour patrick mullen values.
        /// </summary>
        /// <param name="polygon">coordinates of corners</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (List<double>, List<double>)? PrecalcPointInPolygonContourPatrickMullenValues(
            List<Point2D> polygon)
        {
            if (polygon is null)
            {
                return null;
            }

            var constant = new double[polygon.Count];
            var multiple = new double[polygon.Count];

            int i, j = polygon.Count - 1;

            for (i = 0; i < polygon.Count; i++)
            {
                if (Abs(polygon[j].Y - polygon[i].Y) < DoubleEpsilon)
                {
                    constant[i] = polygon[i].X;
                    multiple[i] = 0;
                }
                else
                {
                    constant[i] = polygon[i].X - (polygon[i].Y * polygon[j].X
                        / (polygon[j].Y - polygon[i].Y)) + (polygon[i].Y * polygon[i].X
                        / (polygon[j].Y - polygon[i].Y));
                    multiple[i] = (polygon[j].X - polygon[i].X) / (polygon[j].Y - polygon[i].Y);
                }
                j = i;
            }

            return (new List<double>(constant), new List<double>(multiple));
        }

        /// <summary>
        /// Determines if the given point is inside the polygon contour.
        /// </summary>
        /// <param name="polygon">the vertices of polygon</param>
        /// <param name="point">the given point</param>
        /// <returns>true if the point is inside the polygon; otherwise, false</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Contour Meow NET Point in Polygon method.")]
        [Acknowledgment("http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourMeowNET(
            List<Point2D> polygon, Point2D point)
        {
            var result = false;
            var j = polygon.Count - 1;
            for (var i = 0; i < polygon.Count; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon/
        ///  Globals which should be set before calling this function:
        ///
        ///  int    polygon.Count  =  how many corners the polygon has (no repeats)
        ///  double  polyX[]      =  horizontal coordinates of corners
        ///  double  polyY[]      =  vertical coordinates of corners
        ///  double  x, y         =  point to be tested
        ///
        ///  (Globals are used in this example for purposes of speed.  Change as
        ///  desired.)
        ///
        ///  The function will return YES if the point x,y is inside the polygon, or
        ///  NO if it is not.  If the point is exactly on the edge of the polygon,
        ///  then the function may return YES or NO.
        ///
        ///  Note that division by zero is avoided because the division is protected
        ///  by the "if" clause which surrounds it.
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("AlienRyderFlex Point in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/polygon/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourAlienRyderFlex(
            List<Point2D> polygon, Point2D point)
        {
            int i;
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (i = 0; i < polygon.Count; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }

        /// <summary>
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon/
        ///  Globals which should be set before calling this function:
        ///
        ///  int    polygon.Count  =  how many corners the polygon has (no repeats)
        ///  double  polyX[]      =  horizontal coordinates of corners
        ///  double  polyY[]      =  vertical coordinates of corners
        ///  double  x, y         =  point to be tested
        ///
        ///  (Globals are used in this example for purposes of speed.  Change as
        ///  desired.)
        ///
        ///  The function will return YES if the point x,y is inside the polygon, or
        ///  NO if it is not.  If the point is exactly on the edge of the polygon,
        ///  then the function may return YES or NO.
        ///
        ///  Note that division by zero is avoided because the division is protected
        ///  by the "if" clause which surrounds it.
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Lascha Lagidse 2 Point in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/polygon/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourLaschaLagidse2(
            List<Point2D> polygon, Point2D point)
        {
            int i;
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (i = 0; i < polygon.Count; i++)
            {
                if ((polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                && (polygon[i].X <= point.X || polygon[j].X <= point.X))
                {
                    oddNodes ^= polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X;
                }
                j = i;
            }

            return oddNodes;
        }

        /// <summary>
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
        /// http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test
        /// http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("GilKr Point in Polygon method.")]
        [Acknowledgment("http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon", "http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test", "http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourGilKr(
            List<Point2D> polygon, Point2D point)
        {
            var nvert = polygon.Count;
            var c = false;
            for (int i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y))
                 && (point.X < ((polygon[j].X - polygon[i].X)
                 * (point.Y - polygon[i].Y)
                 / (polygon[j].Y - polygon[i].Y)) + polygon[i].X))
                {
                    c = !c;
                }
            }
            return c;
        }

        /// <summary>
        /// The point in polygon contour m katz w randolph franklin.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon
        /// http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("GilKr Point in Polygon method.")]
        [Acknowledgment("http://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon", "http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test", "http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourMKatzWRandolphFranklin(
            List<Point2D> polygon, Point2D point)
        {
            var minX = polygon[0].X;
            var maxX = polygon[0].X;
            var minY = polygon[0].Y;
            var maxY = polygon[0].Y;
            for (var i = 1; i < polygon.Count; i++)
            {
                var q = polygon[i];
                minX = Min(q.X, minX);
                maxX = Max(q.X, maxX);
                minY = Min(q.Y, minY);
                maxY = Max(q.Y, maxY);
            }

            if (point.X < minX || point.X > maxX || point.Y < minY || point.Y > maxY)
            {
                return false;
            }

            // http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
            var inside = false;
            for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
            {
                if ((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)
                     && point.X < ((polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y)
                     / (polygon[j].Y - polygon[i].Y)) + polygon[i].X)
                {
                    inside = !inside;
                }
            }

            return inside;
        }

        /// <summary>
        /// The point in polygon contour paul bourke.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/geometry/polygonmesh/
        /// http://astronomy.swin.edu.au/pbourke/geometry/
        /// http://www.eecs.umich.edu/courses/eecs380/HANDOUTS/PROJ2/InsidePoly.html
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Paul Bourke Point in Polygon method.")]
        [Acknowledgment("http://paulbourke.net/geometry/polygonmesh/", "http://astronomy.swin.edu.au/pbourke/geometry/", "http://www.eecs.umich.edu/courses/eecs380/HANDOUTS/PROJ2/InsidePoly.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourPaulBourke(
            List<Point2D> polygon, Point2D point)
        {
            Point2D p1, p2;
            var counter = 0;
            int i;
            var N = polygon.Count;
            double xinters;
            p1 = polygon[0];
            for (i = 1; i <= N; i++)
            {
                p2 = polygon[i % N];
                if (point.Y > Min(p1.Y, p2.Y))
                {
                    if (point.Y <= Max(p1.Y, p2.Y))
                    {
                        if (point.X <= Max(p1.X, p2.X))
                        {
                            if (Abs(p1.Y - p2.Y) > DoubleEpsilon)
                            {
                                xinters = ((point.Y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y)) + p1.X;
                                if (Abs(p1.X - p2.X) < DoubleEpsilon || point.X <= xinters)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
                p1 = p2;
            }

            return counter % 2 != 0;
        }

        /// <summary>
        /// The point in polygon contour w randolph franklin.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// https://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("W Randolph Franklin Point in Polygon method.")]
        [Acknowledgment("https://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourWRandolphFranklin(
            List<Point2D> polygon, Point2D point)
        {
            var inside = false;
            var nvert = polygon.Count;
            for (int i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y))
                 && (point.X < ((polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y)
                 / (polygon[j].Y - polygon[i].Y)) + polygon[i].X))
                {
                    inside = !inside;
                }
            }
            return inside;
        }

        /// <summary>
        /// The point in polygon contour saeed amiri.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Saeed Amiri Point in Polygon method.")]
        [Acknowledgment("http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourSaeedAmiri(
            List<Point2D> polygon, Point2D point)
        {
            var coef = polygon.Skip(1).Select((p, i) =>
                  ((p.X - polygon[i].X) * (point.Y - polygon[i].Y))
                - ((p.Y - polygon[i].Y) * (point.X - polygon[i].X))
                ).ToList();

            if (coef.Any(p => Abs(p) < DoubleEpsilon))
            {
                return true;
            }

            for (var i = 1; i < coef.Count; i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The point in polygon contour philippe reverdy.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/geometry/polygonmesh/
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Philippe Reverdy Point in Polygon method.")]
        [Acknowledgment("http://paulbourke.net/geometry/polygonmesh/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourPhilippeReverdy(
            List<Point2D> polygon, Point2D point)
        {
            int i;
            double angle = 0;
            var p1 = new Point2D();
            var p2 = new Point2D();
            var n = polygon.Count;
            for (i = 0; i < n; i++)
            {
                p1.X = polygon[i].X - point.X;
                p1.Y = polygon[i].Y - point.Y;
                p2.X = polygon[(i + 1) % n].X - point.X;
                p2.Y = polygon[(i + 1) % n].Y - point.Y;
                angle += Angle2DTests.Angle2DPhilippeReverdy(p1.X, p1.Y, p2.X, p2.Y);
            }

            return !(Abs(angle) < PI);
        }

        /// <summary>
        /// The point in polygon contour rod stephens.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.Return true if the point is in the polygon.</returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Rod Stephens Point in Polygon method.")]
        [Acknowledgment("http://paulbourke.net/geometry/polygonmesh/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourRodStephens(
            List<Point2D> polygon, Point2D point)
        {
            // Get the angle between the point and the
            // first and last vertices.
            var max_point = polygon.Count - 1;
            var total_angle = Angle3Vector2DTests.AngleVector(
                polygon[max_point].X, polygon[max_point].Y,
                point.X, point.Y,
                polygon[0].X, polygon[0].Y);

            // Add the angles from the point
            // to each other pair of vertices.
            for (var i = 0; i < max_point; i++)
            {
                total_angle += Angle3Vector2DTests.AngleVector(
                    polygon[i].X, polygon[i].Y,
                    point.X, point.Y,
                    polygon[i + 1].X, polygon[i + 1].Y);
            }

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            return Abs(total_angle) > 0.000001;
        }

        /// <summary>
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
        /// https://social.msdn.microsoft.com/Forums/windows/en-US/95055cdc-60f8-4c22-8270-ab5f9870270a/determine-if-the-point-is-in-the-polygon-c?forum=winforms
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Keith Point in Polygon method.")]
        [Acknowledgment("http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon", "https://social.msdn.microsoft.com/Forums/windows/en-US/95055cdc-60f8-4c22-8270-ab5f9870270a/determine-if-the-point-is-in-the-polygon-c?forum=winforms")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourKeith(
            List<Point2D> polygon, Point2D point)
        {
            Point2D p1, p2;

            var inside = false;

            if (polygon.Count < 3)
            {
                return inside;
            }

            var oldPoint = polygon[polygon.Count - 1];

            for (var i = 0; i < polygon.Count; i++)
            {
                var newPoint = polygon[i];

                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.X < point.X) == (point.X <= oldPoint.X)
                    && (point.Y - (long)p1.Y) * (p2.X - p1.X)
                    < (p2.Y - (long)p1.Y) * (point.X - p1.X))
                {
                    inside = !inside;
                }

                oldPoint = newPoint;
            }

            return inside;
        }

        /// <summary>
        /// is target point inside a 2D polygon?
        /// </summary>
        /// <param name="polygon">polygon points</param>
        /// <param name="point">target point</param>
        /// <returns></returns>
        [DisplayName("Point in Polygon")]
        [Description("Bob Stein Point in Polygon method.")]
        [Acknowledgment("http://www.visibone.com/inpoly/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourBobStein(
            List<Point2D> polygon, Point2D point)
        {
            double xnew, ynew;
            double xold, yold;
            double x1, y1;
            double x2, y2;
            int i;
            var inside = false;
            var npoints = polygon.Count;
            if (npoints < 3)
            {
                return false;
            }

            xold = polygon[npoints - 1].X;
            yold = polygon[npoints - 1].Y;
            for (i = 0; i < npoints; i++)
            {
                xnew = polygon[i].X;
                ynew = polygon[i].Y;
                if (xnew > xold)
                {
                    x1 = xold;
                    x2 = xnew;
                    y1 = yold;
                    y2 = ynew;
                }
                else
                {
                    x1 = xnew;
                    x2 = xold;
                    y1 = ynew;
                    y2 = yold;
                }
                if ((xnew < point.X) == (point.X <= xold)          /* edge "open" at one end */
                 && ((long)point.Y - (long)y1) * (long)(x2 - x1)
                  < ((long)point.Y - (long)y1) * (long)(point.X - x1))
                {
                    inside = !inside;
                }
                xold = xnew;
                yold = ynew;
            }
            return inside;
        }

        /// <summary>
        /// The point in polygon contour hormann agathos expanded.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>
        /// http://angusj.com/delphi/clipper.php
        /// </acknowledgment>
        //[DisplayName("Point in Polygon")]
        //[Description("Hormann Agathos Expanded Point in Polygon method.")]
        //[Acknowledgment("http://angusj.com/delphi/clipper.php", "http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonContourHormannAgathosExpanded(List<Point2D> polygon, Point2D point)
        {
            // returns 0 if false, +1 if true, -1 if pt ON polygon boundary
            // See "The Point in Polygon Problem for Arbitrary Polygons" by Hormann & Agathos
            // http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf
            var result = Inclusion.Outside;

            // If the polygon has 2 or fewer points, it is a line or point and has no interior.
            if (polygon.Count < 3)
            {
                return Inclusion.Outside;
            }

            var curPoint = polygon[0];
            for (var i = 1; i <= polygon.Count; ++i)
            {
                var nextPoint = i == polygon.Count ? polygon[0] : polygon[i];
                if (Abs(nextPoint.Y - point.Y) < DoubleEpsilon)
                {
                    if ((Abs(nextPoint.X - point.X) < DoubleEpsilon) || (Abs(curPoint.Y - point.Y) < DoubleEpsilon && ((nextPoint.X > point.X) == (curPoint.X < point.X))))
                    {
                        return Inclusion.Boundary;
                    }
                }

                if ((curPoint.Y < point.Y) != (nextPoint.Y < point.Y))
                {
                    if (curPoint.X >= point.X)
                    {
                        if (nextPoint.X > point.X)
                        {
                            result = 1 - result;
                        }
                        else
                        {
                            var determinant = ((curPoint.X - point.X) * (nextPoint.Y - point.Y)) - ((nextPoint.X - point.X) * (curPoint.Y - point.Y));
                            if (Abs(determinant) < DoubleEpsilon)
                            {
                                return Inclusion.Boundary;
                            }

                            if ((determinant > 0d) == (nextPoint.Y > curPoint.Y))
                            {
                                result = 1 - result;
                            }
                        }
                    }
                    else if (nextPoint.X > point.X)
                    {
                        var determinant = ((curPoint.X - point.X) * (nextPoint.Y - point.Y)) - ((nextPoint.X - point.X) * (curPoint.Y - point.Y));
                        if (Abs(determinant) < DoubleEpsilon)
                        {
                            return Inclusion.Boundary;
                        }

                        if ((determinant > 0d) == (nextPoint.Y > curPoint.Y))
                        {
                            result = 1 - result;
                        }
                    }
                }

                curPoint = nextPoint;
            }

            return result;
        }

        /// <summary>
        /// The point in polygon contour hormann agathos expanded2.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>http://angusj.com/delphi/clipper.php</acknowledgment>
        //[DisplayName("Point in Polygon")]
        //[Description("Hormann Agathos Expanded Point in Polygon method 2.")]
        //[Acknowledgment("http://angusj.com/delphi/clipper.php", "http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonContourHormannAgathosExpanded2(List<Point2D> polygon, Point2D point)
        {
            // returns 0 if false, +1 if true, -1 if pt ON polygon boundary
            // See "The Point in Polygon Problem for Arbitrary Polygons" by Hormann & Agathos
            // http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf
            var result = Inclusion.Outside;

            // If the polygon has 2 or fewer points, it is a line or point and has no interior.
            if (polygon.Count < 3)
            {
                return Inclusion.Outside;
            }

            var curPoint = polygon[0];
            for (var i = 1; i <= polygon.Count; ++i)
            {
                var nextPoint = i == polygon.Count ? polygon[0] : polygon[i];
                // Horizontal line special case.
                // Is end point horizontal to test point?
                if ((Abs(nextPoint.Y - point.Y) < DoubleEpsilon)
                    // And is end point vertical to test point?
                    && ((Abs(nextPoint.X - point.X) < DoubleEpsilon)
                    // Or is start point horizontal to test point?
                    // And is test point between end and start
                    || (Abs(curPoint.Y - point.Y) < DoubleEpsilon && ((nextPoint.X > point.X) == (curPoint.X < point.X)))))
                {
                    return Inclusion.Boundary;
                }

                if ((curPoint.Y < point.Y) != (nextPoint.Y < point.Y))
                {
                    if (curPoint.X >= point.X)
                    {
                        if (nextPoint.X > point.X)
                        {
                            result = 1 - result;
                        }
                        else
                        {
                            var determinant = ((curPoint.X - point.X) * (nextPoint.Y - point.Y)) - ((nextPoint.X - point.X) * (curPoint.Y - point.Y));
                            if (Abs(determinant) < DoubleEpsilon)
                            {
                                return Inclusion.Boundary;
                            }

                            if ((determinant > 0d) == (nextPoint.Y > curPoint.Y))
                            {
                                result = 1 - result;
                            }
                        }
                    }
                    else if (nextPoint.X > point.X)
                    {
                        var determinant = ((curPoint.X - point.X) * (nextPoint.Y - point.Y)) - ((nextPoint.X - point.X) * (curPoint.Y - point.Y));
                        if (Abs(determinant) < DoubleEpsilon)
                        {
                            return Inclusion.Boundary;
                        }

                        if ((determinant > 0d) == (nextPoint.Y > curPoint.Y))
                        {
                            result = 1 - result;
                        }
                    }
                }

                curPoint = nextPoint;
            }

            return result;
        }

        /// <summary>
        /// The point in polygon contour hormann agathos simplified.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>http://angusj.com/delphi/clipper.php</acknowledgment>
        //[DisplayName("Point in Polygon")]
        //[Description("Hormann Agathos Simplified Point in Polygon method.")]
        //[Acknowledgment("http://angusj.com/delphi/clipper.php", "http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonContourHormannAgathosSimplified(List<Point2D> polygon, Point2D point)
        {
            // returns 0 if false, +1 if true, -1 if pt ON polygon boundary
            // See "The Point in Polygon Problem for Arbitrary Polygons" by Hormann & Agathos
            // http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf
            var result = Inclusion.Outside;

            // If the polygon has 2 or fewer points, it is a line or point and has no interior.
            if (polygon.Count < 3)
            {
                return Inclusion.Outside;
            }

            var curPoint = polygon[0];
            var nextPoint = polygon[1];
            for (var i = 1; i <= polygon.Count; ++i)
            {
                nextPoint = i == polygon.Count ? polygon[0] : polygon[i];
                if (Abs(nextPoint.Y - point.Y) < DoubleEpsilon)
                {
                    if ((Abs(nextPoint.X - point.X) < DoubleEpsilon)
                        || (Abs(curPoint.Y - point.Y) < DoubleEpsilon
                        && ((nextPoint.X > point.X) == (curPoint.X < point.X))))
                    {
                        return Inclusion.Boundary;
                    }
                }

                if ((curPoint.Y < point.Y) != (nextPoint.Y < point.Y))
                {
                    if (curPoint.X >= point.X && nextPoint.X > point.X)
                    {
                        result = 1 - result;
                    }
                    else if (curPoint.X >= point.X && nextPoint.X <= point.X || curPoint.X < point.X && nextPoint.X > point.X)
                    {
                        var determinant = ((curPoint.X - point.X) * (nextPoint.Y - point.Y)) - ((nextPoint.X - point.X) * (curPoint.Y - point.Y));
                        if (Abs(determinant) < Epsilon)
                        {
                            return Inclusion.Boundary;
                        }
                        else if ((determinant > 0) == (nextPoint.Y > curPoint.Y))
                        {
                            result = 1 - result;
                        }
                    }
                }

                curPoint = nextPoint;
            }

            return result;
        }

        /// <summary>
        /// The point in polygon contour hormann agathos expanded3.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>http://angusj.com/delphi/clipper.php</acknowledgment>
        //[DisplayName("Point in Polygon")]
        //[Description("Hormann Agathos Expanded Point in Polygon method 3.")]
        //[Acknowledgment("http://angusj.com/delphi/clipper.php", "http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonContourHormannAgathosExpanded3(List<Point2D> polygon, Point2D point)
        {
            // returns 0 if false, +1 if true, -1 if pt ON polygon boundary
            // See "The Point in Polygon Problem for Arbitrary Polygons" by Hormann & Agathos
            // http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf
            var result = Inclusion.Outside;

            // If the polygon has 2 or fewer points, it is a line or point and has no interior.
            if (polygon.Count < 3)
            {
                return Inclusion.Outside;
            }

            var curPoint = polygon[0];
            for (var i = 1; i <= polygon.Count; ++i)
            {
                var nextPoint = i == polygon.Count ? polygon[0] : polygon[i];
                if (Abs(nextPoint.Y - point.Y) < DoubleEpsilon)
                {
                    if ((Abs(nextPoint.X - point.X) < DoubleEpsilon)
                        || (Abs(curPoint.Y - point.Y) < DoubleEpsilon
                        && ((nextPoint.X > point.X) == (curPoint.X < point.X))))
                    {
                        return Inclusion.Boundary;
                    }
                }

                if ((curPoint.Y < point.Y) != (nextPoint.Y < point.Y))
                {
                    if (curPoint.X >= point.X)
                    {
                        if (nextPoint.X > point.X)
                        {
                            result = 1 - result;
                        }
                        else
                        {
                            result = process(nextPoint.X, nextPoint.Y);
                            if (result == Inclusion.Boundary)
                            {
                                return result;
                            }
                        }
                    }
                    else if (nextPoint.X > point.X)
                    {
                        result = process(nextPoint.X, nextPoint.Y);
                        if (result == Inclusion.Boundary)
                        {
                            return result;
                        }
                    }
                }

                curPoint = nextPoint;
            }

            Inclusion process(double nextPointX, double nextPointY)
            {
                var determinant = ((curPoint.X - point.X) * (nextPointY - point.Y)) - ((nextPointX - point.X) * (curPoint.Y - point.Y));
                if (Abs(determinant) < DoubleEpsilon)
                {
                    return Inclusion.Boundary;
                }

                if ((determinant > 0d) == (nextPointY > curPoint.Y))
                {
                    return 1 - result;
                }

                return result;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="List{Point2D}"/>.
        /// </summary>
        /// <param name="polygon">The points that form the corners of the polygon.</param>
        /// <param name="point">The coordinate of the test point.</param>
        /// <returns>
        /// Returns Outside (0) if false, Inside (+1) if true, Boundary (-1) if the point is on a polygon boundary.
        /// </returns>
        /// <acknowledgment>
        /// Adapted from Clipper library: http://www.angusj.com/delphi/clipper.php
        /// See "The Point in Polygon Problem for Arbitrary Polygons" by Hormann and Agathos
        /// http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf
        /// </acknowledgment>
        [DisplayName("Point in Polygon")]
        [Description("Hormann Agathos Point in Polygon method.")]
        [Acknowledgment("http://angusj.com/delphi/clipper.php", "http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        public static bool PointInPolygonContourHormannAgathosNewFor(List<Point2D> polygon, Point2D point)
            => PointInPolygonContourHormannAgathosNewFor(polygon, point, Epsilon) != Inclusion.Outside;

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="PolygonContour2D"/>.
        /// </summary>
        /// <param name="points">The points that form the corners of the polygon.</param>
        /// <param name="p">The coordinate of the test point.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>
        /// Returns Outside (0) if false, Inside (+1) if true, Boundary (-1) if the point is on a polygon boundary.
        /// </returns>
        /// <acknowledgment>
        /// Adapted from Clipper library: http://www.angusj.com/delphi/clipper.php
        /// See "The Point in Polygon Problem for Arbitrary Polygons" by Hormann and Agathos
        /// http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonContourHormannAgathosNewFor(
            List<Point2D> points,
            Point2D p,
            double epsilon = Epsilon)
        {
            // Default value is no inclusion.
            var result = Inclusion.Outside;

            // Special cases for points and line segments.
            if (points.Count < 3)
            {
                if (points.Count == 1)
                {
                    // If the polygon has 1 point, it is a point and has no interior, but a point can intersect a point.
                    return (p.X == points[0].X && p.Y == points[0].Y) ? Inclusion.Boundary : Inclusion.Outside;
                }
                else if (points.Count == 2)
                {
                    // If the polygon has 2 points, it is a line and has no interior, but a point can intersect a line.
                    return ((p.X == points[0].X) && (p.Y == points[0].Y))
                        || ((p.X == points[1].X) && (p.Y == points[1].Y))
                        || (((p.X > points[0].X) == (p.X < points[1].X))
                        && ((p.Y > points[0].Y) == (p.Y < points[1].Y))
                        && ((p.X - points[0].X) * (points[1].Y - points[0].Y) == (p.Y - points[0].Y) * (points[1].X - points[0].X))) ? Inclusion.Boundary : Inclusion.Outside;
                }
                else
                {
                    // Empty geometry.
                    return Inclusion.Outside;
                }
            }

            // Loop through each line segment.
            Point2D curPoint;
            Point2D nextPoint;
            for (int i = points.Count - 1, j = 0; j < points.Count; i = j++)
            {
                curPoint = points[i];
                nextPoint = points[j];
                // Special case for horizontal lines. Check whether the point is on one of the ends, or whether the point is on the segment, if the line is horizontal.
                if (nextPoint.Y == p.Y && (nextPoint.X == p.X || ((curPoint.Y == p.Y) && ((nextPoint.X > p.X) == (curPoint.X < p.X)))))
                //if ((Abs(nextPoint.Y - pY) < epsilon) && ((Abs(nextPoint.X - pX) < epsilon) || (Abs(curPoint.Y - pY) < epsilon && ((nextPoint.X > pX) == (curPoint.X < pX)))))
                {
                    return Inclusion.Boundary;
                }

                // If Point between start and end points horizontally.
                //if ((curPoint.Y < pY) == (nextPoint.Y >= pY))
                if ((curPoint.Y < p.Y) != (nextPoint.Y < p.Y))
                {
                    // If point between start and end points vertically.
                    if (curPoint.X >= p.X)
                    {
                        if (nextPoint.X > p.X)
                        {
                            result = 1 - result;
                        }
                        else
                        {
                            var determinant = ((curPoint.X - p.X) * (nextPoint.Y - p.Y)) - ((nextPoint.X - p.X) * (curPoint.Y - p.Y));
                            if (Abs(determinant) < epsilon)
                            {
                                return Inclusion.Boundary;
                            }
                            else if ((determinant > 0) == (nextPoint.Y > curPoint.Y))
                            {
                                result = 1 - result;
                            }
                        }
                    }
                    else if (nextPoint.X > p.X)
                    {
                        var determinant = ((curPoint.X - p.X) * (nextPoint.Y - p.Y)) - ((nextPoint.X - p.X) * (curPoint.Y - p.Y));
                        if (Abs(determinant) < epsilon)
                        {
                            return Inclusion.Boundary;
                        }

                        if ((determinant > 0) == (nextPoint.Y > curPoint.Y))
                        {
                            result = 1 - result;
                        }
                    }
                }
            }

            return result;
        }
    }
}
