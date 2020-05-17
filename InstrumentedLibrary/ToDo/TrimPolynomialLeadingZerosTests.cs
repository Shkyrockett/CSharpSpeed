namespace InstrumentedLibrary
{
    /// <summary>
    /// The trim polynomial leading zeros tests class.
    /// </summary>
    internal static class TrimPolynomialLeadingZerosTests
    {
        ///// <summary>
        ///// Simplify a polynomial, removing near zero terms.
        ///// </summary>
        ///// <param name="thiscoefficients"></param>
        ///// <param name="epsilon">The minimal difference for comparison.</param>
        ///// <returns>Returns a new instance of the <see cref="Polynomial"/> struct with the near zero terms removed.</returns>
        ///// <acknowledgment>
        ///// This is intended to be used in situations where the polynomial should be reduced. For instance in intersection calculations.
        ///// Simplifying a polynomial before GetMinMax will fail to appropriately get the min, max.
        ///// </acknowledgment>
        ///// <acknowledgment>
        ///// http://www.kevlindev.com/
        ///// </acknowledgment>
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Polynomial Trim(double[] thiscoefficients, double epsilon = Epsilon)
        //{
        //    var coefficients = new double[thiscoefficients.Length + 1];
        //    var degree = (int)Degree;
        //    Array.Copy(thiscoefficients, coefficients, degree);
        //    for (var i = degree; i >= 0; i--)
        //    {
        //        if (Abs(coefficients[i]) <= epsilon)
        //            coefficients = coefficients.RemoveAt(i);
        //        else
        //            break;
        //    }

        //    return new Polynomial() { coefficients = coefficients, isReadonly = this.isReadonly };
        //}

        ///// <summary>
        ///// Trim off any leading zero term coefficients from the Polynomial.
        ///// </summary>
        ///// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        ///// <returns>Returns a <see cref="Polynomial"/> with any leading zero term coefficients removed.</returns>
        ///// <acknowledgment>
        ///// A hodge-podge method based on Simplify from of: http://www.kevlindev.com/
        ///// and Trim from: https://github.com/superlloyd/Poly
        ///// </acknowledgment>
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Polynomial Trim(double[] coefficients, double epsilon = Epsilon)
        //{
        //    var pos = 0;
        //    for (var i = Count - 1; i >= 0; i--)
        //    {
        //        if (Abs(coefficients[i]) <= epsilon)
        //            pos++;
        //        else
        //            break;
        //    }

        //    var ret = new double[Count - pos];
        //    Array.Copy(coefficients, 0, ret, 0, Count - pos);
        //    return new Polynomial() { Coefficients = ret, IsReadonly = isReadonly };
        //}

        ///// <summary>
        ///// Trim off empty coefficients.
        ///// </summary>
        ///// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        ///// <returns></returns>
        ///// <acknowledgment>
        ///// https://github.com/superlloyd/Poly
        ///// </acknowledgment>
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public Polynomial Trim(double epsilon = Epsilon)
        //{
        //    var order = 0;
        //    for (var i = 0; i < coefficients.Length; i++)
        //    {
        //        if (Abs(coefficients[i]) > epsilon)
        //        {
        //            order = i;
        //        }
        //    }

        //    var res = new double[order + 1];
        //    for (var i = 0; i < res.Length; i++)
        //    {
        //        if (Abs(coefficients[i]) > epsilon)
        //        {
        //            res[i] = coefficients[i];
        //        }
        //    }

        //    return new Polynomial() { coefficients = res, isReadonly = this.isReadonly };
        //}
    }
}
