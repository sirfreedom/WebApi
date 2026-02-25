using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
    public interface IRead<TEntity> where TEntity : EntityBase, new()
    {
        Task<List<TEntity>> List();

        Task<TEntity> Get(int Id);

        Task<List<dynamic>> Find(Dictionary<string, string> lParam);

        Task<DataTable> Fill(string FunctionName, Dictionary<string, string> lParam = null);

    }
}

