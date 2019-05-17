using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Repositories;

namespace Services
{
   
    public partial class Service
    {

        public static readonly joole_team1Entities context = new joole_team1Entities();
        public UnitOfWork uow = new UnitOfWork(context);

        public Service()
        {
            
        }

        public void test()
        {
            //print data from repo layer
        }
        //methods for service need 
        //e.g. UsrLogin();
    }
}
    