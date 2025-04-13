
using System.Collections.Generic;

namespace WebApi.Entity
{
	public class FinalTestMessage : EntityBase
	{

        public string Cod { get; set; }
		public string AnswersRangeMin { get; set; }
		public string AnswersRangeMax { get; set; }
        public string FinalTestMessageDescription { get; set; }
		
		public string LevelDescription {  get; set; }

        public List<QuestionLevel> levels 
		{
			get 
			{
				string[] leveldescription;
				List<QuestionLevel> lQuestionLevel = new List<QuestionLevel>();
                leveldescription = LevelDescription.Split("|");

				foreach (string l in leveldescription)
				{
					QuestionLevel ql = new QuestionLevel();
					string[] levelcod;
					levelcod = l.Split("-");
					ql.Cod = levelcod[0];
					ql.Class = levelcod[1];
                    ql.QuestionLevelDescription = levelcod[2];
                    lQuestionLevel.Add(ql);
				}

				return lQuestionLevel;
			}
		}

    }

}