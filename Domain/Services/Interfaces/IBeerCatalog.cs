using System;
using System.Linq;
using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IBeerCatalog
    {
        /// <summary>
        ///     Returns a query searching through all the catalog beers
        /// </summary>
        /// <returns>The query</returns>
        IQueryable<BeerModel> GetAllBeers();

        /// <summary>
        ///     Returns a beer from the catalog
        /// </summary>
        /// <param name="id">The beer id</param>
        /// <returns>The beer</returns>
        BeerModel GetOneBeer(Guid id);

        /// <summary>
        ///     Adds a new beer in the catalog
        /// </summary>
        /// <param name="beer">The beer to add</param>
        /// <returns>The added beer</returns>
        BeerModel AddBeer(BeerModel beer);

        /// <summary>
        ///     Updates a beer in the catalog
        /// </summary>
        /// <param name="beer">The beer to update</param>
        /// <returns>The updated beer</returns>
        BeerModel UpdateBeer(BeerModel beer);

        /// <summary>
        ///     Removes a beer from the catalog
        /// </summary>
        /// <param name="id">The beer id</param>
        void DeleteBeer(Guid id);
    }
}