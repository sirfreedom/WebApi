using WebApi.Entity;

namespace WebApi.Data
{
    public interface ICreateRepository<TEntity> where TEntity : class, new()
    {

        void Insert(TEntity oEntity);

    }
}
