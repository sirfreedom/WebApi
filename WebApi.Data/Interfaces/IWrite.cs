using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
    public interface IWrite<TEntity> where TEntity : EntityBase, new()
    {
        Task Delete(int Id);

        Task Insert(TEntity oEntity);

        Task Update(TEntity oEntity);

        Task ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null);
    }
}
