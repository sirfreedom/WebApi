using System;

namespace WebApi.Model
{
    public class ReservaModel
    {

        public int Id { get; set; } 
        public int IdCliente { get; set; }  
        public int IdServicio { get; set; }
        public string Cliente { get; set; }
        public string Servicio { get; set; }
        public DateTime Fecha { get; set; }

    }
}
