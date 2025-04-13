using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class QuestionBiz
    {

        private string _ConectionString = string.Empty;

        public QuestionBiz(string ConectionString) 
        { 
            _ConectionString = ConectionString;
        }

        public List<Question> Find(int IdDependency, int CodLevel) 
        {
            IFindRepository Serv = new QuestionData(new ContextSQL<Question>(_ConectionString));
            List<dynamic> lq = new List<dynamic>();
            List<Question> lQuestion = new List<Question>();
            Dictionary<string,string> lParam = new Dictionary<string,string>();
            lParam.Add("IdDependency", IdDependency.ToString());
            lParam.Add("CodLevel",  CodLevel.ToString());
            Serv = new QuestionData(new ContextSQL<Question>(_ConectionString));
            lq = Serv.Find(lParam);
            lQuestion = Question.ToList<Question>(lq);

            return lQuestion;
        }






    }
}
