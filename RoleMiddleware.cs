namespace WebApplication1
{
    public class RoleMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // ✅ FIXED PATH
            var path = context.Request.Path.Value?.ToLower();

            // ✅ Allow Swagger
            if (path != null && path.Contains("swagger"))
            {
                await _next(context);
                return;
            }

            // ✅ Allow ALL Auth APIs (IMPORTANT 🔥)
            if (path != null && path.StartsWith("/api/auth"))
            {
                await _next(context);
                return;
            }

            // ✅ Allow Users API
            if (path != null && path.StartsWith("/api/users"))
            {
                await _next(context);
                return;
            }

            var role = context.Request.Headers["role"].ToString();
            var method = context.Request.Method;

            if (string.IsNullOrEmpty(role))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Role header missing");
                return;
            }

            if (role == "Viewer" && method != "GET")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Viewer can only view data");
                return;
            }

            if (role == "Analyst" && (method == "POST" || method == "DELETE"))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Analyst cannot modify data");
                return;
            }

            await _next(context);
        }
    }
}