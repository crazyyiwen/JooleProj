using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Services;

namespace Services.Models
{
    public class InsertDataToDatabase
    {
        private byte[] iimage;
        private string username;
        private string emailaddress;
        private string password;
        private string cpassword;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string EmailAddress
        {
            get { return emailaddress; }
            set { emailaddress = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string CPassword
        {
            get { return cpassword; }
            set { cpassword = value; }
        }
        public byte[] Image
        {
            get { return iimage; }
            set { iimage = value; }
        }
        public InsertDataToDatabase()
        {

        }
        public InsertDataToDatabase(HttpPostedFileBase image, string un, string ea, string pw)
        {
            iimage = ConvertToByte(image);
            username = un;
            emailaddress = ea;
            password = pw;
        }
        public byte[] ConvertToByte(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }
        public void InsertAction()
        {
            /**/
            MD5 md5Hash = MD5.Create();
            byte[] hashpddata = md5Hash.ComputeHash(Encoding.UTF32.GetBytes(password));
            // use the repository layer service
            string insertQuery = @"Insert Into [tblUser] (User_ID, User_Name, User_Email, User_Image, User_Password) Values (@User_ID, @username, @emailaddress, @image, @BinData)";
            string getpdQuery = @"select top 1 User_ID from tblUser order by User_ID desc";
            // configure connection
            SqlConnection connection = new SqlConnection(@"data source=192.168.1.5;initial catalog=joole_team1;user id=T_User;password=us1");
            // getpd from database
            SqlCommand getpdCommand = new SqlCommand(getpdQuery, connection);
            connection.Open();
            getpdCommand.ExecuteNonQuery();
            int userID = Convert.ToInt16(getpdCommand.ExecuteScalar());
            userID++;
            connection.Close();
            // insert sign up information
            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@User_ID", userID);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@emailaddress", emailaddress);
            insertCommand.Parameters.AddWithValue("@image", iimage);
            insertCommand.Parameters.AddWithValue("@BinData", hashpddata);
            connection.Open();
            int a = insertCommand.ExecuteNonQuery();
            connection.Close();
            /**/

        }
    }
}