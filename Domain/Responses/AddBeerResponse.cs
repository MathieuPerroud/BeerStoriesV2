using System.Collections.Generic;
using Domain.Models;
using Domain.Responses.Abstract.Interfaces;

namespace Domain.Responses
{
    public class AddBeerResponse : ISpecificResourceWriteResponse<BeerModel>
    {
        public BeerModel Data { get; set; }

        public Dictionary<string, string> Errors { get; set; }
    }
}