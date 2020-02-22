using Identity.WebApi.Helpers;
using Identity.WebApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Identity.WebApi.Services
{
    public class UserService : IUserService
    {
        #region datas
        private List<User> _users = new List<User>()
        {
            new User {Name ="Muhsin", Surname="Yolcu", Password = "test2020", UserName="muhsin.yolcu"},
            new User {Name ="Fatma", Surname="Yolcu", Password = "test2021"}
        };
        #endregion
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Models.SecurityToken Authenticate(string userName, string password)
        {
            var user = _users.SingleOrDefault(u => u.UserName == userName && u.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // Authentication successful, generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("name", user.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new Models.SecurityToken() { AuthToken = jwtSecurityToken };
        }

    }
}
