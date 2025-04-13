using System.Collections.Generic;
using System.Data;

namespace WebApi.Data
{
    public interface IRepository<TEntity>
    {
        string EntityName { get; }

        List<TEntity> List();

        TEntity Get(int Id);

        List<dynamic> Find(Dictionary<string, string> lParam);

        void Delete(int Id);

        void Insert(Dictionary<string, string> lParam);

        void Update(Dictionary<string, string> lParam);

        DataTable Fill(string FunctionName, Dictionary<string, string> lParam = null);

        void ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null);

    }
}
