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
                lUser.Add(new UserApp(2, "ale", "ale", "1"));
                lUser.Add(new UserApp(3, "pepe", "pepe", "2"));
                lUser.Add(new UserApp(4, "rodrigo", "rodrigo", "2"));
                oUser = lUser.FirstOrDefault(x => x.Name == Name && x.Pass == Pass);
            }
            catch (Exception)
            {
                throw;
            }
            return oUser;
        }





    }
}
