using Microsoft.AspNetCore.Builder;

namespace hw_middleware_api_16_5_22
{
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder useMiddlewarePrintClassAndStudent(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StudentClassMiddleware>();
        }
    }
}
