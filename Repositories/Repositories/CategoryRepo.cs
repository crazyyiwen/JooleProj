using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface ICategoryRepo : IRepository<tblCategory>
    {

    }

    public class CategoryRepo : Repository<tblCategory>, ICategoryRepo
    {
        public CategoryRepo(DbContext context) : base(context)
        {

        }
    }
}