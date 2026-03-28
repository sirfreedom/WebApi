using System;

namespace WebApi.Entity
{

    [Serializable]
    public class UserApp : EntityBase
    {

        public UserApp() { }

        public UserApp(int Id, string username, string pass, string rolecode) 
        {
            UserName = username;
            Pass = pass;
            RoleCode = rolecode;
        }

        public int IdTipoUserApp { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public string UserName { get; set; }
        public string Pass { get; set; }
        public string RoleCode { get; set; }
        public bool IsDisabled { get; set; }

    }
}
