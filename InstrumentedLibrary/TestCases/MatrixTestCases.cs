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
    }
}
