using Domain.Models;
using Domain.Responses.Abstract.Interfaces;

namespace Domain.Responses
{
    public class GetOneBeerResponse : ISpecificResourceReadResponse<BeerModel>
    {
        public BeerModel Data { get; set; }
    }
}