using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
	public class CardPicture : EntityBase
	{
		
		public string imagetextfront { get; set; }
        public string imagetextback { get; set; }

		[NotMapped]
		public string timecreated { get; set; }

        public string fullname { get; set; }
		public string obs { get; set; }

	}

}