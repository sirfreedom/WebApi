using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    [Serializable]
    public class UserApp : EntityBase
    {
        public UserApp() { }

        public UserApp(int Id, string username, string pass, string rolecode) 
        {
            base.Id = Id;
            UserName = username;
            Pass = pass;
            RoleCode = rolecode;
        }

        public int IdUserDataStore { get; set; }
        public int IdTypeUserApp { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pass { get; set; } = string.Empty;
        public string UserName { get; set; }
        public string DescriptionText { get; set; }
        public string LogoImgText { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Provincia { get; set; }
        public string Calle { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }

        [NotMapped]
        public string RoleCode { get; set; }
    }
}
