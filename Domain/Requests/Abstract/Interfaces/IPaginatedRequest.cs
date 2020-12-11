namespace Domain.Requests.Abstract.Interfaces
{
    public interface IPaginatedRequest
    {
        /// <summary>
        ///     The requested page
        /// </summary>
        int? Page { get; set; }

        /// <summary>
        ///     The requested page items count
        /// </summary>
        int? PerPage { get; set; }
    }
}