﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The maths class.
    /// </summary>
    public static class Maths
    {
        #region Epsilons, Minimums, Maximums
        /// <summary>
        /// The horizontal Value: double.NegativeInfinity.
        /// </summary>
        public const double horizontal = double.NegativeInfinity;

        /// <summary>
        /// Negative zero.
        /// </summary>
        /// <remarks>
        /// Might be useful with Atan2
        /// http://www.charlespetzold.com/blog/2008/09/180741.html
        /// </remarks>
        public const double NegativeZero = -0d;//1 / double.NegativeInfinity;

        /// <summary>
        /// The tolerance Value: 1e-6d.
        /// </summary>
        public const double Tolerance = 1e-6d;

        /// <summary>
        /// The accuracy Value: 15d.
        /// </summary>
        public const double Accuracy = 15d;

        /// <summary>
        /// Error difference for line intersection tests.
        /// </summary>
        public const double Epsilon = 5.684341886080801536e-12d;

        /// <summary>
        /// Smallest such that 1.0 + <see cref="Epsilon"/> != 1.0
        /// </summary>
        public const double DoubleEpsilon = 2.2204460492503131e-016d;

        /// <summary>
        /// Smallest such that 1.0 + <see cref="FloatEpsilon"/> != 1.0
        /// </summary>
        public const float FloatEpsilon = 1.192092896e-07f;

        /// <summary>
        /// The near zero epsilon Value: 1E-20.
        /// </summary>
        public const double NearZeroEpsilon = 1E-20;

        /// <summary>
        /// Number close to zero, where float.MinValue is -float.MaxValue
        /// </summary>
        public const float FloatMin = 1.175494351e-38f;

        /// <summary>
        /// SlopeMax is a large value "close to infinity" (Close to the largest value allowed for the data
        /// type). Used in the Slope of a LineSeg
        /// </summary>
        public const double SlopeMax = 9223372036854775807d;

        /// <summary>
        /// The double round limit.
        /// </summary>
        public const double DoubleRoundLimit = 1E+16;

        /// <summary>
        /// The default arc tolerance Value: 0.25.
        /// </summary>
        public const double DefaultArcTolerance = 0.25;

        /// <summary>
        /// The lo range32 Value: 0x7FFF.
        /// </summary>
        public const int LoRange32 = 0x7FFF;

        /// <summary>
        /// The hi range32 Value: 0x7FFF.
        /// </summary>
        public const int HiRange32 = 0x7FFF;

        /// <summary>
        /// The lo range64 Value: 0x3FFFFFFF.
        /// </summary>
        public const long LoRange64 = 0x3FFFFFFF;

        /// <summary>
        /// The hi range64 Value: 0x3FFFFFFFFFFFFFFFL.
        /// </summary>
        public const long HiRange64 = 0x3FFFFFFFFFFFFFFFL;
        #endregion Epsilons, Minimums, Maximums

        #region Pi Derivations
        /// <summary>
        /// Represents the inverse of Pi, or the quotient of one over pi.
        /// </summary>
        public const double InversePi = 1d / PI; // 0.31830988618379067153776752674503d;

        /// <summary>
        /// Represents the inverse of Tau, or the quotient of one over 2 pi.
        /// </summary>
        public const double InverseTau = 1d / Tau; // 0.15915494309189533576888376337251d;

        /// <summary>
        /// Represents the value of the double inverse of Pi, or the quotient of two over pi.
        /// </summary>
        public const double Inverse2OverPi = 2d / PI; // 0.63661977236758134307553505349006d;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the first sixteenth of that circle.
        /// One sixteenth Tau or a eighth Pi.
        /// </summary>
        /// <remarks>PI / 8</remarks>
        public const double EighthPi = 0.125d * PI; // 0.39269908169872415480783042290994d;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the first eighth of that circle.
        /// One eighth Tau or a quarter Pi. A 45 degree angle.
        /// </summary>
        /// <remarks>PI / 4</remarks>
        public const double Quart = 0.25d * PI; // 0.78539816339744830961566084581988d;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the first quarter of that circle.
        /// One quarter Tau or half Pi. A right angle in mathematics.
        /// </summary>
        /// <remarks>PI / 2</remarks>
        public const double HalfPi = 0.5d * PI; // 1.5707963267948966192313216916398d;

        ///// <summary>
        ///// Represents the ratio of the circumference of a circle to its diameter, specified
        ///// by the constant, π (Pi).
        ///// One half Tau or One Pi.
        ///// </summary>
        ///// <value>≈3.1415926535897931...</value>
        //public const double Pi = Math.PI; // 3.1415926535897932384626433832795d;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the third quarter of that circle.
        /// Three quarter tau, or one and a half pi.
        /// </summary>
        /// <remarks>
        /// Three quarter tau, or one and a half pi are just too long and awkward.
        /// Randal Munro's joke "compromise" works well enough for a name: http://xkcd.com/1292/
        /// </remarks>
        /// <acknowledgment>
        /// Randal Munro http://xkcd.com/1292/ 
        /// </acknowledgment>
        public const double Pau = 1.5d * PI; // 4.7123889803846898576939650749193d;

        /// <summary>
        /// Represents the ratio of the circumference of a circle to its radius, specified
        /// by the proposed constant, τ (Tau).
        /// One Tau or two Pi.
        /// </summary>
        /// <value>≈6.28318...</value>
        public const double Tau = 2d * PI; // 6.283185307179586476925286766559d;

        /// <summary>
        /// One Radian.
        /// </summary>
        /// <remarks>PI / 180</remarks>
        public const double Radian = PI / 180d; // 0.01745329251994329576923690768489d;

        /// <summary>
        /// One degree.
        /// </summary>
        /// <remarks>180 / PI</remarks>
        public const double Degree = 180d / PI; // 57.295779513082320876798154814105d;
        #endregion Pi Derivations

        /// <summary>
        /// Represents the golden ratio as specified by the constant, φ (phi).
        /// </summary>
        /// <value>≈1.61803...</value>
        public static readonly double Phi = (1d + Sqrt(5)) * 0.5d; // 1.6180339887498948482045868343656d;

        /// <summary>
        ///  Represents the plastic constant as specified by the constant, ρ.
        /// </summary>
        /// <value>≈1.32471...</value>
        public static readonly double Rho = RootTests.Root(0.5d + (1d / 6d * Sqrt(23d / 3d)), 3d) + RootTests.Root(0.5d - (1d / 6d * Sqrt(23d / 3d)), 3d);

        /// <summary>
        /// The cosine of 0.
        /// </summary>
        public static readonly double Cos0 = Cos(0);

        /// <summary>
        /// The cosine of PI.
        /// </summary>
        public static readonly double CosHalfPi = Cos(HalfPi);

        /// <summary>
        /// The cosine of Pi.
        /// </summary>
        public static readonly double CosPi = Cos(PI);

        /// <summary>
        /// The cosine of Pau.
        /// </summary>
        public static readonly double CosPau = Cos(Pau);

        /// <summary>
        /// The sine of 0.
        /// </summary>
        public static readonly double Sin0 = Sin(0);

        /// <summary>
        /// The sine of half Pi.
        /// </summary>
        public static readonly double SinHalfPi = Sin(HalfPi);

        /// <summary>
        /// The sine of Pi.
        /// </summary>
        public static readonly double SinPi = Sin(PI);

        /// <summary>
        /// The sine of Pau.
        /// </summary>
        public static readonly double SinPau = Sin(Pau);

        #region Roots
        /// <summary>
        /// Represents the inverse square root of 2.
        /// </summary>
        public static readonly double InvSqrt2 = 1d / Sqrt(2d); // 0.70710678118654752440084436210485d;

        /// <summary>
        /// Represents the double inverse square root of Pi.
        /// </summary>
        public static readonly double Inv2SqrtPi = 2d / Sqrt(PI); // 1.1283791670955125738961589031215d;

        /// <summary>
        /// Represents the constant value of the square root of 2.
        /// </summary>
        /// <value>≈1.41421...</value>
        public static readonly double Sqrt2 = Sqrt(2d); // 1.4142135623730950488016887242097d;

        /// <summary>
        /// Represents the constant value of the square root of 3.
        /// </summary>
        /// <value>≈1.73205...</value>
        public static readonly double Sqrt3 = Sqrt(3d); // 1.7320508075688772935274463415059d;

        /// <summary>
        /// Represents the constant value of the square root of 5.
        /// </summary>
        /// <value>≈2.23606...</value>
        public static readonly double Sqrt5 = Sqrt(5d); // 2.2360679774997896964091736687313d;
        #endregion Roots

        #region Fractions
        /// <summary>
        /// The zero Value: 0.
        /// </summary>
        public const double Zero = 0d;

        /// <summary>
        /// The one sixty fourth Value: 0.015625.
        /// </summary>
        public const double OneSixtyfourth = 1d / 64d;

        /// <summary>
        /// The one thirty second Value: 0.03125.
        /// </summary>
        public const double OneThirtysecond = 1d / 32d;

        /// <summary>
        /// The one twenty seventh Value: 0.037037037037037.
        /// </summary>
        public const double OneTwentySeventh = 1d / 27d;

        /// <summary>
        /// The three sixty fourth Value: 0.046875.
        /// </summary>
        public const double ThreeSixtyfourth = 3d / 64d;

        /// <summary>
        /// The one sixteenth Value: 0.0625.
        /// </summary>
        public const double OneSixteenth = 1d / 16d;

        /// <summary>
        /// The five sixty fourth Value: 0.078125.
        /// </summary>
        public const double FiveSixtyfourth = 5d / 64d;

        /// <summary>
        /// The three thirty second Value: 0.09375.
        /// </summary>
        public const double ThreeThirtysecond = 3d / 32d;

        /// <summary>
        /// The seven sixty fourth Value: 0.109375.
        /// </summary>
        public const double SevenSixtyfourth = 7d / 64d;

        /// <summary>
        /// The one eighth Value: 0.125.
        /// </summary>
        public const double OneEighth = 1d / 8d;

        /// <summary>
        /// The nine sixty fourth Value: 0.140625.
        /// </summary>
        public const double NineSixtyfourth = 9d / 64d;

        /// <summary>
        /// The five thirty second Value: 0.15625.
        /// </summary>
        public const double FiveThirtysecond = 5d / 32d;

        /// <summary>
        /// The eleven sixty fourth Value: 0.171875.
        /// </summary>
        public const double ElevenSixtyfourth = 11d / 64d;

        /// <summary>
        /// The three sixteenth Value: 0.1875.
        /// </summary>
        public const double ThreeSixteenth = 3d / 16d;

        /// <summary>
        /// The thirteen sixty fourth Value: 0.203125.
        /// </summary>
        public const double ThirteenSixtyfourth = 13d / 64d;

        /// <summary>
        /// The seven thirty second Value: 0.21875.
        /// </summary>
        public const double SevenThirtysecond = 7d / 32d;

        /// <summary>
        /// The fifteen sixty fourth Value: 0.234375.
        /// </summary>
        public const double FifteenSixtyfourth = 15d / 64d;

        /// <summary>
        /// The one quarter Value: 0.25.
        /// </summary>
        public const double OneQuarter = 1d / 4d;

        /// <summary>
        /// The seventeen sixty fourth Value: 0.265625.
        /// </summary>
        public const double SeventeenSixtyfourth = 17d / 64d;

        /// <summary>
        /// The nine thirty second Value: 0.28125.
        /// </summary>
        public const double NineThirtysecond = 9d / 32d;

        /// <summary>
        /// The nineteen sixty fourth Value: 0.296875.
        /// </summary>
        public const double NineteenSixtyfourth = 19d / 64d;

        /// <summary>
        /// The five sixteenth Value: 0.3125.
        /// </summary>
        public const double FiveSixteenth = 5d / 16d;

        /// <summary>
        /// The twenty one sixty fourth Value: 0.328125.
        /// </summary>
        public const double TwentyoneSixtyfourth = 21d / 64d;

        /// <summary>
        /// The one third Value: 0.3333333333333333.
        /// </summary>
        public const double OneThird = 1d / 3d;

        /// <summary>
        /// The eleven thirty second Value: 0.34375.
        /// </summary>
        public const double ElevenThirtysecond = 11d / 32d;

        /// <summary>
        /// The twenty three sixty fourth Value: 0.359375.
        /// </summary>
        public const double TwentythreeSixtyfourth = 23d / 64d;

        /// <summary>
        /// The three eighths Value: 0.375.
        /// </summary>
        public const double ThreeEighths = 3d / 8d;

        /// <summary>
        /// The twenty five sixty fourth Value: 0.390625.
        /// </summary>
        public const double TwentyfiveSixtyfourth = 25d / 64d;

        /// <summary>
        /// The thirteen thirty second Value: 0.40625.
        /// </summary>
        public const double ThirteenThirtysecond = 13d / 32d;

        /// <summary>
        /// The twenty seven sixty fourth Value: 0.421875.
        /// </summary>
        public const double TwentysevenSixtyfourth = 27d / 64d;

        /// <summary>
        /// The seven sixteenth Value: 0.4375.
        /// </summary>
        public const double SevenSixteenth = 7d / 16d;

        /// <summary>
        /// The twenty nine sixty fourth Value: 0.453125.
        /// </summary>
        public const double TwentynineSixtyfourth = 29d / 64d;

        /// <summary>
        /// The fifteen thirty second Value: 0.46875.
        /// </summary>
        public const double FifteenThirtysecond = 15d / 32d;

        /// <summary>
        /// The thirty one sixty fourth Value: 0.484375.
        /// </summary>
        public const double ThirtyoneSixtyfourth = 31d / 64d;

        /// <summary>
        /// The one half Value: 0.5d.
        /// </summary>
        public const double OneHalf = 1d / 2d;

        /// <summary>
        /// The thirty three sixty fourth Value: 0.515625.
        /// </summary>
        public const double ThirtythreeSixtyfourth = 33d / 64d;

        /// <summary>
        /// The seventeen thirty second Value: 0.53125.
        /// </summary>
        public const double SeventeenThirtysecond = 17d / 32d;

        /// <summary>
        /// The thirty five sixty fourth Value: 0.546875.
        /// </summary>
        public const double ThirtyfiveSixtyfourth = 35d / 64d;

        /// <summary>
        /// The nine sixteenth Value: 0.5625.
        /// </summary>
        public const double NineSixteenth = 9d / 16d;

        /// <summary>
        /// The thirty seven sixty fourth Value: 0.578125.
        /// </summary>
        public const double ThirtysevenSixtyfourth = 37d / 64d;

        /// <summary>
        /// The nineteen thirty second Value: 0.59375.
        /// </summary>
        public const double NineteenThirtysecond = 19d / 32d;

        /// <summary>
        /// The thirty nine sixty fourth Value: 0.609375.
        /// </summary>
        public const double ThirtynineSixtyfourth = 39d / 64d;

        /// <summary>
        /// The five eighths Value: 0.625.
        /// </summary>
        public const double FiveEighths = 5d / 8d;

        /// <summary>
        /// The forty one sixty fourth Value: 0.640625.
        /// </summary>
        public const double FortyoneSixtyfourth = 41d / 64d;

        /// <summary>
        /// The twenty one thirty second Value: 0.65625.
        /// </summary>
        public const double TwentyoneThirtysecond = 21d / 32d;

        /// <summary>
        /// The two thirds Value: 0.6666666666666667.
        /// </summary>
        public const double TwoThirds = 2d / 3d;

        /// <summary>
        /// The forty three sixty fourth Value: 0.671875.
        /// </summary>
        public const double FortythreeSixtyfourth = 43d / 64d;

        /// <summary>
        /// The eleven sixteenth Value: 0.6875.
        /// </summary>
        public const double ElevenSixteenth = 11d / 16d;

        /// <summary>
        /// The forty five sixty fourth Value: 0.703125.
        /// </summary>
        public const double FortyfiveSixtyfourth = 45d / 64d;

        /// <summary>
        /// The twenty three thirty second Value: 0.71875.
        /// </summary>
        public const double TwentythreeThirtysecond = 23d / 32d;

        /// <summary>
        /// The forty seven sixty fourth Value: 0.734375.
        /// </summary>
        public const double FortysevenSixtyfourth = 47d / 64d;

        /// <summary>
        /// The three quarters Value: 0.75.
        /// </summary>
        public const double ThreeQuarters = 3d / 4d;

        /// <summary>
        /// The forty nine sixty fourth Value: 0.765625.
        /// </summary>
        public const double FortynineSixtyfourth = 49d / 64d;

        /// <summary>
        /// The twenty five thirty second Value: 0.78125.
        /// </summary>
        public const double TwentyfiveThirtysecond = 25d / 32d;

        /// <summary>
        /// The fifty one sixty fourth Value: 0.796875.
        /// </summary>
        public const double FiftyoneSixtyfourth = 51d / 64d;

        /// <summary>
        /// The thirteen sixteenth Value: 0.8125.
        /// </summary>
        public const double ThirteenSixteenth = 13d / 16d;

        /// <summary>
        /// The fifty three sixty fourth Value: 0.828125.
        /// </summary>
        public const double FiftythreeSixtyfourth = 53d / 64d;

        /// <summary>
        /// The twenty seven thirty second Value: 0.84375.
        /// </summary>
        public const double TwentysevenThirtysecond = 27d / 32d;

        /// <summary>
        /// The fifty five sixty fourth Value: 0.859375.
        /// </summary>
        public const double FiftyfiveSixtyfourth = 55d / 64d;

        /// <summary>
        /// The seven eighths Value: 0.875.
        /// </summary>
        public const double SevenEighths = 7d / 8d;

        /// <summary>
        /// The fifty seven sixty fourth Value: 0.890625.
        /// </summary>
        public const double FiftysevenSixtyfourth = 57d / 64d;

        /// <summary>
        /// The twenty nine thirty second Value: 0.90625.
        /// </summary>
        public const double TwentynineThirtysecond = 29d / 32d;

        /// <summary>
        /// The fifty nine sixty fourth Value: 0.921875.
        /// </summary>
        public const double FiftynineSixtyfourth = 59d / 64d;

        /// <summary>
        /// The fifteen sixteenth Value: 0.9375.
        /// </summary>
        public const double FifteenSixteenth = 15d / 16d;

        /// <summary>
        /// The sixty one sixty fourth Value: 0.953125.
        /// </summary>
        public const double SixtyoneSixtyfourth = 61d / 64d;

        /// <summary>
        /// The thirty one thirty second Value: 0.96875.
        /// </summary>
        public const double ThirtyoneThirtysecond = 31d / 32d;

        /// <summary>
        /// The sixty three sixty fourth Value: 0.984375.
        /// </summary>
        public const double SixtythreeSixtyfourth = 63d / 64d;

        /// <summary>
        /// The one Value: 1d.
        /// </summary>
        public const double One = 1d;

        /// <summary>
        /// The two Value: 1d.
        /// </summary>
        public const double Two = 2d;

        /// <summary>
        /// The three Value: 3d.
        /// </summary>
        public const double Three = 3d;

        /// <summary>
        /// The four Value: 4d.
        /// </summary>
        public const double Four = 4d;

        /// <summary>
        /// The five Value: 5d.
        /// </summary>
        public const double Five = 5d;

        /// <summary>
        /// The six Value: 6d.
        /// </summary>
        public const double Six = 6d;

        /// <summary>
        /// The seven Value: 7d.
        /// </summary>
        public const double Seven = 7d;

        /// <summary>
        /// The eight Value: 8d.
        /// </summary>
        public const double Eight = 8d;

        /// <summary>
        /// The nine Value: 9d.
        /// </summary>
        public const double Nine = 9d;

        /// <summary>
        /// The ten Value: 10d.
        /// </summary>
        public const double Ten = 10d;
        #endregion Fractions

        #region Logarithms
        ///// <summary>
        /////
        ///// </summary>
        //public const double E = Math.E; // 2.7182818284590452353602874713527d;

        /// <summary>
        /// The base 2 natural log of e.
        /// </summary>
        public const double Log2E = 1.44269504088896340736d;

        /// <summary>
        /// The base 10 natural log of e.
        /// </summary>
        public const double Log10E = 0.434294481903251827651d; // 0.43429448190325182765112891891661d;

        /// <summary>
        /// The base 2 natural log.
        /// </summary>
        public const double LN2 = 0.693147180559945309417d;

        /// <summary>
        /// The base 10 natural log.
        /// </summary>
        public const double LN10 = 2.30258509299404568402d;

        /// <summary>
        /// The Log of Two.
        /// </summary>
        public static readonly double LogTwo = Log(2d);

        /// <summary>
        /// The Log of Ten.
        /// </summary>
        public static readonly double LogTen = Log(10d);

        /// <summary>
        /// The inverse of the log of two.
        /// </summary>
        public static readonly double InverseLogTwo = 1d / LogTwo;
        #endregion Logarithms

        #region Gauss Tables
        /// <summary>
        /// Gauss abscissa table
        /// </summary>
        /// <acknowledgment>
        /// https://code.google.com/archive/p/degrafa/source/default/source
        /// </acknowledgment>
        public static readonly double[] abscissa = new double[]
        {
            // N=2
            -0.5773502692d,
                0.5773502692d,
            // N=3
            -0.7745966692d,
                0.7745966692d,
                0.0000000000d,
            // N=4
            -0.8611363116d,
                0.8611363116d,
            -0.3399810436d,
                0.3399810436d,
            // N=5
            -0.9061798459d,
                0.9061798459d,
            -0.5384693101d,
                0.5384693101d,
                0.0000000000d,
            // N=6
            -0.9324695142d,
                0.9324695142d,
            -0.6612093865d,
                0.6612093865d,
            -0.2386191861d,
                0.2386191861d,
            // N=7
            -0.9491079123d,
                0.9491079123d,
            -0.7415311856d,
                0.7415311856d,
            -0.4058451514d,
                0.4058451514d,
                0.0000000000d,
            // N=8
            -0.9602898565d,
                0.9602898565d,
            -0.7966664774d,
                0.7966664774d,
            -0.5255324099d,
                0.5255324099d,
            -0.1834346425d,
                0.1834346425d
        };

        /// <summary>
        /// Gauss weight table
        /// </summary>
        /// <acknowledgment>
        /// https://code.google.com/archive/p/degrafa/source/default/source
        /// </acknowledgment>
        public static readonly double[] weight = new double[]
        {
            // N=2
            1.0000000000d,
            1.0000000000d,
            // N=3
            0.5555555556d,
            0.5555555556d,
            0.8888888888d,
            // N=4
            0.3478548451d,
            0.3478548451d,
            0.6521451549d,
            0.6521451549d,
            // N=5
            0.2369268851d,
            0.2369268851d,
            0.4786286705d,
            0.4786286705d,
            0.5688888888d,
            // N=6
            0.1713244924d,
            0.1713244924d,
            0.3607615730d,
            0.3607615730d,
            0.4679139346d,
            0.4679139346d,
            // N=7
            0.1294849662d,
            0.1294849662d,
            0.2797053915d,
            0.2797053915d,
            0.3818300505d,
            0.3818300505d,
            0.4179591837d,
            // N=8
            0.1012285363d,
            0.1012285363d,
            0.2223810345d,
            0.2223810345d,
            0.3137066459d,
            0.3137066459d,
            0.3626837834d,
            0.3626837834d
        };
        #endregion Gauss Tables

        #region Color Constants
        /// <summary>
        /// The lower limit for percentages.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double PercentMin = 0d;

        /// <summary>
        /// The upper limit for percentages.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double PercentMax = 1d;

        /// <summary>
        /// The lower limit for H.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double HueMin = 0d;

        /// <summary>
        /// The upper limit for H.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double HueMax = 360d;

        /// <summary>
        /// The lower limit for R, G, B (integer version).
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const byte RGBMin = 0;

        /// <summary>
        /// The upper limit for R, G, B (integer version).
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const byte RGBMax = 255;

        /// <summary>
        /// The lower limit for R, G, B (integer version).
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const byte CYMKMin = 0;

        /// <summary>
        /// The upper limit for R, G, B (integer version).
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const byte CYMKMax = 100;

        /// <summary>
        /// The lower limit for I in YIQ.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double YIQMinI = -0.5957d;

        /// <summary>
        /// The upper limit for I in YIQ.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double YIQMaxI = 0.5957d;

        /// <summary>
        /// The lower limit for Q in YIQ.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double YIQMinQ = -0.5226d;

        /// <summary>
        /// The upper limit for Q in YIQ.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double YIQMaxQ = 0.5226d;

        /// <summary>
        /// The lower limit for U in YUV.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double YUVMinU = -0.436d;

        /// <summary>
        /// The upper limit for U in YUV.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double YUVMaxU = 0.436d;

        /// <summary>
        /// The lower limit for V in YUV.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double YUVMinV = -0.615d;

        /// <summary>
        /// The upper limit for V in YUV.
        /// </summary>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        public const double YUVMaxV = 0.615d;
        #endregion Color Constants

        /// <summary>
        /// Initialize random number generator with seed based on time.
        /// </summary>
        public static readonly Random RandomNumberGenerator = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        /// <summary>
        /// The random.
        /// </summary>
        /// <param name="Lower">The Lower.</param>
        /// <param name="Upper">The Upper.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Random(this double Lower, double Upper) => (RandomNumberGenerator.Next() * (Upper - Lower + 1)) + Lower;

        /// <summary>
        /// Get a the value for a key. If the key does not exist, return null;
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dic">The dictionary to call this method on.</param>
        /// <param name="key">The key to look up.</param>
        /// <returns>
        /// The key value. null if this key is not in the dictionary.
        /// </returns>
        /// <remarks>
        /// http://blogs.windward.net/davidt/2012/01/12/c-dictionary-getvalueordefault/
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key)
            => (!(dic is null)) && dic.TryGetValue(key, out var result) ? result : default;
    }
}
