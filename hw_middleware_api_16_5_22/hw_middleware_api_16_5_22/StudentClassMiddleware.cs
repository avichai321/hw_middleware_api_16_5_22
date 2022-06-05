using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hw_middleware_api_16_5_22
{
    public class StudentClassMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
                string studentclass = context.Request.Path.Value.Split("/")[2];
                await context.Response.WriteAsync($"hello from class  {studentclass}\n");
                await next(context);
        }

        
    }
}
