using System;

namespace WebApi.Entity
{

    [Serializable]
    public class UserApp : EntityBase
    {

        public UserApp() { }

        public UserApp(int Id, string name, string pass, int level) 
        {
            Name = name;
            Pass = pass;
            Level = level;
        }

        public string Name { get; set; }
        public string Pass { get; set; }
        public int Level { get; set; }

    }
}
