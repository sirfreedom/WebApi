using System.Collections.Generic;

namespace WebApi.Data
{
    public interface IListRepository<TEntity>
    {
        string EntityName { get; }

        List<TEntity> List();

    }
}
