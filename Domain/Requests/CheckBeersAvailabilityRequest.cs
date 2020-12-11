using System;
using System.Collections.Generic;

namespace Domain.Requests
{
    public class CheckBeersAvailabilityRequest
    {
        public Dictionary<Guid, int> Beers { get; set; }
    }
}