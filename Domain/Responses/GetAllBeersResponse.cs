using System.Collections.Generic;
using Domain.Models;
using Domain.Responses.Abstract.Interfaces;

namespace Domain.Responses
{
    public class GetAllBeersResponse : IPaginatedResponse<BeerModel>
    {
        public IEnumerable<BeerModel> Data { get; set; }

        public int Page { get; set; }

        public int PerPage { get; set; }

        public int Total { get; set; }
    }
}