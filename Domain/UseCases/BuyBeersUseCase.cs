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
    public class BuyBeersUseCase : IBuyBeersUseCase
    {
        private readonly IBeerCatalog _catalog;

        public BuyBeersUseCase(IBeerCatalog catalog)
        {
            _catalog = catalog;
        }

        public void Execute(BuyBeersRequest request, IBuyBeersPresenter presenter)
        {
            var ids = request.Beers.Keys;

            var catalogBeersStock = _catalog
                .GetAllBeers()
                .Where(x => ids.Contains(x.Id.Value))
                .Select(x => new {BeerId = x.Id.Value, BeerStock = x.Stock.Value});

            var response = new BuyBeersResponse
            {
                Data = new Dictionary<Guid, bool>(),
                Errors = new Dictionary<Guid, string>()
            };


            request.Beers.ToList().ForEach(x =>
            {
                var (key, value) = x;
                var founded = catalogBeersStock.Any(cbs => cbs.BeerId.Equals(key));
                var available = founded && catalogBeersStock.Any(cbs => cbs.BeerStock >= value);

                if (!founded)
                {
                    response.Errors.Add(key, "Unknown Beer.");
                    response.Data.Add(key, false);
                }
                else if (!available)
                {
                    response.Errors.Add(key, "Not enough stock.");
                    response.Data.Add(key, false);
                }
                else
                {
                    response.Data.Add(key, true);
                }
            });

            if (response.Errors.Any())
                response.Data = null;
            else
                request.Beers.ToList().ForEach(x =>
                {
                    var (key, value) = x;

                    var beer = _catalog.GetOneBeer(key);

                    beer.DecreaseStock(value);

                    _catalog.UpdateBeer(beer);
                });

            presenter.Present(response);
        }
    }
}