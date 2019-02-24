﻿using System.Collections.Generic;
using System.Linq;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon class.
    /// </summary>
    public struct Polygon2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon2D"/> class.
        /// </summary>
        /// <param name="contours">The contours.</param>
        public Polygon2D(IEnumerable<PolygonContour2D> contours)
        {
            Contours = contours;
        }

        /// <summary>
        /// Gets or sets the contours.
        /// </summary>
        public IEnumerable<PolygonContour2D> Contours { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => Contours?.Count() ?? 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        public static implicit operator List<List<Point2D>>(Polygon2D polygon)
        {
            var list = new List<List<Point2D>>();

            foreach (var contour in polygon.Contours)
            {
                list.Add(contour);
            }

            return list;
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString() => $"{nameof(Polygon2D)}=[{string.Join(",", Contours)}]";
    }
}