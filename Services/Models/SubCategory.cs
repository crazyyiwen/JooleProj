using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class SubCategory
    {
        public int id { get; set; }
        public int categoryId { get; set; }

        public String name { get; set; }

        public SubCategory(int id, int? categoryId, String name)
        {
            this.id = id;
            this.categoryId = categoryId ?? default(int);
            this.name = name;
        }
    }
}