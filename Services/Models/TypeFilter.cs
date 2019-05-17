using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class TypeFilter
    {
        public int propertyId { get; set; }
        public int subCategoryId { get; set; }
        public String typeName { get; set; }
        public String value { get; set; } 
        public List<String> typeOptions { get; set; }

        public TypeFilter()
        {

        }

        public TypeFilter(int propertyId, int subCategoryId, String typeName, String value, List<String> typeOptions)
        {
            this.propertyId = propertyId;
            this.subCategoryId = subCategoryId;
            this.typeName = typeName;
            this.value = value;
            this.typeOptions = typeOptions;
        }
    }
}