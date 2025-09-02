using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
    internal interface IRepositoryAsync<TEntity> where TEntity : EntityBase, new()
    {

        Task<List<TEntity>> List();

        Task<TEntity> Get(int Id);

        Task<List<dynamic>> Find(Dictionary<string, string> lParam);

        Task Delete(int Id);

        Task<TEntity> Insert(TEntity oEntity);

        Task Update(TEntity oEntity);

        Task<DataTable> Fill(string FunctionName, Dictionary<string, string> lParam = null);

        Task ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null);

    }
}
