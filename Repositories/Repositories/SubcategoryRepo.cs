using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface ISubCategoryRepo : IRepository<tblSubCategory>
    {

    }

    public class SubCategoryRepo : Repository<tblSubCategory>, ISubCategoryRepo
    {
        public SubCategoryRepo(DbContext context) : base(context)
        {

        }
    }
}