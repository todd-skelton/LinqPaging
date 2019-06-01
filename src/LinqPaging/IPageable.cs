namespace System.Linq
{
    /// <summary>
    /// Interface to mark a query as pageable
    /// </summary>
    public interface IPageable
    {
        /// <summary>
        /// The current page number
        /// </summary>
        int? Page { get; }

        /// <summary>
        /// The number of results per page
        /// </summary>
        int? Results { get; }
    }
}
