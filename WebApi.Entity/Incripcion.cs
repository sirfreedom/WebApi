

namespace WebApi.Entity
{
	public class Incripcion : EntityBase
	{
				public string Carrera { get; set; }
		public bool? IsContacted { get; set; }
		public bool? IsNew { get; set; }
		public string Nombre { get; set; }
		public string Telefono { get; set; }


	}

}