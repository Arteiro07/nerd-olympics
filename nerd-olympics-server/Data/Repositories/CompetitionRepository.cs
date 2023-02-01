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
    }
}
