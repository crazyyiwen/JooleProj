using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repositories.Repositories
{
    public interface ISpecFilterRepo : IRepository<tblTechSpecFilter>
    {

    }

    public class SpecFilterRepo : Repository<tblTechSpecFilter>, ISpecFilterRepo

    {
        public SpecFilterRepo(DbContext context) : base(context)
        {

        }
    }
}