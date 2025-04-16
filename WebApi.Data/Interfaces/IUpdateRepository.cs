using WebApi.Entity;

namespace WebApi.Data
{
    public interface IUpdateRepository<TEntity> where TEntity : class, new()
    {

        void Update(TEntity oEntity);

    }
}
