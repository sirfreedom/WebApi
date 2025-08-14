using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
	public class DependencyModel
	{
        [Required]
        public string Descripcion { get; set; }
	}

}