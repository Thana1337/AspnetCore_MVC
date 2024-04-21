using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore_MVC.Helper.Middleware;

public class UserSessionValidationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        if (context.User.Identity!.IsAuthenticated)
        {
            if (!await userManager.Users.AnyAsync(x => x.UserName == context.User.Identity.Name))
                await signInManager.SignOutAsync();
        }
        await _next(context);
    }
}
