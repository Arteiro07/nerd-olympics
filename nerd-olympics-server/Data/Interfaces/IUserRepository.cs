using Data.Models;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}
