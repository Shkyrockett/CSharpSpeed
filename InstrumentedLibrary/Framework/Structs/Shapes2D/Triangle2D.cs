using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public class Triangle2D
    {
        private Point2D a;
        private Point2D b;
        private Point2D c;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Triangle2D(Point2D a, Point2D b, Point2D c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Point2D A
        {
            get
            {
                return a;
            }

            set
            {
                a = value;
            }
        }

        public Point2D B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;
            }
        }

        public Point2D C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Point2D point)
            => PolygonContourContainsPointTests.PointInPolygonContour(new List<Point2D> { a, b, c }, point);
    }
}