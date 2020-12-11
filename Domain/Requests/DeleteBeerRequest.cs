using System;
using Domain.Requests.Abstract.Interfaces;

namespace Domain.Requests
{
    public class DeleteBeerRequest : ISpecificResourceRequest
    {
        public Guid Id { get; set; }
    }
}