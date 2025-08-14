using System.ComponentModel.DataAnnotations;

namespace WebApi.Entity
{
	public class Dependency : EntityBase
	{
        [Required]
        public string Descripcion { get; set; }
	}

}