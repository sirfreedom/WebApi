using System;
using System.Collections.Generic;
using WebApi.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace WebApi.Data
{
    public class UserAppData
    {

        private readonly string _ConnectionString = string.Empty;

        public UserAppData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<UserApp> Login(string Name, string Pass)
        {
            List<UserApp> lUser = new ();
            UserApp oUser;
            IRead<UserApp> UserAppRepository = new ContextSQL<UserApp>(_ConnectionString);
            DataTable dt;
            try
            {
                dt = await UserAppRepository.Fill("Login",new () { { "UserName", Name }, { "Pass", Pass } });
                lUser = UserApp.ToList<UserApp>(dt);
                oUser = lUser.FirstOrDefault(); 
            }
            catch (Exception)
            {
                throw;
            }
            return oUser;
        }

        public async Task Insert(UserApp userApp)
        {
            IWrite<UserApp> UserAppRepository = new ContextSQL<UserApp>(_ConnectionString);
            try
            {
                await UserAppRepository.Insert(userApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(UserApp userApp)
        {
            IWrite<UserApp> UserAppRepository = new ContextSQL<UserApp>(_ConnectionString);
            try
            {
                await UserAppRepository.Update(userApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserApp> Get(int Id)
        {
            IRead<UserApp> UserAppRepository = new ContextSQL<UserApp>(_ConnectionString);
            UserApp oUserApp;
            try
            {
                oUserApp = await UserAppRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oUserApp;
        }
    }
}
