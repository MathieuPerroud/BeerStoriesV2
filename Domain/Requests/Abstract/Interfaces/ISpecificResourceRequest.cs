using System;

namespace Domain.Requests.Abstract.Interfaces
{
    public interface ISpecificResourceRequest
    {
        /// <summary>
        ///     The requested resource id
        /// </summary>
        Guid Id { get; set; }
    }
}