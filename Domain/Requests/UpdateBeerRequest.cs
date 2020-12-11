using System;
using Domain.Requests.Abstract.Interfaces;

namespace Domain.Requests
{
    public class UpdateBeerRequest : ISpecificResourceRequest
    {
        public string Label { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }
        public Guid Id { get; set; }
    }
}