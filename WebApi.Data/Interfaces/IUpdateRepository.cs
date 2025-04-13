
namespace WebApi.Data
{
    public interface IUpdateRepository<TEntity>
    {
        string EntityName { get; }

        void Update(TEntity entity);

    }
}
