using System.ComponentModel.DataAnnotations.Schema;



namespace WebApi.Entity
{
	public class Inscripcion : EntityBase
	{
		public string Carrera { get; set; }

		[NotMapped]
		public bool? IsContacted { get; set; }

        [NotMapped]
        public bool? IsNew { get; set; }
		
		public string Nombre { get; set; }

		public string Telefono { get; set; }


	}

}