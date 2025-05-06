using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Infrastructure.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebApi.Services;
using System.Net;
using WebApi.Model;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly TokenManagement _tokenManagement;
        private readonly IConfiguration _configuration;

        public AccountController(ILogger<AccountController> logger, IUserService userService, TokenManagement tokenManagement, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _tokenManagement = tokenManagement;
            _configuration = configuration;
        }

        /// <summary>
        /// JWT login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            JwtSecurityToken jwtToken;
            SigningCredentials credentials;
            SymmetricSecurityKey key;
            Claim[] claims;
            string token;
            try
            {

                if (!ModelState.IsValid || !_userService.IsValidUser(request.user, request.pass))
                {
                    return BadRequest("Invalid Request");
                }

                claims = new[]
                {
                new Claim(ClaimTypes.Name,request.user)
                };

                key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
                credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                jwtToken = new JwtSecurityToken(
                    _tokenManagement.Issuer,
                    _tokenManagement.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                    signingCredentials: credentials);
                token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }
            catch (WebException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);
                return ValidationProblem("Error", "Get", 500, ex.Message);
            }
            return Ok(new LoginResult { UserName = request.user, JwtToken = token });
        }
    }

   


}
