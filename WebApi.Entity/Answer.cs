using System.ComponentModel.DataAnnotations;

namespace WebApi.Entity
{
	public class Answer : EntityBase
	{
        [Required]
        public string AnswerDescription { get; set; }

        [Required]
        public bool Valid { get; set; }
	}

}