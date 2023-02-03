using Data.Models;

namespace NerdOlympicsAPI.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
    }
}
