using System;
using System.Collections.Generic;

namespace Domain.Requests
{
    public class BuyBeersRequest
    {
        public Dictionary<Guid, int> Beers { get; set; }
    }
}