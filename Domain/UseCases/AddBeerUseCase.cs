using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Presenters.Interfaces;
using Domain.Requests;
using Domain.Responses;
using Domain.Services.Interfaces;
using Domain.UseCases.Interfaces;
using Domain.Validators;

namespace Domain.UseCases
{
    public class AddBeerUseCase : IAddBeerUseCase
    {
        private readonly IBeerCatalog _catalog;

        public AddBeerUseCase(IBeerCatalog catalog)
        {
            _catalog = catalog;
        }

        public void Execute(AddBeerRequest request, IAddBeerPresenter presenter)
        {
            var validator = new AddBeerValidator(_catalog);

            var validationResult = validator.Validate(request);

            var response = new AddBeerResponse();

            if (!validationResult.IsValid)
            {
                response.Data = null;
                response.Errors = validationResult.Errors
                    .Select(e => new KeyValuePair<string, string>(e.PropertyName, e.ErrorMessage))
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                var beer = _catalog.AddBeer(new BeerModel(
                    null,
                    null,
                    null,
                    request.Label,
                    request.Description,
                    request.Stock
                ));

                response.Data = beer;
                response.Errors = null;
            }

            presenter.Present(response);
        }
    }
}