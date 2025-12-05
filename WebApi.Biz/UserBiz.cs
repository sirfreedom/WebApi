using System;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class UserBiz
    {

		public UserApp Get(string Name, string Pass)
		{
            UserApp oUser;
			try
			{
				UserData u = new ();
				oUser = u.Get(Name, Pass);
			}
			catch (Exception)
			{
				throw;
			}
			return oUser;
		}





	}
}
