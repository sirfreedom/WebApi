
namespace WebApi.Entity
{
	public class Setting : EntityBase
	{
		public string tittle { get; set; }
		public string questionperpage { get; set; }
		public string correctanswers { get; set; }
        public string subtittle { get; set; }
		public string instruction { get; set; }
		public string downloadtittle { get; set; }
		public string downloadlink { get; set; }
		public string preinstructiontittle { get; set; }
		public string preinstruction { get; set; }
	}

}