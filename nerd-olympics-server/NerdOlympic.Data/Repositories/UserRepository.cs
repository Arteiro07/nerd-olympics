using Microsoft.EntityFrameworkCore;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Cryptography;
using NerdOlympics.Data.Models.ErrorHandling;
using System.Diagnostics.Tracing;
using System.Net;
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

        public async Task<User> CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || await CheckEmailExists(user.Email))
            {
                throw new CustomException((int)HttpStatusCode.Conflict, ErrorMessage.USER_EMAIL_EXISTS);
            }
            
            await _context.Users!.AddAsync(user);
            await _context.SaveChangesAsync();
            
            var newUser = await _context.Users!.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (newUser == null)
                throw new CustomException((int)HttpStatusCode.InternalServerError, ErrorMessage.USER_CREATE_ERROR);

            return user;
        }

        public async Task<User> Authenticate(string emailAddress, string password)
        {
            string hashedPassword = PasswordHasher.HashPassword(password);

            var user = await _context.Users!.AsNoTracking().FirstOrDefaultAsync(x => x.Email == emailAddress && x.Password == hashedPassword);

            if(user == null)
            {
                throw new CustomException((int)HttpStatusCode.Unauthorized, ErrorMessage.USER_INVALID_CREDENTIALS);
            }

            return user;
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _context.Users!.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
            
            if(user == null)
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.USER_NOT_FOUND);

            return user;
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
