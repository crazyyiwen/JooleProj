/*
 * combine the tblProperty & tblPropertyValue & tblTechSpecFilter
 * together into one tbl 
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Repositories.Repositories
{
    public class GetProducts
    {
        // single value table
        public List<int> PropertyID1;
        public List<string> PropertyName1;
        public List<int> ProductID;
        public List<string> Value;
        // min and max value table
        public List<int> PropertyID2;
        public List<string> PropertyName2;
        public List<int> SubCategoryID;
        public List<string> MinValue;
        public List<string> MaxValue;

        public DataTable singletblreturn;
        public DataTable doubletblreturn;
        /************query string*****************/
        string sqlquery1 = "select Property_ID, Property_Name, Product_ID, Value from (select * from (select  Property_ID, Property_Name from tblProperty where IsType = 0) A inner join(select Property_ID as ID, Product_ID, Value from tblPropertyValue) B  on A.Property_ID = B.ID) C";

        string sqlquery2 = "select Property_ID, Property_Name, SubCategory_ID, Min_Value, Max_Value from (select * from (select  Property_ID, Property_Name from tblProperty where IsTechSpec = 1) AA inner join(select Property_ID as ID, SubCategory_ID, Min_Value, Max_Value from tblTechSpecFilter) BB on AA.Property_ID = BB.ID) CC";
        /************connection string**********/
        //string conn1 = "data source=DESKTOP-CEQSS3O\\SQLEXPRESS;initial catalog=joolecomplex;integrated security=True";
        string conn2 = "data source=192.168.1.5;initial catalog=joole_team1;user id=T_User;password=us1";
        /*****************************************/

        public GetProducts()
        {
            singletblreturn = new DataTable();
            doubletblreturn = new DataTable();

            // instantilization
            // single value table
            PropertyID1 = new List<int>();
            PropertyName1 = new List<string>();
            ProductID = new List<int>();
            Value = new List<string>();
            // min and max value table
            PropertyID2 = new List<int>();
            PropertyName2 = new List<string>();
            SubCategoryID = new List<int>();
            MinValue = new List<string>();
            MaxValue = new List<string>();

    }
        public void GetSingleValueFromJoinTable()
        {
            // configure connection
            SqlConnection sqlconn1 = new SqlConnection(conn2);
            sqlconn1.Open();
            // adapter bind to query and connection object
            SqlDataAdapter sqladapter = new SqlDataAdapter(sqlquery1, sqlconn1);
            sqladapter.Fill(singletblreturn);
            sqlconn1.Close();
            SingleValueIteration();
        }
        public void GetDoubleValueFromJoinTable()
        {
            // configure connection
            SqlConnection sqlconn2 = new SqlConnection(conn2);
            sqlconn2.Open();
            // adapter bind to query and connection object
            SqlDataAdapter sqladapter = new SqlDataAdapter(sqlquery2, sqlconn2);
            sqladapter.Fill(doubletblreturn);
            sqlconn2.Close();
            DoubleValueIteration();
        }
        // get the singkle value table
        public void SingleValueIteration()
        {
            foreach (DataRow row in singletblreturn.Rows)
            {
                PropertyID1.Add(Convert.ToInt32(row[0]));
                PropertyName1.Add(row[1].ToString());
                ProductID.Add(Convert.ToInt32(row[2].ToString()));
                Value.Add(row[3].ToString());
            }
        }
        // get the double value table
        public void DoubleValueIteration()
        {
            foreach (DataRow row in doubletblreturn.Rows)
            {
                PropertyID2.Add(Convert.ToInt32(row["Property_ID"]));
                PropertyName2.Add(row["Property_Name"].ToString());
                SubCategoryID.Add(Convert.ToInt32(row["SubCategory_ID"]));
                MinValue.Add(row["Min_Value"].ToString());
                MaxValue.Add(row["Max_Value"].ToString());
            }
        }
    }
}