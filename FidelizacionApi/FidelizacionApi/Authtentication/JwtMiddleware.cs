using Aplicacion.Authtentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authtentication
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SecretSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<SecretSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Any(x => x.ToLower().Contains("authorization")))
            {
                var token = context.Request.Headers[context.Request.Headers.Keys.First(x => x.ToLower().Contains("authorization"))].FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                    attachUserToContext(context, token);
            }

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var RoleId = Int32.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.Role).Value);
                var Name = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;

                // attach user to context on successful jwt validation
                context.Items["User"] = userId;
                context.Items["Role"] = RoleId;
                context.Items["UserName"] = Name;
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}