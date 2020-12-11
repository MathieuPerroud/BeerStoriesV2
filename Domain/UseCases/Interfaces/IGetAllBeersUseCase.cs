using Domain.Presenters.Interfaces;
using Domain.Requests;

namespace Domain.UseCases.Interfaces
{
    public interface IGetAllBeersUseCase
    {
        /// <summary>
        ///     Executes the GetAllBeers use case request
        /// </summary>
        /// <param name="request">The request to execute</param>
        /// <param name="presenter">The response presenter</param>
        void Execute(GetAllBeersRequest request, IGetAllBeersPresenter presenter);
    }
}