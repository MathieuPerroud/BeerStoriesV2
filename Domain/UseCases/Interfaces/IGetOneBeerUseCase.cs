using Domain.Presenters.Interfaces;
using Domain.Requests;

namespace Domain.UseCases.Interfaces
{
    public interface IGetOneBeerUseCase
    {
        /// <summary>
        ///     Executes the GetOneBeer use case request
        /// </summary>
        /// <param name="request">The request to execute</param>
        /// <param name="presenter">The response presenter</param>
        void Execute(GetOneBeerRequest request, IGetOneBeerPresenter presenter);
    }
}