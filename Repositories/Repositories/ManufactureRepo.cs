using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface IManufactureRepo : IRepository<tblManufacturer>
    {

    }
    public class ManufactureRepo : Repository<tblManufacturer>, IManufactureRepo
    {
        public ManufactureRepo(DbContext context) : base(context)
        {

        }
    }
}