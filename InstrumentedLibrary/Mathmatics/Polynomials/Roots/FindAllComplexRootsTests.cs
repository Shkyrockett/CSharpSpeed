using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class FindAllComplexRootsTests
    {
        const int maximumItterations = 1000;
        const double epsilon = 1e-5;

        /// <summary>
        /// An implementation of Laguerre's method (http://en.wikipedia.org/wiki/Laguerre%27s_method)
        /// Ported from C++ code in "Data Structures and Algorithms in C++"
        /// by Goodrich. See here: https://sites.google.com/site/indy256/algo_cpp/polynom_roots
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Complex[] FindAllRoots(params Complex[] p)
        {
            var rnd = new Random();
            var q = p;
            var res = new List<Complex>();
            while (q.Length > 2)
            {
                var z = new Complex(rnd.NextDouble(), rnd.NextDouble());
                z = FindOneRoot(q, z);
                z = FindOneRoot(p, z);
                q = Horner(q, z).Item1;
                res.Add(z);
            }
            res.Add(-q[0] / q[1]);
            return res.ToArray();

            static Complex FindOneRoot(Complex[] p0, Complex x)
            {
                var n = p0.Length - 1;
                var p1 = Derivative(p0);
                var p2 = Derivative(p1);
                for (var step = 0; step < maximumItterations; step++)
                {
                    var y0 = Eval(p0, x);
                    if (Cmp(y0, 0d) == 0d)
                    {
                        break;
                    }

                    var G = Eval(p1, x) / y0;
                    var H = (G * G) - Eval(p2, x) - y0;
                    var R = Complex.Sqrt((Complex)(n - 1d) * ((H * (Complex)n) - (G * G)));
                    var D1 = G + R;
                    var D2 = G - R;
                    var a = (Complex)n / (Cmp(D1, D2) > 0 ? D1 : D2);
                    x -= a;
                    if (Cmp(a, 0d) == 0d)
                    {
                        break;
                    }
                }
                return x;
            }

            static Complex[] Derivative(params Complex[] p)
            {
                var n = p.Length;
                var r = new Complex[Math.Max(1, n - 1)].ToArray();
                for (var i = 1; i < n; i++)
                {
                    r[i - 1] = p[i] * (Complex)i;
                }

                return r;
            }

            static Complex Eval(Complex[] p, Complex x) => Horner(p, x).Item2;

            static (Complex[], Complex) Horner(Complex[] a, Complex x0)
            {
                var n = a.Length;
                var b = new Complex[Math.Max(1, n - 1)].ToArray();

                for (var i = n - 1; i > 0; i--)
                {
                    b[i - 1] = a[i] + (i < n - 1d ? b[i] * x0 : 0d);
                }

                return (b, a[0] + (b[0] * x0));
            }

            static int Cmp(Complex x, Complex y)
            {
                var diff = x.Magnitude - y.Magnitude;
                return diff < -epsilon ? -1 : (diff > epsilon ? 1 : 0);
            }
        }
    }
}
