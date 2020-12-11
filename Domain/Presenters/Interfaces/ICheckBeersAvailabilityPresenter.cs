using Domain.Responses;

namespace Domain.Presenters.Interfaces
{
    public interface ICheckBeersAvailabilityPresenter
    {
        /// <summary>
        ///     Presents the CheckBeersAvailability use case response
        /// </summary>
        /// <param name="response">The response to present</param>
        void Present(CheckBeersAvailabilityResponse response);
    }
}