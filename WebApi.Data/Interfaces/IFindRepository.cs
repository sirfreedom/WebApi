using System.Collections.Generic;
namespace WebApi.Data
{
    public interface IFindRepository<TEntity> where TEntity : class
    {

        List<dynamic> Find(TEntity oEntity);

    }
}
