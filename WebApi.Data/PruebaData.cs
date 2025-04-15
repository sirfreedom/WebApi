using System.Collections.Generic;
using System.Data;
using WebApi.Entity;

namespace WebApi.Data
{
    public class PruebaData : ICommonSQL
    {

        private readonly IRepository<Setting> _context;

        public PruebaData(IRepository<Setting> context)
        {
            _context = context;
        }

        public string EntityName
        {
            get { return _context.EntityName; }
        }

        public void ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null)
        {
            _context.ExecuteNonQuery(FunctionName, lParam);
        }

        public DataSet Fill(string FunctionName, Dictionary<string, string> lParam = null)
        {
            return _context.Fill(FunctionName, lParam);
        }
    }
}
