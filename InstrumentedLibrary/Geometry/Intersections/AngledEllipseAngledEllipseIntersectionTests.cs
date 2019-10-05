using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class AngledEllipseAngledEllipseIntersectionTests
    {
        /// <summary>
        /// Ellipse, Ellipse intersection.
        /// </summary>
        /// <param name="h1">The c1 x.</param>
        /// <param name="k1">The c1 y.</param>
        /// <param name="a1">The RX1.</param>
        /// <param name="b1">The ry1.</param>
        /// <param name="angle1">The angle1.</param>
        /// <param name="h2">The c2 x.</param>
        /// <param name="k2">The c2 y.</param>
        /// <param name="a2">The RX2.</param>
        /// <param name="b2">The ry2.</param>
        /// <param name="angle2">The angle2.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection EllipseEllipseIntersection(double h1, double k1, double a1, double b1, double angle1, double h2, double k2, double a2, double b2, double angle2, double epsilon = double.Epsilon) => RotatedEllipseRotatedEllipseIntersectionTests.EllipseEllipseIntersection(h1, k1, a1, b1, Cos(angle1), Sin(angle1), h2, k2, a2, b2, Cos(angle2), Sin(angle2), epsilon);
    }
}
