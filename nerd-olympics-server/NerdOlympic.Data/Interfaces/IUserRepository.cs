﻿using NerdOlympics.Data.Models;

namespace NerdOlympics.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string emailAddress, string password);
        Task<User> CreateUser(User user);
        Task<List<int>> GetUserCompetitionIds(int userId);
        Task<List<User>> GetUsers();
        Task<User> GetUser(string email);
        Task<bool> CheckEmailExists(string email);
        Task<bool> UserExists(int userId);
    }
}
