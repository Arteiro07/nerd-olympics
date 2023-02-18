using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using Microsoft.EntityFrameworkCore;
using NerdOlympics.Data.Cryptography;
using System.Diagnostics.Tracing;
using System.Net.Mail;

namespace NerdOlympics.Data.Repositories
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
            return await _context.Users!.AsNoTracking().ToListAsync();
        }

        public async Task<User?> CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || await CheckEmailExists(user.Email))
            {
                return null;
            }
            await _context.Users!.AddAsync(user);
            await _context.SaveChangesAsync();

            return await _context.Users!.FirstOrDefaultAsync(x => x.UserId == user.UserId);
        }

        public async Task<User?> Authenticate(string emailAddress, string password)
        {
            string hashedPassword = PasswordHasher.HashPassword(password);

            return await _context.Users!.AsNoTracking().FirstOrDefaultAsync(x => x.Email == emailAddress && x.Password == hashedPassword);
        }

        public async Task<User?> GetUsers(string email)
        {
            return await _context.Users!.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            return await _context.Users!.AsNoTracking().AnyAsync(x => x.Email!.ToLower() == email.ToLower());
        }

        public async Task<List<int>> GetUserCompetitionIds(int userId)
        {
            return await _context.Competitions!.AsNoTracking().Where(x => x.UserId == userId).Select(x => x.CompetitionId).ToListAsync();
        }

        public async Task<bool> UserExists(int userId)
        {
            return await _context.Users!.AsNoTracking().AnyAsync(x => x.UserId == userId);
        }
    }
}
