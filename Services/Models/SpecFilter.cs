using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class SpecFilter
    {
        public int propertyId { get; set; }
        public int subCategoryId { get; set; }
        public String propertyName { get; set; }
        public int min { get; set; }
        public int max { get; set; }

        public SpecFilter()
        {

        }
        public SpecFilter(int propertyId, int subCategoryId, String propertyName, int? min, int? max)
        {
            this.propertyId = propertyId;
            this.subCategoryId = subCategoryId;
            this.propertyName = propertyName;
            this.min = min ?? default(int);
            this.max = max ?? default(int);
        }
    }
}