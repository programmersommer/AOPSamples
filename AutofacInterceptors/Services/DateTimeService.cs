using Autofac.Extras.DynamicProxy;
using AutofacInterceptors.Interceptors;
using AutofacInterceptors.Interfaces;
using System;

namespace AutofacInterceptors.Services
{
    [Intercept(typeof(LoggingInterceptor))]
    public class DateTimeService : IDateTimeService
    {

        // Attention! Intercepted method should be virtual
        public virtual DateTime GetCurrentDate()
        {
            return DateTime.UtcNow;
        }
    }
}
