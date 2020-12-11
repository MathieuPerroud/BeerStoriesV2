using System.Collections.Generic;
using Domain.Models.Abstract;

namespace Domain.Responses.Abstract.Interfaces
{
    public interface ISpecificResourceWriteResponse<T> where T : AbstractModel
    {
        /// <summary>
        ///     The response data
        /// </summary>
        T Data { get; set; }

        /// <summary>
        ///     The response errors
        /// </summary>
        Dictionary<string, string> Errors { get; set; }
    }
}