using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSharpSpeed
{
    /// <summary>
    /// The reflection helper class.
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// The list static factory constructors.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="T:List{MethodInfo}"/>.</returns>
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
        public static string ArrayToString(this object[] array)
            => string.Join(", ", array.Select(x => x.ToString()));

        /// <summary>
        /// The array to string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ArrayToUrlListString(this string[] array)
        {
            var sb = new StringBuilder();
            foreach (var item in array)
            {
                sb.AppendLine($"- [{item}]({item})");
            }
            return sb.ToString();
        }
    }
}
