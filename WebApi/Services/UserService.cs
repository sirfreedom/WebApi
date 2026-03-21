using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApi.Biz;
using WebApi.Entity;
using WebApi.Model;

namespace WebApi.Services
{

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _ConectionString;

        public UserService(ILogger<UserService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _ConectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<LoginResult> IsValidUser(string userName, string password)
        {
            UserAppBiz u = new UserAppBiz(_ConectionString);
            UserApp oUser;
            LoginResult oLoginResult = new LoginResult();
            try
            {
                oUser = await u.Find(userName, password);
                oLoginResult.UserName = oUser.UserName;
                oLoginResult.AdminType = oUser.RoleCode;
            }
            catch (Exception) 
            {
                throw;
            }
            return oLoginResult;
        }


    }
}
