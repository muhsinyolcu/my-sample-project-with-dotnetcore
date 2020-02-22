using Identity.WebApi.Models;

namespace Identity.WebApi.Services
{
    public interface IUserService
    {
        SecurityToken Authenticate(string userName, string password);
    }
}
