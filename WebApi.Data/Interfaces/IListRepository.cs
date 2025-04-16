using System.Collections.Generic;

namespace WebApi.Data
{
    public interface IListRepository<TEntity> where TEntity : class, new()
    {

        List<TEntity> List();

    }
}
