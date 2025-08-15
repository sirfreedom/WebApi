using System;

namespace WebApi.Entity
{

    [Serializable]
    public class UserApp : EntityBase
    {

        public UserApp() { }

        public UserApp(int Id, string name, string pass, string rolecode) 
        {
            Name = name;
            Pass = pass;
            RoleCode = rolecode;
        }

        public string Name { get; set; }
        public string Pass { get; set; }
        public string RoleCode { get; set; }

    }
}
