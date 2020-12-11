using Domain.Responses;

namespace Domain.Presenters.Interfaces
{
    public interface IBuyBeersPresenter
    {
        /// <summary>
        ///     Presents the BuyBeers use case response
        /// </summary>
        /// <param name="response">The response to present</param>
        void Present(BuyBeersResponse response);
    }
}