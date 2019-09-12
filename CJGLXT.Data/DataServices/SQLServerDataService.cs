using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.Data.DataContexts;
using CJGLXT.Data.DataServices.Base;

namespace CJGLXT.Data.DataServices
{
    public class SQLServerDataService:DataServiceBase
    {
        public SQLServerDataService() : base(new SqlServerDb())
        {
        }
    }
}
