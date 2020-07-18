namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class MatrixTestCases
    {
        #region Identity Matrix 2D Array
        /// <summary>
        /// The matrix scalar identity 2D array
        /// </summary>
        public static readonly double[,] MatrixScalarIdentity2DArray = new double[,]
        {
            { 1d }
        };

        /// <summary>
        /// The matrix2x2 identity 2D array
        /// </summary>
        public static readonly double[,] Matrix2x2Identity2DArray = new double[,]
        {
            { 1d, 0d },
            { 0d, 1d }
        };

        /// <summary>
        /// The matrix3x3 identity 2D array
        /// </summary>
        public static readonly double[,] Matrix3x3Identity2DArray = new double[,]
        {
            { 1d, 0d, 0d },
            { 0d, 1d, 0d },
            { 0d, 0d, 1d }
        };

        /// <summary>
        /// The matrix4x4 identity 2D array
        /// </summary>
        public static readonly double[,] Matrix4x4Identity2DArray = new double[,]
        {
            { 1d, 0d, 0d, 0d },
            { 0d, 1d, 0d, 0d },
            { 0d, 0d, 1d, 0d },
            { 0d, 0d, 0d, 1d }
        };

        /// <summary>
        /// The matrix5x5 identity 2D array
        /// </summary>
        public static readonly double[,] Matrix5x5Identity2DArray = new double[,]
        {
            { 1d, 0d, 0d, 0d, 0d },
            { 0d, 1d, 0d, 0d, 0d },
            { 0d, 0d, 1d, 0d, 0d },
            { 0d, 0d, 0d, 1d, 0d },
            { 0d, 0d, 0d, 0d, 1d }
        };

        /// <summary>
        /// The matrix6x6 identity 2D array
        /// </summary>
        public static readonly double[,] Matrix6x6Identity2DArray = new double[,]
        {
            { 1d, 0d, 0d, 0d, 0d, 0d },
            { 0d, 1d, 0d, 0d, 0d, 0d },
            { 0d, 0d, 1d, 0d, 0d, 0d },
            { 0d, 0d, 0d, 1d, 0d, 0d },
            { 0d, 0d, 0d, 0d, 1d, 0d },
            { 0d, 0d, 0d, 0d, 0d, 1d }
        };
        #endregion

        #region Identity Matrix Jagged 2D Array
        /// <summary>
        /// The matrix scalar identity 2D array
        /// </summary>
        public static readonly double[][] MatrixScalarIdentityJagged2DArray = new double[][]
        {
            new double[] { 1d }
        };

        /// <summary>
        /// The matrix2x2 identity jagged 2D array
        /// </summary>
        public static readonly double[][] Matrix2x2IdentityJagged2DArray = new double[][]
        {
            new double[] { 1d, 0d },
            new double[] { 0d, 1d }
        };

        /// <summary>
        /// The matrix3x3 identity jagged 2D array
        /// </summary>
        public static readonly double[][] Matrix3x3IdentityJagged2DArray = new double[][]
        {
            new double[] { 1d, 0d, 0d },
            new double[] { 0d, 1d, 0d },
            new double[] { 0d, 0d, 1d }
        };

        /// <summary>
        /// The matrix4x4 identity jagged 2D array
        /// </summary>
        public static readonly double[][] Matrix4x4IdentityJagged2DArray = new double[][]
        {
            new double[] { 1d, 0d, 0d, 0d },
            new double[] { 0d, 1d, 0d, 0d },
            new double[] { 0d, 0d, 1d, 0d },
            new double[] { 0d, 0d, 0d, 1d }
        };

        /// <summary>
        /// The matrix5x5 identity jagged 2D array
        /// </summary>
        public static readonly double[][] Matrix5x5IdentityJagged2DArray = new double[][]
        {
            new double[] { 1d, 0d, 0d, 0d, 0d },
            new double[] { 0d, 1d, 0d, 0d, 0d },
            new double[] { 0d, 0d, 1d, 0d, 0d },
            new double[] { 0d, 0d, 0d, 1d, 0d },
            new double[] { 0d, 0d, 0d, 0d, 1d }
        };

        /// <summary>
        /// The matrix6x6 identity jagged 2D array
        /// </summary>
        public static readonly double[][] Matrix6x6IdentityJagged2DArray = new double[][]
        {
            new double[] { 1d, 0d, 0d, 0d, 0d, 0d },
            new double[] { 0d, 1d, 0d, 0d, 0d, 0d },
            new double[] { 0d, 0d, 1d, 0d, 0d, 0d },
            new double[] { 0d, 0d, 0d, 1d, 0d, 0d },
            new double[] { 0d, 0d, 0d, 0d, 1d, 0d },
            new double[] { 0d, 0d, 0d, 0d, 0d, 1d }
        };
        #endregion

        #region Identity Matrix Tuple
        /// <summary>
        /// The matrix2x2 identity tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2,
            double m2x1, double m2x2)
            Matrix2x2IdentityTuple = (
            1d, 0d,
            0d, 1d
        );

        /// <summary>
        /// The matrix3x3 identity tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
            Matrix3x3IdentityTuple = (
            1d, 0d, 0d,
            0d, 1d, 0d,
            0d, 0d, 1d
        );

        /// <summary>
        /// The matrix4x4 identity tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
            Matrix4x4IdentityTuple = (
            1d, 0d, 0d, 0d,
            0d, 1d, 0d, 0d,
            0d, 0d, 1d, 0d,
            0d, 0d, 0d, 1d
        );

        /// <summary>
        /// The matrix5x5 identity tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5)
            Matrix5x5IdentityTuple = (
            1d, 0d, 0d, 0d, 0d,
            0d, 1d, 0d, 0d, 0d,
            0d, 0d, 1d, 0d, 0d,
            0d, 0d, 0d, 1d, 0d,
            0d, 0d, 0d, 0d, 1d
        );

        /// <summary>
        /// The matrix6x6 identity tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6)
            Matrix6x6IdentityTuple = (
            1d, 0d, 0d, 0d, 0d, 0d,
            0d, 1d, 0d, 0d, 0d, 0d,
            0d, 0d, 1d, 0d, 0d, 0d,
            0d, 0d, 0d, 1d, 0d, 0d,
            0d, 0d, 0d, 0d, 1d, 0d,
            0d, 0d, 0d, 0d, 0d, 1d
        );
        #endregion

        #region Elevens Matrix 2D Array
        /// <summary>
        /// The matrix scalar Elevens 2D array
        /// </summary>
        public static readonly double[,] MatrixScalarElevens2DArray = new double[,]
        {
            { 11d }
        };

        /// <summary>
        /// The matrix2x2 elevens 2d array
        /// </summary>
        public static readonly double[,] Matrix2x2Elevens2DArray = new double[,]
        {
            { 11d, 12d },
            { 21d, 22d }
        };

        /// <summary>
        /// The matrix3x3 elevens 2d array
        /// </summary>
        public static readonly double[,] Matrix3x3Elevens2DArray = new double[,]
        {
            { 11d, 12d, 13d },
            { 21d, 22d, 23d },
            { 31d, 32d, 33d }
        };

        /// <summary>
        /// The matrix4x4 elevens 2d array
        /// </summary>
        public static readonly double[,] Matrix4x4Elevens2DArray = new double[,]
        {
            { 11d, 12d, 13d, 14d },
            { 21d, 22d, 23d, 24d },
            { 31d, 32d, 33d, 34d },
            { 41d, 42d, 43d, 44d }
        };

        /// <summary>
        /// The matrix5x5 elevens 2d array
        /// </summary>
        public static readonly double[,] Matrix5x5Elevens2DArray = new double[,]
        {
            { 11d, 12d, 13d, 14d, 15d },
            { 21d, 22d, 23d, 24d, 25d },
            { 31d, 32d, 33d, 34d, 35d },
            { 41d, 42d, 43d, 44d, 45d },
            { 51d, 52d, 53d, 54d, 55d }
        };

        /// <summary>
        /// The matrix6x6 elevens 2d array
        /// </summary>
        public static readonly double[,] Matrix6x6Elevens2DArray = new double[,]
        {
            { 11d, 12d, 13d, 14d, 15d, 16d },
            { 21d, 22d, 23d, 24d, 25d, 26d },
            { 31d, 32d, 33d, 34d, 35d, 36d },
            { 41d, 42d, 43d, 44d, 45d, 46d },
            { 51d, 52d, 53d, 54d, 55d, 56d },
            { 61d, 62d, 63d, 64d, 65d, 66d }
        };
        #endregion

        #region Elevens Matrix Jagged 2D Array
        /// <summary>
        /// The matrix scalar Elevens 2D array
        /// </summary>
        public static readonly double[][] MatrixScalarElevensJagged2DArray = new double[][]
        {
            new double[] { 1d }
        };

        /// <summary>
        /// The matrix2x2 elevens jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix2x2ElevensJagged2DArray = new double[][]
        {
            new double[] { 11d, 12d },
            new double[] { 21d, 22d }
        };

        /// <summary>
        /// The matrix3x3 elevens jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix3x3ElevensJagged2DArray = new double[][]
        {
            new double[] { 11d, 12d, 13d },
            new double[] { 21d, 22d, 23d },
            new double[] { 31d, 32d, 33d }
        };

        /// <summary>
        /// The matrix4x4 elevens jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix4x4ElevensJagged2DArray = new double[][]
        {
            new double[] { 11d, 12d, 13d, 14d },
            new double[] { 21d, 22d, 23d, 24d },
            new double[] { 31d, 32d, 33d, 34d },
            new double[] { 41d, 42d, 43d, 44d }
        };

        /// <summary>
        /// The matrix5x5 elevens jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix5x5ElevensJagged2DArray = new double[][]
        {
            new double[] { 11d, 12d, 13d, 14d, 15d },
            new double[] { 21d, 22d, 23d, 24d, 25d },
            new double[] { 31d, 32d, 33d, 34d, 35d },
            new double[] { 41d, 42d, 43d, 44d, 45d },
            new double[] { 51d, 52d, 53d, 54d, 55d }
        };

        /// <summary>
        /// The matrix6x6 elevens jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix6x6ElevensJagged2DArray = new double[][]
        {
            new double[] { 11d, 12d, 13d, 14d, 15d, 16d },
            new double[] { 21d, 22d, 23d, 24d, 25d, 26d },
            new double[] { 31d, 32d, 33d, 34d, 35d, 36d },
            new double[] { 41d, 42d, 43d, 44d, 45d, 46d },
            new double[] { 51d, 52d, 53d, 54d, 55d, 56d },
            new double[] { 61d, 62d, 63d, 64d, 65d, 66d }
        };
        #endregion

        #region Elevens Matrix Tuple
        /// <summary>
        /// The matrix2x2 elevens tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2,
            double m2x1, double m2x2)
            Matrix2x2ElevensTuple =
        (
            11d, 12d,
            21d, 22d
        );

        /// <summary>
        /// The matrix3x3 elevens tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
            Matrix3x3ElevensTuple =
        (
            11d, 12d, 13d,
            21d, 22d, 23d,
            31d, 32d, 33d
        );

        /// <summary>
        /// The matrix4x4 elevens tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
            Matrix4x4ElevensTuple =
        (
            11d, 12d, 13d, 14d,
            21d, 22d, 23d, 24d,
            31d, 32d, 33d, 34d,
            41d, 42d, 43d, 44d
        );

        /// <summary>
        /// The matrix5x5 elevens tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5)
            Matrix5x5ElevensTuple =
        (
            11d, 12d, 13d, 14d, 15d,
            21d, 22d, 23d, 24d, 25d,
            31d, 32d, 33d, 34d, 35d,
            41d, 42d, 43d, 44d, 45d,
            51d, 52d, 53d, 54d, 55d
        );

        /// <summary>
        /// The matrix6x6 elevens tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6)
            Matrix6x6ElevensTuple =
        (
            11d, 12d, 13d, 14d, 15d, 16d,
            21d, 22d, 23d, 24d, 25d, 26d,
            31d, 32d, 33d, 34d, 35d, 36d,
            41d, 42d, 43d, 44d, 45d, 46d,
            51d, 52d, 53d, 54d, 55d, 56d,
            61d, 62d, 63d, 64d, 65d, 66d
        );
        #endregion

        #region Incremental Matrix 2D Array
        /// <summary>
        /// The matrix2x2 incremental 2d array
        /// </summary>
        public static readonly double[,] Matrix2x2Incremental2DArray = new double[,]
        {
            { 1d, 2d },
            { 3d, 4d }
        };

        /// <summary>
        /// The matrix3x3 incremental 2d array
        /// </summary>
        public static readonly double[,] Matrix3x3Incremental2DArray = new double[,]
        {
            { 1d, 2d, 3d },
            { 4d, 5d, 6d },
            { 7d, 8d, 9d }
        };

        /// <summary>
        /// The matrix4x4 incremental 2d array
        /// </summary>
        public static readonly double[,] Matrix4x4Incremental2DArray = new double[,]
        {
            { 1d, 2d, 3d, 4d },
            { 5d, 6d, 7d, 8d },
            { 9d, 10d, 11d, 12d },
            { 13d, 14d, 15d, 16d }
        };

        /// <summary>
        /// The matrix5x5 incremental 2d array
        /// </summary>
        public static readonly double[,] Matrix5x5Incremental2DArray = new double[,]
        {
            { 1d, 2d, 3d, 4d, 5d },
            { 6d, 7d, 8d, 9d, 10d },
            { 11d, 12d, 13d, 14d, 15d },
            { 16d, 17d, 18d, 19d, 20d },
            { 21d, 22d, 23d, 24d, 25d }
        };

        /// <summary>
        /// The matrix6x6 incremental 2d array
        /// </summary>
        public static readonly double[,] Matrix6x6Incremental2DArray = new double[,]
        {
            { 1d, 2d, 3d, 4d, 5d, 6d },
            { 7d, 8d, 9d, 10d, 11d, 12d },
            { 13d, 14d, 15d, 16d, 17d, 18d },
            { 19d, 20d, 21d, 22d, 23d, 24d },
            { 25d, 26d, 27d, 28d, 29d, 30d },
            { 31d, 32d, 33d, 34d, 35d, 36d }
        };
        #endregion

        #region Incremental Matrix 2D Array
        /// <summary>
        /// The matrix2x2 incremental jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix2x2IncrementalJagged2DArray = new double[][]
        {
            new double[] { 1d, 2d },
            new double[] { 3d, 4d }
        };

        /// <summary>
        /// The matrix3x3 incremental jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix3x3IncrementalJagged2DArray = new double[][]
        {
            new double[] { 1d, 2d, 3d },
            new double[] { 4d, 5d, 6d },
            new double[] { 7d, 8d, 9d }
        };

        /// <summary>
        /// The matrix4x4 incremental jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix4x4IncrementalJagged2DArray = new double[][]
        {
            new double[] { 1d, 2d, 3d, 4d },
            new double[] { 5d, 6d, 7d, 8d },
            new double[] { 9d, 10d, 11d, 12d },
            new double[] { 13d, 14d, 15d, 16d }
        };

        /// <summary>
        /// The matrix5x5 incremental jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix5x5IncrementalJagged2DArray = new double[][]
        {
            new double[] { 1d, 2d, 3d, 4d, 5d },
            new double[] { 6d, 7d, 8d, 9d, 10d },
            new double[] { 11d, 12d, 13d, 14d, 15d },
            new double[] { 16d, 17d, 18d, 19d, 20d },
            new double[] { 21d, 22d, 23d, 24d, 25d }
        };

        /// <summary>
        /// The matrix6x6 incremental jagged 2d array
        /// </summary>
        public static readonly double[][] Matrix6x6IncrementalJagged2DArray = new double[][]
        {
            new double[] { 1d, 2d, 3d, 4d, 5d, 6d },
            new double[] { 7d, 8d, 9d, 10d, 11d, 12d },
            new double[] { 13d, 14d, 15d, 16d, 17d, 18d },
            new double[] { 19d, 20d, 21d, 22d, 23d, 24d },
            new double[] { 25d, 26d, 27d, 28d, 29d, 30d },
            new double[] { 31d, 32d, 33d, 34d, 35d, 36d }
        };
        #endregion

        #region Incremental Matrix Tuple
        /// <summary>
        /// The matrix2x2 incremental tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2,
            double m2x1, double m2x2)
            Matrix2x2IncrementalTuple =
        (
            1d, 2d,
            3d, 4d
        );

        /// <summary>
        /// The matrix3x3 incremental tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
            Matrix3x3IncrementalTuple =
        (
            1d, 2d, 3d,
            4d, 5d, 6d,
            7d, 8d, 9d
        );

        /// <summary>
        /// The matrix4x4 incremental tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
            Matrix4x4IncrementalTuple =
        (
            1d, 2d, 3d, 4d,
            5d, 6d, 7d, 8d,
            9d, 10d, 11d, 12d,
            13d, 14d, 15d, 16d
        );

        /// <summary>
        /// The matrix5x5 incremental tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5)
            Matrix5x5IncrementalTuple =
        (
            1d, 2d, 3d, 4d, 5d,
            6d, 7d, 8d, 9d, 10d,
            11d, 12d, 13d, 14d, 15d,
            16d, 17d, 18d, 19d, 20d,
            21d, 22d, 23d, 24d, 25d
        );

        /// <summary>
        /// The matrix6x6 incremental tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6)
            Matrix6x6IncrementalTuple =
        (
            1d, 2d, 3d, 4d, 5d, 6d,
            7d, 8d, 9d, 10d, 11d, 12d,
            13d, 14d, 15d, 16d, 17d, 18d,
            19d, 20d, 21d, 22d, 23d, 24d,
            25d, 26d, 27d, 28d, 29d, 30d,
            31d, 32d, 33d, 34d, 35d, 36d
        );
        #endregion

        #region Test Cases
        /// <summary>
        /// The matrix3x3 test case tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
            Matrix3x3TestCaseTuple =
        (
            1d, 4d, 0d,
            3d, 2d, 5d,
            7d, 8d, 6d
        );

        /// <summary>
        /// The matrix3x3 test case2 d array
        /// </summary>
        public static readonly double[,] Matrix3x3TestCase2DArray = new double[,]
        {
            { 1d, 4d, 0d, },
            { 3d, 2d, 5d, },
            { 7d, 8d, 6d }
        };

        /// <summary>
        /// The matrix3x3 test case jagged array
        /// </summary>
        public static readonly double[][] Matrix3x3TestCaseJaggedArray = new double[][]
        {
            new double[] { 1d, 4d, 0d, },
            new double[] { 3d, 2d, 5d, },
            new double[] { 7d, 8d, 6d }
        };

        /// <summary>
        /// The matrix4x4 test case tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
            Matrix4x4TestCaseTuple =
        (
            3d, 7d, 2d, 5d,
            1d, 8d, 4d, 2d,
            2d, 1d, 9d, 3d,
            5d, 4d, 7d, 1d
        );

        /// <summary>
        /// The matrix4x4 test case2 d array
        /// </summary>
        public static readonly double[,] Matrix4x4TestCase2DArray = new double[,]
        {
            { 3d, 7d, 2d, 5d },
            { 1d, 8d, 4d, 2d },
            { 2d, 1d, 9d, 3d },
            { 5d, 4d, 7d, 1d }
        };

        /// <summary>
        /// The matrix4x4 test case jagged array
        /// </summary>
        public static readonly double[][] Matrix4x4TestCaseJaggedArray = new double[][]
        {
            new double[] { 3d, 7d, 2d, 5d },
            new double[] { 1d, 8d, 4d, 2d },
            new double[] { 2d, 1d, 9d, 3d },
            new double[] { 5d, 4d, 7d, 1d }
        };
        #endregion

        /// <summary>
        /// The bezier linear2x2 array
        /// </summary>
        public static readonly double[,] BezierLinear2x2Array =
        {
            { 1d, 0d },
            { -1d, 1d }
        };

        /// <summary>
        /// The bezier linear2x2 jagged array
        /// </summary>
        public static readonly double[][] BezierLinear2x2JaggedArray =
        {
            new double[] { 1d, 0d },
            new double[] { -1d, 1d }
        };

        /// <summary>
        /// The bezier2x2 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2,
            double m2x1, double m2x2)
            BezierLinear2x2Tuple =
            (
            1d, 0d,
            -1d, 1d
            );

        /// <summary>
        /// The bezier quadratic3x3 array
        /// </summary>
        public static readonly double[,] BezierQuadratic3x3Array =
        {
            { 1d, 0d, 0d },
            { -2d, 2d, 0d },
            { 1d, -2d, 1d }
        };

        /// <summary>
        /// The bezier quadratic3x3 jagged array
        /// </summary>
        public static readonly double[][] BezierQuadratic3x3JaggedArray =
        {
            new double[] { 1d, 0d, 0d },
            new double[] { -2d, 2d, 0d },
            new double[] { 1d, -2d, 1d }
        };

        /// <summary>
        /// The bezier3x3 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
            BezierQuadratic3x3Tuple =
            (
            1d, 0d, 0d,
            -2d, 2d, 0d,
            1d, -2d, 1d
            );

        /// <summary>
        /// The bezier cubic4x4 tuple
        /// </summary>
        public static readonly double[,] BezierCubic4x4Array =
         {
            { 1d, 0d, 0d, 0d },
            { -3d, 3d, 0d, 0d },
            { 3d, -6d, 3d, 0d },
            { -1d, 3d, -3d, 1d }
        };

        /// <summary>
        /// The bezier cubic4x4 jagged array
        /// </summary>
        public static readonly double[][] BezierCubic4x4JaggedArray =
         {
            new double[] { 1d, 0d, 0d, 0d },
            new double[] { -3d, 3d, 0d, 0d },
            new double[] { 3d, -6d, 3d, 0d },
            new double[] { -1d, 3d, -3d, 1d }
        };

        /// <summary>
        /// The bezier4x4 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x1, double m4x2, double m4x3, double m4x4)
            BezierCubic4x4Tuple =
            (
            1d, 0d, 0d, 0d,
            -3d, 3d, 0d, 0d,
            3d, -6d, 3d, 0d,
            -1d, 3d, -3d, 1d
            );

        /// <summary>
        /// The bezier5x5 tuple
        /// </summary>
        public static readonly double[,] BezierQuartic5x5Array =
        {
            { 1d, 0d, 0d, 0d, 0d },
            { -4d, 4d, 0d, 0d, 0d },
            { 6d, -12d, 6d, 0d, 0d },
            { -4d, 12d, -12d, 4d, 0d },
            { 1d, -4d, 6d, -4d, 1d }
        };

        /// <summary>
        /// The bezier quartic5x5 jagged array
        /// </summary>
        public static readonly double[][] BezierQuartic5x5JaggedArray =
        {
            new double[] { 1d, 0d, 0d, 0d, 0d },
            new double[] { -4d, 4d, 0d, 0d, 0d },
            new double[] { 6d, -12d, 6d, 0d, 0d },
            new double[] { -4d, 12d, -12d, 4d, 0d },
            new double[] { 1d, -4d, 6d, -4d, 1d }
        };

        /// <summary>
        /// The bezier5x5 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5)
            BezierQuartic5x5Tuple =
            (
            1d, 0d, 0d, 0d, 0d,
            -4d, 4d, 0d, 0d, 0d,
            6d, -12d, 6d, 0d, 0d,
            -4d, 12d, -12d, 4d, 0d,
            1d, -4d, 6d, -4d, 1d
            );

        /// <summary>
        /// The bezier6x6 tuple
        /// </summary>
        public static readonly double[,] BezierQuintic6x6Array =
        {
            { 1d, 0d, 0d, 0d, 0d, 0d },
            { -5d, 5d, 0d, 0d, 0d, 0d },
            { 10d, -20d, 10d, 0d, 0d, 0d },
            { -10d, 30d, -30d, 10d, 0d, 0d },
            { 5d, -20d, 30d, -20d, 5d, 0d },
            { -1d, 5d, -10d, 10d, -5d, 1d }
        };

        /// <summary>
        /// The bezier quintic6x6 jagged array
        /// </summary>
        public static readonly double[][] BezierQuintic6x6JaggedArray =
        {
            new double[] { 1d, 0d, 0d, 0d, 0d, 0d },
            new double[] { -5d, 5d, 0d, 0d, 0d, 0d },
            new double[] { 10d, -20d, 10d, 0d, 0d, 0d },
            new double[] { -10d, 30d, -30d, 10d, 0d, 0d },
            new double[] { 5d, -20d, 30d, -20d, 5d, 0d },
            new double[] { -1d, 5d, -10d, 10d, -5d, 1d }
        };

        /// <summary>
        /// The bezier6x6 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6)
            BezierQuintic6x6Tuple =
            (
            1d, 0d, 0d, 0d, 0d, 0d,
            -5d, 5d, 0d, 0d, 0d, 0d,
            10d, -20d, 10d, 0d, 0d, 0d,
            -10d, 30d, -30d, 10d, 0d, 0d,
            5d, -20d, 30d, -20d, 5d, 0d,
            -1d, 5d, -10d, 10d, -5d, 1d
            );

        /// <summary>
        /// The bezier sextic7x7 array
        /// </summary>
        public static readonly double[,] BezierSextic7x7Array =
        {
            {1d, 0d, 0d, 0d, 0d, 0d, 0d },
            {-6d, 6d, 0d, 0d, 0d, 0d, 0d },
            {15d, -30d, 15d, 0d, 0d, 0d, 0d },
            {-20d, 60d, -60d, 20d, 0d, 0d, 0d },
            {15d, -60d, 90d, -60d, 15d, 0d, 0d },
            {-6d, 30d, -60d, 60d, -30d, 6d, 0d },
            { 1d, -6d, 15d, -20d, 15d, -6d, 1d }
        };

        /// <summary>
        /// The bezier sextic7x7 jagged array
        /// </summary>
        public static readonly double[][] BezierSextic7x7JaggedArray =
        {
            new double[] {1d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] {-6d, 6d, 0d, 0d, 0d, 0d, 0d },
            new double[] {15d, -30d, 15d, 0d, 0d, 0d, 0d },
            new double[] {-20d, 60d, -60d, 20d, 0d, 0d, 0d },
            new double[] {15d, -60d, 90d, -60d, 15d, 0d, 0d },
            new double[] {-6d, 30d, -60d, 60d, -30d, 6d, 0d },
            new double[] { 1d, -6d, 15d, -20d, 15d, -6d, 1d }
        };

        /// <summary>
        /// The bezier7x7 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m1x7,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m2x7,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m3x7,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m4x7,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m5x7,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6, double m6x7,
            double m7x1, double m7x2, double m7x3, double m7x4, double m7x5, double m7x6, double m7x7)
            BezierSextic7x7Tuple =
            (
            1d, 0d, 0d, 0d, 0d, 0d, 0d,
            -6d, 6d, 0d, 0d, 0d, 0d, 0d,
            15d, -30d, 15d, 0d, 0d, 0d, 0d,
            -20d, 60d, -60d, 20d, 0d, 0d, 0d,
            15d, -60d, 90d, -60d, 15d, 0d, 0d,
            -6d, 30d, -60d, 60d, -30d, 6d, 0d,
            1d, -6d, 15d, -20d, 15d, -6d, 1d
            );

        /// <summary>
        /// The bezier septic8x8 array
        /// </summary>
        public static readonly double[,] BezierSeptic8x8Array =
        {
            { 1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            { -7d, 7d, 0d, 0d, 0d, 0d, 0d, 0d },
            { 21d, -42d, 21d, 0d, 0d, 0d, 0d, 0d },
            { -35d, 105d, -105d, 35d, 0d, 0d, 0d, 0d },
            { 35d, -140d, 210d, -140d, 35d, 0d, 0d, 0d },
            { -21d, 105d, -210d, 210d, -105d, 21d, 0d, 0d },
            { 7d, -42d, 105d, -140d, 105d, -42d, 7d, 0d },
            { -1d, 7d, -21d, 35d, -35d, 21d, -7d, 1d }
        };

        /// <summary>
        /// The bezier septic8x8 jagged array
        /// </summary>
        public static readonly double[][] BezierSeptic8x8JaggedArray =
        {
            new double[] { 1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] { -7d, 7d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] { 21d, -42d, 21d, 0d, 0d, 0d, 0d, 0d },
            new double[] { -35d, 105d, -105d, 35d, 0d, 0d, 0d, 0d },
            new double[] { 35d, -140d, 210d, -140d, 35d, 0d, 0d, 0d },
            new double[] { -21d, 105d, -210d, 210d, -105d, 21d, 0d, 0d },
            new double[] { 7d, -42d, 105d, -140d, 105d, -42d, 7d, 0d },
            new double[] { -1d, 7d, -21d, 35d, -35d, 21d, -7d, 1d }
        };

        /// <summary>
        /// The bezier8x8 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m1x7, double m1x8,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m2x7, double m2x8,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m3x7, double m3x8,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m4x7, double m4x8,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m5x7, double m5x8,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6, double m6x7, double m6x8,
            double m7x1, double m7x2, double m7x3, double m7x4, double m7x5, double m7x6, double m7x7, double m7x8,
            double m8x1, double m8x2, double m8x3, double m8x4, double m8x5, double m8x6, double m8x7, double m8x8)
            BezierSeptic8x8Tuple =
            (
            1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            -7d, 7d, 0d, 0d, 0d, 0d, 0d, 0d,
            21d, -42d, 21d, 0d, 0d, 0d, 0d, 0d,
            -35d, 105d, -105d, 35d, 0d, 0d, 0d, 0d,
            35d, -140d, 210d, -140d, 35d, 0d, 0d, 0d,
            -21d, 105d, -210d, 210d, -105d, 21d, 0d, 0d,
            7d, -42d, 105d, -140d, 105d, -42d, 7d, 0d,
            -1d, 7d, -21d, 35d, -35d, 21d, -7d, 1d
            );

        /// <summary>
        /// The bezier octic9x9 array
        /// </summary>
        public static readonly double[,] BezierOctic9x9Array =
        {
            {1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {-8d, 8d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {28d, -56d, 28d, 0d, 0d, 0d, 0d, 0d, 0d },
            {-56d, 168d, -168d, 56d, 0d, 0d, 0d, 0d, 0d },
            {70d, -280d, 420d, -280d, 70d, 0d, 0d, 0d, 0d },
            {-56d, 280d, -560d, 560d, -280d, 56d, 0d, 0d, 0d },
            {28d, -168d, 420d, -560d, 420d, -168d, 28d, 0d, 0d },
            {-8d, 56d, -168d, 280d, -280d, 168d, -56d, 8d, 0d },
            { 1d, -8d, 28d, -56d, 70d, -56d, 28d, -8d, 1d }
        };

        /// <summary>
        /// The bezier octic9x9 jagged array
        /// </summary>
        public static readonly double[][] BezierOctic9x9JaggedArray =
        {
            new double[] {1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] {-8d, 8d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] {28d, -56d, 28d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] {-56d, 168d, -168d, 56d, 0d, 0d, 0d, 0d, 0d },
            new double[] {70d, -280d, 420d, -280d, 70d, 0d, 0d, 0d, 0d },
            new double[] {-56d, 280d, -560d, 560d, -280d, 56d, 0d, 0d, 0d },
            new double[] {28d, -168d, 420d, -560d, 420d, -168d, 28d, 0d, 0d },
            new double[] {-8d, 56d, -168d, 280d, -280d, 168d, -56d, 8d, 0d },
            new double[] { 1d, -8d, 28d, -56d, 70d, -56d, 28d, -8d, 1d }
        };

        /// <summary>
        /// The bezier9x9 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m1x7, double m1x8, double m1x9,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m2x7, double m2x8, double m2x9,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m3x7, double m3x8, double m3x9,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m4x7, double m4x8, double m4x9,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m5x7, double m5x8, double m5x9,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6, double m6x7, double m6x8, double m6x9,
            double m7x1, double m7x2, double m7x3, double m7x4, double m7x5, double m7x6, double m7x7, double m7x8, double m7x9,
            double m8x1, double m8x2, double m8x3, double m8x4, double m8x5, double m8x6, double m8x7, double m8x8, double m8x9,
            double m9x1, double m9x2, double m9x3, double m9x4, double m9x5, double m9x6, double m9x7, double m9x8, double m9x9)
            BezierOctic9x9Tuple =
            (
            1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            -8d, 8d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            28d, -56d, 28d, 0d, 0d, 0d, 0d, 0d, 0d,
            -56d, 168d, -168d, 56d, 0d, 0d, 0d, 0d, 0d,
            70d, -280d, 420d, -280d, 70d, 0d, 0d, 0d, 0d,
            -56d, 280d, -560d, 560d, -280d, 56d, 0d, 0d, 0d,
            28d, -168d, 420d, -560d, 420d, -168d, 28d, 0d, 0d,
            -8d, 56d, -168d, 280d, -280d, 168d, -56d, 8d, 0d,
            1d, -8d, 28d, -56d, 70d, -56d, 28d, -8d, 1d
            );

        /// <summary>
        /// The bezier nonic10x10 array
        /// </summary>
        public static readonly double[,] BezierNonic10x10Array =
        {
            {1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {-9d, 9d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {36d, -72d, 36d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {-84d, 252d, -252d, 84d, 0d, 0d, 0d, 0d, 0d, 0d },
            {126d, -504d, 756d, -504d, 126d, 0d, 0d, 0d, 0d, 0d },
            {-126d, 630d, -1260d, 1260d, -630d, 126d, 0d, 0d, 0d, 0d },
            {84d, -504d, 1260d, -1680d, 1260d, -504d, 84d, 0d, 0d, 0d },
            {-36d, 252d, -756d, 1260d, -1260d, 756d, -252d, 36d, 0d, 0d },
            {9d, -72d, 252d, -504d, 630d, -504d, 252d, -72d, 9d, 0d },
            { -1d, 9d, -36d, 84d, -126d, 126d, -84d, 36d, -9d, 1d }
        };

        /// <summary>
        /// The bezier nonic10x10 jagged array
        /// </summary>
        public static readonly double[][] BezierNonic10x10JaggedArray =
        {
            new double[] {1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] {-9d, 9d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] {36d, -72d, 36d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] {-84d, 252d, -252d, 84d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] {126d, -504d, 756d, -504d, 126d, 0d, 0d, 0d, 0d, 0d },
            new double[] {-126d, 630d, -1260d, 1260d, -630d, 126d, 0d, 0d, 0d, 0d },
            new double[] {84d, -504d, 1260d, -1680d, 1260d, -504d, 84d, 0d, 0d, 0d },
            new double[] {-36d, 252d, -756d, 1260d, -1260d, 756d, -252d, 36d, 0d, 0d },
            new double[] {9d, -72d, 252d, -504d, 630d, -504d, 252d, -72d, 9d, 0d },
            new double[] { -1d, 9d, -36d, 84d, -126d, 126d, -84d, 36d, -9d, 1d }
        };

        /// <summary>
        /// The bezier10x10 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m1x7, double m1x8, double m1x9, double m1x10,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m2x7, double m2x8, double m2x9, double m2x10,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m3x7, double m3x8, double m3x9, double m3x10,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m4x7, double m4x8, double m4x9, double m4x10,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m5x7, double m5x8, double m5x9, double m5x10,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6, double m6x7, double m6x8, double m6x9, double m6x10,
            double m7x1, double m7x2, double m7x3, double m7x4, double m7x5, double m7x6, double m7x7, double m7x8, double m7x9, double m7x10,
            double m8x1, double m8x2, double m8x3, double m8x4, double m8x5, double m8x6, double m8x7, double m8x8, double m8x9, double m8x10,
            double m9x1, double m9x2, double m9x3, double m9x4, double m9x5, double m9x6, double m9x7, double m9x8, double m9x9, double m9x10,
            double m10x1, double m10x2, double m10x3, double m10x4, double m10x5, double m10x6, double m10x7, double m10x8, double m10x9, double m10x10)
            BezierNonic10x10Tuple =
            (
            1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            -9d, 9d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            36d, -72d, 36d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            -84d, 252d, -252d, 84d, 0d, 0d, 0d, 0d, 0d, 0d,
            126d, -504d, 756d, -504d, 126d, 0d, 0d, 0d, 0d, 0d,
            -126d, 630d, -1260d, 1260d, -630d, 126d, 0d, 0d, 0d, 0d,
            84d, -504d, 1260d, -1680d, 1260d, -504d, 84d, 0d, 0d, 0d,
            -36d, 252d, -756d, 1260d, -1260d, 756d, -252d, 36d, 0d, 0d,
            9d, -72d, 252d, -504d, 630d, -504d, 252d, -72d, 9d, 0d,
            -1d, 9d, -36d, 84d, -126d, 126d, -84d, 36d, -9d, 1d
            );

        /// <summary>
        /// The bezier decic11x11 array
        /// </summary>
        public static readonly double[,] BezierDecic11x11Array =
        {
            {1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {-10d, 10d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {45d, -90d, 45d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {-120d, 360d, -360d, 120d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            {210d, -840d, 1260d, -840d, 210d, 0d, 0d, 0d, 0d, 0d, 0d },
            {-252d, 1260d, -2520d, 2520d, -1260d, 252d, 0d, 0d, 0d, 0d, 0d },
            {210d, -1260d, 3150d, -4200d, 3150d, -1260d, 210d, 0d, 0d, 0d, 0d },
            {-120d, 840d, -2520d, 4200d, -4200d, 2520d, -840d, 120d, 0d, 0d, 0d },
            {45d, -360d, 1260d, -2520d, 3150d, -2520d, 1260d, -360d, 45d, 0d, 0d },
            {-10d, 90d, -360d, 840d, -1260d, 1260d, -840d, 360d, -90d, 10d, 0d },
            { 1d, -10d, 45d, -120d, 210d, -252d, 210d, -120d, 45d, -10d, 1d }
        };

        /// <summary>
        /// The bezier decic11x11 jagged array
        /// </summary>
        public static readonly double[][] BezierDecic11x11JaggedArray =
        {
            new double[] { 1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] { -10d, 10d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] { 45d, -90d, 45d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] { -120d, 360d, -360d, 120d, 0d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] { 210d, -840d, 1260d, -840d, 210d, 0d, 0d, 0d, 0d, 0d, 0d },
            new double[] { -252d, 1260d, -2520d, 2520d, -1260d, 252d, 0d, 0d, 0d, 0d, 0d },
            new double[] { 210d, -1260d, 3150d, -4200d, 3150d, -1260d, 210d, 0d, 0d, 0d, 0d },
            new double[] { -120d, 840d, -2520d, 4200d, -4200d, 2520d, -840d, 120d, 0d, 0d, 0d },
            new double[] { 45d, -360d, 1260d, -2520d, 3150d, -2520d, 1260d, -360d, 45d, 0d, 0d },
            new double[] { -10d, 90d, -360d, 840d, -1260d, 1260d, -840d, 360d, -90d, 10d, 0d },
            new double[] {  1d, -10d, 45d, -120d, 210d, -252d, 210d, -120d, 45d, -10d, 1d }
        };

        /// <summary>
        /// The bezier11x11 tuple
        /// </summary>
        public static readonly (
            double m1x1, double m1x2, double m1x3, double m1x4, double m1x5, double m1x6, double m1x7, double m1x8, double m1x9, double m1x10, double m1x11,
            double m2x1, double m2x2, double m2x3, double m2x4, double m2x5, double m2x6, double m2x7, double m2x8, double m2x9, double m2x10, double m2x11,
            double m3x1, double m3x2, double m3x3, double m3x4, double m3x5, double m3x6, double m3x7, double m3x8, double m3x9, double m3x10, double m3x11,
            double m4x1, double m4x2, double m4x3, double m4x4, double m4x5, double m4x6, double m4x7, double m4x8, double m4x9, double m4x10, double m4x11,
            double m5x1, double m5x2, double m5x3, double m5x4, double m5x5, double m5x6, double m5x7, double m5x8, double m5x9, double m5x10, double m5x11,
            double m6x1, double m6x2, double m6x3, double m6x4, double m6x5, double m6x6, double m6x7, double m6x8, double m6x9, double m6x10, double m6x11,
            double m7x1, double m7x2, double m7x3, double m7x4, double m7x5, double m7x6, double m7x7, double m7x8, double m7x9, double m7x10, double m7x11,
            double m8x1, double m8x2, double m8x3, double m8x4, double m8x5, double m8x6, double m8x7, double m8x8, double m8x9, double m8x10, double m8x11,
            double m9x1, double m9x2, double m9x3, double m9x4, double m9x5, double m9x6, double m9x7, double m9x8, double m9x9, double m9x10, double m9x11,
            double m10x1, double m10x2, double m10x3, double m10x4, double m10x5, double m10x6, double m10x7, double m10x8, double m10x9, double m10x10, double m10x11,
            double m11x1, double m11x2, double m11x3, double m11x4, double m11x5, double m11x6, double m11x7, double m11x8, double m11x9, double m11x10, double m11x11)
            BezierDecic11x11Tuple =
            (
            1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            -10d, 10d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            45d, -90d, 45d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            -120d, 360d, -360d, 120d, 0d, 0d, 0d, 0d, 0d, 0d, 0d,
            210d, -840d, 1260d, -840d, 210d, 0d, 0d, 0d, 0d, 0d, 0d,
            -252d, 1260d, -2520d, 2520d, -1260d, 252d, 0d, 0d, 0d, 0d, 0d,
            210d, -1260d, 3150d, -4200d, 3150d, -1260d, 210d, 0d, 0d, 0d, 0d,
            -120d, 840d, -2520d, 4200d, -4200d, 2520d, -840d, 120d, 0d, 0d, 0d,
            45d, -360d, 1260d, -2520d, 3150d, -2520d, 1260d, -360d, 45d, 0d, 0d,
            -10d, 90d, -360d, 840d, -1260d, 1260d, -840d, 360d, -90d, 10d, 0d,
            1d, -10d, 45d, -120d, 210d, -252d, 210d, -120d, 45d, -10d, 1d
            );
    }
}
