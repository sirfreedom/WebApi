
namespace WebApi.Data
{
    public interface IGetRepository<TEntity>
    {

        string EntityName { get; }

        TEntity Get(int Id);

    }
}
