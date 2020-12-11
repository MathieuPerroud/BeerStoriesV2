using Domain.Responses;

namespace Domain.Presenters.Interfaces
{
    public interface IDeleteBeerPresenter
    {
        /// <summary>
        ///     Presents the DeleteBeer use case response
        /// </summary>
        /// <param name="response">The response to present</param>
        void Present(DeleteBeerResponse response);
    }
}