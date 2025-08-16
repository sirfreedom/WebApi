using Microsoft.Extensions.Logging;
using System;
using WebApi.Biz;
using WebApi.Entity;
using WebApi.Model;

namespace WebApi.Services
{

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public LoginResult IsValidUser(string userName, string password)
        {
            UserBiz u = new UserBiz();
            UserApp oUser;
            LoginResult oLoginResult = new LoginResult();
            try
            {
                oUser = u.Get(userName, password);
                oLoginResult.UserName = oUser.Name;
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
