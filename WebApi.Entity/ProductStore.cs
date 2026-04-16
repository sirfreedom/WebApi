
namespace WebApi.Entity
{
	public class ProductStore : EntityBase
	{
		public string DescriptionText { get; set; }
		public int IdCategory { get; set; }
		public int IdUserStoreData { get; set; }
		public bool isnew { get; set; } = false;
		public decimal price { get; set; }
		public int Quantity { get; set; }
		public string YouTubeLink { get; set; }

		public string imgtext1 { get; set; }
        public string imgtext2 { get; set; }
        public string imgtext3 { get; set; }
        public string imgtext4 { get; set; }
    }
}