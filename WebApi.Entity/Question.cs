
using System.Collections.Generic;


namespace WebApi.Entity
{
	public class Question : EntityBase
	{
        private string _AnswerDescription = string.Empty;


        public string Cod { get; set; }
        public string QuestionDescription { get; set; }
		public string AnswerDescription { get; set; }
        public string CodLevel { get; set; }
        public List<Answer> Answers 
        {
            get { 
                List<Answer> lAnswer = new List<Answer>();
                string[] la;
                la = AnswerDescription.Split("|");
                
                foreach (string s in la)
                {
                    Answer answer = new Answer();
                    string[] lr;
                    lr = s.Split("-");

                    answer.AnswerDescription = lr[0].Trim();
                    answer.Valid = (lr[1].Trim() == "true") ? true : false;
                    lAnswer.Add(answer);
                }

                return lAnswer;                
            }
        }

    }

}