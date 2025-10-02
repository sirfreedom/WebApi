

namespace WebApi.Entity
{
	public class ExamResult : EntityBase
	{
				public int Distracciones { get; set; }
		public int IdDependency { get; set; }
		public int IdQuestionLevel { get; set; }
		public int IdUsuario { get; set; }
		public string IpHost { get; set; }
		public int Respuestas { get; set; }
		public int Total { get; set; }


	}

}