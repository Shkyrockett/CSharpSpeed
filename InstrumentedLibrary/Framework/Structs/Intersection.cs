﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The intersection struct.
    /// </summary>
    /// <seealso cref="IEquatable{T}" />
    /// <seealso cref="IPrintable" />
    public struct Intersection
        : IEquatable<Intersection>,
        IPrintable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Intersection"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Intersection(IntersectionStates state)
            : this()
        {
            State = state;
            Items = new List<(double X, double Y)>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Intersection"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Intersection(IntersectionStates state, params (double X, double Y)[] points)
            : this(state, points as IList<(double X, double Y)>)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Intersection"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Intersection(IntersectionStates state, IEnumerable<(double X, double Y)> points)
            : this(state, points.ToList())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Intersection"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Intersection(IntersectionStates state, IList<(double X, double Y)> points)
        {
            State = state;
            Items = points as List<(double X, double Y)>;
        }

        /// <summary>
        /// Deconstruct this <see cref="Intersection"/> to a <see cref="ValueTuple{T1, T2}"/>.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out IntersectionStates state, out IList<(double X, double Y)> points)
        {
            state = State;
            points = Items;
        }

        /// <summary>
        /// The Indexer.
        /// </summary>
        /// <param name="index">The index index.</param>
        /// <returns>One element of type Point2D.</returns>
        public (double X, double Y) this[int index] { get { return Items[index]; } set { Items[index] = value; } }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public IntersectionStates State { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        public List<(double X, double Y)> Items { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => Items?.Count ?? 0;

        /// <summary>
        /// The operator ==.
        /// Compares two <see cref="Intersection"/> objects.
        /// The result specifies whether the values of the two <see cref="Intersection"/> objects are equal.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Intersection left, Intersection right) => Equals(left, right);

        /// <summary>
        /// The operator !=.
        /// Compares two <see cref="Intersection"/> objects.
        /// The result specifies whether the values the two <see cref="Intersection"/> objects are unequal.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Intersection left, Intersection right) => !Equals(left, right);

        /// <summary>
        /// The append point.
        /// </summary>
        /// <param name="point">The point.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendPoint((double X, double Y) point)
        {
            if (Items is null)
            {
                Items = new List<(double X, double Y)>();
            }

            Items.Add(point);
        }

        /// <summary>
        /// The append points.
        /// </summary>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendPoints(List<(double X, double Y)> points)
        {
            if (points is null)
            {
                return;
            }

            if (Items is null)
            {
                Items = points;
            }
            else
            {
                Items.AddRange(points);
            }
        }

        /// <summary>
        /// The append points.
        /// </summary>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendPoints(HashSet<(double X, double Y)> points)
        {
            if (Items is null)
            {
                Items = points.ToList();
            }
            else
            {
                Items.AddRange(points);
            }
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(State, Items);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Intersection a, Intersection b)
        {
            if (a.State != b.State) return false;
            return (a.Items is null || b.Items is null) ? (a.Items is null && b.Items is null) : a.Items.SequenceEqual(b.Items);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Intersection && Equals(this, (Intersection)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Intersection value) => Equals(this, value);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public new string ToString() => ToString("R", CultureInfo.InvariantCulture);

        /// <summary>
        /// Creates a string representation of this <see cref="Size2D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Size2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R", provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Intersection"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Intersection"/>.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            _ = format;
            var sep = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Intersection)}({nameof(State)}: {State}{sep} {nameof(Items)}: {(Items is null ? "null" : string.Join(sep, Items))})";
        }
    }
}
