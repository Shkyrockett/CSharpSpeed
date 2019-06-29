using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICachableProperties
    {
        ///// <summary>
        ///// The property changed event of the <see cref="PropertyChangedEventHandler"/>.
        ///// </summary>
        //public event PropertyChangedEventHandler PropertyChanged;

        ///// <summary>
        ///// The property changing event of the <see cref="PropertyChangingEventHandler"/>.
        ///// </summary>
        //public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Property cache for commonly used properties that may take time to calculate.
        /// </summary>
        [Browsable(false)]
        //[field: NonSerialized]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        Dictionary<object, object> PropertyCache { get; set; }

        ///// <summary>
        ///// Raises the property changing event.
        ///// </summary>
        ///// <param name="name">The name.</param>
        //protected void OnPropertyChanging([CallerMemberName] string name = "") => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));

        ///// <summary>
        ///// Raises the property changed event.
        ///// </summary>
        ///// <param name="name">The name.</param>
        //protected void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        /// <summary>
        /// This should be run anytime a property of the item is modified.
        /// </summary>
        [Browsable(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearCache() => PropertyCache?.Clear();

        /// <summary>
        /// Private method for caching computationally and memory intensive properties of child objects
        /// so that the intensive properties only get recalculated and stored when necessary.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks>http://syncor.blogspot.com/2010/11/passing-getter-and-setter-of-c-property.html</remarks>
        [Browsable(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object CachingProperty(Func<object> property, [CallerMemberName]string name = "")
        {
            if (PropertyCache is null)
            {
                PropertyCache = new Dictionary<object, object>();
            }

            if (!PropertyCache.ContainsKey(name))
            {
                var value = property.Invoke();
                PropertyCache.Add(name, value);
                return value;
            }

            return PropertyCache[name];
        }
    }
}
