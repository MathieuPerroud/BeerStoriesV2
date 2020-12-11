using System.Linq;
using Application.ViewModels;
using Domain.Presenters.Interfaces;
using Domain.Responses;

namespace Application.Presenters
{
    public class ApiCheckBeersAvailabilityPresenter : ICheckBeersAvailabilityPresenter
    {
        public ApiCheckBeersAvailabilityViewModel ViewModel { get; private set; }

        public void Present(CheckBeersAvailabilityResponse response)
        {
            ViewModel = new ApiCheckBeersAvailabilityViewModel
            {
                HttpCode = response.Data.Values.Any(x => !x) ? 400 : 200,
                Success = response.Data.Values.All(x => x),
                Data = response.Data
            };
        }
    }
}