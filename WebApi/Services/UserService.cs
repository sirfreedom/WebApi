using Microsoft.Extensions.Logging;
using System;
using WebApi.Biz;
using WebApi.Entity;

namespace WebApi.Services
{
 

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }


        public bool IsValidUser(string userName, string password)
        {
            UserBiz u = new UserBiz();
            UserApp oUser = new UserApp();
            bool b = false;
            try
            {
                oUser = u.Get(userName, password);
                b = (oUser != null);
            }
            catch (Exception) 
            {
                throw;
            }
            return b;
        }


    }
}
