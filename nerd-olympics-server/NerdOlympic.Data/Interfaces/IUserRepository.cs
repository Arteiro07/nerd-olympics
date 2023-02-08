using Data.Models;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Authenticate(string emailAddress, string password);
        Task<User?> CreateUser(User user);
        Task<List<int>> GetUserCompetitionIds(int userId);
        Task<List<User>> GetUsers();
        Task<User?> GetUsers(string email);
        Task<bool> CheckEmailExists(string email);
    }
}
