using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Repositories.Repositories;

namespace Services
{
    public partial class Service
    {

        public tblProduct getProductService(int id)
        {
            tblProduct product =  uow.product.GetByID(id);

            return product;

        }

        public string GetManufNameByID(int id)
        {
            return uow.manufacture.GetByID(id).Manufacturer_Name.ToString();
        }

        public List<tblPropertyValue> GetTblPropertyValueByProductID(int id)
        {
            List<tblPropertyValue> res = new List<tblPropertyValue>();
            List<tblPropertyValue> temp = uow.propertyvalue.GetAll().ToList<tblPropertyValue>();

            foreach (tblPropertyValue pv in temp)
            {
                if(Int32.Parse(pv.Product_ID.ToString()) == id)
                {
                    res.Add(pv);
                }
            }
            return res;
        }
        public List<tblProperty> GetTblPropertiesByPropID(int id)
        {
            List<tblProperty> res = new List<tblProperty>();
            List<tblProperty> temp = uow.property.GetAll().ToList<tblProperty>();

            foreach (tblProperty p in temp)
            {
                if (p.Property_ID == id)
                {
                    res.Add(p);
                }
            }

            return res;

        }
    }
}