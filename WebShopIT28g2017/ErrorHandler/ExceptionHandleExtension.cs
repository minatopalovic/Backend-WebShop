using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIT28g2017.ErrorHandler
{
    public static class ExceptionHandleExtension
    {
        public static void ConfigureErrorHandling(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(
               options =>
               {
                   options.Run(async context =>
                   {
                       context.Response.StatusCode = 500;
                       var exception = context.Features.Get<IExceptionHandlerFeature>();
                       if (exception != null)
                       {
                           await context.Response.WriteAsync("Internal server error. Please try againg later! :)");
                       }

                   });
               }
                );
        }
    }
}
