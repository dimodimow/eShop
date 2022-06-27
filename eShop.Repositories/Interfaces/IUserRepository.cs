using eShop.Entities;
using System.Threading.Tasks;

namespace eShop.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsUserNameAvailable(string userName);
        Task<bool> IsEmailAvailable(string email);
    }
}
