using System.Collections.Generic;
using WebApi.Entity;

namespace WebApi.Data
{
    public class QuestionLevelData : IFindRepository<QuestionLevel>
    {
        private readonly string _ConectionString = string.Empty;

        public QuestionLevelData(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public List<dynamic> Find(QuestionLevel oQuestionLevel)
        {
            IFindRepository<QuestionLevel> Serv = new ContextSQL<QuestionLevel>(_ConectionString);
            return Serv.Find(oQuestionLevel);
        }
    }
}
