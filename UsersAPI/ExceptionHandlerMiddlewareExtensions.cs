namespace UsersAPI
{
    using Microsoft.AspNetCore.Builder;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace API.DemoSample.Exceptions
    {
        public static class ExceptionHandlerMiddlewareExtensions
        {
            public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
            {
                app.UseMiddleware<ExceptionHandlerMiddleware>();
            }
        }
    }
}
