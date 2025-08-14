using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
	public class FinalTestMessageModel
	{
        [Required]
        public int answersrangemax { get; set; }
        
		[Required]
        public int answersrangemin { get; set; }

        [Required]
        public int Cod { get; set; }

        [Required]
        public string FinalTestMessageDescription { get; set; }

        [Required]
        public int IdDependency { get; set; }
	}

}