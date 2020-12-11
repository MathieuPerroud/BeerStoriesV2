using System;
using System.Collections.Generic;
using Domain.FilterOperators;
using Domain.Filters.Interfaces;
using Domain.Requests.Abstract.Interfaces;

namespace Domain.Requests
{
    public class GetAllBeersRequest : IPaginatedRequest, IBeerFilter
    {
        public Dictionary<DateFilterOperator, DateTime> CreatedAt { get; set; }

        public Dictionary<DateFilterOperator, DateTime> LastUpdate { get; set; }

        public Dictionary<StringFilterOperator, string> Label { get; set; }

        public Dictionary<StringFilterOperator, string> Description { get; set; }

        public Dictionary<NumberFilterOperator, int> Stock { get; set; }
        
        public Dictionary<string, SortFilterOperator> Sorts { get; set; }
        
        public int? Page { get; set; }

        public int? PerPage { get; set; }
    }
}