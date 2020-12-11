using Domain.Presenters.Interfaces;
using Domain.Requests;

namespace Domain.UseCases.Interfaces
{
    public interface IBuyBeersUseCase
    {
        /// <summary>
        ///     Executes the BuyBeers use case request
        /// </summary>
        /// <param name="request">The request to execute</param>
        /// <param name="presenter">The response presenter</param>
        void Execute(BuyBeersRequest request, IBuyBeersPresenter presenter);
    }
}