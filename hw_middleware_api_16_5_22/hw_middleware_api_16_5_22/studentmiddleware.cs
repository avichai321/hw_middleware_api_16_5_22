using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hw_middleware_api_16_5_22
{
    public class studentmiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string student = context.Request.Path.Value.Split("/")[3];
            await context.Response.WriteAsync($"hello from student {student}\n ");
         
        }
    }
}
