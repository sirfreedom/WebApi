using System.Collections.Generic;
using WebApi.Entity;

namespace WebApi.Data
{
    public class QuestionLevelData : IFindRepository
    {
        private readonly IRepository<QuestionLevel> _context;

        public QuestionLevelData(IRepository<QuestionLevel> context)
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
