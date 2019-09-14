using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.App.Services.DataServiceFactory;

namespace CJGLXT.App.Services
{
    abstract class DataServiceBase
    {
        public IDataServiceFactory DataServiceFactory { get; }

        protected DataServiceBase(IDataServiceFactory dataServiceFactory)
        {
            DataServiceFactory = dataServiceFactory;
        }
    }
}
