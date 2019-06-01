using System.Threading.Tasks;

namespace System.Linq
{
    /// <summary>
    /// Extension methods for <see cref="IQueryable{T}"/>
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Converts an <see cref="IQueryable{T}"/> into a <see cref="IPagedList{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of data in the source</typeparam>
        /// <param name="queryable">The source data to page</param>
        /// <param name="query">Information about paging</param>
        /// <returns></returns>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> queryable, IPageable query)
        {
            return new PagedList<T>(queryable, query);
        }

        /// <summary>
        /// Converts an <see cref="IQueryable{T}"/> into a <see cref="IPagedList{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of data in the source</typeparam>
        /// <param name="queryable">The source data to page</param>
        /// <param name="query">Information about paging</param>
        /// <returns></returns>
        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> queryable, IPageable query)
        {
            return Task.Run(() => ToPagedList(queryable, query));
        }

        /// <summary>
        /// Converts an <see cref="IQueryable{T}"/> into a <see cref="IPagedList{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="page"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> queryable, int page = 1, int results = 20)
        {
            return new PagedList<T>(queryable, page, results);
        }

        /// <summary>
        /// Converts an <see cref="IQueryable{T}"/> into a <see cref="IPagedList{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="page"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> queryable, int page = 1, int results = 20)
        {
            return Task.Run(() => ToPagedList(queryable, page, results));
        }
    }
}
