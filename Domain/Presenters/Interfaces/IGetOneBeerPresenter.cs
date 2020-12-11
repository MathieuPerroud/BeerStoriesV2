using Domain.Responses;

namespace Domain.Presenters.Interfaces
{
    public interface IGetOneBeerPresenter
    {
        /// <summary>
        ///     Presents the GetOneBeer use case response
        /// </summary>
        /// <param name="response">The response to present</param>
        void Present(GetOneBeerResponse response);
    }
}