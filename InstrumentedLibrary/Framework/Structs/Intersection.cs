using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The intersection struct.
    /// </summary>
    public struct Intersection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Intersection"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Intersection(IntersectionState state)
            : this()
        {
            state = State;
            Points = new List<Point2D>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Intersection"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Intersection(IntersectionState state, params Point2D[] points)
            : this(state, points as IList<Point2D>)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Intersection"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Intersection(IntersectionState state, IEnumerable<Point2D> points)
            : this(state, points as IList<Point2D>)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Intersection"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Intersection(IntersectionState state, IList<Point2D> points)
        {
            State = state;
            Points = points as List<Point2D>;
        }

        /// <summary>
        /// The deconstruct.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Deconstruct(out IntersectionState state, out IList<Point2D> points)
        {
            state = State;
            points = Points;
        }

        /// <summary>
        /// The Indexer.
        /// </summary>
        /// <param name="index">The index index.</param>
        /// <returns>One element of type Point2D.</returns>
        public Point2D this[int index]
        {
            get { return Points[index]; }
            set { Points[index] = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public IntersectionState State { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        public List<Point2D> Points { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count
            => (Points is null) ? 0 : Points.Count;

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
        public static bool operator ==(Intersection left, Intersection right)
            => Equals(left, right);

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
        public static bool operator !=(Intersection left, Intersection right)
            => !Equals(left, right);

        /// <summary>
        /// The append point.
        /// </summary>
        /// <param name="point">The point.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendPoint(Point2D point)
        {
            if (Points is null)
            {
                Points = new List<Point2D>();
            }

            Points.Add(point);
        }

        /// <summary>
        /// The append points.
        /// </summary>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendPoints(List<Point2D> points)
        {
            if (points is null)
            {
                return;
            }

            if (Points is null)
            {
                Points = points;
            }
            else
            {
                Points.AddRange(points);
            }
        }

        /// <summary>
        /// The append points.
        /// </summary>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendPoints(HashSet<Point2D> points)
        {
            if (Points is null)
            {
                Points = points.ToList();
            }
            else
            {
                Points.AddRange(points);
            }
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => State.GetHashCode()
            ^ Points.GetHashCode();

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Intersection a, Intersection b)
            => (a.State == b.State) & (a.Points == b.Points);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
            => obj is Intersection && Equals(this, (Intersection)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Intersection value)
            => Equals(this, value);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Intersection)}{{{nameof(State)}:{State}, {nameof(Points)}:{Points} }}";
    }
}
