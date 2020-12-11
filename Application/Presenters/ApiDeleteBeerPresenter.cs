using Application.ViewModels;
using Domain.Presenters.Interfaces;
using Domain.Responses;

namespace Application.Presenters
{
    public class ApiDeleteBeerPresenter : IDeleteBeerPresenter
    {
        public ApiDeleteBeerViewModel ViewModel { get; private set; }

        public void Present(DeleteBeerResponse response)
        {
            ViewModel = new ApiDeleteBeerViewModel();
        }
    }
}