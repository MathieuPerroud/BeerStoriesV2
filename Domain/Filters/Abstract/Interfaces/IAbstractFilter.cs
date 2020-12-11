using System;
using System.Collections.Generic;
using Domain.FilterOperators;

namespace Domain.Filters.Abstract.Interfaces
{
    public interface IAbstractFilter
    {
        /// <summary>
        ///     The created at datetime filter
        /// </summary>
        Dictionary<DateFilterOperator, DateTime> CreatedAt { get; set; }

        /// <summary>
        ///     The last update datetime filter
        /// </summary>
        Dictionary<DateFilterOperator, DateTime> LastUpdate { get; set; }
    }
}