namespace AspnetCore_MVC.Helper.Middleware;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UserSessionValidation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<UserSessionValidationMiddleware>();
    }
}
