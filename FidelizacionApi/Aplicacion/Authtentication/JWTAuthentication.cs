using Dominio.Entidades;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aplicacion.Authtentication
{
    public class JWTAuthentication : IAuthentication
    {

        private readonly SecretSettings _appSettings;

        public JWTAuthentication(IOptions<SecretSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(Usuario usuario)
        {

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>()
                {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Guid.ToString()),
                        new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                        new Claim(ClaimTypes.Role, usuario.PerfilId.ToString()),
                },
                expires: DateTime.Now.AddHours(5),
                signingCredentials: signinCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return token;
        }
    }
}
