using App.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bussiness.Entities;

namespace App.Bussiness.Service
{
    public class TestService : AppService<TestService>
    {
        public virtual List<TsUser> Test()
        { 
           return GetDbContext().GetTable<TsUser>().ToList();
        }
    }
}
