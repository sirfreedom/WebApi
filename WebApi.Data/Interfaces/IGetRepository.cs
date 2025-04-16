using WebApi.Entity;

namespace WebApi.Data
{
    public interface IGetRepository<TEntity> where TEntity : class, new()
    {

        TEntity Get(int Id);

    }
}
