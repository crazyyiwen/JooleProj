/*
 * Yiwen Zhao 
 *  5/6/2019
 *  UserLoginController.cs
 *  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using DAL.Models;
using Repositories;
using Services;

namespace Services.Models
{

    public class LoginService
    {      
        
        public Tuple<bool, bool> LoginServices(string SUsername, string SPasswd)
        {
            // return value should be a int so that filter the conditions
            Tuple<bool, bool> returntuple = new Tuple<bool, bool>(false, false);
            bool returnvalue1 = false;
            bool returnvalue2 = false;
            Service service = new Service();
            HashMethod hashmethod = new HashMethod();
            MD5 md5Hash = MD5.Create();
            byte[] Ihashpddata = md5Hash.ComputeHash(Encoding.UTF32.GetBytes(SPasswd));

            foreach (tblUser LoginInfo in service.uow.consumer.GetAll().ToList())
            {
                // need to check !!!
                if (string.Equals(SUsername, LoginInfo.User_Name) || string.Equals(SUsername, LoginInfo.User_Email))
                {
                    returnvalue1 = true; 
                    returnvalue2 = hashmethod.VerifyMd5Hash(Ihashpddata, LoginInfo.User_Password);
                    returntuple = Tuple.Create(returnvalue1, returnvalue2);
                    if (returnvalue2)
                    {
                        // user exists
                        returntuple = Tuple.Create(returnvalue1, returnvalue2);
                        return returntuple;
                    }
                    else
                    {
                        if (LoginInfo != null)
                        {
                            //not foreach end continue 
                            ;
                        }
                        else
                        {
                            // pd not correct
                            returntuple = Tuple.Create(returnvalue1, returnvalue2);
                            return returntuple;
                        }
                    }
                }
            }
            // user not exists
            return returntuple;
        }
        
    }
}
