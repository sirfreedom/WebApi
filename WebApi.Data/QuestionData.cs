using System.Collections.Generic;
using WebApi.Entity;

namespace WebApi.Data
{
    public class QuestionData : IFindRepository<Question>
    {
        private readonly string _ConectionString = string.Empty;

        public QuestionData(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public List<dynamic> Find(Question oQuestion)
        {
            IFindRepository<Question> Serv = new ContextSQL<Question>(_ConectionString);
            return Serv.Find(oQuestion);
        }
    
    }
}
