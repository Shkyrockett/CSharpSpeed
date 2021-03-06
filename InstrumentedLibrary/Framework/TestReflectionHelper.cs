﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The test reflection helper class.
    /// </summary>
    public static class TestReflectionHelper
    {
        /// <summary>
        /// Get the types with help attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <returns>
        /// The <see cref="IEnumerable{Type}" />.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<Type> GetTypesWithHelpAttribute(Type attribute)
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(attribute, true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        /// <summary>
        /// Get the types with help attribute.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns>
        /// The <see cref="IEnumerable{Type}" />.
        /// </returns>
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<Type> GetTypesWithHelpAttributeByName(string name, Type attribute)
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes().Where(t => t.FullName == name))
            {
                if (type.GetCustomAttributes(attribute, true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
