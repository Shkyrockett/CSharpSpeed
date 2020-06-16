using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The rectangle contains point tests class.
    /// </summary>
    [DisplayName("Rectangle Contains Point")]
    [Description("Determine whether a point is contained within a Rectangle.")]
    [SourceCodeLocationProvider]
    public static class RectangleContainsPointTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(RectangleContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var rectangle = new Rectangle2D(0d, 0d, 2d, 2d);
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { rectangle, 1d, 1d }, new TestCaseResults(description: "rectangle contains point.", trials: trials, expectedReturnValue: Inclusions.Inside, epsilon: double.Epsilon) },
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
        /// <param name="rectangle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Inclusions RectangleContainsPoint2D(Rectangle2D rectangle, double x, double y)
            => Contains(rectangle, x, y);

        /// <summary>
        /// Determines whether the specified point is contained within the rectangular region defined by this <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DisplayName("Point in Rectangle")]
        [Description("Point in Rectangle method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusions Contains(Rectangle2D rectangle, double X, double Y)
        {
            var point = (X, Y);
            return (rectangle.X <= point.X
                && point.X < rectangle.X + rectangle.Width
                && rectangle.Y <= point.Y
                && point.Y < rectangle.Y + rectangle.Height) ? Inclusions.Inside : Inclusions.Outside;
        }

        /// <summary>
        /// Determines whether the specified point is contained within the rectangular region defined by this <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DisplayName("Point in Rectangle")]
        [Description("Point in Rectangle method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusions Contains2(Rectangle2D rectangle, double X, double Y)
        {
            var point = (X, Y);
            if (((Abs(rectangle.X - point.X) < DoubleEpsilon
                || Abs(rectangle.Bottom - point.X) < DoubleEpsilon)
                && ((rectangle.Y <= point.Y) == (rectangle.Bottom >= point.Y)))
             || ((Abs(rectangle.Right - point.Y) < DoubleEpsilon
             || Abs(rectangle.Left - point.Y) < DoubleEpsilon)
             && ((rectangle.X <= point.X) == (rectangle.Right >= point.X))))
            {
                return Inclusions.Boundary;
            }

            return (rectangle.X <= point.X
                && point.X < rectangle.X + rectangle.Width
                && rectangle.Y <= point.Y
                && point.Y < rectangle.Y + rectangle.Height) ? Inclusions.Inside : Inclusions.Outside;
        }

        /// <summary>
        /// Determines whether the specified point is contained within the rectangular region defined by this <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DisplayName("Point in Rectangle")]
        [Description("Point in Rectangle method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusions PointOnRectangleX(Rectangle2D rectangle, double X, double Y)
        {
            var point = (X, Y);
            var top = Sqrt(((rectangle.Right - rectangle.Left) * (rectangle.Right - rectangle.Left)) + ((rectangle.Top - rectangle.Top) * (rectangle.Top - rectangle.Top)));
            var right = Sqrt(((rectangle.Right - rectangle.Right) * (rectangle.Right - rectangle.Right)) + ((rectangle.Bottom - rectangle.Top) * (rectangle.Bottom - rectangle.Top)));
            var tlp = ((point.X - rectangle.Left) * (point.X - rectangle.Left)) + ((point.Y - rectangle.Top) * (point.Y - rectangle.Top));
            var trp = ((point.X - rectangle.Right) * (point.X - rectangle.Right)) + ((point.Y - rectangle.Top) * (point.Y - rectangle.Top));
            var brp = ((point.X - rectangle.Right) * (point.X - rectangle.Right)) + ((point.Y - rectangle.Bottom) * (point.Y - rectangle.Bottom));
            var blp = ((point.X - rectangle.Left) * (point.X - rectangle.Left)) + ((point.Y - rectangle.Bottom) * (point.Y - rectangle.Bottom));

            if (Abs(top - Sqrt(tlp - trp)) < DoubleEpsilon
                || Abs(right - Sqrt(trp - brp)) < DoubleEpsilon
                || Abs(top - Sqrt(brp - blp)) < DoubleEpsilon
                || Abs(right - Sqrt(blp - tlp)) < DoubleEpsilon)
            {
                return Inclusions.Boundary;
            }

            return (rectangle.X <= point.X
                && point.X < rectangle.X + rectangle.Width
                && rectangle.Y <= point.Y
                && point.Y < rectangle.Y + rectangle.Height) ? Inclusions.Inside : Inclusions.Outside;
        }
    }
}
