using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Rotate point About another point Test")]
    [Description("Rotate point About another point.")]
    [SourceCodeLocationProvider]
    public static class RotatePointAboutPointTests
    {
        /// <summary>
        /// Set of tests to run testing methods.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 45d.ToRadians(), 0d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 1.4142135623730951d), epsilon: double.Epsilon) },
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
        /// <param name="angle"></param>
        /// <param name="ox"></param>
        /// <param name="oy"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double x, double y) RotatePointAboutPoint(double x, double y, double angle, double ox, double oy)
            => RotatePoint(x, y, angle, ox, oy);

        /// <summary>
        /// The rotate point.
        /// </summary>
        /// <param name="x">The x component of the point to rotate.</param>
        /// <param name="y">The y component of the point to rotate.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="ox">The x component of the point to rotate about.</param>
        /// <param name="oy">The x component of the point to rotate about.</param>
        /// <returns>The <see cref="T:(double x, double y)"/>.</returns>
        [DisplayName("Rotate point About another point Test")]
        [Description("Rotate point About another point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) RotatePoint(double x, double y, double angle, double ox, double oy)
            => RotatePoint(x, y, Cos(angle), Sin(angle), ox, oy);

        /// <summary>
        /// The rotate point.
        /// </summary>
        /// <param name="x">The x component of the point to rotate.</param>
        /// <param name="y">The y component of the point to rotate.</param>
        /// <param name="sin">The sine component of the angle.</param>
        /// <param name="cos">The cosine component of the angle.</param>
        /// <param name="ox">The x component of the point to rotate about.</param>
        /// <param name="oy">The x component of the point to rotate about.</param>
        /// <returns>The <see cref="T:(double x, double y)"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) RotatePoint(double x, double y, double cos, double sin, double ox, double oy)
        {
            var deltaX = x - ox;
            var deltaY = y - oy;
            return (ox + ((deltaX * cos) - (deltaY * sin)),
                    oy + ((deltaX * sin) + (deltaY * cos)));
        }

        /// <summary>
        /// Rotate a point around a fulcrum point.
        /// </summary>
        /// <param name="x">The x component of the point to rotate.</param>
        /// <param name="y">The y component of the point to rotate.</param>
        /// <param name="angle">The angle to rotate the point in pi radians.</param>
        /// <param name="cx">The x component of the fulcrum point to rotate the point around.</param>
        /// <param name="cy">The y component of the fulcrum point to rotate the point around.</param>
        /// <returns>A point rotated about the fulcrum point by the specified pi radian angle.</returns>
        [DisplayName("Rotate point About another point Test")]
        [Description("Rotate point About another point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) RotatePoint2D(double x, double y, double angle, double cx, double cy)
        {
            var deltaX = x - cx;
            var deltaY = y - cy;
            var angleCos = Cos(angle);
            var angleSin = Sin(angle);
            return (cx + ((deltaX * angleCos) - (deltaY * angleSin)),
                    cy + ((deltaX * angleSin) + (deltaY * angleCos)));
        }

        /// <summary>
        /// Rotates one point around another
        /// </summary>
        /// <param name="x">The x component of the point to rotate.</param>
        /// <param name="y">The y component of the point to rotate.</param>
        /// <param name="cx">The x component of the center point of rotation.</param>
        /// <param name="cy">The y component of the center point of rotation.</param>
        /// <param name="angle">The rotation angle in radians.</param>
        /// <returns>Rotated point</returns>
        [DisplayName("Rotate point About another point Test")]
        [Description("Rotate point About another point.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) RotatePointFraser(double x, double y, double angle, double cx, double cy)
        {
            var cosTheta = Cos(angle);
            var sinTheta = Sin(angle);
            return (cosTheta * (x - cx) - sinTheta * (y - cy) + cx,
                    sinTheta * (x - cx) + cosTheta * (y - cy) + cy);
        }

        //// Return a rotation matrix to rotate around a point.
        //private (double x, double y) RotateAroundPoint(double x, double y, double angle, double cx, double cy)
        //{
        //    var center = new System.Drawing.PointF((float)cx, (float)cy);
        //    // Translate the point to the origin.
        //    var result = new System.Numerics.Matrix3x2();
        //    result.RotateAt(angle, center);
        //    return result;
        //}
    }
}
