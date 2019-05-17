using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repositories.Repositories
{
    public interface ITypeFilterRepo : IRepository<tblTypeFilter>
    {

    }

    public class TypeFilterRepo : Repository<tblTypeFilter>, ITypeFilterRepo

    {
        public TypeFilterRepo(DbContext context) : base(context)
        {

        }
    }
}