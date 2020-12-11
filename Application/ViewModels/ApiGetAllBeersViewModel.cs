using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ApiGetAllBeersViewModel
    {
        public int HttpCode { get; set; }

        public bool Success { get; set; }

        public IEnumerable<object> Data { get; set; }

        public int Page { get; set; }
        
        public int PerPage { get; set; }
        
        public int Total { get; set; }
    }
}