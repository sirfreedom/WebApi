using System.ComponentModel.DataAnnotations;

namespace WebApi.Entity
{
	public class QuestionLevel : EntityBase
	{
        [Required]
        public string Cod { get; set; }

        [Required]
        public string QuestionLevelDescription { get; set; }

        [Required]
        public string Class { get; set; }
	}

}