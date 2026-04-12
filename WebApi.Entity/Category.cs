
namespace WebApi.Entity
{
    public class Category : EntityBase
    {
        public int IdAppConfig { get; set; }
        public int IdCategory { get; set; }
        public string DescriptionText { get; set; }
        public string ImgText { get; set; }
    }
}
