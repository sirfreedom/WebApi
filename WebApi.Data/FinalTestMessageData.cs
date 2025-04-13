using System.Collections.Generic;
using WebApi.Entity;

namespace WebApi.Data
{
    public class FinalTestMessageData : IFindRepository
    {
        private readonly IRepository<FinalTestMessage> _context;

        public FinalTestMessageData(IRepository<FinalTestMessage> context)
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
