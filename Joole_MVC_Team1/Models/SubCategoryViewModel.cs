using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_MVC_Team1.Models
{
    public class SubCategoryViewModel
    {
        public int category_Id { get; set; }
        public String name { get; set; }

        public SubCategoryViewModel()
        {

        }
        public SubCategoryViewModel(int category_Id, String name)
        {
            this.category_Id = category_Id;
            this.name = name;
        }
    }
}