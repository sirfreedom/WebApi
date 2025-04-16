using System.Collections.Generic;
using WebApi.Entity;

namespace WebApi.Data
{
    public interface IFindRepository<TEntity> where TEntity : class, new()
    { 

        List<dynamic> Find(TEntity oEntity);

    }
}
