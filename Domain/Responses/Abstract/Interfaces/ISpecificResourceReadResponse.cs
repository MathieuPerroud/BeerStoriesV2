using Domain.Models.Abstract;

namespace Domain.Responses.Abstract.Interfaces
{
    public interface ISpecificResourceReadResponse<T> where T : AbstractModel
    {
        /// <summary>
        ///     The response data
        /// </summary>
        T Data { get; set; }
    }
}