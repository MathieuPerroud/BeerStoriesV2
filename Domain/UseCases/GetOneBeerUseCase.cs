using Domain.Presenters.Interfaces;
using Domain.Requests;
using Domain.Responses;
using Domain.Services.Interfaces;
using Domain.UseCases.Interfaces;

namespace Domain.UseCases
{
    public class GetOneBeerUseCase : IGetOneBeerUseCase
    {
        private readonly IBeerCatalog _catalog;

        public GetOneBeerUseCase(IBeerCatalog catalog)
        {
            _catalog = catalog;
        }

        public void Execute(GetOneBeerRequest request, IGetOneBeerPresenter presenter)
        {
            var beer = _catalog.GetOneBeer(request.Id);

            var response = new GetOneBeerResponse
            {
                Data = beer
            };

            presenter.Present(response);
        }
    }
}