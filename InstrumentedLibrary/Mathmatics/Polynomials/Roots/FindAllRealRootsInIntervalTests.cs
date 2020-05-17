using System;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class FindAllRealRootsInIntervalTests
    {
        /// <summary>
        /// An implementation of Laguerre's method (http://en.wikipedia.org/wiki/Laguerre%27s_method)
        /// Ported from C++ code in "Data Structures and Algorithms in C++"
        /// by Goodrich. See here: https://sites.google.com/site/indy256/algo_cpp/polynom_roots
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] FindAllRootsInInterval(double min, double max, params Complex[] p)
        {
            const double rootEpsilon = 1e-3;
            var roots = FindAllComplexRootsTests.FindAllRoots(p);

            // Filter out roots with nonzero imaginary parts and roots
            // with real parts that are not between 0 and 1.
            var candidates = Array.FindAll(roots,
                root => root.Real > min && root.Real <= max && Math.Abs(root.Imaginary) < rootEpsilon
            ).Select(
                root => root.Real
            ).ToHashSet();

            // add t=0 and t=1 ... the edge cases.
            candidates.Add(min);
            candidates.Add(max);

            return candidates.ToArray();
        }
    }
}
