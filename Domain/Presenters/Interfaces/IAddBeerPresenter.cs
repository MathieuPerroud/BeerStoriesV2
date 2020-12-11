using Domain.Responses;

namespace Domain.Presenters.Interfaces
{
    public interface IAddBeerPresenter
    {
        /// <summary>
        ///     Presents the AddBeer use case response
        /// </summary>
        /// <param name="response">The response to present</param>
        void Present(AddBeerResponse response);
    }
}