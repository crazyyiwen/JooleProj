using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class SearchViewModel
    {
        public int subCategoryId { get; set; }
        public int yearMin { get; set; }
        public int yearMax { get; set; }
        public List<SpecFilter> specFilters { get; set; }
        public List<TypeFilter> typeFilters { get; set; }

        public SearchViewModel()
        {

        }

        public SearchViewModel(int subCategoryId, int yearMin, int yearMax, List<SpecFilter> specFilters, List<TypeFilter> typeFilters)
        {
            this.subCategoryId = subCategoryId;
            this.yearMin = yearMin;
            this.yearMax = yearMax;
            this.specFilters = specFilters;
            this.typeFilters = typeFilters;
        }

    }
}