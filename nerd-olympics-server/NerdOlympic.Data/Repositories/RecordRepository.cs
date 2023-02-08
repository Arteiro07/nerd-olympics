using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdOlympics.Data.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly NerdOlympicsDBContext _context;
        public RecordRepository(NerdOlympicsDBContext context)
        {
            _context = context;
        }

        public async Task<Record?> CreateUserRecord(Record record)
        {
            await _context.Records!.AddAsync(record);
            await _context.SaveChangesAsync();
            return await _context.Records!.FirstOrDefaultAsync(x => x.RecordId == record.RecordId);
        }

        public async Task<bool> DeleteUserRecord(int recordId)
        {
            var record = await _context.Records!.FirstOrDefaultAsync(x => x.RecordId == recordId);
            if (record != null)
            {
                _context.Records!.Remove(record);
            }
            return true;
        }
        public async Task<Record?> UpdateUserRecord(Record newRecord)
        {
            var oldRecord = _context.Records!.FirstOrDefault(x => x.RecordId == newRecord.RecordId);

            if (oldRecord == null)
            {
                return null;
            }

            oldRecord.Description = newRecord!.Description;
            oldRecord.Value = newRecord!.Value;

            await _context.SaveChangesAsync();

            return _context.Records!.FirstOrDefault(x => x.CompetitionId != oldRecord.CompetitionId);
        }

        public async Task<bool> Exists(int recordId)
        {
            return await _context.Records!.AnyAsync(x => x.RecordId == recordId);
        }

        public async Task<List<Record>> GetCompetitionRecords(int competitionId)
        {
            return await _context.Records!.Where(x => x.CompetitionId == competitionId).ToListAsync();
        }

        public async Task<List<Record>> GetUserRecords(int userId)
        {
            return await _context.Records!.Where(x => x.UserId == userId).ToListAsync();
        }

    }
}
