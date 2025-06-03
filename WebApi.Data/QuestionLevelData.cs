using System.Collections.Generic;
using System.Data;
using WebApi.Entity;

namespace WebApi.Data
{
    public class QuestionLevelData 
    {
        private readonly string _ConectionString = string.Empty;

        public QuestionLevelData(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public List<QuestionLevel> List(int IdDependency) 
        { 
            Dictionary<string,string> lParam = new Dictionary<string, string>(); 
            DataTable dt = new DataTable();
            lParam.Add("IdDependency",IdDependency.ToString());
            IRepository<QuestionLevel> Serv = new ContextSQL<QuestionLevel>(_ConectionString);
            dt = Serv.Fill("ListByDependency", lParam);
            return QuestionLevel.ToList<QuestionLevel>(dt); 
        }


    }
}
