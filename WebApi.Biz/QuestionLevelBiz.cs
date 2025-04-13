using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Biz
{
    public class QuestionLevelBiz
    {

        private string _ConectionString = string.Empty;

        public QuestionLevelBiz(string ConectionString)
        {
            _ConectionString = ConectionString;
        }

        public List<QuestionLevel> Find(int IdDpendency)
        {
            IFindRepository Serv = new QuestionLevelData(new ContextSQL<QuestionLevel>(_ConectionString));
            List<dynamic> lq = new List<dynamic>();
            List<QuestionLevel> lQuestionLevel = new List<QuestionLevel>();
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            lParam.Add("IdDependency", IdDpendency.ToString());
            lq = Serv.Find(lParam);
            lQuestionLevel = Question.ToList<QuestionLevel>(lq);
            return lQuestionLevel;
        }



    }
}
