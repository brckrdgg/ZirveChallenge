using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Dto;

namespace ZirveChallenge.Core.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, string token)
        {
           
                var tokenHandler = new JwtSecurityTokenHandler();
             
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
              
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                  
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                
                var claims = (((JwtSecurityToken)validatedToken).Claims).ToArray();
                string userName = claims.Where(c => c.Type == JwtRegisteredClaimNames.UniqueName).FirstOrDefault().Value;
                int userId =int.Parse(claims.Where(c => c.Type == JwtRegisteredClaimNames.NameId).FirstOrDefault().Value);

            ActiveUser.Set(new LoginModel()
                {
                    Token = token,
                    UserName=userName,
                    UserId= userId,


                });

            
         
        }
    }
}
