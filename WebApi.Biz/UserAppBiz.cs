using System;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class UserAppBiz
    {

        private readonly string _ConnectionString = string.Empty;

        public UserAppBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<UserApp> Login(string Name, string Pass)
		{
            UserApp oUser;
			UserAppData userAppData = new (_ConnectionString);
            try
			{
				oUser = await userAppData.Login(Name, Pass);
            }
			catch (Exception)
			{
				throw;
			}
			return oUser;
		}

        public async Task Insert(UserApp userApp)
        {
            UserAppData userAppData = new (_ConnectionString);
            try
            {
                await userAppData.Insert(userApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(UserApp userApp)
        {
            UserAppData userAppData = new (_ConnectionString);
            try
            {
                await userAppData.Update(userApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserApp> Get(int Id)
        {
            UserAppData userAppData = new(_ConnectionString);
            UserApp oUserApp;
            try
            {
                oUserApp = await userAppData.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return oUserApp;
        }
    }
}
