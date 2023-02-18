using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace NerdOlympics.Data.Repositories
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly NerdOlympicsDBContext _context;
        
        public CompetitionRepository(NerdOlympicsDBContext context)
        {
            _context = context;
        }

        public async Task<List<Competition>> GetCompetitions()
        {
            return await _context.Competitions!.AsNoTracking().ToListAsync();
        }

        public async Task<Competition?> GetCompetition(int competitionId)
        {
            return await _context.Competitions!.AsNoTracking().FirstOrDefaultAsync(x => x.CompetitionId == competitionId);
        }

        public async Task<Competition?> CreateCompetition(Competition competition)
        {           
            competition.CreatedDate = DateTime.Now;

            var user = _context.Users!.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == competition.UserId);
            if(user == null)
            {
                return null;
            }

            await _context.Competitions!.AddAsync(competition);
            await _context.SaveChangesAsync();

            return await _context.Competitions!.AsNoTracking().FirstOrDefaultAsync(x => x.CompetitionId == competition.CompetitionId);
        }

        public Task<bool> UserOwnsCompetition(string userId, int competitionId)
        {
            return _context.Competitions!.AsNoTracking().AnyAsync(x => x.UserId.ToString() == userId && competitionId == x.CompetitionId);
        }

        public async Task<Competition?> UpdateCompetition(Competition competition)
        {
            var oldCompetition = _context.Competitions!.FirstOrDefault(x => x.CompetitionId == competition.CompetitionId);

            if(oldCompetition == null)
            {
                return null;
            }

            oldCompetition.Description = competition!.Description;
            oldCompetition.Name = competition!.Name;

            await _context.SaveChangesAsync();

            return _context.Competitions!.FirstOrDefault(x => x.CompetitionId!= oldCompetition.CompetitionId);
        }

        public async Task<bool> CompetitionExists(int competitionId)
        {
            return await _context.Competitions!.AsNoTracking().AnyAsync(x => x.CompetitionId == competitionId);
        }
    }
}
