using Domain.Responses;

namespace Domain.Presenters.Interfaces
{
    public interface IGetAllBeersPresenter
    {
        /// <summary>
        ///     Presents the GetAllBeers use case response
        /// </summary>
        /// <param name="response">The response to present</param>
        void Present(GetAllBeersResponse response);
    }
}