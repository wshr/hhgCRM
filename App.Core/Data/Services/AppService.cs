using App.Core.Data;
using App.Core.Data.Linq2DbData;
using App.Core.Interceptor;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public class AppService<T> : IAppService
    {
        protected static ProxyGenerator _generator;
        protected static IRepository _repository;

       

        static AppService()
        {
            _generator = new ProxyGenerator();
        }

        public static T Proxy
        {
            get
            {
                return (T)_generator.CreateClassProxy(typeof(T), new IInterceptor[]
                {
                    new AppServiceInterceptor()
                });
            }
        }

        protected virtual IRepository GetDbContext(string connectionStringName = "default")
        {
            if (_repository == null)
                _repository = new Linq2dbRepository(connectionStringName);

            return _repository;
        }


    }

    
}
