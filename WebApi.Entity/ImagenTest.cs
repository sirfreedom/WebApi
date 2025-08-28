using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class ImagenTest : EntityBase
    {
        [NotMapped]
        public string ImageText { get; set; }

    }
}
