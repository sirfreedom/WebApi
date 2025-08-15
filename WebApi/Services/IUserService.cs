using WebApi.Model;

namespace WebApi.Services
{

    public interface IUserService
    {


        LoginResult IsValidUser(string userName, string password);


    }
}
