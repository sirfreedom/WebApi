using System.Collections.Generic;
using System.Data;
using WebApi.Entity;

namespace WebApi.Data
{


    /// <summary>
    /// La interface solo se va a utilizar dentro del ensamblado DATA, asi que es internal
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal interface IRepository<TEntity> where TEntity : EntityBase, new()
    {
        List<TEntity> List();

        TEntity Get(int Id);

        List<dynamic> Find(Dictionary<string, string> lParam);

        void Delete(int Id);

        TEntity Insert(TEntity oEntity);

        void Update(TEntity oEntity);

        DataTable Fill(string FunctionName, Dictionary<string, string> lParam = null);

        int ExecuteNonQuery(string FunctionName, Dictionary<string, string> lParam = null);

    }
}
