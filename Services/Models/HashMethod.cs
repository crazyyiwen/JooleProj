using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Services.Models
{
    public class HashMethod
    {
        public HashMethod()
        {

        }
        //Return the boolean value
       
        public bool VerifyMd5Hash(byte[] input, byte[] pddata)
        {
            // compare the pd
            for (int i=0; i<input.Length; i++)
            {
                if(input[i] == pddata[i])
                {
                    ;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}