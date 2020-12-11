using Domain.Responses;

namespace Domain.Presenters.Interfaces
{
    public interface IUpdateBeerPresenter
    {
        /// <summary>
        ///     Presents the UpdateBeer use case response
        /// </summary>
        /// <param name="response">The response to present</param>
        void Present(UpdateBeerResponse response);
    }
}