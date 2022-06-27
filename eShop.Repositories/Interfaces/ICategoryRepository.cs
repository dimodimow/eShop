using eShop.Entities;
using System.Threading.Tasks;

namespace eShop.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> IsNameAvailable(string name);
    }
}
