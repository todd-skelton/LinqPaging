using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Linq
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> into a <see cref="IPagedList{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of data in the source</typeparam>
        /// <param name="enumerable">The source data to page</param>
        /// <param name="query">Information about paging</param>
        /// <returns></returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> enumerable, IPageable query)
        {
            return new PagedList<T>(enumerable, query);
        }

        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> into a <see cref="IPagedList{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of data in the source</typeparam>
        /// <param name="enumerable">The source data to page</param>
        /// <param name="query">Information about paging</param>
        /// <returns></returns>
        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IEnumerable<T> enumerable, IPageable query)
        {
            return Task.Run(() => ToPagedList(enumerable, query));
        }

        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> into a <see cref="IPagedList{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="page"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> enumerable, int? page = null, int? results = null)
        {
            return new PagedList<T>(enumerable, page ?? 1, results);
        }

        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> into a <see cref="IPagedList{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="page"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IEnumerable<T> enumerable, int? page = null, int? results = null)
        {
            return Task.Run(() => ToPagedList(enumerable, page, results));
        }
    }
}
