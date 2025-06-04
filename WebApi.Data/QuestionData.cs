using System.Collections.Generic;
using System.Data;
using WebApi.Entity;

namespace WebApi.Data
{
    public class QuestionData 
    {
        private readonly string _ConectionString = string.Empty;

        public QuestionData(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public List<Question> List(int IdDependency, int CodLevel = 0) 
        {
            Dictionary<string, string> lParam = new Dictionary<string, string>();
            DataTable dt = new DataTable();
            IRepository<Question> Serv = new ContextSQL<Question>(_ConectionString);
            lParam.Add("IdDependency", IdDependency.ToString());
            lParam.Add("CodLevel",CodLevel.ToString());
            dt = Serv.Fill("ListByDependency", lParam);
            return Question.ToList<Question>(dt);
        }
    
    }
}
