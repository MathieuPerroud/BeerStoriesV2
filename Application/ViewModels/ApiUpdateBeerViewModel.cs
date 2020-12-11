using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ApiUpdateBeerViewModel
    {
        public int HttpCode { get; set; }

        public bool Success { get; set; }

        public object Data { get; set; }

        public Dictionary<string, string> Errors { get; set; }
    }
}