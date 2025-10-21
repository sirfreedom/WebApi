using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class SettingModel
    {

        [Required]
        public int iddependency { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public int questionperpage { get; set; }

        [Required]
        public int correctanswers { get; set; }

        [Required]
        public string subtitle { get; set; }

        public string instruction { get; set; }

        public string downloadtitle { get; set; }

        public string downloadlink { get; set; }

        public string preinstructiontitle { get; set; }

        public string preinstruction { get; set; }

        [Required]
        [Range(1, 60, ErrorMessage = "El valor debe estar entre 1 y 60.")]
        public int timeinminutes { get; set; }
    }
}
