using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    /// <summary>
    /// Exposes a subset of a set of items.
    /// </summary>
    /// <typeparam name="T">The type of items</typeparam>
    public class PagedList<T> : IPagedList<T>
    {
        /// <summary>
        /// Constructs a <see cref="PagedList{T}"/> from a list of items
        /// </summary>
        /// <param name="source"></param>
        /// <param name="page"></param>
        /// <param name="results"></param>
        public PagedList(IQueryable<T> source, int page, int? results)
        {
            if(source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if(page < 1)
            {
                throw new ArgumentException("Page must be greater than 1", nameof(page));
            }

            if (results.HasValue)
            {
                if (results < 1)
                {
                    throw new ArgumentException("Results must be greater than 1", nameof(results));
                }

                int index = page - 1;

                int max = index * results.Value;

                var items = source.Skip(max).Take(results.Value).ToList();

                Items = items;
                Results = results.Value;
                Total = source.Count();
            }
            else
            {
                if(page != 1)
                {
                    throw new ArgumentException("If results is null the page must be 1, because all results will be returned in 1 page.", nameof(results));
                }

                var items = source.ToList();

                Items = items;
                Results = items.Count;
                Total = items.Count;
            }

            Page = page;
            HasNext = page * results < Total;
            HasPrevious = page > 1;
        }

        /// <summary>
        /// Constructs a <see cref="PagedList{T}"/> from a list of items
        /// </summary>
        /// <param name="source"></param>
        /// <param name="page"></param>
        /// <param name="results"></param>
        public PagedList(IEnumerable<T> source, int page, int? results) : this(source.AsQueryable(), page, results) { }


        /// <summary>
        /// Constructs a <see cref="PagedList{T}"/> from a list of items
        /// </summary>
        /// <param name="source"></param>
        /// <param name="query"></param>
        public PagedList(IQueryable<T> source, IPageable query) : this(source, query.Page ?? 1, query.Results) { }


        /// <summary>
        /// Constructs a <see cref="PagedList{T}"/> from a list of items
        /// </summary>
        /// <param name="source"></param>
        /// <param name="query"></param>
        public PagedList(IEnumerable<T> source, IPageable query) : this(source.AsQueryable(), query) { }

        /// <summary>
        /// The subset being returned
        /// </summary>
        public IEnumerable<T> Items { get; }

        /// <summary>
        /// The current page number
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// The number of results per page
        /// </summary>
        public int Results { get; }

        /// <summary>
        /// The total number of items in the source
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Whether or not the data source has another page
        /// </summary>
        public bool HasNext { get; }

        /// <summary>
        /// Whether or not the data source has a previous page
        /// </summary>
        public bool HasPrevious { get; }

        /// <summary>
        /// The enumerator to iterate over the subset
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();
    }
}