using Domain.Presenters.Interfaces;
using Domain.Requests;

namespace Domain.UseCases.Interfaces
{
    public interface ICheckBeersAvailabilityUseCase
    {
        /// <summary>
        ///     Executes the CheckBeersAvailability use case request
        /// </summary>
        /// <param name="request">The request to execute</param>
        /// <param name="presenter">The response presenter</param>
        void Execute(CheckBeersAvailabilityRequest request, ICheckBeersAvailabilityPresenter presenter);
    }
}