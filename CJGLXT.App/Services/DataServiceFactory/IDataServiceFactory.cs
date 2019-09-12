using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.Data.DataServices;

namespace CJGLXT.App.Services.DataServiceFactory
{
    interface IDataServiceFactory
    {
        IDataService CreateDataService();
    }
}
