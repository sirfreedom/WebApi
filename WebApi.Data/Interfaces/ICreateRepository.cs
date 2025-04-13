
namespace WebApi.Data
{
    public interface ICreateRepository<TEntity>
    {

        string EntityName { get; }

        void Insert(TEntity entity);

    }
}
