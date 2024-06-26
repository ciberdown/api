using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.Helpers
{
    public abstract class BaseQueryObj
    {
        public int? SkipCount { get; set; }
        public int? MaxResultCount { get; set; }
        public string? Sort { get; set; }
    }
}