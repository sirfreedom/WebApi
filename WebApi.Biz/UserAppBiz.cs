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

        public async Task<UserApp> Find(string Name, string Pass)
		{
            UserApp oUser;
			UserAppData userAppData = new UserAppData(_ConnectionString);
            try
			{
				oUser = await userAppData.Find(Name, Pass);
            }
			catch (Exception)
			{
				throw;
			}
			return oUser;
		}





	}
}
