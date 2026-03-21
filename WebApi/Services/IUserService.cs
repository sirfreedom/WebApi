using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Services
{

    public interface IUserService
    {


        Task<LoginResult> IsValidUser(string userName, string password);


    }
}
