using System;

namespace WebApi.Entity
{
	public class Inscripcion : EntityBase
	{
		public string Carrera { get; set; }

		public bool? IsContacted { get; set; }

		public DateTime? Fecha { get; set; }

        public string Nombre { get; set; }

		public string Telefono { get; set; }


	}

}