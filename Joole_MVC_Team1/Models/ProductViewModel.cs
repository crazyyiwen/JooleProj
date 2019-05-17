using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Services;
using System.ComponentModel.DataAnnotations;

namespace Joole_MVC_Team1.Models
{
    public class ProductViewModel
    {

        public ProductViewModel(int id)
        {
            Service s = new Service();
            tblProduct product = s.getProductService(id);
            /*
            pvList = s.GetTblPropertyValueByProductID(id);

            
            techSpecList = init_TechSpecList();

    */
            techSpecList = init_TechSpecList();
            productID = Int32.Parse(product.Product_ID.ToString());
            Manufacture = s.GetManufNameByID(Int32.Parse( product.Manufacturer_ID.ToString()));
            Series = product.Series.ToString();
            Model = product.Model.ToString();
            UseType = "Commercial";
            Application = "Indoor";
            MountingLoaction = "";
            Accessories = "With Lignt";
            ModelYear = product.Model_Year.Year.ToString();
        }

        [Key]
        public int productID { get; set; }

        public string Manufacture { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }

        public string UseType { get; set; }

        public string Application { get; set; }
        public string MountingLoaction { get; set; }
        public string Accessories { get; set; }

        public string ModelYear { get; set; }

        public List<tblPropertyValue> pvList { get; set; }

        public List<TechSpecViewModel> techSpecList { get; set; }

        private List<TechSpecViewModel> init_TechSpecList()
        {
            List < TechSpecViewModel > res = new List<TechSpecViewModel>();
            
            return res;
        }

    }
}