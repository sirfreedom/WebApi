using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApi.Entity
{
	public class Question : EntityBase
	{

        [Required]
        public string Cod { get; set; }

        [Required]
        public string QuestionDescription { get; set; }

        [Required]
        public string AnswerDescription { get; set; }

        [Required]
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