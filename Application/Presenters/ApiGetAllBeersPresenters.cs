using System.Linq;
using Application.ViewModels;
using Domain.Presenters.Interfaces;
using Domain.Responses;

namespace Application.Presenters
{
    public class ApiGetAllBeersPresenters : IGetAllBeersPresenter
    {
        public ApiGetAllBeersViewModel ViewModel { get; private set; }

        public void Present(GetAllBeersResponse response)
        {
            ViewModel = new ApiGetAllBeersViewModel
            {
                HttpCode = response.Data.Any() ? 200 : 204,
                Success = true,
                Data = response.Data.Select(x => new
                {
                    Id = x.Id.Value,
                    Label = x.Label.Value,
                    Description = x.Description.Value,
                    Stock = x.Stock.Value,
                    Available = x.Stock.Value > 0,
                    LimitedStock = x.Stock.Value <= 50
                }),
                Page = response.Page,
                PerPage = response.PerPage,
                Total = response.Total
            };
        }
    }
}