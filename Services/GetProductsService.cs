using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Repositories.Repositories;

namespace Services
{
    public class GetProductsService
    {
        GetProducts getproducts;
        List<int> spropertyidposition;
        List<int> dpropertyidposition;
        List<DataRow> singlevaluedata;
        List<DataRow> doublevaluedata;
        public GetProductsService()
        {
            getproducts = new GetProducts();
            getproducts.GetSingleValueFromJoinTable();
            getproducts.GetDoubleValueFromJoinTable();
            spropertyidposition = new List<int>();
            dpropertyidposition = new List<int>();
            singlevaluedata = new List<DataRow>();
            doublevaluedata = new List<DataRow>();
        }
        /*********************Single value search***********************************/
        public void PropertyIDSearch(int propertyid)
        {
            for (int i=0; i<getproducts.PropertyID1.Count; i++)
            {
                if (propertyid == getproducts.PropertyID1[i])
                {
                    spropertyidposition.Add(i);
                }
                else
                {
                    ;
                }
            }
            if (spropertyidposition.Count == 0)
            {
                throw new System.ArgumentException("PropertyID does not exist !");
            }
        }
        public int ProductIDSearch(int productid)
        {
            int returnvalue = 0;
            for (int i=0; i<spropertyidposition.Count; i++){
                if(productid == getproducts.ProductID[spropertyidposition[i]])
                {
                    returnvalue = spropertyidposition[i];
                }
                else
                {
                    ;
                }
            }
            if(returnvalue == 0)
            {
                throw new System.ArgumentException("ProductID does not exist !");
            }
            return returnvalue;
        }
        /****************************************************************************/

        /************************Double value search*******************************/
        public void SubPropertyIDSearch(int propertyid)
        {
            for (int i = 0; i < getproducts.PropertyID2.Count; i++)
            {
                if (propertyid == getproducts.PropertyID2[i])
                {
                    dpropertyidposition.Add(i);
                }
                else
                {
                    ;
                }
            }
            if (dpropertyidposition.Count == 0)
            {
                throw new System.ArgumentException("PropertyID does not exist !");
            }
        }
        public int SubCategoryIDSearch(int subcategoryid)
        {
            // set returnvalue == 10 so that determine if it has the proper value
            int returnvalue = 10;
            for (int i = 0; i < dpropertyidposition.Count; i++)
            {
                if (subcategoryid == getproducts.SubCategoryID[dpropertyidposition[i]])
                {
                    returnvalue = dpropertyidposition[i];
                }
                else
                {
                    ;
                }
            }
            // returnvalue can not compare to 0 !!!!!! so use 10 instead
            if (returnvalue == 10)
            {
                throw new System.ArgumentException("ProductID does not exist !");
            }
            return returnvalue;
        }
        /****************************************************************************/
        // return single value and double value
        public ArrayList ReturnSingleData(int propertyid, int productid)
        {
            ArrayList datas = new ArrayList();
            PropertyIDSearch(propertyid);
            int position = ProductIDSearch(productid);
            datas.Add(getproducts.PropertyID1[position]);
            datas.Add(getproducts.PropertyName1[position]);
            datas.Add(getproducts.ProductID[position]);
            datas.Add(getproducts.Value[position]);
            return datas;
        }
        public ArrayList ReturnDoubleData(int propertyid, int subcategoryid)
        {
            ArrayList datad = new ArrayList();
            SubPropertyIDSearch(propertyid);
            int position = SubCategoryIDSearch(subcategoryid);
            datad.Add(getproducts.PropertyID2[position]);
            datad.Add(getproducts.PropertyName2[position]);
            datad.Add(getproducts.SubCategoryID[position]);
            datad.Add(getproducts.MinValue[position]);
            datad.Add(getproducts.MaxValue[position]);
            return datad;
        }
        /************Single based on ProductID to search all PropertyID**********/
        public void ProductIDToAllPropertyID(int productid)
        {
            foreach (DataRow row in getproducts.singletblreturn.Rows)
            {
                if(Convert.ToInt32(row[2].ToString()) == productid)
                {
                    singlevaluedata.Add(row);
                }
            }
        }
        /************Single based on ProductID to search all PropertyID**********/
        public void SubCategoryIDToAllPropertyID(int subcategoryid)
        {
            foreach (DataRow row in getproducts.doubletblreturn.Rows)
            {
                if (Convert.ToInt32(row["SubCategory_ID"]) == subcategoryid)
                {
                    doublevaluedata.Add(row);
                }
            }
        }
    }
}