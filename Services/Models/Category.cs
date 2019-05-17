using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class Category
    {
        public int id { get; set; }
        public String name { get; set; }

        public Category(int id, String name)
        {
            this.id = id;
            this.name = name;
        }
    }
}