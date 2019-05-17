using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Repositories.Repositories;

namespace Repositories
{
    public class UnitOfWork:IDisposable
    {
        DbContext Context;
        public IConsumerRepo consumer;
        public IProductRepo product;
        public ICategoryRepo category;
        public ISubCategoryRepo subCategory;
        public IManufactureRepo manufacture;
        public IPropertyValueRepo propertyvalue;
        public IPropertyRepo property;
        public ISpecFilterRepo specFilter;
        public ITypeFilterRepo typeFilter;

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
            consumer = new ConsumerRepo(this.Context);
            product = new ProductRepo(this.Context);
            category = new CategoryRepo(this.Context);
            subCategory = new SubCategoryRepo(this.Context);
            manufacture = new ManufactureRepo(this.Context);
            propertyvalue = new PropertyValueRepo(this.Context);
            property = new PropertyRepo(this.Context);
            specFilter = new SpecFilterRepo(this.Context);
            typeFilter = new TypeFilterRepo(this.Context);

            //add attrs
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Context.Dispose();
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}