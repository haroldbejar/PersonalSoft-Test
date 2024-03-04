using Domain.Models;

namespace Repositories.Repositories
{
    public interface IAppUserRepository : IBaseRepository<AppUser>
    {
        Task<AppUser> GetUserByUserName(string userName);


    }
}
