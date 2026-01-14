using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class TipoInscripcion : EntityBase
    {

        public string Tipo { get; set; }
        public string Texto { get; set; }
        public bool IsDisabled { get; set; }

    }
}
