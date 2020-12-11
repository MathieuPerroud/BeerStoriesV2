using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ApiBuyBeersViewModel
    {
        public int HttpCode { get; set; }

        public bool Success { get; set; }

        public Dictionary<Guid, bool> Data { get; set; }

        public Dictionary<Guid, string> Errors { get; set; }
    }
}