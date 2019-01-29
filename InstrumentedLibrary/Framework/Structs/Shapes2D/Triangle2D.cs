using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public class Triangle2D
    {
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Triangle2D(Point2D a, Point2D b, Point2D c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public Point2D A { get; set; }

        public Point2D B { get; set; }

        public Point2D C { get; set; }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Point2D point)
            => PolygonContourContainsPointTests.PolygonContourContainsPoint(new List<Point2D> { A, B, C }, point);
    }
}