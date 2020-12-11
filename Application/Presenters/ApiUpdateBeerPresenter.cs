using System.Linq;
using Application.ViewModels;
using Domain.Presenters.Interfaces;
using Domain.Responses;

namespace Application.Presenters
{
    public class ApiUpdateBeerPresenter : IUpdateBeerPresenter
    {
        public ApiUpdateBeerViewModel ViewModel { get; private set; }

        public void Present(UpdateBeerResponse response)
        {
            ViewModel = new ApiUpdateBeerViewModel
            {
                HttpCode = response.Errors != null && response.Errors.Any() ? 400 : 201,
                Success = response.Errors == null || !response.Errors.Any(),
                Data = response.Errors != null && response.Errors.Any()
                    ? null
                    : new
                    {
                        Id = response.Data.Id.Value,
                        Label = response.Data.Label.Value,
                        Description = response.Data.Description.Value,
                        Stock = response.Data.Stock.Value,
                        Available = response.Data.Stock.Value > 0,
                        LimitedStock = response.Data.Stock.Value <= 50
                    },
                Errors = response.Errors
            };
        }
    }
}