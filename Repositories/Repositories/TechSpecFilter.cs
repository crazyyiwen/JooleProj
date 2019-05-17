using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface ITechPscFilterRepo : IRepository<tblTechSpecFilter>
    {

    }

    public class TechPscFilterRepo : Repository<tblTechSpecFilter>, ITechPscFilterRepo
    {
        public TechPscFilterRepo(DbContext context) : base(context)
        {

        }
    }
}