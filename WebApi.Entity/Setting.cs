using System;
using System.ComponentModel.DataAnnotations;


namespace WebApi.Entity
{
	public class Setting : EntityBase
	{

		[Required]
		public int iddependency { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 1 y 100.")]
        public int questionperpage { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 1 y 100.")]
        public int correctanswers { get; set; }
        
        [Required]
        public string subtitle { get; set; }

        public string instruction { get; set; }
		
        public string downloadtitle { get; set; }
		
        public string downloadlink { get; set; }
		
        public string preinstructiontitle { get; set; }
		
        public string preinstruction { get; set; }
	}

}