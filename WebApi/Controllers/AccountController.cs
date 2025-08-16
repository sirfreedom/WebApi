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
            DateTime ExpirationDateUTC = DateTime.UtcNow.AddMinutes(_tokenManagement.AccessExpiration).AddHours(_tokenManagement.UniversalTimeZone);
            LoginResult loginResult = new LoginResult();
            try
            {
                loginResult = _userService.IsValidUser(request.user, request.pass);

                if (!ModelState.IsValid || loginResult.UserName.Length == 0 )
                {
                    return BadRequest("Invalid Request");
                }
                
                loginResult.UserName = request.user;
                loginResult.ExpirationYear = ExpirationDateUTC.Year;
                loginResult.ExpirationMonth = ExpirationDateUTC.Month;
                loginResult.ExpirationDay = ExpirationDateUTC.Day;
                loginResult.ExpirationHour = ExpirationDateUTC.Hour;
                loginResult.ExpirationMinute = ExpirationDateUTC.Minute;
                loginResult.UniversalCentralTime = _tokenManagement.UniversalTimeZone;
                loginResult.TimeNow = DateTime.UtcNow.AddHours(_tokenManagement.UniversalTimeZone).ToString(_tokenManagement.FormatTime);
                loginResult.TimeOfServer = DateTime.Now.ToString(_tokenManagement.FormatTime);
                loginResult.FormatTime = _tokenManagement.FormatTime;

                claims = new[]
{
                    new Claim(ClaimTypes.Name,request.user),
                    new Claim("AdminType",loginResult.AdminType)
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
                loginResult.Token = token;
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
            return Ok(loginResult);
        }
    }

   


}
