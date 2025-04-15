using System.Collections.Generic;
using System.Data;

namespace WebApi.Data
{
    public interface ICommonSQL
    {

        DataSet Fill(string FunctionName, Dictionary<string, string> lParam = null);

        void ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null);

    }
}
