using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Find Parabola a from a point and a vertex")]
    [Description("Find Parabola a from a point and a vertex.")]
    [SourceCodeLocationProvider]
    public static class FindParabolaAFromAPointAndVertexTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(FindParabolaAFromAPointAndVertexTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 6d, 0d, 4.8530d, 10d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: -7.601042558997389d, epsilon: double.Epsilon) },
                { new object[] { 6d, 0d, 2.9970d, 10d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: -1.1088922177833265d, epsilon: double.Epsilon) },
                { new object[] { 2d, 10d, 5d, 8d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 0.2222222222222222d, epsilon: double.Epsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double FindParabolaAFromAPointAndVertex(double x, double y, double h, double k)
            => FindParabolaAFromAPointAndVertex1(x, y, h, k);

        /// <summary>
        /// Find the a of a parabola given two points on the parabola and the k vertex height.
        /// </summary>
        /// <param name="x">The x component of a point on the parabola.</param>
        /// <param name="y">The y component of a point on the parabola.</param>
        /// <param name="h">The h or horizontal component of the vertex of the parabola.</param>
        /// <param name="k">The k or vertex height of the parabola.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK
        /// </acknowledgment>
        [DisplayName("Find Parabola a from a point and a vertex")]
        [Description("Find Parabola a from a point and a vertex.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FindParabolaAFromAPointAndVertex1(double x, double y, double h, double k)
        {
            return x - h is 0d ? 0d : (y - k) / ((x - h) * (x - h));
        }

        /// <summary>
        /// Find the a of a parabola given two points on the parabola and the k vertex height.
        /// </summary>
        /// <param name="x">The x component of a point on the parabola.</param>
        /// <param name="y">The y component of a point on the parabola.</param>
        /// <param name="h">The h or horizontal component of the vertex of the parabola.</param>
        /// <param name="k">The k or vertex height of the parabola.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK
        /// </acknowledgment>
        [DisplayName("Find Parabola a from a point and a vertex")]
        [Description("Find Parabola a from a point and a vertex.")]
        [Acknowledgment("https://answers.yahoo.com/question/index?qid=20090730215957AAFg8ZK")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FindParabolaAFromAPointAndVertex2(double x, double y, double h, double k)
        {
            return x - h is 0d ? 0d : (y - k) / (h * h - 2 * h * x + x * x);
        }
    }
}
