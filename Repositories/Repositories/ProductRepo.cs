using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{

    public interface IProductRepo : IRepository<tblProduct>
    {

    }
    public class ProductRepo : Repository<tblProduct>, IProductRepo
    {
        public ProductRepo(DbContext context):base(context)
        {

        }
    }
}