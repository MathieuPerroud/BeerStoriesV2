using System;
using System.Collections.Generic;

namespace Domain.Responses
{
    public class BuyBeersResponse
    {
        public Dictionary<Guid, bool> Data { get; set; }

        public Dictionary<Guid, string> Errors { get; set; }
    }
}