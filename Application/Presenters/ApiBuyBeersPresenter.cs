using System.Linq;
using Application.ViewModels;
using Domain.Presenters.Interfaces;
using Domain.Responses;

namespace Application.Presenters
{
    public class ApiBuyBeersPresenter : IBuyBeersPresenter
    {
        public ApiBuyBeersViewModel ViewModel { get; private set; }

        public void Present(BuyBeersResponse response)
        {
            ViewModel = new ApiBuyBeersViewModel
            {
                HttpCode = response.Data.Values.Any(x => !x) ? 400 : 200,
                Success = response.Data.Values.All(x => x),
                Data = response.Data,
                Errors = response.Errors
            };
        }
    }
}