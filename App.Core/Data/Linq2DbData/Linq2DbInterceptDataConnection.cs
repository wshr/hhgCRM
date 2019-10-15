using LinqToDB.Data;
using LinqToDB.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Core.Data.Linq2DbData
{
    public class Linq2DbInterceptDataConnection : DataConnection
    {
        public Linq2DbInterceptDataConnection(IDataProvider provider, string connStr)
            : base(provider, connStr)
        {
        }
    }
}
