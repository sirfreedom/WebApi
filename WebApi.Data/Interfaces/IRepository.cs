using System.Collections.Generic;
using System.Data;
using WebApi.Entity;

namespace WebApi.Data
{
    public interface IRepository<TEntity> where TEntity : EntityBase, new ()
    {
        List<TEntity> List();

        TEntity Get(int Id);

        List<dynamic> Find(TEntity oEntity);

        void Delete(int Id);

        void Insert(TEntity oEntity);

        void Update(TEntity oEntity);

        DataSet Fill(string FunctionName, Dictionary<string, string> lParam = null);

        void ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null);

    }
}
