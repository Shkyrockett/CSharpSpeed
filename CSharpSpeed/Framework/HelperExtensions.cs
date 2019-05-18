using System;
using System.Collections.Generic;
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
        /// <returns>The <see cref="T:List{MethodInfo}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<MethodInfo> ListStaticFactoryConstructors(this Type type)
            => new List<MethodInfo>
            (
                from method in type.GetMethods()
                where method.IsStatic
                where method.ReturnType == type
                select method
            ).OrderBy(x => x.Name).ToList();

        /// <summary>
        /// The list static factory constructors list.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="type2">The type2.</param>
        /// <returns>The <see cref="T:List{MethodInfo}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<MethodInfo> ListStaticFactoryConstructorsList(this Type type, Type type2)
            => new List<MethodInfo>
            (
                from method in type.GetMethods()
                where method.IsStatic
                where method.ReturnType == type2
                select method
            ).OrderBy(x => x.Name).ToList();

        /// <summary>
        /// The list static methods with attribute.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attributeType">The attribute.</param>
        /// <returns>The <see cref="T:List{MethodInfo}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<MethodInfo> ListStaticMethodsWithAttribute(this Type type, Type attributeType)
            => new List<MethodInfo>(
                from method in type.GetMethods()
                where method.IsStatic
                where method.GetCustomAttributes(attributeType).Any()
                select method
                ).OrderBy(x => x.Name).ToList();

        /// <summary>
        /// The list classes with attribute.
        /// </summary>
        /// <param name="attributeType">The attributeType.</param>
        /// <returns>The <see cref="T:IEnumerable{TypeInfo}"/>.</returns>
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
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ArrayToUrlListString(this string[] array)
        {
            var sb = new StringBuilder();
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
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ArrayToString(this object[] array)
            => string.Join(", ", array.Select(x => x.ObjectValueToString()));

        /// <summary>
        /// The object value to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ObjectValueToString(this object value)
        {
            // This mess is to make sure to print reproducible floating point values in order to be able to correct test cases, and enable printing some complex types.
            switch (value)
            {
                case float f:
                    return $"{f:R}";
                case double d:
                    return $"{d:R}";
                case ValueTuple<float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R})";
                case ValueTuple<double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R})";
                case ValueTuple<float, float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R})";
                case ValueTuple<double, double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R})";
                case ValueTuple<float, float, float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R})";
                case ValueTuple<double, double, double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R})";
                case ValueTuple<float, float, float, float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R})";
                case ValueTuple<double, double, double, double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R})";
                case ValueTuple<float, float, float, float, float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R}, {t.Item6:R})";
                case ValueTuple<double, double, double, double, double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R}, {t.Item6:R})";
                case ValueTuple<float, float, float, float, float, float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R}, {t.Item6:R}, {t.Item7:R})";
                case ValueTuple<double, double, double, double, double, double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R}, {t.Item6:R}, {t.Item7:R})";
                case ValueTuple<float, float, float, float, float, float, float, ValueTuple<float>> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R}, {t.Item6:R}, {t.Item7:R}, {t.Item8:R})";
                case ValueTuple<double, double, double, double, double, double, double, ValueTuple<double>> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R}, {t.Item6:R}, {t.Item7:R}, {t.Item8:R})";
                case ValueTuple<float, float, float, float, float, float, float, ValueTuple<float, float>> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R}, {t.Item6:R}, {t.Item7:R}, {t.Item8:R}, {t.Item9:R})";
                case ValueTuple<double, double, double, double, double, double, double, ValueTuple<double, double>> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R}, {t.Item5:R}, {t.Item6:R}, {t.Item7:R}, {t.Item8:R}, {t.Item9:R})";
                case float[] l:
                    return $"float\\[\\] {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case double[] l:
                    return $"double\\[\\] {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case (float, float)[] v:
                    return $"(float, float)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double)[] v:
                    return $"(double, double)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float, float)[] v:
                    return $"(float, float, float)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double, double)[] v:
                    return $"(double, double, double)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float, float, float)[] v:
                    return $"(float, float, float, float)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double, double, double)[] v:
                    return $"(double, double, double, double)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float, float, float, float)[] v:
                    return $"(float, float, float, float, float)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double, double, double, double)[] v:
                    return $"(double, double, double, double, double)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float, float, float, float, float)[] v:
                    return $"(float, float, float, float, float, float)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double, double, double, double, double)[] v:
                    return $"(double, double, double, double, double, double)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float, float, float, float, float, float)[] v:
                    return $"(float, float, float, float, float, float, float)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double, double, double, double, double, double)[] v:
                    return $"(double, double, double, double, double, double, double)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float, float, float, float, float, float, float)[] v:
                    return $"(float, float, float, float, float, float, float, float)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double, double, double, double, double, double, double)[] v:
                    return $"(double, double, double, double, double, double, double, double)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float, float, float, float, float, float, float, float)[] v:
                    return $"(float, float, float, float, float, float, float, float, float)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double, double, double, double, double, double, double, double)[] v:
                    return $"(double, double, double, double, double, double, double, double, double)\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<float> l:
                    return $"List\\<float\\>{{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case List<double> l:
                    return $"List\\<double\\>{{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case List<(float, float)> v:
                    return $"List\\<(float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(double, double)> v:
                    return $"List\\<(double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(float, float, float)> v:
                    return $"List\\<(float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(double, double, double)> v:
                    return $"List\\<(double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(float, float, float, float)> v:
                    return $"List\\<(float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(double, double, double, double)> v:
                    return $"List\\<(double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(float, float, float, float, float)> v:
                    return $"List\\<(float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(double, double, double, double, double)> v:
                    return $"List\\<(double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(float, float, float, float, float, float)> v:
                    return $"List\\<(float, float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(double, double, double, double, double, double)> v:
                    return $"List\\<(double, double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(float, float, float, float, float, float, float)> v:
                    return $"List\\<(float, float, float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(double, double, double, double, double, double, double)> v:
                    return $"List\\<(double, double, double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(float, float, float, float, float, float, float, float)> v:
                    return $"List\\<(float, float, float, float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(double, double, double, double, double, double, double, double)> v:
                    return $"List\\<(double, double, double, double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(float, float, float, float, float, float, float, float, float)> v:
                    return $"List\\<(float, float, float, float, float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case List<(double, double, double, double, double, double, double, double, double)> v:
                    return $"List\\<(double, double, double, double, double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<float> l:
                    return $"IList\\<float\\>{{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case IList<double> l:
                    return $"IList\\<double\\>{{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case IList<(float, float)> v:
                    return $"IList\\<(float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double)> v:
                    return $"IList\\<(double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float, float)> v:
                    return $"IList\\<(float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double, double)> v:
                    return $"IList\\<(double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float, float, float)> v:
                    return $"IList\\<(float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double, double, double)> v:
                    return $"IList\\<(double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float, float, float, float)> v:
                    return $"IList\\<(float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double, double, double, double)> v:
                    return $"IList\\<(double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float, float, float, float, float)> v:
                    return $"IList\\<(float, float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double, double, double, double, double)> v:
                    return $"IList\\<(double, double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float, float, float, float, float, float)> v:
                    return $"IList\\<(float, float, float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double, double, double, double, double, double)> v:
                    return $"IList\\<(double, double, double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float, float, float, float, float, float, float)> v:
                    return $"IList\\<(float, float, float, float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double, double, double, double, double, double, double)> v:
                    return $"IList\\<(double, double, double, double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float, float, float, float, float, float, float, float)> v:
                    return $"IList\\<(float, float, float, float, float, float, float, float, float)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double, double, double, double, double, double, double, double)> v:
                    return $"IList\\<(double, double, double, double, double, double, double, double, double)\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float)[][] v:
                    return $"(float, float)\\[\\]\\[\\]\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double)[][] v:
                    return $"(double, double)\\[\\]\\[\\]\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (float, float, float)[][] v:
                    return $"(float, float, float)\\[\\]\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case (double, double, double)[][] v:
                    return $"(double, double, double)\\[\\]\\[\\]{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float)[]> v:
                    return $"IList\\<(float, float)\\[\\]\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double)[]> v:
                    return $"IList\\<(double, double)\\[\\]\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(float, float, float)[]> v:
                    return $"IList\\<(float, float, float)\\[\\]\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<(double, double, double)[]> v:
                    return $"IList\\<(double, double, double)\\[\\]\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<List<(float, float)>> v:
                    return $"IList\\<List\\<(float, float)\\>\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<List<(double, double)>> v:
                    return $"IList\\<List\\<(double, double)\\>\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<List<(float, float, float)>> v:
                    return $"IList\\<List\\<(float, float, float)\\>\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case IList<List<(double, double, double)>> v:
                    return $"IList\\<List\\<(double, double, double)\\>\\>{{{ string.Join(", ", v.Select(o => ObjectValueToString(o)))}}}";
                case Complex[] l:
                    return $"Complex\\[\\] {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case List<Complex> l:
                    return $"List\\<Complex\\> {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case IList<Complex> l:
                    return $"IList\\<Complex\\> {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case object[] l:
                    return string.Join(", ", l.Select(x => x.ToString()));
                case null:
                    return "Null";
                default:
                    return value.ToString();
            }
        }

        /// <summary>
        /// Special equivalency tests.
        /// </summary>
        /// <param name="testcase">The test-case.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Equivalency(this KeyValuePair<object[], TestCaseResults> testcase)
        {
            const string equal = "==";
            const string notEqual = "!=";
            string equivalency;
            switch (testcase.Value.ReturnValue)
            {
                case int i:
                    switch (testcase.Value.ExpectedReturnValue)
                    {
                        case int j:
                            equivalency = Math.Abs(i - j) <= testcase.Value.Epsilon ? equal : notEqual;
                            break;
                        case float f:
                            equivalency = Math.Abs(i - f) <= testcase.Value.Epsilon ? equal : notEqual;
                            break;
                        case double d:
                            equivalency = Math.Abs(i - d) <= testcase.Value.Epsilon ? equal : notEqual;
                            break;
                        default:
                            equivalency = Equals(i, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                            break;
                    }
                    break;
                case float f:
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
                case double d:
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
                case IList<int> l:
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
                case IList<float> l:
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
                case IList<(float, float)> l:
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
                case IList<(float, float, float)> l:
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
                case IList<(float, float, float, float)> l:
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
                case IList<(float, float, float, float, float)> l:
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
                case IList<(float, float, float, float, float, float)> l:
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
                case IList<(float, float, float, float, float, float, float)> l:
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
                case IList<(float, float, float, float, float, float, float, float)> l:
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
                case IList<(float, float, float, float, float, float, float, float, float)> l:
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
                case IList<double> l:
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
                case IList<(double, double)> l:
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
                case IList<(double, double, double)> l:
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
                case IList<(double, double, double, double)> l:
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
                case IList<(double, double, double, double, double)> l:
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
                case IList<(double, double, double, double, double, double)> l:
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
                case IList<(double, double, double, double, double, double, double)> l:
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
                case IList<(double, double, double, double, double, double, double, double)> l:
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
                case IList<(double, double, double, double, double, double, double, double, double)> l:
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
                case IList<List<double>> l:
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
                case IList<List<(double, double)>> l:
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
                case IList<List<(double, double, double)>> l:
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
                case IList<double[]> l:
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
                case IList<(double, double)[]> l:
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
                case IList<(double, double, double)[]> l:
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
                default:
                    equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                    break;
            }

            return equivalency;
        }
    }
}
