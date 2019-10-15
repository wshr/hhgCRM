using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interceptor
{
    /// <summary>
    /// Service拦截器
    /// </summary>
    public class AppServiceInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            //throw new NotImplementedException();
        }
    }
}
