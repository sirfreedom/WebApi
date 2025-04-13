
namespace WebApi.Data.Interfaces
{
    public interface IDeleteRespository
    {
        string EntityName { get; }

        void Delete(int Id);

    }
}
