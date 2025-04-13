using System.Collections.Generic;
using System.Data;

namespace WebApi.Data
{
    public interface ICommonSQL
    {

        DataTable Fill(string FunctionName, Dictionary<string, string> lParam = null);

        void ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null);

    }
}
