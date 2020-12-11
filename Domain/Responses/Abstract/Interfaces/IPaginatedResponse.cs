using System.Collections.Generic;
using Domain.Models.Abstract;

namespace Domain.Responses.Abstract.Interfaces
{
    public interface IPaginatedResponse<T> where T : AbstractModel
    {
        /// <summary>
        ///     The response data
        /// </summary>
        IEnumerable<T> Data { get; set; }

        /// <summary>
        ///     The current page
        /// </summary>
        int Page { get; set; }

        /// <summary>
        ///     The current page items count
        /// </summary>
        int PerPage { get; set; }

        /// <summary>
        ///     The total items count
        /// </summary>
        int Total { get; set; }
    }
}