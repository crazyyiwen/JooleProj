using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_MVC_Team1.Models
{
    public class ProductCmpViewModel
    {
        public ProductCmpViewModel(int id1, int id2)
        {
            pvm1 = new ProductViewModel(id1);
            pvm2 = new ProductViewModel(id2);
            pvm3 = null;
        }

        public ProductCmpViewModel(int id1, int id2, int id3)
        {
            pvm1 = new ProductViewModel(id1);
            pvm2 = new ProductViewModel(id2);
            pvm3 = new ProductViewModel(id3);
        }

        public ProductViewModel pvm1 { get; set; }
        public ProductViewModel pvm2 { get; set; }
        public ProductViewModel pvm3 { get; set; }
    }
}