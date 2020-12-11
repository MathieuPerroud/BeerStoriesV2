using System;
using System.Linq;
using Domain.Models;
using Domain.Presenters.Interfaces;
using Domain.Requests;
using Domain.Responses;
using Domain.Services;
using Domain.Services.Interfaces;
using Domain.UseCases.Interfaces;

namespace Domain.UseCases
{
    public class GetAllBeersUseCase : IGetAllBeersUseCase
    {
        private readonly IBeerCatalog _catalog;

        public GetAllBeersUseCase(IBeerCatalog catalog)
        {
            _catalog = catalog;
        }

        public void Execute(GetAllBeersRequest request, IGetAllBeersPresenter presenter)
        {
            var beers = _catalog.GetAllBeers();

            FilterService<BeerModel>.ApplyPaginationFilter(ref beers, request.Page ?? 1, request.PerPage ?? 50);

            if (request.CreatedAt != null)
                FilterService<BeerModel>.ApplyDateFilters(ref beers, request.CreatedAt, nameof(BeerModel.CreatedAt));
            if (request.LastUpdate != null)
                FilterService<BeerModel>.ApplyDateFilters(ref beers, request.LastUpdate, nameof(BeerModel.LastUpdate));
            if (request.Label != null)
                FilterService<BeerModel>.ApplyStringFilters(ref beers, request.Label, nameof(BeerModel.Label));
            if (request.Description != null)
                FilterService<BeerModel>.ApplyStringFilters(ref beers, request.Description,
                    nameof(BeerModel.Description));
            if (request.Stock != null)
                FilterService<BeerModel>.ApplyNumberFilters(ref beers, request.Stock, nameof(BeerModel.Stock));
            if (request.Sorts != null)
                // FilterService<BeerModel>.ApplySortFilters(ref beers, request.Sorts);
                beers = beers;
            else
                beers = beers.OrderByDescending(b => b.CreatedAt.Value);

            var count = beers.Count();
            var data = beers.ToList();

            presenter.Present(new GetAllBeersResponse
            {
                Data = data,
                Page = request.Page ?? 1,
                PerPage = request.PerPage ?? 50,
                Total = count
            });
        }
    }
}