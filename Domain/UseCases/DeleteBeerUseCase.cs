using Domain.Presenters.Interfaces;
using Domain.Requests;
using Domain.Responses;
using Domain.Services.Interfaces;
using Domain.UseCases.Interfaces;

namespace Domain.UseCases
{
    public class DeleteBeerUseCase : IDeleteBeerUseCase
    {
        private readonly IBeerCatalog _catalog;

        public DeleteBeerUseCase(IBeerCatalog catalog)
        {
            _catalog = catalog;
        }

        public void Execute(DeleteBeerRequest request, IDeleteBeerPresenter presenter)
        {
            _catalog.DeleteBeer(request.Id);

            var response = new DeleteBeerResponse();

            presenter.Present(response);
        }
    }
}