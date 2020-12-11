using System;
using System.Collections.Generic;

namespace Domain.Responses
{
    public class CheckBeersAvailabilityResponse
    {
        public Dictionary<Guid, bool> Data { get; set; }
    }
}