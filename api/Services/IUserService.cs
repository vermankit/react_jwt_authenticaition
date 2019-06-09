using api.Entities;

namespace api.Services
{
    public interface IUserService
    {
         User Authenticate(string username,string password);
    }
}