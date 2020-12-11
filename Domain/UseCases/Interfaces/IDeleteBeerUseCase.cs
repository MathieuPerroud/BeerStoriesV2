using Domain.Presenters.Interfaces;
using Domain.Requests;

namespace Domain.UseCases.Interfaces
{
    public interface IDeleteBeerUseCase
    {
        /// <summary>
        ///     Executes the DeleteBeer use case request
        /// </summary>
        /// <param name="request">The request to execute</param>
        /// <param name="presenter">The response presenter</param>
        void Execute(DeleteBeerRequest request, IDeleteBeerPresenter presenter);
    }
}