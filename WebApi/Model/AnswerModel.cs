using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
	public class AnswerModel
	{
        [Required]
        public string AnswerDescription { get; set; }
        
        [Required]
        public int IdQuestion { get; set; }

        [Required]
        public bool Valid { get; set; }
	}

}