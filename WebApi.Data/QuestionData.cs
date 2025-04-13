using System.Collections.Generic;
using WebApi.Entity;

namespace WebApi.Data
{
    public class QuestionData : IFindRepository 
    {
        private readonly IRepository<Question> _context;

        public QuestionData(IRepository<Question> context)
        {
            _context = context;
        }

        public string EntityName
        {
            get { return _context.EntityName; }
        }

        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            return _context.Find(lParam);
        }
    
    }
}
