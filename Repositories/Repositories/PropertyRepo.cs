using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface IPropertyRepo : IRepository<tblProperty>
    {

    }
    public class PropertyRepo : Repository<tblProperty>, IPropertyRepo
    {
        public PropertyRepo(DbContext context) : base(context)
        {

        }
    }
}