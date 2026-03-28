using System;
using System.Collections.Generic;
using WebApi.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class UserAppData
    {

        private readonly string _ConnectionString = string.Empty;

        public UserAppData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<UserApp> Find(string Name, string Pass)
        {
            List<UserApp> lUser = new ();
            UserApp oUser;
            IRead<UserApp> UserAppRepository = new ContextSQL<UserApp>(_ConnectionString);
            List<dynamic> lResult = new ();
            try
            {
                lResult = await UserAppRepository.Find(new Dictionary<string, string>() { { "UserName", Name }, { "Pass", Pass } });
                lUser = UserApp.ToList<UserApp>(lResult);
                oUser = lUser.FirstOrDefault(); 
            }
            catch (Exception)
            {
                throw;
            }
            return oUser;
        }





    }
}
