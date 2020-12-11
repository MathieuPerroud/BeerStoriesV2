using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ApiCheckBeersAvailabilityViewModel
    {
        public int HttpCode { get; set; }

        public bool Success { get; set; }

        public Dictionary<Guid, bool> Data { get; set; }
    }
}