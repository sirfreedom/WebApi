
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
	public class QuestionModel
	{
        [Required]
        public string Cod { get; set; }

        [Required]
        public int IdDependency { get; set; }

        [Required]
        public int IdQuestionLevel { get; set; }

        [Required]
        public string QuestionDescription { get; set; }
	}

}