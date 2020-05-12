using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    /// <summary>
    /// An interface for a subset of a list of items
    /// </summary>
    /// <typeparam name="T">The type of items</typeparam>
    public interface IPagedList<out T>
    {
        /// <summary>
        /// The subset being returned
        /// </summary>
        IEnumerable<T> Items { get; }

        /// <summary>
        /// The current page number
        /// </summary>
        int Page { get; }

        /// <summary>
        /// The number of results per page
        /// </summary>
        int Results { get; }
        /// <summary>
        /// The total number of items in the source
        /// </summary>
        int Total { get; }

        /// <summary>
        /// Whether or not the data source has another page
        /// </summary>
        bool HasNext { get; }
        
        /// <summary>
        /// Whether or not the data source has a previous page
        /// </summary>
        bool HasPrevious { get; }
 
        /// <summary>
        ///  An enumerator that can be used to iterate through the subset.
        /// </summary>
        IEnumerator<T> GetEnumerator();
    }
}