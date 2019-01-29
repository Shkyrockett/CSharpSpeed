namespace InstrumentedLibrary
{
    /// <summary>
    /// The wrap point to rectangle tests class.
    /// </summary>
    //[DisplayName("Wrap a Point to a rectangle Tests")]
    //[Description("Wrap a point to the bounds of a rectangle.")]
    //[Signature("public static Point2D WrapPointToRectangle(Point2D point, Rectangle2D bounds)")]
    //[SourceCodeLocationProvider]
    public static class WrapPointToRectangleTests
    {
        ///// <summary>
        ///// Set of tests to run testing methods that calculate the wrapped position of a point in a rectangle.
        ///// </summary>
        ///// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        //[DisplayName(nameof(Point2DInCircle2DTests))]
        //public static List<SpeedTester> TestHarness()
        //{
        //    var trials = 10000;
        //    var tests = new Dictionary<object[], TestCaseResults> {
        //        { new object[] { new Rectangle2D(0d, 0d, 10d, 10d), new Point2D(5d, 5d) }, new TestCaseResults(description: "Warp a point", trials: trials, expectedReturnValue: new Point2D(1.625d, 1.25d), DoubleEpsilon) },
        //        { new object[] { new Rectangle2D(0d, 0d, 20d, 20d), new Point2D(31d, 21d) }, new TestCaseResults(description: "Warp a point", trials: trials, expectedReturnValue: new Point2D(1.625d, 1.25d), DoubleEpsilon) },
        //    };

        //    var results = new List<SpeedTester>();
        //    foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
        //    {
        //        var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
        //        results.Add(new SpeedTester(method, methodDescription, tests));
        //    }
        //    return results;
        //}

        /// <summary>
        /// The wrap point to rectangle.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="point">The point.</param>
        /// <param name="reference">The reference.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        public static Point2D WrapPointToRectangle(Rectangle2D bounds, Point2D point, ref Point2D reference)
        {
            // ToDo: Try to remember why reference is used here...
            if (point.X <= bounds.X)
            {
                reference -= new Size2D(bounds.X, 0);
                return new Point2D(bounds.Width - 2, point.Y);
            }
            if (point.Y <= bounds.Y)
            {
                reference -= new Size2D(0, bounds.Y);
                return new Point2D(point.X, bounds.Height - 2);
            }
            if (point.X >= (bounds.Width - 1))
            {
                reference += new Size2D(bounds.Width, 0);
                return new Point2D(bounds.X + 2, point.Y);
            }
            if (point.Y >= (bounds.Height - 1))
            {
                reference += new Size2D(0, bounds.Height);
                return new Point2D(point.X, bounds.Y + 2);
            }
            return point;
            // 'ToDo: Adjust My_StartPoint when Screen is wrapped
        }
    }
}
