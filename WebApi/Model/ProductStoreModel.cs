
namespace WebApi.Model
{
	public class ProductStoreModel
	{
        public int iduserdatastore { get; set; }
        public string descriptiontext { get; set; }
		public int idcategory { get; set; }
		public bool isnew { get; set; } = false;
		public decimal price { get; set; }
		public int quantity { get; set; } = 0;
		public string youtubelink { get; set; }

        public string imgtext1 { get; set; }
        public string imgtext2 { get; set; }
        public string imgtext3 { get; set; }
        public string imgtext4 { get; set; }
    }
}