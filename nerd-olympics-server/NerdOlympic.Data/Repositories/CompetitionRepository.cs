using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using Microsoft.EntityFrameworkCore;
using NerdOlympics.Data.Models.ErrorHandling;
using System.Net;

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

        public async Task<Competition> GetCompetition(int competitionId)
        {
            var competition = await _context.Competitions!.AsNoTracking().FirstOrDefaultAsync(x => x.CompetitionId == competitionId);

            if (competition == null)
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.COMPETITION_NOT_FOUND);
            
            return competition;
        }

        public async Task<Competition> CreateCompetition(Competition competition)
        {           
            competition.CreatedDate = DateTime.Now;

            var user = _context.Users!.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == competition.UserId);

            if(user == null)            
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.USER_NOT_FOUND);            

            await _context.Competitions!.AddAsync(competition);
            await _context.SaveChangesAsync();

            var comp = await _context.Competitions!.AsNoTracking().FirstOrDefaultAsync(x => x.CompetitionId == competition.CompetitionId);

            if (comp == null)
                throw new CustomException((int)HttpStatusCode.InternalServerError,ErrorMessage.COMPETITION_CREATE_ERROR);

            return comp;
        }

        public Task<bool> UserOwnsCompetition(string userId, int competitionId)
        {
            return _context.Competitions!.AsNoTracking().AnyAsync(x => x.UserId.ToString() == userId && competitionId == x.CompetitionId);
        }

        public async Task<Competition> UpdateCompetition(Competition competition)
        {
            var oldCompetition = _context.Competitions!.FirstOrDefault(x => x.CompetitionId == competition.CompetitionId);

            if(oldCompetition == null)
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.COMPETITION_NOT_FOUND);            

            oldCompetition.Description = competition!.Description;
            oldCompetition.Name = competition!.Name;

            await _context.SaveChangesAsync();

            var c = _context.Competitions!.FirstOrDefault(x => x.CompetitionId!= oldCompetition.CompetitionId);

            if (c == null)
                throw new CustomException((int)HttpStatusCode.InternalServerError, ErrorMessage.COMPETITION_CREATE_ERROR);

            return c;
        }

        public async Task<bool> CompetitionExists(int competitionId)
        {
            return await _context.Competitions!.AsNoTracking().AnyAsync(x => x.CompetitionId == competitionId);
        }        
        
        public async Task<bool> CompetitionNameExists(string competitionName)
        {
            return await _context.Competitions!.AsNoTracking().AnyAsync(x => x.Name == competitionName);
        }
    }
}
