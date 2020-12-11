using System;
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
    public class UpdateBeerUseCase : IUpdateBeerUseCase
    {
        private readonly IBeerCatalog _catalog;

        public UpdateBeerUseCase(IBeerCatalog catalog)
        {
            _catalog = catalog;
        }

        public void Execute(UpdateBeerRequest request, IUpdateBeerPresenter presenter)
        {
            var response = new UpdateBeerResponse();

            var validator = new UpdateBeerValidator(_catalog);

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                response.Data = null;
                response.Errors = validationResult.Errors
                    .Select(e => new KeyValuePair<string, string>(e.PropertyName, e.ErrorMessage))
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                var beer = _catalog.GetOneBeer(request.Id);

                var toUpdate = new BeerModel(
                    beer.Id.Value,
                    beer.CreatedAt.Value,
                    DateTime.Now,
                    request.Label,
                    request.Description,
                    request.Stock
                );

                var updated = _catalog.UpdateBeer(toUpdate);

                response.Data = updated;
                response.Errors = null;
            }

            presenter.Present(response);
        }
    }
}