using InstrumentedLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpSpeed
{
    /// <summary>
    /// The reflection helper class.
    /// </summary>
    public static class HelperExtensions
    {
        /// <summary>
        /// The list static factory constructors.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The <see cref="List{MethodInfo}" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<MethodInfo> ListStaticFactoryConstructors(this Type type)
            => new List<MethodInfo>
            (
                from method in type?.GetMethods()
                where method.IsStatic
                where method.ReturnType == type
                select method
            ).OrderBy(x => x.Name).ToList();

        /// <summary>
        /// The list static factory constructors list.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="type2">The type2.</param>
        /// <returns>
        /// The <see cref="List{MethodInfo}" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<MethodInfo> ListStaticFactoryConstructorsList(this Type type, Type type2)
            => new List<MethodInfo>
            (
                from method in type?.GetMethods()
                where method.IsStatic
                where method.ReturnType == type2
                select method
            ).OrderBy(x => x.Name).ToList();

        /// <summary>
        /// The list static methods with attribute.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attributeType">The attribute.</param>
        /// <returns>
        /// The <see cref="List{MethodInfo}" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<MethodInfo> ListStaticMethodsWithAttribute(this Type type, Type attributeType)
            => new List<MethodInfo>
            (
                from method in type?.GetMethods()
                where method.IsStatic
                where method.GetCustomAttributes(attributeType).Any()
                select method
            ).OrderBy(x => x.Name).ToList();

        /// <summary>
        /// The list classes with attribute.
        /// </summary>
        /// <param name="attributeType">The attributeType.</param>
        /// <returns>
        /// The <see cref="IEnumerable{TypeInfo}" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TypeInfo> ListClassesWithAttribute(this Type attributeType)
            => (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.DefinedTypes
                where type.IsDefined(attributeType, false)
                select type).ToList();

        /// <summary>
        /// The array to string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ArrayToAddressListString(this string[] array)
        {
            var sb = new StringBuilder();
            if (!(array is null))
                foreach (var item in array)
                {
                    sb.AppendLine($"- [{item}]({item})");
                }
            return sb.ToString();
        }

        /// <summary>
        /// The array to string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ArrayToString(this object[] array) => string.Join(", ", array.Select(x => x.ObjectValueToString()));

        /// <summary>
        /// Converts to jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="twoDimensionalArray">The two dimensional array.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/25995025
        /// </acknowledgment>
        public static T[][] ToJaggedArray<T>(this T[,] twoDimensionalArray)
        {
            var rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            var rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            var numberOfRows = rowsLastIndex + 1;

            var columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            var columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            var numberOfColumns = columnsLastIndex + 1;

            var jaggedArray = new T[numberOfRows][];
            for (var i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (var j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }

            return jaggedArray;
        }

        /// <summary>
        /// Converts to jagged array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="threeDimensionalArray">The three dimensional array.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/25995025
        /// </acknowledgment>
        public static T[][][] ToJaggedArray<T>(this T[,,] threeDimensionalArray)
        {
            var rowsFirstIndex = threeDimensionalArray.GetLowerBound(0);
            var rowsLastIndex = threeDimensionalArray.GetUpperBound(0);
            var numberOfRows = rowsLastIndex + 1;

            var columnsFirstIndex = threeDimensionalArray.GetLowerBound(1);
            var columnsLastIndex = threeDimensionalArray.GetUpperBound(1);
            var numberOfColumns = columnsLastIndex + 1;

            var stacksFirstIndex = threeDimensionalArray.GetLowerBound(2);
            var stacksLastIndex = threeDimensionalArray.GetUpperBound(2);
            var numberOfstacks = stacksLastIndex + 1;

            var jaggedArray = new T[numberOfRows][][];
            for (var i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns][];
                for (var j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = new T[numberOfstacks];
                    for (var k = stacksFirstIndex; k <= stacksLastIndex; k++)
                    {
                        jaggedArray[i][j][k] = threeDimensionalArray[i, j, k];

                    }
                }
            }

            return jaggedArray;
        }

        /// <summary>
        /// The object value to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ObjectValueToString(this object value)
        {
            // This mess is to make sure to print reproducible floating point values in order to be able to correct test cases, and enable printing some complex types.
            return value switch
            {
                null => "null",
                bool b => $"{b}",
                sbyte b => $"{b}",
                byte b => $"{b}",
                int i => $"{i}",
                uint i => $"{i}U",
                short s => $"{s}S",
                ushort s => $"{s}US",
                long l => $"{l}L",
                ulong l => $"{l}UL",
                float f => $"{f.ToString("R", CultureInfo.InvariantCulture)}F",
                double d => $"{d.ToString("R", CultureInfo.InvariantCulture)}D",
                decimal d => $"{d.ToString("R", CultureInfo.InvariantCulture)}M",
                Complex c => $"{c.ToString("R", CultureInfo.InvariantCulture)}",
                IPrintable i => i.ToString("R", CultureInfo.InvariantCulture),
                ValueTuple<float, float> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)})",
                ValueTuple<double, double> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)})",
                ValueTuple<float, float, float> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)})",
                ValueTuple<double, double, double> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)})",
                ValueTuple<float, float, float, float> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)})",
                ValueTuple<double, double, double, double> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)})",
                ValueTuple<float, float, float, float, float> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)})",
                ValueTuple<double, double, double, double, double> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)})",
                ValueTuple<float, float, float, float, float, float> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)}, {ObjectValueToString(t.Item6)})",
                ValueTuple<double, double, double, double, double, double> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)}, {ObjectValueToString(t.Item6)})",
                ValueTuple<float, float, float, float, float, float, float> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)}, {ObjectValueToString(t.Item6)}, {ObjectValueToString(t.Item7)})",
                ValueTuple<double, double, double, double, double, double, double> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)}, {ObjectValueToString(t.Item6)}, {ObjectValueToString(t.Item7)})",
                ValueTuple<float, float, float, float, float, float, float, ValueTuple<float>> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)}, {ObjectValueToString(t.Item6)}, {ObjectValueToString(t.Item7)}, {ObjectValueToString(t.Item8)})",
                ValueTuple<double, double, double, double, double, double, double, ValueTuple<double>> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)}, {ObjectValueToString(t.Item6)}, {ObjectValueToString(t.Item7)}, {ObjectValueToString(t.Item8)})",
                ValueTuple<float, float, float, float, float, float, float, ValueTuple<float, float>> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)}, {ObjectValueToString(t.Item6)}, {ObjectValueToString(t.Item7)}, {ObjectValueToString(t.Item8)}, {ObjectValueToString(t.Item9)})",
                ValueTuple<double, double, double, double, double, double, double, ValueTuple<double, double>> t => $"({ObjectValueToString(t.Item1)}, {ObjectValueToString(t.Item2)}, {ObjectValueToString(t.Item3)}, {ObjectValueToString(t.Item4)}, {ObjectValueToString(t.Item5)}, {ObjectValueToString(t.Item6)}, {ObjectValueToString(t.Item7)}, {ObjectValueToString(t.Item8)}, {ObjectValueToString(t.Item9)})",
                float[] l => $"float\\[\\] {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                double[] l => $"double\\[\\] {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                (float, float)[] v => $"(float, float)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double)[] v => $"(double, double)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float, float)[] v => $"(float, float, float)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double, double)[] v => $"(double, double, double)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float, float, float)[] v => $"(float, float, float, float)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double, double, double)[] v => $"(double, double, double, double)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float, float, float, float)[] v => $"(float, float, float, float, float)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double, double, double, double)[] v => $"(double, double, double, double, double)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float, float, float, float, float)[] v => $"(float, float, float, float, float, float)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double, double, double, double, double)[] v => $"(double, double, double, double, double, double)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float, float, float, float, float, float)[] v => $"(float, float, float, float, float, float, float)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double, double, double, double, double, double)[] v => $"(double, double, double, double, double, double, double)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float, float, float, float, float, float, float)[] v => $"(float, float, float, float, float, float, float, float)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double, double, double, double, double, double, double)[] v => $"(double, double, double, double, double, double, double, double)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float, float, float, float, float, float, float, float)[] v => $"(float, float, float, float, float, float, float, float, float)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double, double, double, double, double, double, double, double)[] v => $"(double, double, double, double, double, double, double, double, double)\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<float> l => $"List\\<float\\> {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                List<double> l => $"List\\<double\\> {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                List<(float, float)> v => $"List\\<(float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(double, double)> v => $"List\\<(double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(float, float, float)> v => $"List\\<(float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(double, double, double)> v => $"List\\<(double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(float, float, float, float)> v => $"List\\<(float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(double, double, double, double)> v => $"List\\<(double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(float, float, float, float, float)> v => $"List\\<(float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(double, double, double, double, double)> v => $"List\\<(double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(float, float, float, float, float, float)> v => $"List\\<(float, float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(double, double, double, double, double, double)> v => $"List\\<(double, double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(float, float, float, float, float, float, float)> v => $"List\\<(float, float, float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(double, double, double, double, double, double, double)> v => $"List\\<(double, double, double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(float, float, float, float, float, float, float, float)> v => $"List\\<(float, float, float, float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(double, double, double, double, double, double, double, double)> v => $"List\\<(double, double, double, double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(float, float, float, float, float, float, float, float, float)> v => $"List\\<(float, float, float, float, float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                List<(double, double, double, double, double, double, double, double, double)> v => $"List\\<(double, double, double, double, double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<float> l => $"IList\\<float\\> {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                IList<double> l => $"IList\\<double\\> {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                IList<(float, float)> v => $"IList\\<(float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double)> v => $"IList\\<(double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float, float)> v => $"IList\\<(float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double, double)> v => $"IList\\<(double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float, float, float)> v => $"IList\\<(float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double, double, double)> v => $"IList\\<(double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float, float, float, float)> v => $"IList\\<(float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double, double, double, double)> v => $"IList\\<(double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float, float, float, float, float)> v => $"IList\\<(float, float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double, double, double, double, double)> v => $"IList\\<(double, double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float, float, float, float, float, float)> v => $"IList\\<(float, float, float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double, double, double, double, double, double)> v => $"IList\\<(double, double, double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float, float, float, float, float, float, float)> v => $"IList\\<(float, float, float, float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double, double, double, double, double, double, double)> v => $"IList\\<(double, double, double, double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float, float, float, float, float, float, float, float)> v => $"IList\\<(float, float, float, float, float, float, float, float, float)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double, double, double, double, double, double, double, double)> v => $"IList\\<(double, double, double, double, double, double, double, double, double)\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                float[,] v => $"float\\[,\\] {{ { string.Join(", ", v.ToJaggedArray().Select(o => ObjectValueToString(o)))} }}",
                double[,] v => $"double\\[,\\] {{ { string.Join(", ", v.ToJaggedArray().Select(o => ObjectValueToString(o)))} }}",
                float[][] v => $"float\\[\\]\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                double[][] v => $"double\\[\\]\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float)[][] v => $"(float, float)\\[\\]\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double)[][] v => $"(double, double)\\[\\]\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (float, float, float)[][] v => $"(float, float, float)\\[\\]\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                (double, double, double)[][] v => $"(double, double, double)\\[\\]\\[\\] {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float)[]> v => $"IList\\<(float, float)\\[\\]\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double)[]> v => $"IList\\<(double, double)\\[\\]\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(float, float, float)[]> v => $"IList\\<(float, float, float)\\[\\]\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<(double, double, double)[]> v => $"IList\\<(double, double, double)\\[\\]\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<List<(float, float)>> v => $"IList\\<List\\<(float, float)\\>\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<List<(double, double)>> v => $"IList\\<List\\<(double, double)\\>\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<List<(float, float, float)>> v => $"IList\\<List\\<(float, float, float)\\>\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                IList<List<(double, double, double)>> v => $"IList\\<List\\<(double, double, double)\\>\\> {{ { string.Join(", ", v.Select(o => ObjectValueToString(o)))} }}",
                Complex[] l => $"Complex\\[\\] {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                List<Complex> l => $"List\\<Complex\\> {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                IList<Complex> l => $"IList\\<Complex\\> {{ {string.Join(", ", l.Select(x => $"{ObjectValueToString(x)}"))} }}",
                object[] l => $"object\\[\\] {{ {string.Join(", ", l.Select(x => x?.ToString() ?? "Null"))} }}",
                _ => value?.ToString(),
            };
        }

        /// <summary>
        /// Special equivalency tests.
        /// </summary>
        /// <param name="testcase">The test-case.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Equivalency(this KeyValuePair<object[], TestCaseResults> testcase)
        {
            const string equal = "==";
            const string notEqual = "!=";
            string equivalency;
            switch (testcase.Value.ReturnValue)
            {
                case int i:
                    {
                        equivalency = testcase.Value.ExpectedReturnValue switch
                        {
                            int j => Math.Abs(i - j) <= testcase.Value.Epsilon ? equal : notEqual,
                            float f => Math.Abs(i - f) <= testcase.Value.Epsilon ? equal : notEqual,
                            double d => Math.Abs(i - d) <= testcase.Value.Epsilon ? equal : notEqual,
                            _ => Equals(i, testcase.Value.ExpectedReturnValue) ? equal : notEqual,
                        };
                    }
                    break;
                case float f:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case int i:
                                equivalency = Math.Abs(f - i) <= testcase.Value.Epsilon ? equal : notEqual;
                                break;
                            case float g:
                                if (float.IsNaN(f))
                                {
                                    equivalency = float.IsNaN(g) ? equal : notEqual;
                                }
                                else if (float.IsPositiveInfinity(f))
                                {
                                    equivalency = float.IsPositiveInfinity(g) ? equal : notEqual;
                                }
                                else if (float.IsNegativeInfinity(f))
                                {
                                    equivalency = float.IsNegativeInfinity(g) ? equal : notEqual;
                                }
                                else
                                {
                                    equivalency = Math.Abs(f - g) <= testcase.Value.Epsilon ? equal : notEqual;
                                }
                                break;
                            case double e:
                                if (float.IsNaN(f))
                                {
                                    equivalency = double.IsNaN(e) ? equal : notEqual;
                                }
                                else if (float.IsPositiveInfinity(f))
                                {
                                    equivalency = double.IsPositiveInfinity(e) ? equal : notEqual;
                                }
                                else if (float.IsNegativeInfinity(f))
                                {
                                    equivalency = double.IsNegativeInfinity(e) ? equal : notEqual;
                                }
                                else
                                {
                                    equivalency = Math.Abs(f - e) <= testcase.Value.Epsilon ? equal : notEqual;
                                }
                                break;
                            default:
                                equivalency = Equals(f, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case double d:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case int i:
                                equivalency = Math.Abs(d - i) <= testcase.Value.Epsilon ? equal : notEqual;
                                break;
                            case float f:
                                if (double.IsNaN(d))
                                {
                                    equivalency = float.IsNaN(f) ? equal : notEqual;
                                }
                                else if (double.IsPositiveInfinity(d))
                                {
                                    equivalency = float.IsPositiveInfinity(f) ? equal : notEqual;
                                }
                                else if (double.IsNegativeInfinity(d))
                                {
                                    equivalency = float.IsNegativeInfinity(f) ? equal : notEqual;
                                }
                                else
                                {
                                    equivalency = Math.Abs(d - f) <= testcase.Value.Epsilon ? equal : notEqual;
                                }
                                break;
                            case double e:
                                if (double.IsNaN(d))
                                {
                                    equivalency = double.IsNaN(e) ? equal : notEqual;
                                }
                                else if (double.IsPositiveInfinity(e))
                                {
                                    equivalency = double.IsPositiveInfinity(d) ? equal : notEqual;
                                }
                                else if (double.IsNegativeInfinity(e))
                                {
                                    equivalency = double.IsNegativeInfinity(d) ? equal : notEqual;
                                }
                                else
                                {
                                    equivalency = Math.Abs(d - e) <= testcase.Value.Epsilon ? equal : notEqual;
                                }
                                break;
                            default:
                                equivalency = Equals(d, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case double[,] l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case double[,] k:
                                equivalency = equal;
                                if (l.Length != k.Length)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    foreach (var i in l)
                                    {
                                        foreach (var j in k)
                                        {
                                            if (i != j)
                                            {
                                                equivalency = notEqual;
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case double[][] l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case double[][] k:
                                equivalency = equal;
                                if (l.Length != k.Length)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    foreach (var i in l)
                                    {
                                        foreach (var j in k)
                                        {
                                            if (i != j)
                                            {
                                                equivalency = notEqual;
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<int> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<int> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<float> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<float> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(float, float)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(float, float)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(float, float, float)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(float, float, float)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(float, float, float, float)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(float, float, float, float)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(float, float, float, float, float)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(float, float, float, float, float)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(float, float, float, float, float, float)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(float, float, float, float, float, float)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(float, float, float, float, float, float, float)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(float, float, float, float, float, float, float)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(float, float, float, float, float, float, float, float)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(float, float, float, float, float, float, float, float)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(float, float, float, float, float, float, float, float, float)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(float, float, float, float, float, float, float, float, float)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<double> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<double> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double, double)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double, double)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double, double, double)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double, double, double)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double, double, double, double)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double, double, double, double)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double, double, double, double, double)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double, double, double, double, double)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double, double, double, double, double, double)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double, double, double, double, double, double)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double, double, double, double, double, double, double)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double, double, double, double, double, double, double)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double, double, double, double, double, double, double, double)> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double, double, double, double, double, double, double, double)> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i] != k[i])
                                        {
                                            equivalency = notEqual;
                                            break;
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<List<double>> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<List<double>> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i].Count != k[i].Count)
                                        {
                                            equivalency = notEqual;
                                        }
                                        else
                                        {
                                            for (var j = 0; j < l[i].Count; j++)
                                            {
                                                if (l[i][j] != k[i][j])
                                                {
                                                    equivalency = notEqual;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<List<(double, double)>> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<List<(double, double)>> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i].Count != k[i].Count)
                                        {
                                            equivalency = notEqual;
                                        }
                                        else
                                        {
                                            for (var j = 0; j < l[i].Count; j++)
                                            {
                                                if (l[i][j] != k[i][j])
                                                {
                                                    equivalency = notEqual;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<List<(double, double, double)>> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<List<(double, double, double)>> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i].Count != k[i].Count)
                                        {
                                            equivalency = notEqual;
                                        }
                                        else
                                        {
                                            for (var j = 0; j < l[i].Count; j++)
                                            {
                                                if (l[i][j] != k[i][j])
                                                {
                                                    equivalency = notEqual;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<double[]> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<double[]> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i].Length != k[i].Length)
                                        {
                                            equivalency = notEqual;
                                        }
                                        else
                                        {
                                            for (var j = 0; j < l[i].Length; j++)
                                            {
                                                if (l[i][j] != k[i][j])
                                                {
                                                    equivalency = notEqual;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double)[]> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double)[]> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i].Length != k[i].Length)
                                        {
                                            equivalency = notEqual;
                                        }
                                        else
                                        {
                                            for (var j = 0; j < l[i].Length; j++)
                                            {
                                                if (l[i][j] != k[i][j])
                                                {
                                                    equivalency = notEqual;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                case IList<(double, double, double)[]> l:
                    {
                        switch (testcase.Value.ExpectedReturnValue)
                        {
                            case IList<(double, double, double)[]> k:
                                equivalency = equal;
                                if (l.Count != k.Count)
                                {
                                    equivalency = notEqual;
                                }
                                else
                                {
                                    for (var i = 0; i < l.Count; i++)
                                    {
                                        if (l[i].Length != k[i].Length)
                                        {
                                            equivalency = notEqual;
                                        }
                                        else
                                        {
                                            for (var j = 0; j < l[i].Length; j++)
                                            {
                                                if (l[i][j] != k[i][j])
                                                {
                                                    equivalency = notEqual;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                                break;
                        }
                        break;
                    }
                default:
                    {
                        equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                        break;
                    }
            }

            return equivalency;
        }

        /// <summary>
        /// Elapsed the nano seconds.
        /// </summary>
        /// <param name="watch">The watch.</param>
        /// <returns></returns>
        public static long ElapsedNanoSeconds(this Stopwatch watch) => watch?.ElapsedTicks * 1000000000L / Stopwatch.Frequency ?? 0L;

        /// <summary>
        /// Elapsed the micro seconds.
        /// </summary>
        /// <param name="watch">The watch.</param>
        /// <returns></returns>
        public static long ElapsedMicroSeconds(this Stopwatch watch) => watch?.ElapsedTicks * 1000000L / Stopwatch.Frequency ?? 0L;
    }
}
