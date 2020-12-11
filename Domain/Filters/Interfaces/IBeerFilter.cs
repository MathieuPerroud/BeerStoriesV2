using System.Collections.Generic;
using Domain.FilterOperators;
using Domain.Filters.Abstract.Interfaces;

namespace Domain.Filters.Interfaces
{
    public interface IBeerFilter : IAbstractFilter
    {
        /// <summary>
        ///     The label string filter
        /// </summary>
        Dictionary<StringFilterOperator, string> Label { get; set; }

        /// <summary>
        ///     The description string filter
        /// </summary>
        Dictionary<StringFilterOperator, string> Description { get; set; }

        /// <summary>
        ///     The stock integer filter
        /// </summary>
        Dictionary<NumberFilterOperator, int> Stock { get; set; }
    }
}