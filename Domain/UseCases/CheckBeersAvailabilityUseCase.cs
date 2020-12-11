using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Presenters.Interfaces;
using Domain.Requests;
using Domain.Responses;
using Domain.Services.Interfaces;
using Domain.UseCases.Interfaces;

namespace Domain.UseCases
{
    public class CheckBeersAvailabilityUseCase : ICheckBeersAvailabilityUseCase
    {
        private readonly IBeerCatalog _catalog;

        public CheckBeersAvailabilityUseCase(IBeerCatalog catalog)
        {
            _catalog = catalog;
        }

        public void Execute(CheckBeersAvailabilityRequest request, ICheckBeersAvailabilityPresenter presenter)
        {
            var ids = request.Beers.Keys;

            var catalogBeersStock = _catalog
                .GetAllBeers()
                .Where(x => ids.Contains(x.Id.Value))
                .Select(x => new {BeerId = x.Id.Value, BeerStock = x.Stock.Value});

            var response = new CheckBeersAvailabilityResponse
            {
                Data = new Dictionary<Guid, bool>()
            };

            request.Beers.ToList().ForEach(x =>
            {
                response.Data.Add(x.Key, catalogBeersStock.Any(cbs =>
                    cbs.BeerId.Equals(x.Key) && cbs.BeerStock >= x.Value)
                );
            });

            presenter.Present(response);
        }
    }
}