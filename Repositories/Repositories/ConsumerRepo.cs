using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface IConsumerRepo: IRepository<tblUser>
    {

    }
    public class ConsumerRepo :Repository<tblUser> , IConsumerRepo
    {
        public ConsumerRepo(DbContext context) : base(context)
        {
            
        }
    }
}