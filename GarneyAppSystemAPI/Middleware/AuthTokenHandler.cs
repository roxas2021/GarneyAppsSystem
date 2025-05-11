using GarneyAppSystemAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace GarneyAppSystemAPI.Middleware
{
    public class AuthTokenHandler
    {
        private readonly RequestDelegate _next;

        public AuthTokenHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext _context)
        {
            var path = context.Request.Path.Value;

            if (path.StartsWith("/api/login", StringComparison.OrdinalIgnoreCase) || path.StartsWith("/swagger", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token))
            {
                var isValidToken = await _context.userlogin.AnyAsync(t => t.authtoken == token);

                if (isValidToken)
                {
                    var user = await _context.userlogin.FirstOrDefaultAsync(u => u.authtoken == token);
                    if (user != null)
                    {
                        context.Items["User"] = user;
                    }
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid or expired token.");
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Authorization token is missing.");
                return;
            }

            await _next(context);
        }
    }
}
