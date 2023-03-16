using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Models.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<Record> CreateUserRecord(Record record)
        {
            await _context.Records!.AddAsync(record);
            await _context.SaveChangesAsync();
            var r = await _context.Records!.FirstOrDefaultAsync(x => x.RecordId == record.RecordId);

            if (r == null)
                throw new CustomException((int)HttpStatusCode.InternalServerError, ErrorMessage.RECORD_CREATE_ERROR);

            return r;
        }

        public async Task<bool> DeleteUserRecord(int recordId)
        {
            var record = await _context.Records!.AsNoTracking().FirstOrDefaultAsync(x => x.RecordId == recordId);
            if (record == null)
                throw new CustomException((int)HttpStatusCode.NotFound,ErrorMessage.RECORD_NOT_FOUND);
            
            _context.Records!.Remove(record);
            _context.SaveChanges();

            if (_context.Records!.Any(x => x.RecordId == recordId)) 
                throw new CustomException((int)HttpStatusCode.InternalServerError,ErrorMessage.RECORD_DELETE_ERROR);
            
            return true;
        }

        public async Task<Record> UpdateUserRecord(Record newRecord)
        {
            var oldRecord = await _context.Records!.FirstOrDefaultAsync(x => x.RecordId == newRecord.RecordId);

            if (oldRecord == null)            
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.RECORD_NOT_FOUND);            

            oldRecord.Description = newRecord!.Description;
            oldRecord.Value = newRecord!.Value;

            await _context.SaveChangesAsync();

            var record = await _context.Records!.FirstOrDefaultAsync(x => x.CompetitionId != oldRecord.CompetitionId);

            if(record == null)
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.RECORD_UPDATE_ERROR);
            
            return record;
        }

        public async Task<bool> Exists(int recordId)
        {
            return await _context.Records!.AsNoTracking().AnyAsync(x => x.RecordId == recordId);
        }

        public async Task<List<Record>> GetCompetitionRecords(int competitionId)
        {
            return await _context.Records!.AsNoTracking().Where(x => x.CompetitionId == competitionId).ToListAsync();
        }

        public async Task<List<Record>> GetUserRecords(int userId)
        {
            return await _context.Records!.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
