using Domain.Presenters.Interfaces;
using Domain.Requests;

namespace Domain.UseCases.Interfaces
{
    public interface IAddBeerUseCase
    {
        /// <summary>
        ///     Executes the AddBeer use case request
        /// </summary>
        /// <param name="request">The request to execute</param>
        /// <param name="presenter">The response presenter</param>
        void Execute(AddBeerRequest request, IAddBeerPresenter presenter);
    }
}