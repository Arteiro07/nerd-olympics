using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using NerdOlympicsData.Cryptography;
using System.Diagnostics.Tracing;
using System.Net.Mail;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NerdOlympicsDBContext _context;
        
        public UserRepository(NerdOlympicsDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users!.ToListAsync();
        }

        public async Task<User?> CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.EmailAddress) || !await CheckEmailExists(user.EmailAddress))
            {
                return null;
            }
            await _context.Users!.AddAsync(user);
            await _context.SaveChangesAsync();

            return _context.Users?.FirstOrDefault(user);
        }

        public async Task<User?> Authenticate(string emailAddress, string password)
        {
            string hashedPassword = PasswordHasher.HashPassword(password);

            return await _context.Users!.FirstOrDefaultAsync(x => x.EmailAddress == emailAddress && x.Password == hashedPassword);
        }

        public async Task<User?> GetUsers(string email)
        {
            return await _context.Users!.FirstOrDefaultAsync(x => x.EmailAddress == email);
        }


        public async Task<bool> CheckEmailExists(string email)
        {
            return await _context.Users!.AnyAsync(x => x.EmailAddress!.ToLower() == email.ToLower());
        }
    }
}
