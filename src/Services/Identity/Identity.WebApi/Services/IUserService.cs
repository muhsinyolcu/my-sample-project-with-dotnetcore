using Common.Core.Helpers;
using Identity.WebApi.Models;

namespace Identity.WebApi.Services
{
    public interface IUserService
    {
        ServiceResult<User> LoginUser(string userName, string password);
    }
}
