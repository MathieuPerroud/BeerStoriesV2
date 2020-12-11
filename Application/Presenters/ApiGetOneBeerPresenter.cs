using Application.ViewModels;
using Domain.Presenters.Interfaces;
using Domain.Responses;

namespace Application.Presenters
{
    public class ApiGetOneBeerPresenter : IGetOneBeerPresenter
    {
        public ApiGetOneBeerViewModel ViewModel { get; private set; }

        public void Present(GetOneBeerResponse response)
        {
            ViewModel = new ApiGetOneBeerViewModel
            {
                HttpCode = response.Data == null ? 404 : 200,
                Success = response.Data != null,
                Data = response.Data == null
                    ? null
                    : new
                    {
                        Id = response.Data.Id.Value,
                        Label = response.Data.Label.Value,
                        Description = response.Data.Description.Value,
                        Stock = response.Data.Stock.Value,
                        Available = response.Data.Stock.Value > 0,
                        LimitedStock = response.Data.Stock.Value <= 50
                    }
            };
        }
    }
}