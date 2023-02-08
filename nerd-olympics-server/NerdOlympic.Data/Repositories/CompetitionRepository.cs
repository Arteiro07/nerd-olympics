using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
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
            return await _context.Competitions!.ToListAsync();
        }

        public async Task<Competition?> CreateCompetition(Competition competition)
        {           
            await _context.Competitions!.AddAsync(competition);
            await _context.SaveChangesAsync();

            return await _context.Competitions!.FirstOrDefaultAsync(x => x.CompetitionId == competition.CompetitionId);
        }

        public Task<bool> UserOwnsCompetition(string userId, int competitionId)
        {
            return _context.Competitions!.AnyAsync(x => x.UserId.ToString() == userId && competitionId == x.CompetitionId);
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
    }
}
