using System.Collections.Generic;
using System.Data;

namespace WebApi.Data
{
    public class PruebaData : ICommonSQL
    {

        private readonly string _ConectionString = string.Empty;

        public PruebaData(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public void ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null)
        {
            throw new System.NotImplementedException();
        }

        public DataSet Fill(string FunctionName, Dictionary<string, string> lParam = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
