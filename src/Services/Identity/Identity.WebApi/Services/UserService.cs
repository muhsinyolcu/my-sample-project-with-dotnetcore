using Common.Core.Enums;
using Common.Core.Helpers;
using Common.Core.Models;
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
        private readonly List<User> _users = new List<User>()
        {
            new User {FirstName ="Muhsin", LastName="Yolcu", Password = "test2020", Username="muhsin.yolcu", Role = AuthRole.Admin},
            new User {FirstName ="Test", LastName="Yolcu", Password = "test2021", Username = "test.com", Role = AuthRole.Admin }
        };
        #endregion
        private readonly JwtSettings _jwtSettings;
        public UserService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        private string GenerateJSONWebToken(User user)
        {
            // Authentication successful, generate jwt token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.FirstName),
                        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(1440),
                signingCredentials: credentials
                );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodeToken;
        }
        public ServiceResult<User> LoginUser(string userName, string password)
        {
            var serviceResult = new ServiceResult<User>();
            try
            {
                var user = _users.SingleOrDefault(u => u.Username == userName && u.Password == password);

                // check if user not found
                if (user == null)
                {
                    serviceResult.StatusCode = (int)StatusCodesEnum.BadRequest;
                    serviceResult.ValidationMessages.Add("Username or Password is incorrect");
                }
                else
                {
                    user.Token = GenerateJSONWebToken(user);
                    serviceResult.Result = user;
                }
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.StatusCode = (int)StatusCodesEnum.SystemException;
                serviceResult.ValidationMessages.Add(ex.Message);
                //LOG
            }
            return serviceResult;
        }
    }
}
