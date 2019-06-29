using System;
using System.Collections.Generic;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RectanglePerimeterTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static double RectanglePerimeter(double left, double top, double width, double height)
        {
            return (Distance2DTests.Distance2D(left, top, left + width, top) * 2d) + (Distance2DTests.Distance2D(left, top, left, top + height) * 2d);
        }
    }
}
