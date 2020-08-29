using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LevenshteinDistanceWorkflow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LevenshteinDistanceWorkflow.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// API to validate user credentials to login
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel credentials)
        {
            try
            {
                UserModel login = new UserModel();
                login.UserName = credentials.UserName;
                login.Password = credentials.Password;

                IActionResult response = Unauthorized();
                var user = AuthorizeUser(login);

                if (user != null)
                {
                    var tokenStr = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenStr });
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        /// <summary>
        ////Authorize the user if user credentials match with predefined credentials
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private UserModel AuthorizeUser(UserModel login)
        {
            try
            {
                UserModel user = null;

                if (login.UserName == "gleacuser" && login.Password == "1234")
                {
                    //For this assignment, I have hardcoded the User Info. Otherwise, we fetch it from database
                    user = new UserModel
                    {
                        UserName = "gleacuser",
                        Password = "1234",
                        EmailAddress = "gleacuser@gleac.com"
                    };
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This is to generate JSON Web Token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(UserModel userInfo)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                var token = new JwtSecurityToken(
                        issuer: _config["Jwt:Issuer"],
                        audience: _config["Jwt:Issuer"],
                        claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials
                    );

                var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

                return encodedToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
    }
}