using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchSample.Models
{
    public class SearchResults
    {
        public string ResultCount { get; set; }

        public IEnumerable<Result> Results { get; set; }

    }
}
