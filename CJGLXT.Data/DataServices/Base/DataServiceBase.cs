using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.Data.DataContexts;

namespace CJGLXT.Data.DataServices.Base
{
    public abstract partial class DataServiceBase : IDataService, IDisposable
    {
        private IDataSource _dataSource = null;

        protected DataServiceBase(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dataSource != null)
                {
                    _dataSource.Dispose();
                }
            }
        }
        #endregion
    }
}
