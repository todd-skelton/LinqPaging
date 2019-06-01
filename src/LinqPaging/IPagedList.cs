namespace System.Linq
{
    /// <summary>
    /// Exposes a subset of a set of items.
    /// </summary>
    public interface IPagedList
    {
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
    }
}
