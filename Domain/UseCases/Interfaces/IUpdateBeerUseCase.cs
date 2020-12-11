using Domain.Presenters.Interfaces;
using Domain.Requests;

namespace Domain.UseCases.Interfaces
{
    public interface IUpdateBeerUseCase
    {
        /// <summary>
        ///     Executes the UpdateBeer use case request
        /// </summary>
        /// <param name="request">The request to execute</param>
        /// <param name="presenter">The response presenter</param>
        void Execute(UpdateBeerRequest request, IUpdateBeerPresenter presenter);
    }
}