using System;
using Domain.Requests.Abstract.Interfaces;

namespace Domain.Requests
{
    public class GetOneBeerRequest : ISpecificResourceRequest
    {
        public Guid Id { get; set; }
    }
}