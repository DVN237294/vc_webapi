using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace vc_webapi.Helpers
{
    public interface IJWTTokenGenerator
    {
        public string GenerateToken(IEnumerable<Claim> claims);
    }
    public class JWTTokenHelper : IJWTTokenGenerator
    {
        private readonly SigningCredentials signCreds;
        public JWTTokenHelper(SigningCredentials credentials)
        {
            signCreds = credentials;
        }

        public string GenerateToken (IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                NotBefore = DateTime.UtcNow,
                SigningCredentials = signCreds
            };
            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(jwtToken);
        }
    }
}
