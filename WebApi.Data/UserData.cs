using System;
using System.Collections.Generic;
using WebApi.Entity;
using System.Linq;

namespace WebApi.Data
{
    public class UserData
    {


        public UserApp Get(string Name, string Pass)
        {
            List<UserApp> lUser = new List<UserApp>();
            UserApp oUser;
            try
            {
                lUser.Add(new UserApp(1, "admin", "1234", "2"));
                lUser.Add(new UserApp(2, "admin", "2223", "1"));
                lUser.Add(new UserApp(3, "admin", "0000", "3"));
                lUser.Add(new UserApp(4, "rodrigo", "rodrigo", "3"));
                oUser = lUser.FirstOrDefault(x => x.Name.ToLower() == Name.ToLower() && x.Pass.ToLower() == Pass.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
            return oUser;
        }





    }
}
