using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class Product
    {
        public int productId { get; set; }
        public String manufacturerName { get; set; }
        public String productName { get; set; }
        public String productImage { get; set; }
        public String Series { get; set; }
        public String Model { get; set; }
        public int modelYear { get; set; } 
        Dictionary<int, int> propertyValues { get; set; }

        public Product(int productId, String manufacturerName, String productName, String productImage, String Series, String Model, int modelYear, Dictionary<int, int> propertyValues)
        {
            this.productId = productId;
            this.manufacturerName = manufacturerName;
            this.productName = productName;
            this.productImage = productImage;
            this.Series = Series;
            this.Model = Model;
            this.modelYear = modelYear;
            this.propertyValues = propertyValues;

        }
    }
}