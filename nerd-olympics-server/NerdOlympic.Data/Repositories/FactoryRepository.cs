using Azure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdOlympics.Data.Repositories
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly NerdOlympicsDBContext _context;

        public FactoryRepository(NerdOlympicsDBContext context)
        {
            _context = context;
        }

        public async Task<List<Record>> GetCompetitionRecordsWithUsers(int competitionId)
        {
            return await _context.Records!.Include(x => x.User).Where(x => x.CompetitionId == competitionId).ToListAsync();
        }
    }
}
