using System.Collections.Generic;

namespace System.Linq
{
    /// <summary>
    /// An interface for a subset of a list of items
    /// </summary>
    /// <typeparam name="T">The type of items</typeparam>
    public interface IPagedList<T> : IPagedList
    {
        /// <summary>
        /// The subset being returned
        /// </summary>
        IEnumerable<T> Items { get; }

        /// <summary>
        /// The enumerator to iterate over the subset
        /// </summary>
        /// <returns></returns>
        new IEnumerator<T> GetEnumerator();
    }
}
