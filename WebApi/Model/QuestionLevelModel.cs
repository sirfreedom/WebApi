using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
	public class QuestionLevelModel
	{
        [Required]
        public string Class { get; set; }

        [Required]
        public int Cod { get; set; }
        
        [Required]
        public int IdDependency { get; set; }

        [Required]
        public string QuestionLevelDescription { get; set; }
	}

}